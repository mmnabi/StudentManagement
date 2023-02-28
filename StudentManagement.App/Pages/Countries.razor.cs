using StudentManagement.App.Services;
using Microsoft.AspNetCore.Components;
using StudentManagement.Shared.Domain;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace StudentManagement.App.Pages
{
    public partial class Countries
    {
        string Title = "Countries";
        string SearchString = "";
        List<Country> CountryList = new List<Country>();

        int deleteId = 0;
        [Inject] protected IDialogService DialogService { get; set; }

        [Inject]
        public ICountryDataService CountryDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CountryList = (await CountryDataService.GetAllCountries()).ToList();
        }

        public async Task OnDeleteClickAsync(int countryId)
        {
            bool? result = await DialogService.ShowMessageBox("Warning",
                "Deleting can not be undone!", yesText: "Delete!", cancelText: "Cancel");

            deleteId = result == null ? 0 : countryId;
            if (deleteId == 0) return;

            await CountryDataService.DeleteCountry(deleteId);

            var record = CountryList.FirstOrDefault(e => e.Id == deleteId);
            if (record != null)
                CountryList.Remove(record);
        }

        private bool FilterFunc1(Country element) => FilterFunc(element, SearchString);

        private bool FilterFunc(Country element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}
