using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ALMPortalTestSuite
{
    [Binding]
    public class ALMBuildSteps
    {
        private IWebDriver driver;        

        [Given(@"I have typed Main-ALMFETDS in the build definitions search box")]
        public void GivenIHaveTypedMain_ALMFETDSInTheBuildDefinitionsSearchBox()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I finished typing")]
        public void WhenIFinishedTyping()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The returned result will display Main-ALMFETDS as the first option")]
        public void ThenTheReturnedResultWillDisplayMain_ALMFETDSAsTheFirstOption()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can click on it to display the queue button")]
        public void ThenICanClickOnItToDisplayTheQueueButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I click on it to go to Queue Build for Main-ALMFETDS screen")]
        public void ThenIClickOnItToGoToQueueBuildForMain_ALMFETDSScreen()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I click on queue build at the bottom of the page to queue the build")]
        public void ThenIClickOnQueueBuildAtTheBottomOfThePageToQueueTheBuild()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can see the Build summary screen")]
        public void ThenICanSeeTheBuildSummaryScreen()
        {
            ScenarioContext.Current.Pending();
        }
        [Given(@"I am on ASOS ALM portal")]
        public void GivenIAmOnASOSALMPortal()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter environment name Main-ALMFETDS in the search box")]
        public void WhenIEnterEnvironmentNameMain_ALMFETDSInTheSearchBox()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The returned result will display environment name Main-ALMFETDS as the first option")]
        public void ThenTheReturnedResultWillDisplayEnvironmentNameMain_ALMFETDSAsTheFirstOption()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am deploying main alm build")]
        public void GivenIAmDeployingMainAlmBuild()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I search for MAIN-ALMBUILD")]
        public void WhenISearchForMAIN_ALMBUILD()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should get compiled buils")]
        public void ThenIShouldGetCompiledBuils()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have found the compiled deploy")]
        public void GivenIHaveFoundTheCompiledDeploy()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can queue it by pressing queue build button")]
        public void ThenICanQueueItByPressingQueueBuildButton()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
