using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMPortalTestSuite
{
    public abstract class BasePage
    {
        protected void takeScreenShot(Exception e, IWebDriver driver, String fileName)
        {
            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();

            try
            {
                 var screenshotDir = @"\ScreenShots\";
                if (!Directory.Exists(screenshotDir))
                {
                    Directory.CreateDirectory(screenshotDir);
                }

                screenShot.SaveAsFile(screenshotDir + fileName + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".png", ImageFormat.Png);
            }
            catch (IOException ioe)
            {
                throw new SystemException(ioe.InnerException.ToString(), ioe);
            }
            throw e;
        }
       
        protected void CleanUp(IWebDriver driver)
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
