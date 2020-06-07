using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public partial class UserRoles
    {
        [Key]
        public string UserId { get; set; }
        [Key]
        public string RoleId { get; set; }
    }
}
