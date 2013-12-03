using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMPortalTestSuite
{
    public class BuildDefinitionsPage : SearchPage
    {
        private IWebDriver driver;
        public BuildDefinitionsPage(IWebDriver driver)
        {
            try
            {
                this.driver = driver;

                var buildScreenHeader = "id('content')/div/h1";

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IWebElement BuildScreen = wait.Until<IWebElement>((d) => { return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(buildScreenHeader))); });

                var buildHeader = driver.FindElement(By.XPath(buildScreenHeader)).Text;
                if (!buildHeader.Equals("Build Definitions"))
                {
                    var exception = new InvalidElementStateException("This is not build definitation page " + driver.Url);
                    takeScreenShot(exception, driver, "Not_on_Build_Definition_Page");
                    throw exception;
                }
            }
            catch (Exception e)
            {
                takeScreenShot(e, driver, "Build_Definition_Header_Not_Found");
            }
        }
        
        public void SearchForABuild(string buildName)
        {
            SearchForABuildOrDeploy(driver,buildName);
        }       

        public QueueBuildPage QueueSearchedBuild()
        {
            //Click the queue button (need to click on the anchor)
            driver.FindElement(By.XPath("id('content')/div/div[3]/div[1]/div[1]/div[2]/div/div[2]/a")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement QueuePage = wait.Until<IWebElement>((d) =>
            {
                return wait.Until(ExpectedConditions.ElementExists(By.XPath("id('content')/h1")));
            });

            return new QueueBuildPage(driver);
        }
    }
}
