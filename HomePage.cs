using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Drawing.Imaging;

namespace ALMPortalTestSuite
{
    public class HomePage : BasePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            try
            {
                this.driver = driver;
                string baseUrl = "http://asnav-devweb-13:8888/";
                driver.Navigate().GoToUrl(baseUrl);
            }
            catch (Exception e)
            {
                takeScreenShot(e, driver, "Home_Page_Navigation_Error");
            }            
        }
        /*
        public void OverrideLoginWindow()
        {
            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("network.http.phishy-userpass-length", 255);
            profile.SetPreference("network.automatic-ntlm-auth.trusted-uris", "http://asnav-devweb-13:8888/");
            driver = new FirefoxDriver(profile);
        }*/

        public BuildScreenPage NavigateToBuildScreen()
        {
            try
            {
                driver.FindElement(By.XPath("id('sidebar-left')/div/ul/li[5]/a")).Click(); //this is running faster for some reason than css selector
                //driver.FindElement(By.CssSelector("i.fa-icon-wrench")).Click();
                driver.FindElement(By.XPath("id('sidebar-left')/div/ul/li[5]/ul/li[2]/a")).Click();
            }
            catch (SystemException ex)
            {
                takeScreenShot(ex, driver, "Navigation_To_Build_Screen_Error");
            }

            return new BuildScreenPage(driver);

        }
    }
}
