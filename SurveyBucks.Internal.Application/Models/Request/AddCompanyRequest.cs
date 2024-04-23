namespace SurveyBucks.Internal.Application.Models.Request
{
    public class AddCompanyRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int IndustryId { get; set; }
    }
}
