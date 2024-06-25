using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumFramework.PageObjects;

public class HomePage
{
    private IWebDriver _driver;
    //This page contains elements of Index Page 
    public HomePage(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
    
   
    
}