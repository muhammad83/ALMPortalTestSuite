using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ALMPortalTestSuite
{
    public class BuildSummaryPage : BasePage
    {
        private IWebDriver driver;

        private readonly string buildSummaryPageHeader = "id('content')/div/div/h1";
        private readonly string buildStatus = "id('content')/div/div/div[3]/div[2]/div/div[1]/fieldset/div[1]/label";

        public BuildSummaryPage(IWebDriver driver)
        {
            this.driver = driver;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            IWebElement BuildSummaryPageHeader = wait.Until<IWebElement>((d) => { return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(buildStatus))); });

            try
            {
                var buildHeader = driver.FindElement(By.XPath(buildStatus)).Text;
                if (!buildHeader.Equals("Build Status"))
                {
                    var exception = new InvalidElementStateException("This is not build summary page " + driver.Url);
                    takeScreenShot(exception, driver, "Not_On_Build_Summary_Page_Error");
                    throw exception;
                }
            }
            catch (Exception e)
            {
                takeScreenShot(e, driver, "Build_Summary_Page_header_not_found");
                throw e;
            }
        }

        private string GetBuildStatus()
        {
            return driver.FindElement(By.XPath("id('content')/div/div/div[3]/div[2]/div/div[1]/fieldset/div[1]/div/span")).Text;
        }

        public bool VerifyBuildIsQueued(string buildName)
        {            
            var buildNameCheck = false;
            var counter = 0;

            while (true)
            {
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("id('content')/div/div/div[3]/div[1]/div/div[2]/div/button[1]")).Click();
                var buildNameXpathText = driver.FindElement(By.XPath("id('content')/div/div/h1/span")).Text;
                var length = 10;
                if (int.TryParse(buildNameXpathText, out length))
                {
                    length = 5;
                }
                if (length == 0)
                {
                    length = buildName.Length;
                }
                var extractedBuildName = buildNameXpathText.Substring(0, length);
                buildNameCheck = extractedBuildName.Equals(buildName) ? true : false;

                if (buildNameCheck == true || counter == 5)
                {
                    break;
                }

                counter++;
            }

            var inProgressCheck = GetBuildStatus().Equals("In Progress") ? true : false;

            if (inProgressCheck && buildNameCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*public bool VerifyPowerShellScript() 
        {
            // go to details tak to get the powershell command
            driver.FindElement(By.XPath("id('content')/div/div/div[3]/div[1]/div/div[1]/button[3]")).Click();
            //get the powershell commmand
            var powerShellCommand =driver.FindElement(By.XPath("id('DeploymentDetails')/div/div/div/fieldset/div[1]/div/pre/code")).Text;



            return false;
        }*/

        public void StopBuild()
        {
            driver.FindElement(By.XPath("id('content')/div/div/div[3]/div[1]/div/div[2]/div/button[2]")).Click();
            var counter = 0;

            while (true)
            {
                var buildStopped = GetBuildStatus().Equals("Stopped") ? true : false;
                if (buildStopped || counter == 5)
                {
                    break;
                }

                counter++;
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("id('content')/div/div/div[3]/div[1]/div/div[2]/div/button[1]")).Click();
            }
        }

        public void CleanUp(EnumStopbuild stopBuild)
        {
            if (stopBuild == EnumStopbuild.stopBuild)
            {
                StopBuild();
            }
            CleanUp(driver);
        }
    }
}
