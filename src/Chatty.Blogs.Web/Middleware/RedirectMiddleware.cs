namespace Chatty.Blogs.Web.Middleware
{
	public class RedirectMiddleware(RequestDelegate next)
	{
		private readonly RequestDelegate _next = next;

		public async Task InvokeAsync(HttpContext context)
		{
            if (context.Request.Path.StartsWithSegments("/Admin") && context.Request.Path.Value?.ToLower() == "/admin")
			{
				if (context.User.Identity?.IsAuthenticated==true)
				{
                    context.Response.Redirect("/admin/home");
				}
				else
				{
                    context.Response.Redirect("/admin/login");
                }

				return;
			}

			await _next(context);
		}
	}
}
