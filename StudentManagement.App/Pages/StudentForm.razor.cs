using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using StudentManagement.App.Services;
using StudentManagement.Shared.Domain;

namespace StudentManagement.App.Pages
{
    public partial class StudentForm
    {
        protected string Title = "Student Form";
        protected Student Model = new Student();
        protected bool Saved;
        protected string Message = string.Empty;
        protected Severity StatusClass = Severity.Info;
        List<Country> CountryList = new List<Country>();
        List<Class> ClassList = new List<Class>();

        [Parameter]
        public string? Id { get; set; }

        [Inject]
        public IStudentDataService? StudentDataService { get; set; }

        [Inject]
        public ICountryDataService? CountryDataService { get; set; }

        [Inject]
        public IClassDataService? ClassDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            CountryList.Add(new Country { Name = "Please Select" });
            CountryList.AddRange((await CountryDataService.GetAllCountries()).ToList());

            ClassList.Add(new Class { ClassName = "Please Select" });
            ClassList.AddRange((await ClassDataService.GetAllClasses()).ToList());

            int.TryParse(Id, out var studentId);

            if (studentId == 0) //new student is being created
            {
                //add some defaults
                Model = new Student();
            }
            else
            {
                Model = await StudentDataService.GetStudentById(studentId);
                Model.Country = CountryList.FirstOrDefault(e => e.Id == Model.Id);
                Model.Class = ClassList.FirstOrDefault(e => e.Id == Model.Id);
            }
        }

        protected async Task OnValidSubmitAsync(EditContext context)
        {
            Saved = false;

            if (Model.Id == 0) //new
            {
                var addedStudent = await StudentDataService.AddStudent(Model);
                if (addedStudent != null)
                {
                    StatusClass = Severity.Success;
                    Message = "New student added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = Severity.Error;
                    Message = "Something went wrong adding the new student. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await StudentDataService.UpdateStudent(Model);
                StatusClass = Severity.Success;
                Message = "Student updated successfully.";
                Saved = true;
            }
        }
    }
}
