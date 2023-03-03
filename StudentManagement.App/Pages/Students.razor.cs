using StudentManagement.App.Services;
using Microsoft.AspNetCore.Components;
using StudentManagement.Shared.Domain;
using MudBlazor;

namespace StudentManagement.App.Pages
{
    public partial class Students
    {
        string Title = "Students";
        string SearchString = "";
        List<Student> StudentList = new List<Student>();

        int deleteId = 0;
        [Inject] protected IDialogService DialogService { get; set; }

        [Inject]
        public IStudentDataService StudentDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            StudentList = (await StudentDataService.GetAllStudents()).ToList();
        }

        public async Task OnDeleteClickAsync(int studentId)
        {
            bool? result = await DialogService.ShowMessageBox("Warning",
                "Deleting can not be undone!", yesText: "Delete!", cancelText: "Cancel");

            deleteId = result == null ? 0 : studentId;
            if (deleteId == 0) return;

            await StudentDataService.DeleteStudent(deleteId);

            var record = StudentList.FirstOrDefault(e => e.Id == deleteId);
            if (record != null)
                StudentList.Remove(record);
        }

        private bool FilterFunc1(Student element) => FilterFunc(element, SearchString);

        private bool FilterFunc(Student element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}
