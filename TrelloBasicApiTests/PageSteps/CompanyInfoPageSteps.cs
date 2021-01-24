using System;
using TrelloBasicApiTests.Assert;
using TrelloBasicApiTests.Page;
using TrelloTests.Fixture;

namespace TrelloBasicApiTests.PageSteps
{
    public class CompanyInfoPageSteps : BaseTestSteps
    {
        private CompanyInfoForm companyInfoPage = new CompanyInfoForm();
        public CompanyInfoPageSteps()
        {
        }

        public void FillInfoAboutCompanyAndTeam(String companyName, String emails)
        {
            Check.EqualBoolean(true, companyInfoPage.IsCompanyInfoFormDisplayed(), "Company form displayed", "Company form isn't displayed");
            companyInfoPage.EnterCompanyName(companyName)
                .ClickTypeOfTeamDropdown()
                .ChooseMarketingOption()
                .ClickCreateTeamSubmitBtn();

            Check.EqualBoolean(true, companyInfoPage.IsMembersFieldDisplayed(), "Members field is displayed", "Members field isn't displayed");
            companyInfoPage.FillMemberEmails(emails)
                .ClickMembersInfoBtn();

        }
    }
}
