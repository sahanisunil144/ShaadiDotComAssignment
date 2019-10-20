using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace ShaadiDotComProject.Tests
{
    public class Base
    {
        public static string TestData;
        public static IWebDriver Instance = new ChromeDriver(Directory.GetParent(Directory.GetParent(Directory.GetParent(Assembly.GetExecutingAssembly().Location)
               .ToString()).ToString()).ToString());
        public static WebDriverWait wait;        
        public Base()
        {
            wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(5));
            Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            Instance.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            Instance.Quit();
        }
       
        public static IWebElement FindElement(By by)
        {
            return Instance.FindElement(by);
        }

        public static ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Instance.FindElements(by);

        }

        public static void click(IWebElement element)
        {
            element.Click();
        }

        public static void enter_text(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public static void clickDropdownValue(By element, string text)
        {
            IList<IWebElement> list = FindElements(element);
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(element));
            try
            {
                if (list.Count > 0)
                {
                    foreach (IWebElement dd_value in list)
                    {
                        if (dd_value.Text.ToLower().Contains(text.ToLower()))
                        {
                            dd_value.Click();
                            break;
                        }
                    }
                }
                else
                {
                    throw new Exception("Value is not available in the dropdown");
                }
            }
            catch (Exception)
            {
                throw new Exception("No values found in the dropdown");
            }
        }

        public static void GetFile(string FileName)
        {
            string RelativePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Assembly.GetExecutingAssembly().Location)
                .ToString()).ToString()).ToString();
            string ActualFilePath = RelativePath + @"\" + "TestData" + @"\";
            TestData = File.ReadAllText(ActualFilePath + FileName);
        }

        public static string GetJsonData(string Key)
        {
            JObject parsedObject = JObject.Parse(TestData);
            foreach (JProperty parsedProperty in parsedObject.Properties())
            {
                if (parsedProperty.Name.Equals(Key))
                {
                    return parsedProperty.Value.ToString();
                }
            }
            return null;
        }

        public bool isElementPresent(By element)
        {
            bool flag = false;
            int count = Instance.FindElements(element).Count;
            if (count != 0)
            {
                flag = true;
            }
            return flag;
        }
    }
}
