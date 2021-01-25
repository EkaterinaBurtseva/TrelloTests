using System;
using HtmlElements.Elements;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TrelloAssignment.UI.Base;

namespace TrelloAssignment.UI.Pages
{
    public class CompanyInfoForm :BasePage
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public CompanyInfoForm() : base()
        {
            Logger.Info("Company info form");
        }

        public HtmlElement NameOfTheTeamField => new HtmlElement(FindElement(By.CssSelector("input[data-test-id='header-create-team-name-input']")));
        public HtmlElement TypeOfTeamDropdown => new HtmlElement(FindElement(By.CssSelector("div[data-test-id='header-create-team-type-input']")));
        public HtmlElement TypeOfTeamDropDownMarketing => new HtmlElement(FindElement(By.CssSelector("div[data-test-id='header-create-team-type-input-marketing']")));
        public HtmlElement CreateTeamSubmitBtn => new HtmlElement(FindElement(By.CssSelector("button[data-test-id='header-create-team-submit-button']")));
        public HtmlElement AddMembersFields => new HtmlElement(FindElement(By.CssSelector("input.autocomplete-input")));
        public HtmlElement MembersInfoSubmit => new HtmlElement(FindElement(By.CssSelector("button[data-test-id='team-invite-submit-button']")));

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

        public CompanyInfoForm FillMemberEmails(string emails)
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
