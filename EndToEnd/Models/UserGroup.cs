using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class UserGroup
    {
        public int UserGroupId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateCreated {

            get { return DateTime.Now; }
            set { }
        }
        public bool Active {

            get { return Active; }
            set { Active = true; }
        }

    }

    public class AssignUserGroupRole
    {
        public int AssignUserGroupRoleId { get; set; }

        //nav links { assigning usergroup a role
            public int UserGroupId { get; set; }
            public virtual UserGroup UserGroup { get; set; }

        public string RoleDTOId { get; set; }
        public virtual RoleDTO Role { get; set; }


    }

    public class AssignStaffUserGroup
    {
        public int AssignStaffUserGroupId { get; set; }

        public string StaffId { get; set; }

        public virtual Staff Staff { get; set; }

        public int UserGroupId { get; set; }

        public virtual UserGroup UserGroup { get; set; }
    }


}