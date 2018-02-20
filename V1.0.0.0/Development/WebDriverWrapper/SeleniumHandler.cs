using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverWrapper
{
    public class SeleniumHandler
    {
        private string webDriverParams = "{\"Driver\":\"InternetExplorer\"}";
        public string WebDriverParams
        {
            get
            {
                return webDriverParams;
            }
            set
            {
                webDriverParams = value;
            }
            
        }

        private IWebDriver webDriver = null;
        public IWebDriver WebDriver
        {
            get
            {
                if (webDriver == null)
                {
                    webDriver = SetWebDriver();
                }
                return webDriver;
            }

        }

        private IWebDriver SetWebDriver()
        {
            try
            {
                var driverParams = JObject.Parse(WebDriverParams);
                if (driverParams["Driver"].ToString() == "Firefox")
                {
                    return SetFirefoxDriver();
                }
                else if (driverParams["Driver"].ToString() == "IE")
                {
                    return SetInternetExplorerDriver();
                }
                else if (driverParams["Driver"].ToString() == "Chrome")
                {
                    return SetChromeDriver();
                }
                return SetInternetExplorerDriver();
            }
            catch (Exception)
            {

                throw;
                //throw new NotImplementedException();
            }
        }
        private IWebDriver SetFirefoxDriver()
        {
            try
            {
                //obsolete
                var profile = new FirefoxProfile();
                profile.AcceptUntrustedCertificates = true;
                profile.DeleteAfterUse = true;
                
                
                /*
                var options = new FirefoxOptions();
                options.AcceptInsecureCertificates = true;
                options.Profile.AcceptUntrustedCertificates = true;
                options.Profile.DeleteAfterUse = true;
                */

                return new FirefoxDriver(profile);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IWebDriver SetChromeDriver()
        {
            //throw new NotImplementedException();
            try
            {
                //System.setProperty(“webdriver.chrome.driver”, “C:\\Program Files(x86)\\Google\\Chrome\\Application\\chrome.exe”);
                var options = new ChromeOptions();
                //options.AddArgument("--disable-extensions");
                options.BinaryLocation = @"C:\Program Files(x86)\Google\Chrome Dev\Application\chrome.exe";

                return new ChromeDriver(options);
            }
            catch (Exception)
            {
                throw;
            }

        }

        private IWebDriver SetInternetExplorerDriver()
        {
            try
            {
                var options = new InternetExplorerOptions();
                options.EnsureCleanSession = true;
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                //options.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Dismiss;
                options.UnhandledPromptBehavior = (UnhandledPromptBehavior)InternetExplorerUnexpectedAlertBehavior.Dismiss;
                options.PageLoadStrategy = PageLoadStrategy.Normal;

                return new InternetExplorerDriver(options);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GoToUrl(string url)
        {
            try
            {
                WebDriver.Navigate().GoToUrl(url);
                WebDriver.Manage().Window.Maximize();
                WebDriver.SwitchTo().ActiveElement();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IWebElement FindElement(By by, int interval = 500, int timeout = 15000)
        {
            try
            {
                do
                {
                    try
                    {

                    }
                    catch { }
                } while (true);
            }
            catch (Exception)
            {

                throw;
            }
            finally { }
        }
    }
}
