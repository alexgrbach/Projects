﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models.Responses
{
    public class StateResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public States state { get; set; }
    }
}
