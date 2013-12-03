using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMPortalTestSuite
{
    public class QueueBuildJourney
    {
        private IWebDriver driver;

        public void QueueBuild(string buildName)
        {            
            var searchPage = ((new LoginPage()).OverrideLoginWindow()).NavigateToBuildDefinitionsPage();
            searchPage.SearchForABuild(buildName);
            Assert.IsTrue(searchPage.VerifySearchReturnedResults());
            Assert.IsTrue(searchPage.VerifyFirstElementOfSearch(buildName));
            searchPage.ClickSearchedBuildToDisplayQueueButton();
            var queueBuildPage=searchPage.QueueSearchedBuild();
            var buildSummaryPage = queueBuildPage.QueueBuild();
            Assert.IsTrue(buildSummaryPage.VerifyBuildIsQueued(buildName));            
            buildSummaryPage.CleanUp(EnumStopbuild.stopBuild);
        }
    }
}
