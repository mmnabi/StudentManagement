using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using StudentManagement.Shared.Domain;
using StudentManagement.App.Services;
using MudBlazor;

namespace StudentManagement.App.Pages
{
    public partial class ClassForm
    {
        protected string Title = "Class Form";
        protected Class Model = new Class();
        protected bool Saved;
        protected string Message = string.Empty;
        protected Severity StatusClass = Severity.Info;

        [Parameter]
        public string? Id { get; set; }

        [Inject]
        public IClassDataService? ClassDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            int.TryParse(Id, out var classId);

            if (classId == 0) //new class is being created
            {
                //add some defaults
                Model = new Class();
            }
            else
            {
                Model = await ClassDataService.GetClassById(classId);
            }
        }

        protected async Task OnValidSubmitAsync(EditContext context)
        {
            Saved = false;

            if (Model.Id == 0) //new
            {
                var addedClass = await ClassDataService.AddClass(Model);
                if (addedClass != null)
                {
                    StatusClass = Severity.Success;
                    Message = "New class added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = Severity.Error;
                    Message = "Something went wrong adding the new class. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await ClassDataService.UpdateClass(Model);
                StatusClass = Severity.Success;
                Message = "Class updated successfully.";
                Saved = true;
            }
        }
    }
}
