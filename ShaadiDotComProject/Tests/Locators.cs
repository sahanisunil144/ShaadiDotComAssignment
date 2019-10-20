using OpenQA.Selenium;

namespace ShaadiDotComProject.Tests
{
    public class Locators : Base
    {
        public IWebDriver driver;
        public Locators()
        {
            driver = Instance;
        }
        //Registeration Page MarathishaadiDotCom

        public IWebElement lnk_login => FindElement(By.LinkText("Login"));
        public IWebElement lnk_signup => FindElement(By.LinkText("Sign Up Free"));
        public IWebElement txt_email => FindElement(By.CssSelector("input[name='email']"));
        public By email_error = By.CssSelector("p[data-testid='email_error']");
        public By passwd_error = By.CssSelector("p[data-testid='password1_error']");
        public IWebElement txt_passwd => FindElement(By.CssSelector("input[type='password']"));
        public IWebElement dd_createprofile => FindElement(By.CssSelector(".Dropdown-placeholder"));
        public By dd_createprofilelist = By.CssSelector(".Dropdown-menu.postedby_options > div");
        public IWebElement btn_next => FindElement(By.XPath("//button[@type='submit']"));
        public IWebElement rad_gender_male => FindElement(By.CssSelector("#gender_male"));
        public IWebElement rad_gender_female => FindElement(By.CssSelector("#gender_female"));
        public By gender_error = By.CssSelector("p[data-testid='gender_error']");
        public IWebElement txt_first_name => FindElement(By.CssSelector("input[name='first_name']"));
        public IWebElement txt_last_name => FindElement(By.CssSelector("input[name='last_name']"));
        public IWebElement dd_dobday => FindElement(By.CssSelector(".Dropdown-control.day_selector"));
        public IWebElement dd_dobmonth => FindElement(By.CssSelector(".Dropdown-control.month_selector"));
        public IWebElement dd_dobyear => FindElement(By.CssSelector(".Dropdown-control.year_selector"));
        public By dd_daylist = By.CssSelector(".Dropdown-menu.day_options > .Dropdown-option");
        public By dd_monthlist = By.CssSelector(".Dropdown-menu.month_options > .Dropdown-option");
        public By dd_yearlist => By.CssSelector(".Dropdown-menu.year_options > .Dropdown-option");
        public IWebElement dd_religion => FindElement(By.CssSelector(".Dropdown-control.community_selector"));
        public By dd_religionlist = By.CssSelector(".Dropdown-menu.community_options > .Dropdown-option");
        public IWebElement dd_mothertongue => FindElement(By.CssSelector(".Dropdown-control.mother_tongue_selector.Dropdown-disabled"));
        public IWebElement dd_mothertongue_defaulted => FindElement(By.CssSelector(".Dropdown-control.mother_tongue_selector.Dropdown-disabled > .Dropdown-placeholder.is-selected"));
        public IWebElement dd_country => FindElement(By.CssSelector(".Dropdown-control.countryofresidence_selector"));
        public By dd_countrylist = By.CssSelector(".Dropdown-menu.countryofresidence_options > div > .Dropdown-option");
        public IWebElement btn_signup => FindElement(By.XPath("//button[contains(text(),'Sign Up')]"));
    }
}
