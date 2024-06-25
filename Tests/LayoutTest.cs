using SeleniumFramework.PageObjects;
using SeleniumFramework.Utilities;

namespace SeleniumFramework.Tests;

public class LayoutTest : Base
{
    
    [Test, Category("Smoke")]
    public void GoToLoginPageTest()
    {
        var layoutPage = new LayoutPage(GetDriver());
        var loginPage = new LoginPage(GetDriver());
        layoutPage.NavigateToLoginPage();
        //Check URL 
        string ecpectedURl = "https://ecommerce-playground.lambdatest.io/index.php?route=account/login";
        Assert.That(GetDriver().Url, Is.EqualTo(ecpectedURl));
        //Check Element
        string expectedTitle = "Returning Customer";
        Assert.That(loginPage.GetLblLoginTitleElement().Text, Is.EqualTo(expectedTitle));
    }
}