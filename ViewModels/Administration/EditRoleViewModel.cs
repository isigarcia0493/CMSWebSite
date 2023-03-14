using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMSWebsite.ViewModels.Administration
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        public string RoleId { get; set; }

        [Required(ErrorMessage = "Please enter a role name")]
        [DisplayName("Role Name")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
