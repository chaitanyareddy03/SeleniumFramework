using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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

    public IList<IWebElement> GetSideMenu()
    {
        return mnuSideList;
    }
}