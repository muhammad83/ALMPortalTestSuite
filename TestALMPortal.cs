using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMPortalTestSuite
{
    class TestALMPortal
    {
        private IWebDriver driver;
        [Test]
        public void TestALMHomePage() 
        {
            var homePage = new HomePage(driver);
            var searchBuild = "Main-ALMFETDS";
            homePage.OpenALMPortal();
            homePage.NavigateToBuildScreen();
            homePage.SearchForABuild(searchBuild);
            Assert.IsTrue(homePage.VerifySearchReturnedResults());
            Assert.IsTrue(homePage.VerifyFirstElementOfSearch(searchBuild));
            homePage.ClickSearchedBuildToDisplayQueueButton();
            homePage.QueueSearchedBuild();
            homePage.QueueBuildFromBuildParametersScreen();
            homePage.CleanUp();
        }
    }
}
