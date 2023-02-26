using MudBlazor;

namespace StudentManagement.App.Shared
{
    public partial class MainLayout
    {
        private bool _drawerOpen = true;
        private bool _isDarkMode;
        private MudTheme _theme = new();

        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }
    }
}
