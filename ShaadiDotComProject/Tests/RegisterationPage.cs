using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using ShaadiDotComProject.Tests;
using TechTalk.SpecFlow;

namespace ShaadiDotComProject
{
    public class MarathiShaadiDotCom : Base
    {
        public IWebDriver driver;
        public MarathiShaadiDotCom()
        {
            driver = Instance;
        }

        [Test]
        public void MarathiShaadiRegisteration()
        {
            //Negative Test, change the email in json to run sucessfully
            Locators locate = new Locators();
            GetFile("MarathiRegisterationData.json");
            driver.Navigate().GoToUrl("https://www.marathishaadi.com/");
            RegisterationFlow(locate);
        }

        [Test]
        public void GujaratiShaadiRegisteration()
        {
            Locators locate = new Locators();
            GetFile("GujaratiRegisterationData.json");
            driver.Navigate().GoToUrl("https://www.gujaratishaadi.com/");
            RegisterationFlow(locate);
        }

        //Not clicking on signup button to avoid creating fake signups
        public void RegisterationFlow(Locators locate)
        {
            string error_text = "";
            try
            {
                click(locate.lnk_login);
                click(locate.lnk_signup);
                enter_text(locate.txt_email, GetJsonData("Email"));
                enter_text(locate.txt_passwd, GetJsonData("Password"));
                click(locate.dd_createprofile);
                clickDropdownValue(locate.dd_createprofilelist, GetJsonData("Profile"));
                if (GetJsonData("Profile").Equals("Self") || GetJsonData("Profile").Equals("Friend") || GetJsonData("Profile").Equals("Relative"))
                {
                    if (GetJsonData("Gender").Equals("Female"))
                    {
                        click(locate.rad_gender_female);
                    }
                    else
                    {
                        click(locate.rad_gender_male);
                    }
                }
                click(locate.btn_next);
                if (isElementPresent(locate.email_error))
                {
                    error_text = driver.FindElement(locate.email_error).Text;
                    throw new Exception();
                }
                if (isElementPresent(locate.passwd_error))
                {
                    error_text = driver.FindElement(locate.passwd_error).Text;
                    throw new Exception();
                }
                enter_text(locate.txt_first_name, GetJsonData("Firstname"));
                enter_text(locate.txt_last_name, GetJsonData("Lastname"));
                click(locate.dd_dobday);
                clickDropdownValue(locate.dd_daylist, GetJsonData("BirthDay"));
                click(locate.dd_dobmonth);
                clickDropdownValue(locate.dd_monthlist, GetJsonData("BirthMonth"));
                click(locate.dd_dobyear);
                clickDropdownValue(locate.dd_yearlist, GetJsonData("BirthYear"));
                click(locate.dd_religion);
                clickDropdownValue(locate.dd_religionlist, GetJsonData("Religion"));
                Assert.AreEqual(locate.dd_mothertongue_defaulted.Text, GetJsonData("MotherTongue"));
                click(locate.dd_country);
                clickDropdownValue(locate.dd_countrylist, GetJsonData("Country"));
                //click(locate.btn_signup);
                Dispose();
            }
            catch (Exception e)
            {
                if(error_text == ""){
                    Dispose();
                    throw new Exception(e.Message);
                }
                else
                {
                    Dispose();
                    throw new Exception(error_text);
                }
            }
        }
    }
}
