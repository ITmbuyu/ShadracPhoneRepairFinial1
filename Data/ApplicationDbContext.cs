using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShadracPhoneRepairFinial1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadracPhoneRepairFinial1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<DeviceDescription> DeviceDescriptions { get; set; }
        public DbSet<DeviceProblem> DeviceProblems { get; set; }
        public DbSet<DeviceStatus> DeviceStatuses { get; set; }
        public DbSet<DeviceStatusWalkIns> DeviceStatusesWalkIns { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestPayments> requestPayments { get; set; }
        public DbSet<RepairStatus> RepairStatuses { get; set; }
        public DbSet<WalkInPayments> WalkInPayments { get; set; }
        public DbSet<WalkInRequest> WalkInRequests { get; set; }
        public DbSet<WalkInTimes> WalkInTimes { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Parts> parts { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<SupplierPart> supplierParts { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<ApprovalMessages> ApprovalMessages { get; set; }
        public DbSet<CApprovalMessages> CApprovalMessages { get; set; }
        public DbSet<PartsCollection> PartsCollections { get; set; }

        public DbSet<TradeinDropOff> TradeinDropOff { get; set; }

        public DbSet<TradeinCollect> TradeinCollect { get; set; }

        public DbSet<DevicePurchase> DevicePurchase { get; set; }
    }
}
