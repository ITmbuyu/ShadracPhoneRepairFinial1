using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShadracPhoneRepairFinial1.Data;
using ShadracPhoneRepairFinial1.Models;

namespace ShadracPhoneRepairFinial1.Controllers
{
    public class ApprovalMessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApprovalMessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApprovalMessages
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApprovalMessages.ToListAsync());
        }

        // GET: ApprovalMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approvalMessages = await _context.ApprovalMessages
                .FirstOrDefaultAsync(m => m.ApprovalMessagesId == id);
            if (approvalMessages == null)
            {
                return NotFound();
            }

            return View(approvalMessages);
        }

        // GET: ApprovalMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApprovalMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApprovalMessagesId,AMessages")] ApprovalMessages approvalMessages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(approvalMessages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(approvalMessages);
        }

        // GET: ApprovalMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approvalMessages = await _context.ApprovalMessages.FindAsync(id);
            if (approvalMessages == null)
            {
                return NotFound();
            }
            return View(approvalMessages);
        }

        // POST: ApprovalMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApprovalMessagesId,AMessages")] ApprovalMessages approvalMessages)
        {
            if (id != approvalMessages.ApprovalMessagesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(approvalMessages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApprovalMessagesExists(approvalMessages.ApprovalMessagesId))
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
            return View(approvalMessages);
        }

        // GET: ApprovalMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approvalMessages = await _context.ApprovalMessages
                .FirstOrDefaultAsync(m => m.ApprovalMessagesId == id);
            if (approvalMessages == null)
            {
                return NotFound();
            }

            return View(approvalMessages);
        }

        // POST: ApprovalMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var approvalMessages = await _context.ApprovalMessages.FindAsync(id);
            _context.ApprovalMessages.Remove(approvalMessages);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApprovalMessagesExists(int id)
        {
            return _context.ApprovalMessages.Any(e => e.ApprovalMessagesId == id);
        }
    }
}
