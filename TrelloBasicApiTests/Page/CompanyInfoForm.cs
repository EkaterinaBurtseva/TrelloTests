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


        public bool IsCompanyInfoFormDisplayed()
        {
            return NameOfTheTeamField.Displayed;
        }

        public CompanyInfoForm EnterCompanyName(string company)
        {
            NameOfTheTeamField.SendKeys(company);
            return this;
        }

        public CompanyInfoForm ClickTypeOfTeamDropdown()
        {
            TypeOfTeamDropdown.Click();
            return this;

        }

        public CompanyInfoForm ChooseMarketingOption()
        {
            TypeOfTeamDropDownMarketing.Click();
            return this;
        }

        public CompanyInfoForm ClickCreateTeamSubmitBtn()
        {
            CreateTeamSubmitBtn.Click();
            return this;

        }

        public bool IsMembersFieldDisplayed()
        {
            return AddMembersFields.Displayed;
        }

        public CompanyInfoForm FillMemberEmails(String emails)
        {
            AddMembersFields.SendKeys(emails);
            return this;

        }

        public CompanyInfoForm ClickMembersInfoBtn()
        {
            MembersInfoSubmit.Click();
            return this;

        }

    }

}