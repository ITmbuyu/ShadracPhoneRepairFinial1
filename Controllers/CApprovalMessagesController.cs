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
    public class CApprovalMessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CApprovalMessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CApprovalMessages
        public async Task<IActionResult> Index()
        {
            return View(await _context.CApprovalMessages.ToListAsync());
        }

        // GET: CApprovalMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cApprovalMessages = await _context.CApprovalMessages
                .FirstOrDefaultAsync(m => m.CApprovalMessagesId == id);
            if (cApprovalMessages == null)
            {
                return NotFound();
            }

            return View(cApprovalMessages);
        }

        // GET: CApprovalMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CApprovalMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CApprovalMessagesId,CMessages")] CApprovalMessages cApprovalMessages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cApprovalMessages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cApprovalMessages);
        }

        // GET: CApprovalMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cApprovalMessages = await _context.CApprovalMessages.FindAsync(id);
            if (cApprovalMessages == null)
            {
                return NotFound();
            }
            return View(cApprovalMessages);
        }

        // POST: CApprovalMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CApprovalMessagesId,CMessages")] CApprovalMessages cApprovalMessages)
        {
            if (id != cApprovalMessages.CApprovalMessagesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cApprovalMessages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CApprovalMessagesExists(cApprovalMessages.CApprovalMessagesId))
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
            return View(cApprovalMessages);
        }

        // GET: CApprovalMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cApprovalMessages = await _context.CApprovalMessages
                .FirstOrDefaultAsync(m => m.CApprovalMessagesId == id);
            if (cApprovalMessages == null)
            {
                return NotFound();
            }

            return View(cApprovalMessages);
        }

        // POST: CApprovalMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cApprovalMessages = await _context.CApprovalMessages.FindAsync(id);
            _context.CApprovalMessages.Remove(cApprovalMessages);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CApprovalMessagesExists(int id)
        {
            return _context.CApprovalMessages.Any(e => e.CApprovalMessagesId == id);
        }
    }
}
