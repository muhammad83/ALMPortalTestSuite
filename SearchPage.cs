﻿using OpenQA.Selenium;
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
                
                throw;
            }            
        }

        protected bool VerifySearchReturnedResults(IWebDriver driver)
        {
            return driver.FindElements(By.XPath("id('content')/div/div/div/div/div/div")).Count > 0 ? true : false;
        }

        protected bool VerifyFirstElementOfSearch(IWebDriver driver,string BuildSearch)
        {
            return driver.FindElement(By.XPath("id('content')/div/div/div/div/div/div")).Text == BuildSearch ? true : false;
        }

        protected void ClickSearchedBuildToDisplayQueueButton(IWebDriver driver)
        {
            //click on the first return result to highlight it and display the queue button
            driver.FindElement(By.XPath("id('content')/div/div[3]/div[1]/div[1]/div[2]/div/div[1]")).Click();
        }
    }
}
