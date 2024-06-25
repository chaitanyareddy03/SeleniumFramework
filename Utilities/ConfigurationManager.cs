using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.DevTools.V123.Network;


namespace SeleniumFramework.Utilities;

public class ConfigurationManager
{
    private readonly IConfiguration _configuration;
    public ConfigurationManager()
    {
        string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        var builder = new ConfigurationBuilder()
            .AddJsonFile(path + "/appsettings.json", optional: false,
                reloadOnChange: true);
        _configuration = builder.Build();
    }
    public string? GetBrowserName()
    {
        return _configuration["AppSettings:Browser"];
        
        // IConfiguration config = new ConfigurationBuilder()
        //     .AddJsonFile("/Users/chaitu/SeleniumFramework/SeleniumFramework/appsettings.json", optional: false,
        //         reloadOnChange: true)
        //     .Build();
        // var appSettings = new AppConfig();
        // config.GetSection("AppSettings").Bind(appSettings);
        // return appSettings;
    }
    public string? GetEnvironmentUrl(string environment)
    {
        return _configuration[$"Environments:{environment}"];
    }
}