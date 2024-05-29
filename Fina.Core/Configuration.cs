namespace Fina.Core;

public static class Configuration
{
    public const int DefaultStatusCode = 200;
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 25;
    
    public static string BackendUrl { get; set; } = string.Empty;
    public static string FrontendUrl { get; set; } = string.Empty;
}