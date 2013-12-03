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
        public void TestALMBuildJourney() 
        {
            var queueBuildJourney = new QueueBuildJourney();
            queueBuildJourney.QueueBuild("Main-ALMFETDS");
        }

        [Test]
        public void TestALMDeployJourney()
        {
            var queueDeployJourney = new QueueDeployJourney();
            queueDeployJourney.QueueDeploy("MQPT1");
        }
    }
}
