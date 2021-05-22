namespace specflowselenium.Bindings
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using TechTalk.SpecFlow;

    [Binding]
    class SpecflowBindings
    {
        private IWebDriver Driver;

        [When(@"I start the browser")]
        public void WhenIStartTheBrowser()
        {
            Driver = new FirefoxDriver();
        }

        [When(@"I navigate to '(.*)'")]
        public void WhenINavigateToHttpExample_Com(string Url)
        {
            Driver.Navigate().GoToUrl(Url);
        }

    }
}
