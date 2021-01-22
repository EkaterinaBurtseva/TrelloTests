using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TrelloBasicApiTests.Page
{
    public class CompanyInfoForm : BasePage
    {
        public CompanyInfoForm() : base()
        {
            LogName = "Company info form";
        }

        [FindsBy(How = How.CssSelector, Using = "input[data-test-id='header-create-team-name-input']")]
        private IWebElement NameOfTheTeamField;

        [FindsBy(How = How.CssSelector, Using = "div[data-test-id='header-create-team-type-input']")]
        private IWebElement TypeOfTeamDropdown;

        [FindsBy(How = How.CssSelector, Using = "div[data-test-id='header-create-team-type-input-marketing']")]
        private IWebElement TypeOfTeamDropDownMarketing;

        [FindsBy(How = How.CssSelector, Using = "div[data-test-id='header-create-team-submit-button']")]
        private IWebElement CreateTeamSubmitBtn;

        [FindsBy(How = How.CssSelector, Using = "div[data-test-id='add-members-input']")]
        private IWebElement AddMembersFields;

        [FindsBy(How = How.CssSelector, Using = "div[data-test-id='team-invite-submit-button']")]
        private IWebElement MembersInfoSubmit;


        public bool IsCompanyInfoFormDisplaye()
        {
            return NameOfTheTeamField.Displayed;
        }

        public void EnterCompanyName(string company)
        {
            NameOfTheTeamField.SendKeys(company);
        }

        public void ClickTypeOfTeamDropdown()
        {
            TypeOfTeamDropdown.Click();

        }

        public void ChooseMarketingOption()
        {
            TypeOfTeamDropDownMarketing.Click();
        }

        public void ClickCreateTeamSubmitBtn()
        {
            CreateTeamSubmitBtn.Click();

        }

        public bool IsMembersFieldDisplayed()
        {
            return AddMembersFields.Displayed;
        }

        public void IsMembersFieldDisplayed(String emails)
        {
            AddMembersFields.SendKeys(emails);

        }

        public void ClickMembersInfoBtn()
        {
            MembersInfoSubmit.Click();

        }

    }

}