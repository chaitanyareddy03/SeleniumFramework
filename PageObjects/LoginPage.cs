using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumFramework.PageObjects;

public class LoginPage
{
    private readonly IWebDriver _driver;
    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
    
    [FindsBy(How = How.XPath, Using = "//h2[normalize-space()='Returning Customer']")]
    private IWebElement lblLoginTitle { get; set; }
    [FindsBy(How=How.Id, Using = "input-email")]
    private IWebElement txtEmail { get; set; }
    [FindsBy(How = How.Id, Using = "input-password")]
    private IWebElement txtPassword { get; set; }
    [FindsBy(How = How.CssSelector, Using = "input[value='Login']")]
    private IWebElement btnLogin { get; set; }
    [FindsBy(How = How.CssSelector, Using = "div[class='alert alert-danger alert-dismissible']")]
    private IWebElement lblErrorMessage { get; set; }
    
    
    public IWebElement GetLblLoginTitleElement()
    {
        return lblLoginTitle;
    }
    public IWebElement GetTxtEmailElement()
    {
        return txtEmail;
    }
    public IWebElement GetTxtPasswordElement()
    {
        return txtPassword;
    }
    public IWebElement GetLblErrorMessageElement()
    {
        return lblErrorMessage;
    }

    public MyAccountPage PerformLogin(string username, string password)
    {
        txtEmail.SendKeys(username);
        txtPassword.SendKeys(password);
        btnLogin.Click();
        return new MyAccountPage(_driver);
    }
}