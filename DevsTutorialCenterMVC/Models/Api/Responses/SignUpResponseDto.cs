namespace DevsTutorialCenterMVC.Models.Api.Responses
{
    public class SignUpResponseDto
    {
        public SignUpViewModel User { get; set; }
        public string Token { get; set; }
        public IEnumerable<Error> Errors { get; set; }
    }
}
