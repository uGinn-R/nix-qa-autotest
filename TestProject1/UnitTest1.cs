using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;

namespace TestProject1
{
    public class Tests
    {
        IWebDriver driver;
        Variables Variables = new Variables();
        Find _Find = new Find();


        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArguments(Variables.Arguments);
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(Variables.Url);
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void Test1()
        {
            _Find.andClick(driver, Variables.locators["enterBtn"]);

            _Find.andSendKeys(driver, Variables.locators["loginField"], Variables.login);

            _Find.andSendKeys(driver, Variables.locators["passwordField"], Variables.password);

            _Find.andClick(driver, Variables.locators["loginBtn"]);

            _Find.andClick(driver, Variables.locators["hamburgerBtn"]);

            _Find.andClick(driver, Variables.locators["quizLink"]);

            _Find.andClick(driver, Variables.locators["testLink"]);

            _Find.andClick(driver, Variables.locators["startQuizBtn"]);

            _Find.andClick(driver, Variables.locators["hamburgerBtn"]);


            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var waitlow = new WebDriverWait(driver, TimeSpan.FromMilliseconds(1000));

            try
            {
                while (wait.Until(x => x.FindElement(By.XPath("//div[@class='qtext']")).Displayed))
                {

                    foreach (var q in Variables.Questions)
                    {

                        if (driver.FindElement(By.XPath("//div[@class='qtext']")).Text.Trim().Contains(q.Key))
                        {

                            if (waitlow.Until(x => x.FindElement(By.XPath("//input[@type='checkbox']"))).Displayed) // if multiple answers (checkboxes)
                            {
                                foreach (var item in q.Value.Split("|"))
                                {
                                    _Find.andClick(driver, By.XPath($"//div[@class='answer']//label[text()='{item}']"));
                                }
                            }

                            else // radiobutton

                            {

                                var allAnswers = driver.FindElements(By.XPath("//div[@class='answer']//label"));
                                foreach (var answer in allAnswers)
                                {
                                    if (answer.Text.Contains(q.Value))
                                    {

                                        answer.Click();

                                    }
                                }
                            }
                            _Find.andClick(driver, Variables.locators["nextBtn"]);
                            Thread.Sleep(200);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is WebDriverTimeoutException || ex is NoSuchElementException) // some weird way to check if the quiz is over
                {
                    if (waitlow.Until(x => x.FindElement(Variables.locators["processAttemptBtn"])).Displayed)
                    {
                        driver.FindElement(Variables.locators["processAttemptBtn"]).Click();
                        wait.Until(x => x.FindElement(Variables.locators["confirmBtn"])).Click();
                        Assert.IsTrue(wait.Until(x => x.FindElement(By.XPath("//table[@class='generaltable generalbox quizreviewsummary']")).Displayed), "Can't find final results table...");
                    }
                }

                foreach (var tr in driver.FindElements(By.XPath("//table[@class='generaltable generalbox quizreviewsummary']//tr"))) // logging results table
                {
                    Console.WriteLine(tr.Text);
                }
            }
        }

        [TearDown]

        public void TearDown()
        {
            driver.Quit();
        }
    }
}