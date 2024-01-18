﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public partial class GetEmployeeByIDResult
    {
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Location { get; set; }
        public string Designation { get; set; }
        public string Email_Address { get; set; }
        public bool? Deleted { get; set; }
        public int ID { get; set; }
        public string Gender { get; set; }
    }
}