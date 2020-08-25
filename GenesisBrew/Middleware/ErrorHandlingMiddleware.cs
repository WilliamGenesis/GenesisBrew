using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Domain.Exceptions;

namespace GenesisBrew.Middleware
{
    public class ErrorHandlingMiddleware
    {
		private readonly RequestDelegate _next;

		public ErrorHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (Exception e)
			{
				httpContext.Response.StatusCode = GetHttpStatusCode(e);
				httpContext.Response.ContentType = "application/json";
				httpContext.Response.Headers.Add("exception", "messageException");
				var json = JsonConvert.SerializeObject(new { Message = e.Message });
				await httpContext.Response.WriteAsync(json);
			}
		}

		private int GetHttpStatusCode(Exception e)
        {
			if (e.GetType() == typeof(HttpException))
            {
				var httpException = (HttpException)e;
				return (int)httpException.StatusCode.GetTypeCode();

			}
			return 500;
		}
	}

	public static class ErrorHandlingMiddlewareExtensions
	{
		public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<ErrorHandlingMiddleware>();
		}
	}
}
