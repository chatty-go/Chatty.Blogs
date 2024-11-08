using Chatty.Blogs.Services.Blogs.Visitor;

namespace Chatty.Blogs.Web.Middleware
{
	public class RequestLoggingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<RequestLoggingMiddleware> _logger;

		public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
		{
			_next = next;
			_logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
		}

		public async Task Invoke(HttpContext context, IVisitorService visitorService)
		{
			// 记录 PV
			await visitorService.InsertAsync(new Entities.Blogs.SiteVisitRecord()
			{
				IpAddress= context.Connection.RemoteIpAddress?.ToString().Split(":").Last(),
				RequestMethod = context.Request.Method,
				RequestQueryString = context.Request.QueryString.Value,
				UserAgent = context.Request.Headers.UserAgent.ToString(),
				RequestPath = context.Request.Path,
				RowId = Guid.NewGuid().ToString("N"),
			});

			await _next(context);
		}

	}
}
