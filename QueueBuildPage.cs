using OpenQA.Selenium;
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

            try
            {
                var buildHeader = driver.FindElement(By.XPath("id('content')/h1")).Text;
                if (!buildHeader.Equals("Queue Build for Main-ALMFETDS"))
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

        public void QueueBuild()
        {
            try
            {
                driver.FindElement(By.XPath("id('content')/div/div/div[2]/form/fieldset/div[20]/button")).Click();
            }
            catch (Exception e)
            {
                takeScreenShot(e, driver, "Queue_Build_Page_Queue_Button_Not_Found");
                throw e;
            } 
        }
    }
}
