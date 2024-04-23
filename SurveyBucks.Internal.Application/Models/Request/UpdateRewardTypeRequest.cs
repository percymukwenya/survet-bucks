namespace SurveyBucks.Internal.Application.Models.Request
{
    public class UpdateRewardTypeRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
