﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestTest.Core.Domain.Enums;

namespace RestTest.Infrastructure.Data.Entities
{
    public class Employee
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }

        public virtual int JobTitle { get; set; }
    }
}
