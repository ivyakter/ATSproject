﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.Data.Models
{
    public class Upazila
    {
        public int id { set; get; }
        public int districtId { set; get; }
        public string name { set; get; }
        public string banglaName { set; get; }
        public string url { set; get; }
    }
}
