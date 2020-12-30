using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskAuthenticationAuthorization.Models;

namespace TaskAuthenticationAuthorization.Controllers
{
    [Authorize(Roles = "admin")]
    public class SuperMarketsController : Controller
    {
        private readonly ShoppingContext _context;

        public SuperMarketsController(ShoppingContext context) => _context = context;

        [AllowAnonymous]
        public async Task<IActionResult> Index() => View(await _context.SuperMarkets.ToListAsync());

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superMarket = await _context.SuperMarkets.FirstOrDefaultAsync(m => m.ID == id);

            if (superMarket == null)
            {
                return NotFound();
            }

            return View(superMarket);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address")] SuperMarket superMarket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superMarket);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(superMarket);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superMarket = await _context.SuperMarkets.FindAsync(id);

            if (superMarket == null)
            {
                return NotFound();
            }

            return View(superMarket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address")] SuperMarket superMarket)
        {
            if (id != superMarket.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superMarket);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperMarketExists(superMarket.ID))
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

            return View(superMarket);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superMarket = await _context.SuperMarkets.FirstOrDefaultAsync(m => m.ID == id);

            if (superMarket == null)
            {
                return NotFound();
            }

            return View(superMarket);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var superMarket = await _context.SuperMarkets.FindAsync(id);

            _context.SuperMarkets.Remove(superMarket);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool SuperMarketExists(int id) => _context.SuperMarkets.Any(e => e.ID == id);
    }
}
