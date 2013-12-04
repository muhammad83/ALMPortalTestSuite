using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ALMPortalTestSuite
{
    public class DeployDefinitionsPage : SearchPage
    {
        private IWebDriver driver;

        private const string DeployDefinitionsHeader = "id('content')/div/div/h1";
        private const string SearchedDeployDefinition = "id('content')/div/div/div[3]/div/div/div[1]/div[2]/div/div[1]";

        public DeployDefinitionsPage(IWebDriver driver)
        {
            this.driver = driver;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            IWebElement DeployDefinitionsPageHeader = wait.Until<IWebElement>((d) =>
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(DeployDefinitionsHeader)));
            });

            try
            {
                var buildHeader = driver.FindElement(By.XPath(DeployDefinitionsHeader)).Text;
                if (!buildHeader.Equals("Deployment Definitions"))
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

        public void SearchForDeploy(string deployName)
        {
            base.SearchForABuildOrDeploy(driver, deployName);
        }

        public bool VerifySearchReturnedResults()
        {
            return base.VerifySearchReturnedResults(driver);
        }

        public bool VerifyFirstElementOfSearch(string deployName)
        {
            var firstSearchResult = false;
            try
            {
                firstSearchResult = driver.FindElement(By.XPath(SearchedDeployDefinition)).Text == deployName ? true : false;
            }
            catch (Exception ex)
            {
                takeScreenShot(ex, driver, "Veifying first search results error");
            }
            return firstSearchResult;
        }

        public void ClickSearcheDeployToDisplayQueueButton()
        {
            try
            {
                driver.FindElement(By.XPath(SearchedDeployDefinition)).Click();
            }
            catch (Exception ex)
            {
                takeScreenShot(ex, driver, "Could not click searched deploy");
            }
        }

        public void QueueSearchDeploy()
        {
            try
            {
                driver.FindElement(By.XPath("id('content')/div/div/div[3]/div/div/div[1]/div[2]/div/div[2]/button")).Click();
            }
            catch (Exception ex)
            {
                takeScreenShot(ex, driver, "Queue button not found error");
            }
        }

        public void QueueDeployFromPopUpWindow()
        {
            try
            {
                driver.SwitchTo().ActiveElement();

                driver.FindElement(By.XPath("/html/body/div[2]/form/div[3]/div/button[1]")).Click();
            }
            catch (Exception ex)
            {
                takeScreenShot(ex, driver, "could not queue from popup");
            }
        }

        public bool CheckQueuedBuild(string deployName)
        {
            var isDeploying = false;
            var isInProgress = false;
            try
            {
                driver.SwitchTo().ActiveElement();

                var count = 0;
                do
                {
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    count++;
                    driver.FindElement(By.XPath("id('content')/div/div/div[3]/div/div/div[2]/p/button")).Click();
                    if (driver.FindElement(By.XPath("id('content')/div/div/div[3]/div/div/div[2]/div[2]/h3[2]")).Enabled)
                    {
                        break;
                    }
                } while (count > 15);

                // this is how it should be if signal R is refreshing the page fine leaving this in just in case
                /*
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
                IWebElement inProgressSection = wait.Until<IWebElement>((d) =>
                {
                    return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("id('content')/div/div/div[3]/div/div/div[2]/div[2]/h3[2]")));
                });
                */
                driver.FindElement(By.XPath("id('content')/div/div/div[3]/div/div/div[2]/div[2]/div[2]/div/div[1]")).Click();
                driver.FindElement(By.XPath("id('content')/div/div/div[3]/div/div/div[2]/div[2]/div[2]/div/div[1]/a")).Click();
                var headerText = driver.FindElement(By.XPath("id('content')/div/div/h1/span")).Text;
                isDeploying = headerText.Contains(deployName) ? true : false;
                var statusText = driver.FindElement(By.XPath("id('DeploymentSummary')/div/div/div[1]/fieldset/div[1]/div/span")).Text;
                isInProgress = statusText.Equals("In Progress");
            }
            catch (Exception ex)
            {
                takeScreenShot(ex, driver, "Deployment not in progress error");
            }
            return isDeploying && isInProgress ? true : false;
        }

        public void CleanUp(EnumStopbuild stopDeploy)
        {
            if (stopDeploy == EnumStopbuild.stopBuild)
            {
                driver.FindElement(By.XPath("id('content')/div/div/div[3]/div[1]/div/div[2]/div/button[2]")).Click();
            }
            base.CleanUp(driver);
        }
    }
}
