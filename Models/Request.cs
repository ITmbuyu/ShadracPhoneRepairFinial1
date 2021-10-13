using ShadracPhoneRepairFinial1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Models
{
    public class Request
    {
        public int RequestId { get; set; }

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

        [Display(Name = "Here is the charge to repair device")]
        public double Price { get; set; }

        [Display(Name = "Date and time of your request made")]
        public DateTime RequestDateTime { get; set; }

        public string UserId { get; set; }

        //FK - Payment Status
        [Display(Name = "Payment status of repair")]
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

        public string DeviceProblems { get;set;  }

        public string DeviceNames {  get; set; }

        public string DeviceCapacity {  get; set; }

        public string DeviceColors {  get; set; }


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
