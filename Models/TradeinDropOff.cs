using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Models
{
    public class TradeinDropOff
    {
        //Primary Key
        public int TradeinDropOffId { get; set; }

        public string TradeinNumber { get; set; }

        //FK - Brand
        public string Brand { get; set; }

        //FK - DeviceProblem
        [Display(Name = "Select issue with your device")]
        public int DeviceProblemId { get; set; }
        public virtual DeviceProblem DeviceProblem { get; set; }

        //FK - DeviceName
        [Display(Name = "Select Your Device Name")]
        public int DeviceDescriptionId { get; set; }
        public virtual DeviceDescription DeviceDescription { get; set; }

        //FK - Storage
        [Display(Name = "Select Storage capicity of Device")]
        public int StorageId { get; set; }
        public virtual Storage Storage { get; set; }

        //FK - ColourName
        [Display(Name = "Select Color of your device")]
        public int ColourId { get; set; }
        public virtual Colour Colour { get; set; }

        [StringLength(15)]
        [Display(Name = "Enter IMEI number for your device")]
        public string IMEI { get; set; }

        public string DeviceCondition { get; set; }
        
        [NotMapped]
        public string DevicePicture { get; set; }

        public DateTime RequestDateTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime WalkInDate { get; set; }

        //FK - WalkInTime Slot
        public int WalkInTimesId { get; set; }
        public virtual WalkInTimes WalkInTimes { get; set; }

        public string UserId { get; set; }

        //FK - Charge Approval
        [Display(Name = "Customer has ")]
        public int CApprovalMessagesId { get; set; }
        public virtual CApprovalMessages CApprovalMessages { get; set; }

        //FK - Approval Of Request
        [Display(Name = "Request has been")]
        public int ApprovalMessagesId { get; set; }
        public virtual ApprovalMessages ApprovalMessages { get; set; }

    }
}
