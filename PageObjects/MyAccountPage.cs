using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace SeleniumFramework.PageObjects;

public class MyAccountPage
{
    private readonly IWebDriver _driver;
    
    public MyAccountPage(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
    
    [FindsBy(How = How.XPath, Using = "//aside[@id='column-right']/div/a")]
    private IList<IWebElement> mnuSideList { get; set; }

    [FindsBy(How = How.XPath, Using = "//h2[normalize-space()='My Account']")]
    private IWebElement lblMyAccount { get; set; }

    public IList<IWebElement> GetSideMenu()
    {
        return mnuSideList;
    }
    public IWebElement GetMyAccountLabel()
    {
        return lblMyAccount;
    }
    public void WaitForAccountPageDisplay()
    {
        WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
        webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h2[normalize-space()='My Account']")));
    }
}