﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace UserManagement.Models;

public partial class Skill
{
    public int Skillid { get; set; }

    public string Skill1 { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}