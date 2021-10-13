using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Models
{
    public class WalkInRequest
    {
        public int WalkInRequestId { get; set; }

        //FK - Brand
        public string BrandName { get; set; }

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

        [Display(Name = "Please choose your preferd date to come in")]
        [DataType(DataType.Date)]
        public DateTime WalkInDate { get; set; }

        //FK - WalkInTime Slot
        [Display(Name = "Please choose your preferd time slot to come in")]
        public int WalkInTimesId { get; set; }
        public virtual WalkInTimes WalkInTimes { get; set; }

        [Display(Name = "Here is the charge to repair device")]
        public double Price { get; set; }

        public string UserId { get; set; }

        //FK - Payment Status
        public int PaymentStatusId { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }

        //FK - Charge Approval
        [Display(Name = "Customer has ")]
        public int CApprovalMessagesId { get; set; }
        public virtual CApprovalMessages CApprovalMessages { get; set; }

        //FK - Approval Of Request
        [Display(Name = "Request has been")]
        public int ApprovalMessagesId { get; set; }
        public virtual ApprovalMessages ApprovalMessages { get; set; }

        public string UserEmail { get; set; }

        public string DeviceProblems { get; set; }

        public string DeviceNames { get; set; }

        public string DeviceCapacity { get; set; }

        public string DeviceColors { get; set; }


        //public double CalcPrice()
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();

        //    var price =
        //        db.DeviceDescriptions.Find(DeviceDescriptionId).Brand.BrandRate *
        //        db.DeviceProblems.Find(DeviceProblemId).CostOfP;

        //    return price;
        //}
    }
}
