using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace ALMPortalTestSuite
{
    [Binding]
    public class ALMBuildSteps
    {
        private HomePage browser = new HomePage();

        [Given(@"I have typed Main-ALMFETDS in the build definitions search box")]
        public void GivenIHaveTypedMain_ALMFETDSInTheBuildDefinitionsSearchBox()
        {
            browser.OpenALMPortal();
            browser.NavigateToBuildScreen();
            browser.SearchForABuild("Main-ALMFETDS");
        }

        [When(@"I finished typing")]
        public void WhenIFinishedTyping()
        {
            Assert.IsTrue(browser.VerifySearchReturnedResults());
        }

        [Then(@"The returned result will display Main-ALMFETDS as the first option")]
        public void ThenTheReturnedResultWillDisplayMain_ALMFETDSAsTheFirstOption()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can click on it to display the queue button")]
        public void ThenICanClickOnItToDisplayTheQueueButton()
        {
            browser.ClickSearchedBuildToDisplayQueueButton();
        }

        [Then(@"I click on it to go to Queue Build for Main-ALMFETDS screen")]
        public void ThenIClickOnItToGoToQueueBuildForMain_ALMFETDSScreen()
        {
            browser.QueueSearchedBuild();
        }

        [Then(@"I click on queue build at the bottom of the page to queue the build")]
        public void ThenIClickOnQueueBuildAtTheBottomOfThePageToQueueTheBuild()
        {
            browser.QueueBuildFromBuildParametersScreen();
        }

        [Then(@"I can see the Build summary screen")]
        public void ThenICanSeeTheBuildSummaryScreen()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
