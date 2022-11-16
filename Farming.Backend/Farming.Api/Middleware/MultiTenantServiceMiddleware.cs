using Farming.Infrastructure.EF.MultiTenancy;

namespace Farming.Api.Middleware
{
    public class MultiTenantServiceMiddleware : IMiddleware
    {
        private readonly ITenantSetter _setter;

        public MultiTenantServiceMiddleware(ITenantSetter setter)
        {
            _setter = setter;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Query.TryGetValue("tenant", out var values))
            {
                var value = values.FirstOrDefault();
                Guid tenant;
                if (string.IsNullOrWhiteSpace(value))
                {
                    tenant = Guid.NewGuid();
                }
                else
                {
                    if (!Guid.TryParse(value, out tenant))
                    {
                        tenant = Guid.NewGuid();
                    }
                }

                _setter.SetTenant(tenant);
            }
            else
            {
                _setter.SetTenant(Guid.NewGuid());
            }

            await next(context);
        }
    }
}
