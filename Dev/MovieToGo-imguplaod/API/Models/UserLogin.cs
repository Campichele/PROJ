using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class UserLogin
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
    }
}
