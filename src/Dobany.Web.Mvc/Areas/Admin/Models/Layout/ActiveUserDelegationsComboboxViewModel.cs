using System.Collections.Generic;
using Dobany.Authorization.Delegation;
using Dobany.Authorization.Users.Delegation.Dto;

namespace Dobany.Web.Areas.Admin.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }
        
        public List<UserDelegationDto> UserDelegations { get; set; }
    }
}
