
using Serilog;

namespace Product.Api.Extensions
{
	public static class LoggerExtension
	{
		public static void SerilogConfiguration(this IServiceCollection service)
		{
			var logger = new LoggerConfiguration()
				.WriteTo.Console()
				.WriteTo.File(path: "ProductApi.log", rollingInterval: RollingInterval.Year,
					outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
				.CreateLogger();
		}
	}
}
