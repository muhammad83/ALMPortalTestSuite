using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMPortalTestSuite
{
    public class BuildScreenPage : BasePage
    {
        private IWebDriver driver;
        public BuildScreenPage(IWebDriver driver)
        {
            try
            {
                this.driver = driver;

                var buildHeader = driver.FindElement(By.XPath("id('content')/div/h1")).Text;
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            
            IWebElement searchBox = wait.Until<IWebElement>((d) =>
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(By.Id("definitionFilter")));
            });

            driver.FindElement(By.Id("definitionFilter")).SendKeys(buildName);
        }

        public bool VerifySearchReturnedResults()
        {
            return driver.FindElements(By.XPath("id('content')/div/div/div/div/div/div")).Count > 0 ? true : false;
        }

        public bool VerifyFirstElementOfSearch(string BuildSearch)
        {
            return driver.FindElement(By.XPath("id('content')/div/div/div/div/div/div")).Text == BuildSearch ? true : false;
        }

        public void ClickSearchedBuildToDisplayQueueButton()
        {
            //click on the first return result to highlight it and display the queue button
            driver.FindElement(By.XPath("id('content')/div/div[3]/div[1]/div[1]/div[2]/div/div[1]")).Click();
        }

        public QueueBuildPage QueueSearchedBuild()
        {
            //Click the queue button (need to click on the anchor)
            driver.FindElement(By.XPath("id('content')/div/div[3]/div[1]/div[1]/div[2]/div/div[2]/a")).Click();

            return new QueueBuildPage(driver);
        }
    }
}
