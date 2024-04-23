namespace SurveyBucks.Internal.Application.Models.Request
{
    public class UpdateCompanyRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IndustryId { get; set; }
    }
}
