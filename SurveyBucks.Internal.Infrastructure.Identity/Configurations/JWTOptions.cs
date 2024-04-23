namespace SurveyBucks.Internal.Infrastructure.Identity.Configurations
{
    public class JWTOptions
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
    }
}
