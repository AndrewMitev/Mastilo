﻿namespace Mastilo.Web.ViewModels.Manage
{
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Data.Models;

    public class IndexViewModel
    {
        public bool HasPassword { get; set; }

        public User CurrentUser { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public string PhoneNumber { get; set; }

        public bool TwoFactor { get; set; }

        public bool BrowserRemembered { get; set; }
    }
}