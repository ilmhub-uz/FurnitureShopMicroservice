using Serilog;
using TelegramSink;

namespace FurnitureShop.Common.Extensions;

public static class LoggerExtension
{
    public static void SerilogConfig(this WebApplicationBuilder builder)
    {
        var botToken = builder.Configuration["SerilogConfiguration:BotToken"];
        var chatId = builder.Configuration["SerilogConfiguration:ChatId"];

        var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.TeleSink(botToken, chatId, minimumLevel: Serilog.Events.LogEventLevel.Error)
            .CreateLogger();

        builder.Logging.AddSerilog(logger);
    }
}
