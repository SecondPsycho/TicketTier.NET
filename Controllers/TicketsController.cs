using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketTier.Data;
using TicketTier.Models;

namespace TicketTier.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketTierContext _context;

        public TicketsController(TicketTierContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Ticket == null) {
                return Problem("Entity set 'TicketTierContext.Ticket'  is null.");
            }

            /*

            var tickets = await (from star in _context.Ticket select star).ToListAsync();

            if (!String.IsNullOrEmpty(searchString)) {
                //tickets = tickets.Where(ticket => ticket.Title!.Contains(searchString) || ticket.Description!.Contains(searchString));
                foreach (TicketTier.Models.Ticket ticket in tickets) {
                    if (!Search(ticket, searchString)) {
                        Console.WriteLine("Nothing.");
                    }
                }
            }
            return View(tickets);

            /*/
            var tickets = from star in _context.Ticket select star;

            if (!String.IsNullOrEmpty(searchString)) {
                tickets = tickets.Where(ticket => ticket.Title!.Contains(searchString) || ticket.Description!.Contains(searchString));
            }
            
            return View(await tickets.ToListAsync());
            //*/
        }

        private bool Search (TicketTier.Models.Ticket ticket, string searchString) {
            return ticket.Title!.Contains(searchString) || ticket.Description!.Contains(searchString);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ticket == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description")] Ticket ticket)
        {
            ticket.CreationDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ticket == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,CreationDate")] Ticket ticket)
        {
            if (id != ticket.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.ID))
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
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ticket == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ticket == null)
            {
                return Problem("Entity set 'TicketTierContext.Ticket'  is null.");
            }
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket != null)
            {
                _context.Ticket.Remove(ticket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
          return (_context.Ticket?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
