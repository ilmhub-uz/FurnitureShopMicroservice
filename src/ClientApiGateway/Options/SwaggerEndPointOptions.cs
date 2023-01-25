namespace ClientApiGateway.Options;

public class SwaggerEndPointOptions
{
    public const string ConfigurationSectionName = "SwaggerEndPoints";

    public List<SwaggerEndPointConfig>? Config { get; set; }
}