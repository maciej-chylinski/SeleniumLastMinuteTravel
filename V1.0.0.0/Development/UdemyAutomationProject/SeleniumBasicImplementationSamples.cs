﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
//for combo-boxes
using OpenQA.Selenium.Support.UI;
using WebDriverWrapper;




namespace UdemyAutomationProject
{
    /// <summary>
    /// Summary description for SeleniumBasicImplementationSamples
    /// </summary>
    [TestClass]
    //Copies drivers to the TestOut directory so that the tests will run
    [DeploymentItem("IEDriverServer.exe")]    
    [DeploymentItem("ChromeDriver.exe")]
    [DeploymentItem("geckodriver.exe")]
    public class SeleniumBasicImplementationSamples:SeleniumHandler
    {
        public SeleniumBasicImplementationSamples()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void WebDriverSample()
        {
            //deklaracja za pomocą interfejsu - umożliwi późniejsze castowanie miedzy webDrivrami        
            IWebDriver webDriver = new InternetExplorerDriver();
            Thread.Sleep(1000);
            webDriver.Dispose();

            //Firefox - broken
            //var geckoDriverDirPath = @"C:\Users\mchylinx\Documents\Visual Studio 2015\Projects\UdemyAutomationTestingCourse\V1.0.0.0\OuterReferences\Debug";
            //webDriver = new FirefoxDriver(geckoDriverDirPath);
            //webDriver = new FirefoxDriver();
            //Thread.Sleep(1000);
            //webDriver.Dispose();

            //Chrome
            //webDriver = new ChromeDriver();
            //Thread.Sleep(1000);
            //webDriver.Dispose();

        }

        [TestMethod]
        public void WebElementSamples()
        {
            IWebDriver webDriver = new InternetExplorerDriver();
            //IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://www.lastminutetravel.com/flights");
            webDriver.Manage().Window.Maximize();

            var radioButton = webDriver.FindElement(By.XPath("//*[@id='flights']/div/div[4]/div[3]/label"));
            radioButton.Click();

            Assert.AreNotEqual(true, radioButton.Selected);


            //DEALING WITH TEXT-BOX
            //https://sqa.stackexchange.com/questions/7441/has-any-faced-issue-when-automating-auto-suggest-text-box-using-selenium-webdriv

            //from
            var fromTextBox = webDriver.FindElement(By.XPath("//*[@id=\"autosuggest-flightsFrom\"]"));
            fromTextBox.Click();
            fromTextBox.Clear();
            fromTextBox.SendKeys("New York");
            Thread.Sleep(1000);
            //DEALING WITH AUTO-FILLING             
            webDriver.FindElement(By.XPath("//*[@id='react-autowhatever-1-section-0-item-0']/div/span[4]")).Click();

            //to
            var toTextBox = webDriver.FindElement(By.XPath("//*[@id='autosuggest-flightsTo']"));
            toTextBox.Click();
            toTextBox.Clear();
            toTextBox.SendKeys("Miami");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//*[@id='react-autowhatever-1-section-0-item-0']/div/span[2]")).Click();
            



            //DEALING WITH CALLENDAR (DATE SELECTION)
            /*
            //startDate
            var textBox = webDriver.FindElement(By.XPath("//*[@id='checkInDateInput']"));
            textBox.Clear();
            textBox.SendKeys(DateTime.Now.ToString("MM/dd/yyyy"));

            //endDate
            textBox = webDriver.FindElement(By.XPath("//*[@id='checkInDateInput']"));
            textBox.Clear();
            textBox.SendKeys(DateTime.Now.AddDays(3).ToString("MM/dd/yyyy"));
            */

            /*
            var textBox = webDriver.FindElement(By.XPath("//*[@id='dateRangeWrapper']/div/div/div/div[1]/div"));
            textBox.Click();            
            webDriver.FindElement(By.XPath("//*[@id='dateRangeWrapper']/div/div/div[2]/div/div/div[3]/div/div[2]/table/tbody/tr[3]/td[4]")).Click();
            webDriver.FindElement(By.XPath("//*[@id='dateRangeWrapper']/div/div/div[2]/div/div/div[3]/div/div[3]/table/tbody/tr[3]/td[3]")).Click();
            */

            //DEALING WITH COMBO BOX    
            var comboBox = 
                webDriver.FindElement(By.XPath("//*[@id='flights']/div/div[4]/div[1]/select"));
            var selectElement = new SelectElement(comboBox);
            selectElement.SelectByIndex(1);
            selectElement.SelectByValue("economyClass");


            /*
            //DEALING WITH CHECKBOXes
            var checkBox =
                webDriver.FindElement(By.XPath(""));
            checkBox.Click();
            Assert.AreEqual(true, checkBox.Selected);
            */

            //BUTTON
            var button = webDriver.FindElement(By.XPath("//*[@id='findFlights']"));
            button.Click();
            webDriver.Manage().Window.Maximize();

            //checking if the results shown - this is problem during asynchronic page load - item is not displayed
            //solution is to use wrapper and do it dynamically
            var results = webDriver.FindElement(By.XPath("//*[@id='imgHeaderImage']"));
            Assert.AreEqual(true, results.Displayed); //Displayed is a boolean value
            
            Thread.Sleep(1000);
            webDriver.Dispose();

            

        }

        [TestMethod]
        public void JsonObjectSample()
        {
            var jsonSample = new SeleniumWrapper();
            jsonSample.ParseJson
                ("{\"FirstName\":\"Maciej\",\"LastName\":\"Chylinski\",\"Age\":33,\"LikeThisCourse\":true}");
        }

        [TestMethod]
        public void SeleniumHandlerSamples()
        {
            var drivers = new List<string>();
            //drivers.Add("{\"Driver\":\"Firefox\"}");
            drivers.Add("{\"Driver\":\"IE\"}");
            //drivers.Add("{\"Driver\":\"Chrome\"}");

            drivers.ForEach(_driver =>
            {
                var handler = new SeleniumHandler();
                handler.WebDriverParams = _driver;
                //var driver = handler.SetInternetExplorerDriver();
                //var driver = handler.SetChromeDriver();
                //var driver = handler.SetFirefoxDriver();
                var driver = handler.WebDriver;
                try
                {
                    driver.Navigate().GoToUrl("http://www.lastminutetravel.com/flights");
                    driver.Manage().Window.Maximize();
                    driver.FindElement(By.XPath("//*[@id='productsNavHotels']")).Click();
                    //driver.Dispose();
                }
                catch (Exception)
                {
                    throw;
                    //driver.Dispose();
                }
                finally { driver.Dispose(); }          
            });

            //Thread.Sleep(2000);
            //driver.Dispose();
        }


        [TestMethod]
        public void SearchHotelsWithWrapper()
        {
            WebDriverParams = "{\"Driver\":\"InternetExplorer\"}";
            GoToUrl("http://www.lastminutetravel.com");
            var radioButton = FindElement(By.XPath("//*[@id='flights']/div/div[4]/div[3]/label"));
            radioButton.Click();
            Assert.AreNotEqual(true, radioButton.Selected);
        }
    }
}