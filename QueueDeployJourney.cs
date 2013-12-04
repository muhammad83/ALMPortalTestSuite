using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMPortalTestSuite
{
    public class QueueDeployJourney
    {
        public void QueueDeploy(string deployName)
        {
            var deploySearchPage = ((new LoginPage()).OverrideLoginWindow()).NavigateToDeployDefinitionsPage();
            deploySearchPage.SearchForDeploy(deployName);
            Assert.IsTrue(deploySearchPage.VerifySearchReturnedResults());
            Assert.IsTrue(deploySearchPage.VerifyFirstElementOfSearch(deployName));
            deploySearchPage.ClickSearcheDeployToDisplayQueueButton();
            deploySearchPage.QueueSearchDeploy();
            deploySearchPage.QueueDeployFromPopUpWindow();
            Assert.IsTrue(deploySearchPage.CheckQueuedBuild(deployName));
            deploySearchPage.CleanUp(EnumStopbuild.stopBuild);

            
        }
    }
}
