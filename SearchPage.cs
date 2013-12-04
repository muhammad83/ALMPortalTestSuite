using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMPortalTestSuite
{
    public abstract class SearchPage : BasePage
    {
        protected void SearchForABuildOrDeploy(IWebDriver driver, string buildOrDeployName)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                IWebElement searchBox = wait.Until<IWebElement>((d) =>
                {
                    return wait.Until(ExpectedConditions.ElementIsVisible(By.Id("definitionFilter")));
                });

                driver.FindElement(By.Id("definitionFilter")).SendKeys(buildOrDeployName);
            }
            catch (Exception ex)
            {
                takeScreenShot(ex, driver, "Search_error");
            }
        }

        protected bool VerifySearchReturnedResults(IWebDriver driver)
        {
            var searchResult = false;
            try
            {
                searchResult = driver.FindElements(By.XPath("id('content')/div/div/div/div/div/div")).Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                takeScreenShot(ex, driver, "Veifying search results error");
            }

            return searchResult;
        }
    }
}
