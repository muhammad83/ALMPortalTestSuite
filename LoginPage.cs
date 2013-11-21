using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMPortalTestSuite
{
    public class LoginPage : BasePage
    {
        private IWebDriver driver;
        public void OverrideLoginWindow()
        {
            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("network.http.phishy-userpass-length", 255);
            profile.SetPreference("network.automatic-ntlm-auth.trusted-uris", "http://asnav-devweb-13:8888/");
            driver = new FirefoxDriver(profile);
        }

        public void CleanUp()
        {
            CleanUp(driver);
        }

    }
}
