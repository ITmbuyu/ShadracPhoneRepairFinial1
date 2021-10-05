using ShadracPhoneRepairFinial1.Data;
using ShadracPhoneRepairFinial1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.ViewModels
{
    public class DevicePurchaseVM : DevicePurchase
    {
        public string Nonce { get; set; }
    }
}
