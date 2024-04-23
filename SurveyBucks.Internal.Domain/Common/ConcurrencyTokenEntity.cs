namespace SurveyBucks.Internal.Domain.Common
{
    public class ConcurrencyTokenEntity : BaseEntity
    {
        public ConcurrencyTokenEntity() : base() { }

        public byte[] TimeStamp { get; set; }
    }
}
