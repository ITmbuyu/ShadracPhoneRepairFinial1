using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
    public class RequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public RequestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var applicationDbContext = _context.Requests.Include(r => r.ApprovalMessages).Include(r => r.CApprovalMessages).Include(r => r.Colour).Include(r => r.DeviceDescription).Include(r => r.DeviceProblem).Include(r => r.PaymentStatus).Include(r => r.Storage);
            if (User.IsInRole("Customer"))
            {
                //deviceStatuses = db.DeviceStatuses.Include(d => d.RepairStatus).Where(x => x.UserId == userId);
                return View(_context.Requests.Where(x => x.UserId == userId).ToList());
            }
            return View(await applicationDbContext.ToListAsync());

            ///



            //var applicationDbContext = _context.Requests.Include(r => r.ApprovalMessages).Include(r => r.CApprovalMessages).Include(r => r.Colour).Include(r => r.DeviceDescription).Include(r => r.DeviceProblem).Include(r => r.PaymentStatus).Include(r => r.Storage);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.ApprovalMessages)
                .Include(r => r.CApprovalMessages)
                .Include(r => r.Colour)
                .Include(r => r.DeviceDescription)
                .Include(r => r.DeviceProblem)
                .Include(r => r.PaymentStatus)
                .Include(r => r.Storage)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Requests/Create
        public IActionResult Create()
        {
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages");
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CMessages");
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name");
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceDescriptionId", "DeviceName");
            ViewData["DeviceProblemId"] = new SelectList(_context.DeviceProblems, "DeviceProblemId", "Description");
            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatus, "PaymentStatusId", "Status");
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId,BrandName,DeviceProblemId,DeviceDescriptionId,StorageId,ColourId,IMEI,Price,RequestDateTime,UserId,PaymentStatusId,CApprovalMessagesId,ApprovalMessagesId,UserEmail")] Request request)
        {
            var brandid = (from ds in _context.DeviceDescriptions where ds.DeviceDescriptionId == request.DeviceDescriptionId select ds.BrandId).FirstOrDefault();
            var brandname = (from b in _context.Brands where b.BrandId == brandid select b.BrandName).FirstOrDefault();
            var deviceproblemid = (from ds in _context.DeviceProblems where ds.DeviceProblemId == request.DeviceProblemId select ds.DeviceProblemId).FirstOrDefault();
            var deviceproblem = (from b in _context.DeviceProblems where b.DeviceProblemId == deviceproblemid select b.Description).FirstOrDefault();
            var devicestorageid = (from ds in _context.Storage where ds.StorageId == request.StorageId select ds.StorageId).FirstOrDefault();
            var devicestorage = (from b in _context.Storage where b.StorageId == devicestorageid select b.StorageCapacity).FirstOrDefault();
            var devicecolorid = (from ds in _context.Colours where ds.ColourId == request.ColourId select ds.ColourId).FirstOrDefault();
            var devicecolor = (from b in _context.Colours where b.ColourId == devicecolorid select b.Name).FirstOrDefault();
            var devicename = (from b in _context.DeviceDescriptions where b.DeviceDescriptionId == brandid select b.DeviceName).FirstOrDefault();
            if (ModelState.IsValid)
            {

                // request.BrandName = _context.DeviceDescriptions.Find(request.DeviceDescriptionId).Brand.BrandName;
                request.BrandName = brandname;
                request.DeviceColors = devicecolor;
                request.DeviceProblems = deviceproblem;
                request.DeviceCapacity = devicestorage;
                request.DeviceNames = devicename;
                request.RequestDateTime = DateTime.Now;
                request.UserEmail = User.Identity.Name;
                request.Price = 0;
                request.PaymentStatus = _context.PaymentStatus.Find(1);
                request.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                request.ApprovalMessages = _context.ApprovalMessages.Find(1);
                request.CApprovalMessages = _context.CApprovalMessages.Find(1);
                _context.Add(request);
                await _context.SaveChangesAsync();

                DeviceStatus status = new DeviceStatus();
                status.TrackingNumber = "STR" + Convert.ToString(request.RequestId);
                status.Brand = request.BrandName;
                //status.DeviceProblem = _context.DeviceProblems.Find(request.DeviceProblemId).Description;//request.DeviceProblem.Description;
                status.DeviceProblem = deviceproblem;
                //status.DeviceName = request.DeviceDescription.DeviceName;
                status.DeviceName = devicename;
                //variable name=  databaseinstance.find(primarykeyofrespectivetable).itemlookingfor
                //status.Capacity = _context.Storage.Find(request.StorageId).StorageCapacity;
                status.Capacity = devicestorage;
                //status.Colour = _context.Colours.Find(request.ColourId).Name;
                status.Colour = devicecolor;
                status.IMEI = request.IMEI;
                status.Price = request.Price;
                status.PaymentStatus = _context.PaymentStatus.Find(request.PaymentStatusId).Status;
                status.RepairStatus = _context.RepairStatuses.Find(1);
                status.RequestDateTime = request.RequestDateTime;
                status.UserId = request.UserId;
                status.ApprovalOfCharge = _context.CApprovalMessages.Find(request.CApprovalMessagesId).CMessages;
                status.ApprovalOfRequest = _context.ApprovalMessages.Find(request.ApprovalMessagesId).AMessages;
                //status.StatusId = 1;
                _context.DeviceStatuses.Add(status);
                await _context.SaveChangesAsync();
                SendEmail(request, status);
                return RedirectToAction("details", new { id = request.RequestId });
            }
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages", request.ApprovalMessagesId);
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CMessages", request.CApprovalMessagesId);
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name", request.ColourId);
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceDescriptionId", "DeviceName", request.DeviceDescriptionId);
            ViewData["DeviceProblemId"] = new SelectList(_context.DeviceProblems, "DeviceProblemId", "Description", request.DeviceProblemId);
            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatus, "PaymentStatusId", "Status", request.PaymentStatusId);
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity", request.StorageId);
            return View(request);
        }

        //method to send email 
        public void SendEmail(Request request, DeviceStatus status)
        {
            var user = _context.Users.Find(request.UserId);
            var email = User.FindFirstValue(ClaimTypes.Name);
            string message =
                $"Hi there, \n\n" +
                $"You have made a request with Shadrack Phone Repair. Here are the details: \n\n" +
                $"Your Tracking Number is: {status.TrackingNumber} \n" +
                $"Your Request Number is: {request.RequestId} \n" +
                $"Your Device Brand is: {request.BrandName} \n" +
                $"Your Device Name is: {request.DeviceNames} \n" +
                $"Your Device Storage is: {request.DeviceCapacity} \n" +
                $"Colour Of Device is: { request.DeviceColors} \n" +
                $"Device IMEI Number is: {request.IMEI} \n" +
                $"Problem with device: {request.DeviceProblems} \n" +
                $"Price of repair R: {request.Price} \n\n" +
                $"Please check dashboard for status of repair and to see qotation. Please apporove or reject qoutation \n\n" +
                $"Kind Regards";

            // Sendemail
            var senderEmail = new MailAddress("shadrachphonerepair@gmail.com", "Sharac Phone Repair Tech");
            var recieverMail = new MailAddress(email, "Client");
            var password = "Aigdloves2Nar1";
            var sub = $"New Request #{request.RequestId}";
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



        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages", request.ApprovalMessagesId);
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CMessages", request.CApprovalMessagesId);
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name", request.ColourId);
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceDescriptionId", "DeviceName", request.DeviceDescriptionId);
            ViewData["DeviceProblemId"] = new SelectList(_context.DeviceProblems, "DeviceProblemId", "Description", request.DeviceProblemId);
            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatus, "PaymentStatusId", "Status", request.PaymentStatusId);
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity", request.StorageId);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestId,BrandName,DeviceProblemId,DeviceDescriptionId,StorageId,ColourId,IMEI,Price,RequestDateTime,UserId,PaymentStatusId,CApprovalMessagesId,ApprovalMessagesId,UserEmail")] Request request)
        {
            if (id != request.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                     _context.SaveChanges();
                    DeviceStatus status = new DeviceStatus();
                    if (User.Identity.IsAuthenticated)
                    {
                        if (User.IsInRole("Technician"))
                        {
                            status.ApprovalOfCharge = _context.CApprovalMessages.Find(request.CApprovalMessagesId).CMessages;
                            status.ApprovalOfRequest = _context.ApprovalMessages.Find(request.ApprovalMessagesId).AMessages;
                            _context.DeviceStatuses.Add(status) ;
                            _context.SaveChanges();

                            if ((request.CApprovalMessagesId == 3))
                            {
                                TSendEmail(request, status);
                            }
                        }
                        else if (User.IsInRole("Customer"))
                        {

                            status.ApprovalOfCharge = _context.CApprovalMessages.Find(request.CApprovalMessagesId).CMessages;
                            status.ApprovalOfRequest = _context.ApprovalMessages.Find(request.ApprovalMessagesId).AMessages;
                            _context.DeviceStatuses.Add(status);
                            _context.SaveChanges();

                            if ((request.CApprovalMessagesId == 2) && (request.CApprovalMessagesId == 2))
                            {
                                ASendEmail(request, status);
                            }
                            else if ((request.CApprovalMessagesId == 3) && (request.CApprovalMessagesId == 3))
                            {
                                DSendEmail(request, status);
                            }

                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestId))
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
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages", request.ApprovalMessagesId);
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CMessages", request.CApprovalMessagesId);
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name", request.ColourId);
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceDescriptionId", "DeviceName", request.DeviceDescriptionId);
            ViewData["DeviceProblemId"] = new SelectList(_context.DeviceProblems, "DeviceProblemId", "Description", request.DeviceProblemId);
            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatus, "PaymentStatusId", "Status", request.PaymentStatusId);
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity", request.StorageId);
            return View(request);
        }

        //method to Approving send email 
        public void ASendEmail(Request request, DeviceStatus status)
        {
            var user = _context.Users.Find(request.UserId);
            var email = User.FindFirstValue(ClaimTypes.Name);
            string message =
                 $"Hi there, \n\n" +
                $"You have accepted the charge for the repair of your device. Here are the details: \n\n" +
                $"Your Tracking Number is: {status.TrackingNumber} \n" +
                $"Your Request Number is: {request.RequestId} \n" +
                $"Your Device Brand is: {request.BrandName} \n" +
                $"Your Device Name is: {request.DeviceDescription.DeviceName} \n" +
                $"Your Device Storage is: {_context.Storage.Find(request.StorageId).StorageCapacity} \n" +
                $"Colour Of Device is: { _context.Colours.Find(request.ColourId).Name} \n" +
                $"Device IMEI Number is: {request.IMEI} \n" +
                $"Problem with device: {_context.DeviceProblems.Find(request.DeviceProblemId).Description} \n" +
                $"Price of repair R: {request.Price} \n\n" +
                $"State Of Repair: {request.ApprovalMessages} \n\n" +
                $"Estimated Charge of Repair  : {request.CApprovalMessages} \n\n" +
                $"The Driver is on the way to pick up your device, please check dashboard for status of repair \n\n" +
                $"Kind Regards";

            // Sendemail
            var senderEmail = new MailAddress("shadrachphonerepair@gmail.com", "Sharac Phone Repair Tech");
            var recieverMail = new MailAddress(email, "Client");
            var password = "Aigdloves2Nar1";
            var sub = $"New Request #{request.RequestId}";
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

        //method to Declining send email 
        public void DSendEmail(Request request, DeviceStatus status)
        {
            var user = _context.Users.Find(request.UserId);
            var email = User.FindFirstValue(ClaimTypes.Name);
            string message =
                $"Hi there, \n\n" +
                $"You have Declined the charge for the repair of your device, the Repair Request has been termenated. Here are the details: \n\n" +
                $"Your Tracking Number is: {status.TrackingNumber} \n" +
                $"Your Request Number is: {request.RequestId} \n" +
                $"Your Device Brand is: {request.BrandName} \n" +
                $"Your Device Name is: {request.DeviceDescription.DeviceName} \n" +
                $"Your Device Storage is: {_context.Storage.Find(request.StorageId).StorageCapacity} \n" +
                $"Colour Of Device is: { _context.Colours.Find(request.ColourId).Name} \n" +
                $"Device IMEI Number is: {request.IMEI} \n" +
                $"Problem with device: {_context.DeviceProblems.Find(request.DeviceProblemId).Description} \n" +
                $"Price of repair R: {request.Price} \n\n" +
                $"State Of Repair: {request.ApprovalMessages} \n\n" +
                $"Estimated Charge of Repair  : {request.CApprovalMessages} \n\n" +
                $"Create a new request if you would like, your device to be repaired  \n\n" +
                $"Kind Regards";

            // Sendemail
            var senderEmail = new MailAddress("shadrachphonerepair@gmail.com", "Sharac Phone Repair Tech");
            var recieverMail = new MailAddress(email, "Client");
            var password = "Aigdloves2Nar1";
            var sub = $"New Request #{request.RequestId}";
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
        public void TSendEmail(Request request, DeviceStatus status)
        {
            var user = _context.Users.Find(request.UserId);
            var email = User.FindFirstValue(ClaimTypes.Name);
            string message =
                $"Hi there, \n\n" +
                $"Sorry your request of repair has been declined has we dont have the matreial to proceed with the repair therefor,  the Repair Request has been termenated. Here are the details: \n\n" +
                $"Your Tracking Number is: {status.TrackingNumber} \n" +
                $"Your Request Number is: {request.RequestId} \n" +
                $"Your Device Brand is: {request.BrandName} \n" +
                $"Your Device Name is: {request.DeviceDescription.DeviceName} \n" +
                $"Your Device Storage is: {_context.Storage.Find(request.StorageId).StorageCapacity} \n" +
                $"Colour Of Device is: { _context.Colours.Find(request.ColourId).Name} \n" +
                $"Device IMEI Number is: {request.IMEI} \n" +
                $"Problem with device: {_context.DeviceProblems.Find(request.DeviceProblemId).Description} \n" +
                $"Price of repair R: {request.Price} \n\n" +
                $"State Of Repair: {request.ApprovalMessages} \n\n" +
                $"Estimated Charge of Repair  : {request.CApprovalMessages} \n\n" +
                $"We will be able to repair this kinds of device soon  \n\n" +
                $"Kind Regards";

            // Sendemail
            var senderEmail = new MailAddress("shadrachphonerepair@gmail.com", "Sharac Phone Repair Tech");
            var recieverMail = new MailAddress(email, "Client");
            var password = "Aigdloves2Nar1";
            var sub = $"New Request #{request.RequestId}";
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

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.ApprovalMessages)
                .Include(r => r.CApprovalMessages)
                .Include(r => r.Colour)
                .Include(r => r.DeviceDescription)
                .Include(r => r.DeviceProblem)
                .Include(r => r.PaymentStatus)
                .Include(r => r.Storage)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.RequestId == id);
        }
    }
}
