﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebAppApi.Models
{
    public partial class UserRoleTb
    {
        public int UserRoleId { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }

        public virtual RoleTb Role { get; set; }
        public virtual UserTb User { get; set; }
    }
}