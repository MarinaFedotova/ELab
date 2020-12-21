using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverBasic.business_objects;
using WebDriverBasic.po;
using WebDriverBasic.po.page_components;

namespace WebDriverBasic.service.ui
{
    class UserService
    {
        public static LoggedPage Login(User user, IWebDriver driver)
        {
            MainPage mainPage = new MainPage(driver);
            return mainPage.ClickOnInputLogin(user);
        }

        public static MainPage SignOut(IWebDriver driver)
        {
            NavBar navBar = new NavBar(driver);
            return navBar.ClickOnLinkLogout();
        }
    }
}
