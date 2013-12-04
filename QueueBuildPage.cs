using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMPortalTestSuite
{
    public class QueueBuildPage : BasePage
    {
        private IWebDriver driver;

        public QueueBuildPage(IWebDriver driver)
        {
            this.driver = driver;

            var queueBuildPageHeader = "id('content')/h1";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement queueBuildHeader = wait.Until<IWebElement>((d) => { return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(queueBuildPageHeader))); });

            try
            {
                var buildHeader = driver.FindElement(By.XPath(queueBuildPageHeader)).Text;
                if (!buildHeader.Contains("Queue Build for"))
                {
                    var exception = new InvalidElementStateException("This is not queue build definitation page " + driver.Url);
                    takeScreenShot(exception, driver, "Not_On_Queue_Build_Page_Error");
                    throw exception;
                }
            }
            catch (Exception e)
            {
                takeScreenShot(e, driver, "Queue_Build_Page_header_not_found");
                throw e;
            }
            
        }

        public BuildSummaryPage QueueBuild()
        {
            try
            {
                driver.FindElement(By.XPath("id('content')/div/div/div/form/div/button")).Click();
            }
            catch (Exception e)
            {
                takeScreenShot(e, driver, "Queue_Build_Page_Queue_Button_Not_Found");
                throw e;
            }

            return new BuildSummaryPage(driver);
        }

        public void CleanUp()
        {
            CleanUp(driver);
        }
    }
}
