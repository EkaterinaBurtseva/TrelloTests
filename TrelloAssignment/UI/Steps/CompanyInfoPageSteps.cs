using System;
using TrelloAssignment.Assert;
using TrelloAssignment.UI.Pages;
using TrelloAssignment.UI.Properties;

namespace TrelloAssignment.UI.Steps
{
    public class CompanyInfoPageSteps
    {
        public static CompanyInfoForm OpenCompanyInfoForm()
        {
            return Activators.Get<CompanyInfoForm>();
        }

        public void FillInfoAboutCompanyAndTeam(String companyName, String emails)
        {
            CompanyInfoForm companyInfoForm = OpenCompanyInfoForm();
            companyInfoForm.WaitTillLoaded();
            Check.EqualBoolean(true, companyInfoForm.IsCompanyInfoFormDisplayed(), "Company form displayed", "Company form isn't displayed");
            companyInfoForm.EnterCompanyName(companyName)
                .ClickTypeOfTeamDropdown()
                .ChooseMarketingOption()
                .ClickCreateTeamSubmitBtn();

            Check.EqualBoolean(true, companyInfoForm.IsMembersFieldDisplayed(), "Members field is displayed", "Members field isn't displayed");
            companyInfoForm.FillMemberEmails(emails)
                .ClickMembersInfoBtn();

        }
    }
}
