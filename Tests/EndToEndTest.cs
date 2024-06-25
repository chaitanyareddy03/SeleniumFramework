using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumFramework.PageObjects;
using SeleniumFramework.Utilities;

namespace SeleniumFramework.Tests;

public class EndToEndTest : Base
{
    [Test]
    public void IndexPageTest()
    {
        LayoutPage layoutTest = new LayoutPage(GetDriver());
        layoutTest.NavigateToLoginPage();
        // Actions mouseAction = new Actions(GetDriver());
        //
        // mouseAction.MoveToElement(layoutTest.GetMyAccountDropdownElement()).Perform();
        // layoutTest.GetLoginItemElement().Click();
        //_driver.FindElement(By.LinkText("Login")).Click();
        IList <IWebElement> elements = GetDriver().FindElements(By.XPath("//aside[@id='column-right']/div/a"));
        foreach(IWebElement e in elements) {
            TestContext.Out.WriteLine(e.Text);
        }
        var ele = GetDriver().FindElement(By.Name("search"));
        ele.SendKeys("Phone");
        ele.SendKeys(Keys.Enter);   
        
        string text = GetDriver().FindElement(By.XPath("//h1[@class='h4']")).Text;
        TestContext.Out.WriteLine(text);

    }
    
}