namespace Identity.API.Models
{
    public class UserToken
    {
        public string Id { get; internal set; }
        public string Email { get; internal set; }
        public object Claims { get; internal set; }
    }
}
