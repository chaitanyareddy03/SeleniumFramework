using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace SeleniumFramework.PageObjects;

public class LayoutPage
{
    private readonly IWebDriver _driver;
    public LayoutPage(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
    
    [FindsBy(How = How.LinkText, Using = "My account")]
    private IWebElement ddlMyAccount;
    [FindsBy(How = How.LinkText, Using = "Login")]
    private IWebElement itemLogin;
    
    //Encapsulating the above elements into methods

    public IWebElement GetMyAccountDropdownElement()
    {
        return ddlMyAccount;
    }
    public IWebElement GetLoginItemElement()
    {
        return itemLogin;
    }
    
    //Navigate to Login Page
    public LoginPage NavigateToLoginPage()
    {
        var mouseAction = new Actions(_driver);
        mouseAction.MoveToElement(GetMyAccountDropdownElement()).Perform();
        GetLoginItemElement().Click();
        return new LoginPage(_driver);
    }
}