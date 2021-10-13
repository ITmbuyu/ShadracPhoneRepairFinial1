using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShadracPhoneRepairFinial1.Data;
using ShadracPhoneRepairFinial1.Models;

namespace ShadracPhoneRepairFinial1.Controllers
{
    public class WalkInRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public WalkInRequestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // GET: WalkInRequests
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var applicationDbContext = _context.WalkInRequests.Include(r => r.ApprovalMessages).Include(r => r.CApprovalMessages).Include(r => r.Colour).Include(r => r.DeviceDescription).Include(r => r.DeviceProblem).Include(r => r.PaymentStatus).Include(r => r.Storage);
            if (User.IsInRole("Customer"))
            {
                //deviceStatuses = db.DeviceStatuses.Include(d => d.RepairStatus).Where(x => x.UserId == userId);
                return View(_context.Requests.Where(x => x.UserId == userId).ToList());
            }
            return View(await applicationDbContext.ToListAsync());


            //var applicationDbContext = _context.WalkInRequests.Include(w => w.ApprovalMessages).Include(w => w.CApprovalMessages).Include(w => w.Colour).Include(w => w.DeviceDescription).Include(w => w.DeviceProblem).Include(r => r.PaymentStatus).Include(w => w.Storage).Include(w => w.WalkInTimes);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: WalkInRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walkInRequest = await _context.WalkInRequests
                .Include(w => w.ApprovalMessages)
                .Include(w => w.CApprovalMessages)
                .Include(w => w.Colour)
                .Include(w => w.DeviceDescription)
                .Include(w => w.DeviceProblem)
                .Include(r => r.PaymentStatus)
                .Include(w => w.Storage)
                .Include(w => w.WalkInTimes)
                .FirstOrDefaultAsync(m => m.WalkInRequestId == id);
            if (walkInRequest == null)
            {
                return NotFound();
            }

            return View(walkInRequest);
        }

        // GET: WalkInRequests/Create
        public IActionResult Create()
        {
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages");
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CMessages");
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name");
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceDescriptionId", "DeviceName");
            ViewData["DeviceProblemId"] = new SelectList(_context.DeviceProblems, "DeviceProblemId", "Description");
            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatus, "PaymentStatusId", "Status");
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity");
            ViewData["WalkInTimesId"] = new SelectList(_context.WalkInTimes, "WalkInTimesId", "WalkInTime");
            return View();
        }

        // POST: WalkInRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WalkInRequestId,BrandName,DeviceProblemId,DeviceDescriptionId,StorageId,ColourId,IMEI,WalkInDate,WalkInTimesId,Price,UserId,CApprovalMessagesId,ApprovalMessagesId,UserEmail")] WalkInRequest walkInRequest)
        {
            var brandid = (from ds in _context.DeviceDescriptions where ds.DeviceDescriptionId == walkInRequest.DeviceDescriptionId select ds.BrandId).FirstOrDefault();
            var brandname = (from b in _context.Brands where b.BrandId == brandid select b.BrandName).FirstOrDefault();
            var deviceproblemid = (from ds in _context.DeviceProblems where ds.DeviceProblemId == walkInRequest.DeviceProblemId select ds.DeviceProblemId).FirstOrDefault();
            var deviceproblem = (from b in _context.DeviceProblems where b.DeviceProblemId == deviceproblemid select b.Description).FirstOrDefault();
            var devicestorageid = (from ds in _context.Storage where ds.StorageId == walkInRequest.StorageId select ds.StorageId).FirstOrDefault();
            var devicestorage = (from b in _context.Storage where b.StorageId == devicestorageid select b.StorageCapacity).FirstOrDefault();
            var devicecolorid = (from ds in _context.Colours where ds.ColourId == walkInRequest.ColourId select ds.ColourId).FirstOrDefault();
            var devicecolor = (from b in _context.Colours where b.ColourId == devicecolorid select b.Name).FirstOrDefault();
            var devicename = (from b in _context.DeviceDescriptions where b.DeviceDescriptionId == brandid select b.DeviceName).FirstOrDefault();
            if (ModelState.IsValid)
            {
                walkInRequest.BrandName = _context.DeviceDescriptions.Find(walkInRequest.DeviceDescriptionId).Brand.BrandName;
                walkInRequest.DeviceColors = devicecolor;
                walkInRequest.DeviceProblems = deviceproblem;
                walkInRequest.DeviceCapacity = devicestorage;
                walkInRequest.DeviceNames = devicename;
                walkInRequest.WalkInDate = DateTime.Now;
                walkInRequest.UserEmail = User.Identity.Name;
                walkInRequest.Price = 0;
                walkInRequest.PaymentStatus = _context.PaymentStatus.Find(1);
                walkInRequest.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                walkInRequest.CApprovalMessages = _context.CApprovalMessages.Find(1);
                _context.Add(walkInRequest);
                await _context.SaveChangesAsync();

                DeviceStatusWalkIns status = new DeviceStatusWalkIns();
                status.TrackingNumber = "WSTR" + Convert.ToString(walkInRequest.WalkInRequestId);
                status.Brand = walkInRequest.BrandName;
                //status.DeviceProblem = _context.DeviceProblems.Find(walkInRequest.DeviceProblemId).Description;//request.DeviceProblem.Description;
                status.DeviceProblem = deviceproblem;
                //status.DeviceName = walkInRequest.DeviceDescription.DeviceName;
                status.DeviceName =devicename;
                //variable name=  databaseinstance.find(primarykeyofrespectivetable).itemlookingfor
                //status.Capacity = _context.Storage.Find(walkInRequest.StorageId).StorageCapacity;
                status.Capacity = devicestorage;
                //status.Colour = _context.Colours.Find(walkInRequest.ColourId).Name;
                status.Colour = devicecolor;
                status.IMEI = walkInRequest.IMEI;
                status.Price = walkInRequest.Price;
                status.PaymentStatus = _context.PaymentStatus.Find(walkInRequest.PaymentStatusId).Status;
                status.WalkInDate = walkInRequest.WalkInDate;
                status.WalkInTime = _context.WalkInTimes.Find(walkInRequest.WalkInTimesId).WalkInTime;
                status.WalkInStatus = "Please Drop your Device In for Repair on " + Convert.ToString(status.WalkInDate) + "Between " + Convert.ToString(status.WalkInTime);
                status.RepairStatus = _context.RepairStatuses.Find(4);
                status.RequestDateTime = walkInRequest.WalkInDate;
                status.UserId = walkInRequest.UserId;
                status.ApprovalOfCharge = _context.CApprovalMessages.Find(walkInRequest.CApprovalMessagesId).CMessages;
                //status.StatusId = 1;
                _context.DeviceStatusesWalkIns.Add(status);
                _context.SaveChanges();
                WalkInSendEmail(walkInRequest, status);

                return RedirectToAction(nameof(Index));
            }
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages", walkInRequest.ApprovalMessagesId);
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CApprovalMessages", walkInRequest.CApprovalMessagesId);
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name", walkInRequest.ColourId);
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceProblemId", "Description", walkInRequest.DeviceDescriptionId);
            ViewData["DeviceProblemId"] = new SelectList(_context.DeviceProblems, "DeviceProblemId", "DeviceProblemId", walkInRequest.DeviceProblemId);
            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatus, "PaymentStatusId", "Status", walkInRequest.PaymentStatusId);
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity", walkInRequest.StorageId);
            ViewData["WalkInTimesId"] = new SelectList(_context.WalkInTimes, "WalkInTimesId", "WalkInTime", walkInRequest.WalkInTimesId);
            return View(walkInRequest);
        }

        //method to send email 
        public void WalkInSendEmail(WalkInRequest walkInRequest, DeviceStatusWalkIns status)
        {
            var user = _context.Users.Find(walkInRequest.UserId);
            var email = User.FindFirstValue(ClaimTypes.Name);
            string message =
                $"Hi there, \n\n" +
                $" Thank You for choosing to repair your device with Shadrack Phone Repair, you have made a WalkIn Booking. Here are the details of the booking: \n\n" +
                $"Your Tracking Number is: {status.TrackingNumber} \n" +
                $"Your Request Number is: {walkInRequest.WalkInRequestId} \n" +
                $"Date of Booking is: {walkInRequest.WalkInDate} \n" +
                $"Time of Booking is: {walkInRequest.WalkInDate} \n" +
                $"Here are the details of the Device to be repaired: \n\n" +
                $"Your Device Brand is: {walkInRequest.BrandName} \n" +
                $"Your Device Name is: {walkInRequest.DeviceDescription.DeviceName} \n" +
                $"Your Device Storage is: {_context.Storage.Find(walkInRequest.StorageId).StorageCapacity} \n" +
                $"Colour Of Device is: { _context.Colours.Find(walkInRequest.ColourId).Name} \n" +
                $"Device IMEI Number is: {walkInRequest.IMEI} \n" +
                $"Problem with device: {_context.DeviceProblems.Find(walkInRequest.DeviceProblemId).Description} \n" +
                
                $"Looking foward to seeing you, please check dashboard for status of repair and for the estimated charge of repair \n\n" +
                $"Kind Regards";

            // Sendemail
            var senderEmail = new MailAddress("shadrachphonerepair@gmail.com", "Sharac Phone Repair Tech");
            var recieverMail = new MailAddress(email, "Client");
            var password = "Aigdloves2Nar1";
            var sub = $"New Request #{walkInRequest.WalkInRequestId}";
            var body = message;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                // EnableSsl = false,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, recieverMail)
            {
                Subject = sub,
                Body = body
            })
            {
                smtp.Send(mess);
            }
        }

        // GET: WalkInRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walkInRequest = await _context.WalkInRequests.FindAsync(id);
            if (walkInRequest == null)
            {
                return NotFound();
            }
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages", walkInRequest.ApprovalMessagesId);
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CApprovalMessages", walkInRequest.CApprovalMessagesId);
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name", walkInRequest.ColourId);
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceProblemId", "Description", walkInRequest.DeviceDescriptionId);
            ViewData["DeviceProblemId"] = new SelectList(_context.DeviceProblems, "DeviceProblemId", "DeviceProblemId", walkInRequest.DeviceProblemId);
            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatus, "PaymentStatusId", "Status", walkInRequest.PaymentStatusId);
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity", walkInRequest.StorageId);
            ViewData["WalkInTimesId"] = new SelectList(_context.WalkInTimes, "WalkInTimesId", "WalkInTime", walkInRequest.WalkInTimesId);
            return View(walkInRequest);
        }

        // POST: WalkInRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WalkInRequestId,BrandName,DeviceProblemId,DeviceDescriptionId,StorageId,ColourId,IMEI,WalkInDate,WalkInTimesId,Price,UserId,CApprovalMessagesId,ApprovalMessagesId,UserEmail")] WalkInRequest walkInRequest)
        {
            if (id != walkInRequest.WalkInRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(walkInRequest);
                    await _context.SaveChangesAsync();

                    DeviceStatusWalkIns status = new DeviceStatusWalkIns();
                    if (User.Identity.IsAuthenticated)
                    {
                        status.ApprovalOfCharge = _context.CApprovalMessages.Find(walkInRequest.CApprovalMessagesId).CMessages;
                        _context.DeviceStatusesWalkIns.Add(status);
                        _context.SaveChanges();

                        if ((walkInRequest.CApprovalMessagesId == 3))
                        {
                            TSendEmail(walkInRequest, status);
                        }
                        else if (User.IsInRole("Customer"))
                        {
                            status.ApprovalOfCharge = _context.CApprovalMessages.Find(walkInRequest.CApprovalMessagesId).CMessages;
                            _context.DeviceStatusesWalkIns.Add(status);
                            _context.SaveChanges();

                            if ((walkInRequest.CApprovalMessagesId == 2) && (walkInRequest.CApprovalMessagesId == 2))
                            {
                                ASendEmail(walkInRequest, status);
                            }
                            else if ((walkInRequest.CApprovalMessagesId == 3) && (walkInRequest.CApprovalMessagesId == 3))
                            {
                                DSendEmail(walkInRequest, status);
                            }
                        }
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalkInRequestExists(walkInRequest.WalkInRequestId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages", walkInRequest.ApprovalMessagesId);
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CApprovalMessages", walkInRequest.CApprovalMessagesId);
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name", walkInRequest.ColourId);
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceProblemId", "Description", walkInRequest.DeviceDescriptionId);
            ViewData["DeviceProblemId"] = new SelectList(_context.DeviceProblems, "DeviceProblemId", "DeviceProblemId", walkInRequest.DeviceProblemId);
            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatus, "PaymentStatusId", "Status", walkInRequest.PaymentStatusId);
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity", walkInRequest.StorageId);
            ViewData["WalkInTimesId"] = new SelectList(_context.WalkInTimes, "WalkInTimesId", "WalkInTime", walkInRequest.WalkInTimesId);
            return View(walkInRequest);
        }

        //method to Approving send email 
        public void ASendEmail(WalkInRequest walkInRequest, DeviceStatusWalkIns status)
        {
            var user = _context.Users.Find(walkInRequest.UserId);
            var email = User.FindFirstValue(ClaimTypes.Name);
            string message =
                 $"Hi there, \n\n" +
                $"Your Tracking Number is: {status.TrackingNumber} \n" +
                $"Your Request Number is: {walkInRequest.WalkInRequestId} \n" +
                $"Date of Booking is: {walkInRequest.WalkInDate} \n" +
                $"Time of Booking is: {walkInRequest.WalkInDate} \n" +
                $"Here are the details of the Device to be repaired: \n\n" +
                $"Your Device Brand is: {walkInRequest.BrandName} \n" +
                $"Your Device Name is: {walkInRequest.DeviceDescription.DeviceName} \n" +
                $"Your Device Storage is: {_context.Storage.Find(walkInRequest.StorageId).StorageCapacity} \n" +
                $"Colour Of Device is: { _context.Colours.Find(walkInRequest.ColourId).Name} \n" +
                $"Device IMEI Number is: {walkInRequest.IMEI} \n" +
                $"Problem with device: {_context.DeviceProblems.Find(walkInRequest.DeviceProblemId).Description} \n" +
                $"Price of repair R: {walkInRequest.Price} \n\n" +
                $"Estimated Charge of Repair  : {walkInRequest.CApprovalMessages} \n\n" +
                $"The Driver is on the way to pick up your device, please check dashboard for status of repair \n\n" +
                $"Kind Regards";

            // Sendemail
            var senderEmail = new MailAddress("shadrachphonerepair@gmail.com", "Sharac Phone Repair Tech");
            var recieverMail = new MailAddress(email, "Client");
            var password = "Aigdloves2Nar1";
            var sub = $"New Request #{walkInRequest.WalkInRequestId}";
            var body = message;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                //  EnableSsl = false,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, recieverMail)
            {
                Subject = sub,
                Body = body
            })
            {
                smtp.Send(mess);
            }
        }

        //method to Declining send email 
        public void DSendEmail(WalkInRequest walkInRequest, DeviceStatusWalkIns status)
        {
            var user = _context.Users.Find(walkInRequest.UserId);
            var email = User.FindFirstValue(ClaimTypes.Name);
            string message =
                $"Hi there, \n\n" +
                $"You have Declined the charge for the repair of your device, the Repair Request has been termenated. Here are the details: \n\n" +
                $"Your Tracking Number is: {status.TrackingNumber} \n" +
                $"Your Request Number is: {walkInRequest.WalkInRequestId} \n" +
                $"Date of Booking is: {walkInRequest.WalkInDate} \n" +
                $"Time of Booking is: {walkInRequest.WalkInDate} \n" +
                $"Here are the details of the Device to be repaired: \n\n" +
                $"Your Device Brand is: {walkInRequest.BrandName} \n" +
                $"Your Device Name is: {walkInRequest.DeviceDescription.DeviceName} \n" +
                $"Your Device Storage is: {_context.Storage.Find(walkInRequest.StorageId).StorageCapacity} \n" +
                $"Colour Of Device is: { _context.Colours.Find(walkInRequest.ColourId).Name} \n" +
                $"Device IMEI Number is: {walkInRequest.IMEI} \n" +
                $"Problem with device: {_context.DeviceProblems.Find(walkInRequest.DeviceProblemId).Description} \n" +
                $"Price of repair R: {walkInRequest.Price} \n\n" +
                $"Estimated Charge of Repair  : {walkInRequest.CApprovalMessages} \n\n" +
                $"Create a new request if you would like, your device to be repaired  \n\n" +
                $"Kind Regards";

            // Sendemail
            var senderEmail = new MailAddress("shadrachphonerepair@gmail.com", "Sharac Phone Repair Tech");
            var recieverMail = new MailAddress(email, "Client");
            var password = "Aigdloves2Nar1";
            var sub = $"New Request #{walkInRequest.WalkInRequestId}";
            var body = message;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                // EnableSsl = false,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, recieverMail)
            {
                Subject = sub,
                Body = body
            })
            {
                smtp.Send(mess);
            }
        }

        //method to Tecnician send email 
        public void TSendEmail(WalkInRequest walkInRequest, DeviceStatusWalkIns status)
        {
            var user = _context.Users.Find(walkInRequest.UserId);
            var email = User.FindFirstValue(ClaimTypes.Name);
            string message =
                $"Hi there, \n\n" +
                $"Sorry your request of repair has been declined has we dont have the matreial to proceed with the repair therefor,  the Repair Request has been termenated. Here are the details: \n\n" +
                $"Your Tracking Number is: {status.TrackingNumber} \n" +
                $"Your Request Number is: {walkInRequest.WalkInRequestId} \n" +
                $"Date of Booking is: {walkInRequest.WalkInDate} \n" +
                $"Time of Booking is: {walkInRequest.WalkInDate} \n" +
                $"Here are the details of the Device to be repaired: \n\n" +
                $"Your Device Brand is: {walkInRequest.BrandName} \n" +
                $"Your Device Name is: {walkInRequest.DeviceDescription.DeviceName} \n" +
                $"Your Device Storage is: {_context.Storage.Find(walkInRequest.StorageId).StorageCapacity} \n" +
                $"Colour Of Device is: { _context.Colours.Find(walkInRequest.ColourId).Name} \n" +
                $"Device IMEI Number is: {walkInRequest.IMEI} \n" +
                $"Problem with device: {_context.DeviceProblems.Find(walkInRequest.DeviceProblemId).Description} \n" +
                $"Price of repair R: {walkInRequest.Price} \n\n" +
                $"Estimated Charge of Repair  : {walkInRequest.CApprovalMessages} \n\n" +
                $"We will be able to repair this kinds of device soon  \n\n" +
                $"Kind Regards";

            // Sendemail
            var senderEmail = new MailAddress("shadrachphonerepair@gmail.com", "Sharac Phone Repair Tech");
            var recieverMail = new MailAddress(email, "Client");
            var password = "Aigdloves2Nar1";
            var sub = $"New Request #{walkInRequest.WalkInRequestId}";
            var body = message;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                //  EnableSsl = false,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, recieverMail)
            {
                Subject = sub,
                Body = body
            })
            {
                smtp.Send(mess);
            }
        }



        // GET: WalkInRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walkInRequest = await _context.WalkInRequests
                .Include(w => w.ApprovalMessages)
                .Include(w => w.CApprovalMessages)
                .Include(w => w.Colour)
                .Include(w => w.DeviceDescription)
                .Include(w => w.DeviceProblem)
                .Include(r => r.PaymentStatus)
                .Include(w => w.Storage)
                .Include(w => w.WalkInTimes)
                .FirstOrDefaultAsync(m => m.WalkInRequestId == id);
            if (walkInRequest == null)
            {
                return NotFound();
            }

            return View(walkInRequest);
        }

        // POST: WalkInRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var walkInRequest = await _context.WalkInRequests.FindAsync(id);
            _context.WalkInRequests.Remove(walkInRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WalkInRequestExists(int id)
        {
            return _context.WalkInRequests.Any(e => e.WalkInRequestId == id);
        }
    }
}
