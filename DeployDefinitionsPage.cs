using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALMPortalTestSuite
{
    public class DeployDefinitionsPage : SearchPage
    {
        private IWebDriver driver;

        private const string DeployDefinitionsHeader = "id('content')/div/div/h1";

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
            SearchForABuildOrDeploy(driver, deployName);
        }
    }
}
