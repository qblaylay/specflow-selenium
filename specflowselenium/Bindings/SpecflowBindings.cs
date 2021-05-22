namespace specflowselenium.Bindings
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using TechTalk.SpecFlow;

    [Binding]
    class SpecflowBindings
    {
        private static IWebDriver Driver;
        
        [AfterScenario]
        public static void CloseBrowser()
        {
            Driver.Quit();;
        }

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

        [When(@"I click on the '(.*)'")]
        public void WhenIClickOnThe(string Link)
        {
            Driver.FindElement(By.PartialLinkText(Link)).Click();        
        }

        [Then(@"a link with text '(.*)' must be present")]
        public void ThenALinkWithTextMustBePresent(string p0)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"the '(.*)' box must contain '(.*)' at index '(.*)'")]
        public void ThenTheBoxMustContainAtIndex(string p0, string p1, string p2)
        {
            ScenarioContext.StepIsPending();
        }
    }
}
