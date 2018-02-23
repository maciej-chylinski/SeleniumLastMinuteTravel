using System;
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
using WebDriverWrapper.Extensions;




namespace UdemyAutomationProject
{
    /// <summary>
    /// Summary description for SeleniumBasicImplementationSamples
    /// </summary>
    [TestClass]
    //Copies drivers to the TestOut directory so that the tests will run
    [DeploymentItem("IEDriverServer.exe")]    
    [DeploymentItem("chromedriver.exe")]
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
            //IE
            IWebDriver webDriver = new InternetExplorerDriver();

            //FF
            //var binary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
            //IWebDriver webDriver = new FirefoxDriver(binary, new FirefoxProfile());
                
            //Chrome            
            //IWebDriver webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl("http://www.lastminutetravel.com/flights");
            //webDriver.Manage().Window.Maximize();

            var radioButton = webDriver.FindElement(By.XPath("//*[@id='flights']/div/div[4]/div[3]/label"));
            radioButton.Click();

            Assert.AreNotEqual(true, radioButton.Selected);


            //DEALING WITH TEXT-BOX
            //https://sqa.stackexchange.com/questions/7441/has-any-faced-issue-when-automating-auto-suggest-text-box-using-selenium-webdriv

            //from
            var fromTextBox = webDriver.FindElement(By.XPath("//*[@id=\"autosuggest-flightsFrom\"]"));
            fromTextBox.Click();
            fromTextBox.Clear();
            fromTextBox.SendKeys("N");
            Thread.Sleep(1000);
            //DEALING WITH AUTO-FILLING             
            webDriver.FindElement(By.XPath("//*[@id='react-autowhatever-1-section-0-item-0']/div/span[4]")).Click();

            //to
            var toTextBox = webDriver.FindElement(By.XPath("//*[@id='autosuggest-flightsTo']"));
            toTextBox.Click();
            toTextBox.Clear();
            toTextBox.SendKeys("M");
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
            WebDriverParams = "{\"Driver\":\"Chrome\"}";
            GoToUrl("http://www.lastminutetravel.com/flights");
            var radioButton = FindElement(By.XPath("//*[@id='flights']/div/div[4]/div[3]"));
            radioButton.Click();
            var radio2 = FindElement(By.XPath("//*[@id='radio2']"));
            Assert.AreEqual(true, radio2.Selected);




            //auto-complete text-box
            //from
            FindElement(By.XPath("//*[@id=\"autosuggest-flightsFrom\"]")).SendKeys("N"); ;
            //DEALING WITH AUTO-FILLING             
            FindElement(By.XPath("//*[@id='react-autowhatever-1-section-0-item-0']/div/span[2]")).Click();
            
            //to
            FindElement(By.XPath("//*[@id='autosuggest-flightsTo']")).SendKeys("M");
            FindElement(By.XPath("//*[@id='react-autowhatever-1-section-0-item-0']/div/span[2]")).Click();
            
            FindElement(By.XPath("//*[@id='flights']/div/div[4]/div[1]/select")).ComboBox().SelectByIndex(1);


            FindElement(By.XPath("//*[@id='findFlights']")).Click();

            //
            Assert.AreNotEqual(0, FindElements(By.XPath("//*[@id='SBInnerContent']")));

            WebDriver.Dispose();
        }

        [TestMethod]
        public void FindElementsSamples()
        {
            WebDriverParams = "{\"Driver\":\"IE\"}";
            GoToUrl("http://www.lastminutetravel.com/flights");

            var elements = FindElements(By.XPath("//input[@type='radio']"));
            //elements.ForEach(element => { element.Click(); });
            foreach (var element in elements)
            {
                element.Click();
            }            
        }

        [TestMethod]
        public void GetDisplayedElementSample()
        {
            WebDriverParams = "{\"Driver\":\"Chrome\"}";
            GoToUrl("http://www.lastminutetravel.com/flights");

            var xpath = "//*[contains(@id, 'autosuggest-flights')]";

            GetDisplayedElement(By.XPath(xpath)).SendKeys("N");
            //FindElement(By.XPath("//*[@id='flights']/div/div[4]/div[1]/select")).Click();
            FindElement(By.XPath("//*[@id='react-autowhatever-1-section-0-item-0']/div/span[2]")).Click();

            var radioButton = FindElement(By.XPath("//*[@id='flights']/div/div[4]/div[3]/label"));
            radioButton.Click();


            //cel tego testu jest taki, że po kliknięciu radiobuttona zmienia się nazwa comboBoxa
            // w teście posłużono się więc template'ową wartością nazwy w xpath'cie - typu contains

            GetDisplayedElement(By.XPath(xpath)).SendKeys("N");
            //FindElement(By.XPath("//*[@id='flights']/div/div[4]/div[1]/select")).Click();
            FindElement(By.XPath("//*[@id='react-autowhatever-1-section-0-item-0']/div/span[2]")).Click();
        }


        [TestMethod]
        public void GetDisplayedElementsSample()
        {
            WebDriverParams = "{\"Driver\":\"Chrome\"}";
            GoToUrl("http://www.lastminutetravel.com/flights");

            var elements = GetDisplayedElements(By.XPath("//input[@type='radio']"));
            //elements.ForEach(element => { element.Click(); });
            foreach (var element in elements)
            {
                element.Click();
            }
        }

        [TestMethod]
        public void WaitForDisplayedElementSample()
        {
            WebDriverParams = "{\"Driver\":\"Chrome\"}";
            GoToUrl("http://www.lastminutetravel.com/flights");

            var radioGroup = FindElement(By.XPath("//*[@id='flights']/div/div[4]/div[3]"));
            radioGroup.Click();
            var radioButton = FindElement(By.XPath("//*[@id='radio2']"));

            Assert.AreEqual(true, radioButton.Selected);
            
            //from
            FindElement(By.XPath("//*[@id=\"autosuggest-flightsFrom\"]")).SendKeys("N"); ;
            //select from prompt menu
            FindElement(By.XPath("//*[@id='react-autowhatever-1-section-0-item-0']/div/span[2]")).Click();
            //to
            FindElement(By.XPath("//*[@id='autosuggest-flightsTo']")).SendKeys("M");
            FindElement(By.XPath("//*[@id='react-autowhatever-1-section-0-item-0']/div/span[2]")).Click();

            FindElement(By.XPath("//*[@id='flights']/div/div[4]/div[1]/select")).ComboBox().SelectByIndex(1);

            //btn
            FindElement(By.XPath("//*[@id='findFlights']")).Click();

            //Assert.AreNotEqual(0, FindElements(By.XPath("//*[@id='SBInnerContent']")));


            //var temp = GetDisplayedElement(By.XPath("//*[@id='Tgs_f_depTitle']/td")).Text;
            //var temp = FindElement(By.XPath("//*[@id='Tgs_f_depTitle']/td")).Text;
            //var temp = WaitForDisplayedElement(By.XPath("//*[@id='Tgs_f_depTitle']/td")).Text;

            //for elements that appear after sth is clicked etc. - expensive method
            WaitForDisplayedElement(By.XPath("//*[@id='Tgs_f_depTitle']/td")).Click();

            WebDriver.Dispose();

        }




    }
}
