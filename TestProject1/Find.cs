using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    class Find
    {

        public void andClick(IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            if (wait.Until(x => x.FindElement(locator).Displayed))

            driver.FindElement(locator).Click();
        }

        public void andSendKeys(IWebDriver driver, By locator, string input)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            if (wait.Until(x => x.FindElement(locator).Displayed))

            driver.FindElement(locator).SendKeys(input);
        }
    }
}
