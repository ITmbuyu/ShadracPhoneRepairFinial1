using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShadracPhoneRepairFinial1.Data.Migrations
{
    public partial class Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovalMessages",
                columns: table => new
                {
                    ApprovalMessagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMessages = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalMessages", x => x.ApprovalMessagesId);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "CApprovalMessages",
                columns: table => new
                {
                    CApprovalMessagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CMessages = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CApprovalMessages", x => x.CApprovalMessagesId);
                });

            migrationBuilder.CreateTable(
                name: "Colours",
                columns: table => new
                {
                    ColourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colours", x => x.ColourId);
                });

            migrationBuilder.CreateTable(
                name: "DeviceProblems",
                columns: table => new
                {
                    DeviceProblemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostOfP = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceProblems", x => x.DeviceProblemId);
                });

            migrationBuilder.CreateTable(
                name: "DevicePurchase",
                columns: table => new
                {
                    DevicePurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DevicePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceRAM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceROM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Devicestorage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceCamera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceBattery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceProcesser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DevicePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicePurchase", x => x.DevicePurchaseId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmpSurname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmpEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmpPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpRate = table.Column<double>(type: "float", nullable: false),
                    EmpHours = table.Column<int>(type: "int", nullable: false),
                    EmpWage = table.Column<double>(type: "float", nullable: false),
                    EmployeeRole = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "parts",
                columns: table => new
                {
                    PartsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Part_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Part_Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parts", x => x.PartsId);
                });

            migrationBuilder.CreateTable(
                name: "PartsCollections",
                columns: table => new
                {
                    PartsCollectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quaunity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsCollections", x => x.PartsCollectionId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    PaymentStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.PaymentStatusId);
                });

            migrationBuilder.CreateTable(
                name: "RepairStatuses",
                columns: table => new
                {
                    RepairStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairStatuses", x => x.RepairStatusId);
                });

            migrationBuilder.CreateTable(
                name: "requestPayments",
                columns: table => new
                {
                    RequestPaymentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentmethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CVVnumber = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeofpayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrackingNumberOfRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priceofrepair = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestPayments", x => x.RequestPaymentsId);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    StorageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.StorageId);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supplier_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier_CellNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "WalkInPayments",
                columns: table => new
                {
                    WalkInPaymentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentmethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CVVnumber = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeofpayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrackingNumberOfRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priceofrepair = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkInPayments", x => x.WalkInPaymentsId);
                });

            migrationBuilder.CreateTable(
                name: "WalkInTimes",
                columns: table => new
                {
                    WalkInTimesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalkInTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkInTimes", x => x.WalkInTimesId);
                });

            migrationBuilder.CreateTable(
                name: "DeviceDescriptions",
                columns: table => new
                {
                    DeviceDescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDescriptions", x => x.DeviceDescriptionId);
                    table.ForeignKey(
                        name: "FK_DeviceDescriptions_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceStatuses",
                columns: table => new
                {
                    TrackingNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceProblem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMEI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    RepairStatusId = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicianId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalOfRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalOfCharge = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceStatuses", x => x.TrackingNumber);
                    table.ForeignKey(
                        name: "FK_DeviceStatuses_RepairStatuses_RepairStatusId",
                        column: x => x.RepairStatusId,
                        principalTable: "RepairStatuses",
                        principalColumn: "RepairStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceStatusesWalkIns",
                columns: table => new
                {
                    TrackingNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceProblem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMEI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalkInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalkInTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    WalkInStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairStatusId = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicianId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalOfCharge = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceStatusesWalkIns", x => x.TrackingNumber);
                    table.ForeignKey(
                        name: "FK_DeviceStatusesWalkIns_RepairStatuses_RepairStatusId",
                        column: x => x.RepairStatusId,
                        principalTable: "RepairStatuses",
                        principalColumn: "RepairStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "supplierParts",
                columns: table => new
                {
                    SupplierPartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartsId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    PartSupplied_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartSupplied_Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplierParts", x => x.SupplierPartId);
                    table.ForeignKey(
                        name: "FK_supplierParts_parts_PartsId",
                        column: x => x.PartsId,
                        principalTable: "parts",
                        principalColumn: "PartsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_supplierParts_suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceProblemId = table.Column<int>(type: "int", nullable: false),
                    DeviceDescriptionId = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    ColourId = table.Column<int>(type: "int", nullable: false),
                    IMEI = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    RequestDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatusId = table.Column<int>(type: "int", nullable: false),
                    CApprovalMessagesId = table.Column<int>(type: "int", nullable: false),
                    ApprovalMessagesId = table.Column<int>(type: "int", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_ApprovalMessages_ApprovalMessagesId",
                        column: x => x.ApprovalMessagesId,
                        principalTable: "ApprovalMessages",
                        principalColumn: "ApprovalMessagesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_CApprovalMessages_CApprovalMessagesId",
                        column: x => x.CApprovalMessagesId,
                        principalTable: "CApprovalMessages",
                        principalColumn: "CApprovalMessagesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Colours_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colours",
                        principalColumn: "ColourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_DeviceDescriptions_DeviceDescriptionId",
                        column: x => x.DeviceDescriptionId,
                        principalTable: "DeviceDescriptions",
                        principalColumn: "DeviceDescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_DeviceProblems_DeviceProblemId",
                        column: x => x.DeviceProblemId,
                        principalTable: "DeviceProblems",
                        principalColumn: "DeviceProblemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_PaymentStatus_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "PaymentStatus",
                        principalColumn: "PaymentStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TradeinCollect",
                columns: table => new
                {
                    TradeinCollectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeinNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceDescriptionId = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    ColourId = table.Column<int>(type: "int", nullable: false),
                    IMEI = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DeviceCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DevicePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CApprovalMessagesId = table.Column<int>(type: "int", nullable: false),
                    ApprovalMessagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeinCollect", x => x.TradeinCollectId);
                    table.ForeignKey(
                        name: "FK_TradeinCollect_ApprovalMessages_ApprovalMessagesId",
                        column: x => x.ApprovalMessagesId,
                        principalTable: "ApprovalMessages",
                        principalColumn: "ApprovalMessagesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeinCollect_CApprovalMessages_CApprovalMessagesId",
                        column: x => x.CApprovalMessagesId,
                        principalTable: "CApprovalMessages",
                        principalColumn: "CApprovalMessagesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeinCollect_Colours_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colours",
                        principalColumn: "ColourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeinCollect_DeviceDescriptions_DeviceDescriptionId",
                        column: x => x.DeviceDescriptionId,
                        principalTable: "DeviceDescriptions",
                        principalColumn: "DeviceDescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeinCollect_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TradeinDropOff",
                columns: table => new
                {
                    TradeinDropOffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeinNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceProblemId = table.Column<int>(type: "int", nullable: false),
                    DeviceDescriptionId = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    ColourId = table.Column<int>(type: "int", nullable: false),
                    IMEI = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DeviceCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalkInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalkInTimesId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CApprovalMessagesId = table.Column<int>(type: "int", nullable: false),
                    ApprovalMessagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeinDropOff", x => x.TradeinDropOffId);
                    table.ForeignKey(
                        name: "FK_TradeinDropOff_ApprovalMessages_ApprovalMessagesId",
                        column: x => x.ApprovalMessagesId,
                        principalTable: "ApprovalMessages",
                        principalColumn: "ApprovalMessagesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeinDropOff_CApprovalMessages_CApprovalMessagesId",
                        column: x => x.CApprovalMessagesId,
                        principalTable: "CApprovalMessages",
                        principalColumn: "CApprovalMessagesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeinDropOff_Colours_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colours",
                        principalColumn: "ColourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeinDropOff_DeviceDescriptions_DeviceDescriptionId",
                        column: x => x.DeviceDescriptionId,
                        principalTable: "DeviceDescriptions",
                        principalColumn: "DeviceDescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeinDropOff_DeviceProblems_DeviceProblemId",
                        column: x => x.DeviceProblemId,
                        principalTable: "DeviceProblems",
                        principalColumn: "DeviceProblemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeinDropOff_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeinDropOff_WalkInTimes_WalkInTimesId",
                        column: x => x.WalkInTimesId,
                        principalTable: "WalkInTimes",
                        principalColumn: "WalkInTimesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalkInRequests",
                columns: table => new
                {
                    WalkInRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceProblemId = table.Column<int>(type: "int", nullable: false),
                    DeviceDescriptionId = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    ColourId = table.Column<int>(type: "int", nullable: false),
                    IMEI = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    WalkInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalkInTimesId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatusId = table.Column<int>(type: "int", nullable: false),
                    CApprovalMessagesId = table.Column<int>(type: "int", nullable: false),
                    ApprovalMessagesId = table.Column<int>(type: "int", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkInRequests", x => x.WalkInRequestId);
                    table.ForeignKey(
                        name: "FK_WalkInRequests_ApprovalMessages_ApprovalMessagesId",
                        column: x => x.ApprovalMessagesId,
                        principalTable: "ApprovalMessages",
                        principalColumn: "ApprovalMessagesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalkInRequests_CApprovalMessages_CApprovalMessagesId",
                        column: x => x.CApprovalMessagesId,
                        principalTable: "CApprovalMessages",
                        principalColumn: "CApprovalMessagesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalkInRequests_Colours_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colours",
                        principalColumn: "ColourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalkInRequests_DeviceDescriptions_DeviceDescriptionId",
                        column: x => x.DeviceDescriptionId,
                        principalTable: "DeviceDescriptions",
                        principalColumn: "DeviceDescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalkInRequests_DeviceProblems_DeviceProblemId",
                        column: x => x.DeviceProblemId,
                        principalTable: "DeviceProblems",
                        principalColumn: "DeviceProblemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalkInRequests_PaymentStatus_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "PaymentStatus",
                        principalColumn: "PaymentStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalkInRequests_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalkInRequests_WalkInTimes_WalkInTimesId",
                        column: x => x.WalkInTimesId,
                        principalTable: "WalkInTimes",
                        principalColumn: "WalkInTimesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDescriptions_BrandId",
                table: "DeviceDescriptions",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceStatuses_RepairStatusId",
                table: "DeviceStatuses",
                column: "RepairStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceStatusesWalkIns_RepairStatusId",
                table: "DeviceStatusesWalkIns",
                column: "RepairStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ApprovalMessagesId",
                table: "Requests",
                column: "ApprovalMessagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CApprovalMessagesId",
                table: "Requests",
                column: "CApprovalMessagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ColourId",
                table: "Requests",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DeviceDescriptionId",
                table: "Requests",
                column: "DeviceDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DeviceProblemId",
                table: "Requests",
                column: "DeviceProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PaymentStatusId",
                table: "Requests",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StorageId",
                table: "Requests",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_supplierParts_PartsId",
                table: "supplierParts",
                column: "PartsId");

            migrationBuilder.CreateIndex(
                name: "IX_supplierParts_SupplierId",
                table: "supplierParts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeinCollect_ApprovalMessagesId",
                table: "TradeinCollect",
                column: "ApprovalMessagesId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeinCollect_CApprovalMessagesId",
                table: "TradeinCollect",
                column: "CApprovalMessagesId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeinCollect_ColourId",
                table: "TradeinCollect",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeinCollect_DeviceDescriptionId",
                table: "TradeinCollect",
                column: "DeviceDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeinCollect_StorageId",
                table: "TradeinCollect",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeinDropOff_ApprovalMessagesId",
                table: "TradeinDropOff",
                column: "ApprovalMessagesId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeinDropOff_CApprovalMessagesId",
                table: "TradeinDropOff",
                column: "CApprovalMessagesId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeinDropOff_ColourId",
                table: "TradeinDropOff",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeinDropOff_DeviceDescriptionId",
                table: "TradeinDropOff",
                column: "DeviceDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeinDropOff_DeviceProblemId",
                table: "TradeinDropOff",
                column: "DeviceProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeinDropOff_StorageId",
                table: "TradeinDropOff",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeinDropOff_WalkInTimesId",
                table: "TradeinDropOff",
                column: "WalkInTimesId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkInRequests_ApprovalMessagesId",
                table: "WalkInRequests",
                column: "ApprovalMessagesId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkInRequests_CApprovalMessagesId",
                table: "WalkInRequests",
                column: "CApprovalMessagesId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkInRequests_ColourId",
                table: "WalkInRequests",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkInRequests_DeviceDescriptionId",
                table: "WalkInRequests",
                column: "DeviceDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkInRequests_DeviceProblemId",
                table: "WalkInRequests",
                column: "DeviceProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkInRequests_PaymentStatusId",
                table: "WalkInRequests",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkInRequests_StorageId",
                table: "WalkInRequests",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkInRequests_WalkInTimesId",
                table: "WalkInRequests",
                column: "WalkInTimesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevicePurchase");

            migrationBuilder.DropTable(
                name: "DeviceStatuses");

            migrationBuilder.DropTable(
                name: "DeviceStatusesWalkIns");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "PartsCollections");

            migrationBuilder.DropTable(
                name: "requestPayments");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "supplierParts");

            migrationBuilder.DropTable(
                name: "TradeinCollect");

            migrationBuilder.DropTable(
                name: "TradeinDropOff");

            migrationBuilder.DropTable(
                name: "WalkInPayments");

            migrationBuilder.DropTable(
                name: "WalkInRequests");

            migrationBuilder.DropTable(
                name: "RepairStatuses");

            migrationBuilder.DropTable(
                name: "parts");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "ApprovalMessages");

            migrationBuilder.DropTable(
                name: "CApprovalMessages");

            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropTable(
                name: "DeviceDescriptions");

            migrationBuilder.DropTable(
                name: "DeviceProblems");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "WalkInTimes");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
