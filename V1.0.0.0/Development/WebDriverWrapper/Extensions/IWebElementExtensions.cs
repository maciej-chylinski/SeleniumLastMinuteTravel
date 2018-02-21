using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverWrapper.Extensions
{
    public static class IWebElementExtensions
    {
        public static SelectElement ComboBox(this IWebElement webElement)
        {
            try
            {
                return new SelectElement(webElement);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
