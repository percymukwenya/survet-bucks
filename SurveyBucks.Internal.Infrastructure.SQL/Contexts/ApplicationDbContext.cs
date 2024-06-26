﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SurveyBucks.Internal.Infrastructure.SQL.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using SurveyBucks.Internal.Infrastructure.SQL.Shared;
using SurveyBucks.Internal.Domain.Common;
using SurveyBucks.Internal.Domain.Entities;

namespace SurveyBucks.Internal.Infrastructure.SQL.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _username;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            ArgumentNullException.ThrowIfNull(options);
            ArgumentNullException.ThrowIfNull(httpContextAccessor);

            var claimsPrincipal = httpContextAccessor.HttpContext?.User;
            _username = claimsPrincipal?.Identity.Name ?? claimsPrincipal?.Identity.Name ?? "System";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        private static readonly TaggedQueryCommandInterceptor _interceptor = new TaggedQueryCommandInterceptor();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_interceptor); ;
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>()
                .HaveColumnType("varchar")
                .HaveMaxLength(255);

            configurationBuilder.Properties<int>()
                .HaveColumnType("int");
        }

        public DbSet<AuditEntry> AuditEntries { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<SurveyResponse> Responses { get; set; }
        public DbSet<QuestionResponseChoice> ResponseChoices { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyParticipation> SurveyResponses { get; set; }
        public DbSet<SurveyStatus> SurveyStatuses { get; set; }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            // Get audit entries
            var auditEntries = OnBeforeSaveChanges();

            // Save current entity
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

            // Save audit entries
            await OnAfterSaveChangesAsync(auditEntries);
            return result;
        }

        private List<AuditEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var entries = new List<AuditEntry>();

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                // Dot not audit entities that are not tracked, not changed, or not of type IAuditable
                if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                DateTimeOffset changeDateTime = DateTimeOffset.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = changeDateTime;
                    entry.Entity.CreatedBy = _username;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedDate = changeDateTime;
                    entry.Entity.ModifiedBy = _username;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.ModifiedDate = changeDateTime;
                    entry.Entity.ModifiedBy = _username;
                    entry.Entity.IsDeleted = true;
                }

                // Dot not audit entities that are not tracked, not changed, or not of type IAuditable
                if (!(entry.Entity is IAuditable))
                    continue;

                var auditEntry = new AuditEntry
                {
                    ActionType = entry.State == EntityState.Added ? "INSERT" : entry.State == EntityState.Deleted ? "DELETE" : "UPDATE",
                    EntityId = entry.Properties.Single(p => p.Metadata.IsPrimaryKey()).CurrentValue.ToString(),
                    EntityName = entry.Metadata.ClrType.Name,
                    Username = _username,
                    TimeStamp = DateTimeOffset.Now,
                    Changes = entry.Properties.Select(p => new { p.Metadata.Name, p.CurrentValue }).ToDictionary(i => i.Name, i => i.CurrentValue),

                    // TempProperties are properties that are only generated on save, e.g. ID's
                    // These properties will be set correctly after the audited entity has been saved
                    TempProperties = entry.Properties.Where(p => p.IsTemporary).ToList(),
                };

                entries.Add(auditEntry);
            }

            return entries;
        }

        private Task OnAfterSaveChangesAsync(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return Task.CompletedTask;

            // For each temporary property in each audit entry - update the value in the audit entry to the actual (generated) value
            foreach (var entry in auditEntries)
            {
                foreach (var prop in entry.TempProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        entry.EntityId = prop.CurrentValue.ToString();
                        entry.Changes[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        entry.Changes[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }
            }

            AuditEntries.AddRange(auditEntries);
            return SaveChangesAsync();
        }
    }
}
