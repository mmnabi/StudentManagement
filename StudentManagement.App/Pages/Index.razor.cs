using Microsoft.AspNetCore.Components;
using MudBlazor;
using StudentManagement.App.Services;

namespace StudentManagement.App.Pages
{
    public partial class Index
    {
        double? AvgAge { get; set; }

        List<double> ClassStudentCount = new List<double>();
        List<string> ClassStudentCountLabel = new List<string>();

        List<double> CountryStudentCount = new List<double>();
        List<string> CountryStudentCountLabel = new List<string>();

        [Inject]
        public IStudentDataService StudentDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var classDict = await StudentDataService.GetStudentsPerClass();
            foreach (var item in classDict)
            {
                ClassStudentCount.Add(item.Value);
                ClassStudentCountLabel.Add($"{item.Key}({item.Value})");
            }

            var countryDict = await StudentDataService.GetStudentsPerCountry();
            foreach (var item in countryDict)
            {
                CountryStudentCount.Add(item.Value);
                CountryStudentCountLabel.Add($"{item.Key}({item.Value})");
            }
            AvgAge = await StudentDataService.GetStudentsAvgAge();
        }
    }
}
