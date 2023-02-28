using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using StudentManagement.Shared.Domain;
using StudentManagement.App.Services;
using MudBlazor;

namespace StudentManagement.App.Pages
{
    public partial class CountryForm
    {
        protected string Title = "Country Form";
        protected Country Model = new Country();
        protected bool Saved;
        protected string Message = string.Empty;
        protected Severity StatusClass = Severity.Info;

        [Parameter]
        public string? Id { get; set; }

        [Inject]
        public ICountryDataService? CountryDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            int.TryParse(Id, out var countryId);

            if (countryId == 0) //new country is being created
            {
                //add some defaults
                Model = new Country();
            }
            else
            {
                Model = await CountryDataService.GetCountryById(countryId);
            }
        }

        protected async Task OnValidSubmitAsync(EditContext context)
        {
            Saved = false;

            if (Model.Id == 0) //new
            {
                var addedCountry = await CountryDataService.AddCountry(Model);
                if (addedCountry != null)
                {
                    StatusClass = Severity.Success;
                    Message = "New country added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = Severity.Error;
                    Message = "Something went wrong adding the new country. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await CountryDataService.UpdateCountry(Model);
                StatusClass = Severity.Success;
                Message = "Country updated successfully.";
                Saved = true;
            }
        }
    }
}
