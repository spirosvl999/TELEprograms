using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Final.Models;

namespace MVC_Final.Controllers
{
    public class BillsCallsController : Controller
    {
        private readonly LabDBContext _context;

        public BillsCallsController(LabDBContext context)
        {
            _context = context;
        }

        // GET: BillsCalls
        public async Task<IActionResult> Index()
        {
            var labDBContext = _context.BillsCalls.Include(b => b.Bill).Include(b => b.Call);
            return View(await labDBContext.ToListAsync());
        }

        // GET: BillsCalls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billsCall = await _context.BillsCalls
                .Include(b => b.Bill)
                .Include(b => b.Call)
                .FirstOrDefaultAsync(m => m.BillId == id);
            if (billsCall == null)
            {
                return NotFound();
            }

            return View(billsCall);
        }

        // GET: BillsCalls/Create
        public IActionResult Create()
        {
            ViewData["BillId"] = new SelectList(_context.Bills, "BillId", "BillId");
            ViewData["CallId"] = new SelectList(_context.Calls, "CallId", "CallId");
            return View();
        }

        // POST: BillsCalls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BillId,CallId")] BillsCall billsCall)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billsCall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BillId"] = new SelectList(_context.Bills, "BillId", "BillId", billsCall.BillId);
            ViewData["CallId"] = new SelectList(_context.Calls, "CallId", "CallId", billsCall.CallId);
            return View(billsCall);
        }

        // GET: BillsCalls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billsCall = await _context.BillsCalls.FindAsync(id);
            if (billsCall == null)
            {
                return NotFound();
            }
            ViewData["BillId"] = new SelectList(_context.Bills, "BillId", "BillId", billsCall.BillId);
            ViewData["CallId"] = new SelectList(_context.Calls, "CallId", "CallId", billsCall.CallId);
            return View(billsCall);
        }

        // POST: BillsCalls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BillId,CallId")] BillsCall billsCall)
        {
            if (id != billsCall.BillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billsCall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillsCallExists(billsCall.BillId))
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
            ViewData["BillId"] = new SelectList(_context.Bills, "BillId", "BillId", billsCall.BillId);
            ViewData["CallId"] = new SelectList(_context.Calls, "CallId", "CallId", billsCall.CallId);
            return View(billsCall);
        }

        // GET: BillsCalls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billsCall = await _context.BillsCalls
                .Include(b => b.Bill)
                .Include(b => b.Call)
                .FirstOrDefaultAsync(m => m.BillId == id);
            if (billsCall == null)
            {
                return NotFound();
            }

            return View(billsCall);
        }

        // POST: BillsCalls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billsCall = await _context.BillsCalls.FindAsync(id);
            if (billsCall != null)
            {
                _context.BillsCalls.Remove(billsCall);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillsCallExists(int id)
        {
            return _context.BillsCalls.Any(e => e.BillId == id);
        }
    }
}
