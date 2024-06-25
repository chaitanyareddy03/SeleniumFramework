using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace SeleniumFramework.Utilities;

public class Base
{
    private IWebDriver _driver;
    [SetUp]
    public void Setup()
    {
        //Reading Browser name form configuration file.
        ConfigurationManager con = new ConfigurationManager();
        //Creating the selected browser driver instance.
        InitBrowser(con.GetBrowserName());//InitBrowser("Chrome");
        
        _driver.Manage().Window.Maximize();
        _driver.Url = con.GetEnvironmentUrl("Testing");
    }

    private void InitBrowser(string? browserName)
    {
        _driver = browserName switch
        {
            "Chrome" => new ChromeDriver(),
            "Firefox" => new FirefoxDriver(),
            "Edge" => new EdgeDriver(),
            "Safari" => new SafariDriver(),
            _ => _driver
        };
    }
    public IWebDriver GetDriver()
    {
        return _driver;
    }
    [TearDown]
    public void AfterTest()
    {
        
        _driver.Close();
    }
}