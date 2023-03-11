using System.Collections.Generic;
using MvvmHelpers;
using Dobany.Models.NavigationMenu;

namespace Dobany.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}