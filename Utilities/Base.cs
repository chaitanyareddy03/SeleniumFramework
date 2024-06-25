using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace SeleniumFramework.Utilities;

public class Base
{
    //private IWebDriver _driver;
    private ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();
    string? browserName;
    string? envName;


    [SetUp]
    public void Setup()
    {
        //Get Brower Name, EnvironmentURL from the terminal 
        browserName = TestContext.Parameters["browserName"];
        envName = TestContext.Parameters["envName"];
        //Reading Browser name form configuration file.
        ConfigurationManager con = new ConfigurationManager();
        if (browserName is null)
        {
            browserName = con.GetBrowserName();
        }
        else if(envName is null){
            envName = "Testing";
        }
        
        //Creating the selected browser driver instance.
        InitBrowser(browserName);//InitBrowser("Chrome");
        _driver.Value.Manage().Window.Maximize();
        _driver.Value.Url = con.GetEnvironmentUrl(envName);
    }

    private void InitBrowser(string? browserName)
    {
        _driver.Value = browserName switch
        {
            "Chrome" => new ChromeDriver(),
            "Firefox" => new FirefoxDriver(),
            "Edge" => new EdgeDriver(),
            "Safari" => new SafariDriver(),
            _ => throw new ArgumentException("Browser not supported: " + browserName)
        };
    }
    public IWebDriver GetDriver()
    {
        return _driver.Value;
    }
    [TearDown]
    public void AfterTest()
    {
        if (_driver.Value != null)
        {
            _driver.Value.Quit();
            _driver.Value.Dispose();
        }
    }
    [OneTimeTearDown]
    public void Dispose()
    {
        if (_driver != null)
        {
            _driver.Dispose();
        }
    }
}