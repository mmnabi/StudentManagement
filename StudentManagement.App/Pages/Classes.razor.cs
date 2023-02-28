using StudentManagement.App.Services;
using Microsoft.AspNetCore.Components;
using StudentManagement.Shared.Domain;
using MudBlazor;

namespace StudentManagement.App.Pages
{
    public partial class Classes
    {
        string Title = "Classes";
        string SearchString = "";
        List<Class> ClassList = new List<Class>();

        int deleteId = 0;
        [Inject] protected IDialogService DialogService { get; set; }

        [Inject]
        public IClassDataService ClassDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ClassList = (await ClassDataService.GetAllClasses()).ToList();
        }

        public async Task OnDeleteClickAsync(int classId)
        {
            bool? result = await DialogService.ShowMessageBox("Warning",
                "Deleting can not be undone!", yesText: "Delete!", cancelText: "Cancel");

            deleteId = result == null ? 0 : classId;
            if (deleteId == 0) return;

            await ClassDataService.DeleteClass(deleteId);

            var record = ClassList.FirstOrDefault(e => e.Id == deleteId);
            if (record != null)
                ClassList.Remove(record);
        }

        private bool FilterFunc1(Class element) => FilterFunc(element, SearchString);

        private bool FilterFunc(Class element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.ClassName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}
