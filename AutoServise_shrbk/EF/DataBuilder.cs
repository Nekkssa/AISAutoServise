﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServise_shrbk.EF
{
    public partial class Employee
    {
        public string FIO { get => $"{SecondName} {FirstName} {Patronymic}"; }

    }

    public partial class Client
    {
        public string FIO { get => $"{SecondName} {FirstName} {Patronymic}"; }

    }
}
