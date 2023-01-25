using Serilog;
using TelegramSink;

namespace Contract.Api.Extensions;

public static class SeriologConfiguration
{
    public static void AddSeriologConfig(this WebApplicationBuilder builder)
    {
        var telegramApiKey = builder.Configuration["TelegramSeriologConfiguration:telegramApiKey"];
        var telegramChatId = builder.Configuration["TelegramSeriologConfiguration:TelegramChatId"];

        var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("ContractApiLogging")
            .WriteTo.TeleSink(telegramApiKey, telegramChatId, minimumLevel: Serilog.Events.LogEventLevel.Error)
            .CreateLogger();

        builder.Logging.AddSerilog(logger);
    }
}