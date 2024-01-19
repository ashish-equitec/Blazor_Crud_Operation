namespace BlazorApp1.Shared
{
    public partial class NavMenu
    {
        private string ListDisplay => showList ? "block" : "none";
        private bool showList = false;
        private void ToggleDropdown()
        {
            showList = !showList;
        }
        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
    }
}