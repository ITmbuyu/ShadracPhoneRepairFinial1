﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Models
{
    public class PartsCollection
    {
        public int PartsCollectionId { get; set; }
        public string PartName { get; set; }
        public string Quaunity { get; set; }
        public string Price { get; set; }
        public string Supplier { get; set; }
        public string SupplierAddress { get; set; }
    }
}
