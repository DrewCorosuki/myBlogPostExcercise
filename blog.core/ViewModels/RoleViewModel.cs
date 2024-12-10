﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.ViewModels
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class RoleListViewModel : ServiceResponseViewModel<RoleViewModel> { }
}
