namespace Farming.Api.Helpers
{
    internal sealed class CurrentUserHelper : ICurrentUserHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetId()
        {
            var userId = _httpContextAccessor?.HttpContext?.Items.FirstOrDefault(x => x.Key == "UserId").Value;
            return Guid.Parse(userId.ToString());
        }
    }
}
