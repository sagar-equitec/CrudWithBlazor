﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models
{
    public partial class GetEmployeeWithSkillsResult
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserDesignation { get; set; }
        public string UserCity { get; set; }
        public bool? UserIsActive { get; set; }
        public int? SkillId { get; set; }
        public string SkillName { get; set; }
    }
}
