using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ninja_manager.Models;
using NuGet.Packaging;

namespace ninja_manager.Controllers
{
    public class NinjaController : Controller
    {
        private readonly NinjaContext _context;

        public NinjaController(NinjaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Ninjas != null ?
                        View(await _context.Ninjas.ToListAsync()) :
                        Problem("Entity set 'NinjaContext.Ninjas'  is null.");
        }

        public IActionResult ShopView(int id)
        {
            var categories = _context.Categories.ToList();

            var shop = new ShopModelView
            {
                NinjaId = id,
                Categories = categories
            };

            return View(shop);
        }

        public IActionResult DetailsNinjaView(int ninjaId)
        {
            var ninja = _context.Ninjas.FirstOrDefault(n => n.Id == ninjaId);

            var ninjaWithEquipments = _context.Inventories
                                            .Where(i => i.NinjaId == ninjaId)
                                            .Select(i => i.Equipment)
                                            .OrderBy(e => e.CategoryName)
                                            .ToList();
            int totalStats = 0;
            double totalGearValue = 0.0;

            foreach (var stat in ninjaWithEquipments)
            {
                totalStats += stat.Strength;
                totalStats += stat.Agility;
                totalStats += stat.Intelligence;
                totalGearValue += stat.Gold;
            }

            string url = null;

            switch (totalStats)
            {
                case > 0 and < 100:
                    url = "~/images/ninja_lvl2.png";
                    break;
                case >= 100 and < 200:
                    url = "~/images/ninja_lvl3.png";
                    break;
                case >= 200 and < 300:
                    url = "~/images/ninja_lvl4.png";
                    break;
                case >= 300 and < 400:
                    url = "~/images/ninja_lvl5.png";
                    break;
                case >= 400 and < 500:
                    url = "~/images/ninja_lvl6.png";
                    break;
                case >= 500 and < 600:
                    url = "~/images/ninja_lvl7.png";
                    break;
                case >= 600 and < 700:
                    url = "~/images/ninja_lvl8.png";
                    break;
                case >= 700 and < 800:
                    url = "~/images/ninja_lvl9.png";
                    break;
                case >= 800:
                    url = "~/images/ninja_lvl10.png";
                    break;
                default:
                    url = "~/images/ninja_lvl1.png";
                    break;
            }

            if (ninjaWithEquipments.Count == 0)
            {
                var categorieNames = _context.Categories.Select(c => c.Name).ToList();

                var newEquipmentList = new List<Equipment>();
                foreach (var categoryName in categorieNames)
                {
                    var newEquipment = new Equipment
                    {
                        Name = "None",
                        CategoryName = categoryName,
                        Strength = 0,
                        Intelligence = 0,
                        Agility = 0,
                        Gold = 0
                    };

                    newEquipmentList.Add(newEquipment);
                }

                ninjaWithEquipments.AddRange(newEquipmentList);
            }

            var ninjaViewModel = new NinjaEquipmentViewModel
            {
                NinjaId = ninja.Id,
                NinjaName = ninja.Name,
                Gold = ninja.Gold,
                imageUrl = url,
                EquipmentList = ninjaWithEquipments
            };

            return View(ninjaViewModel);
        }


        //ninja edit page
        public async Task<IActionResult> EditNinjaView(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ninja = await _context.Ninjas.FindAsync(id);
            if (ninja == null)
            {
                return NotFound();
            }
            return View(ninja);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNinjaView(int id, Ninja ninja)
        {
            //check if it can find the ninja id
            if (id != ninja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ninja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NinjaExists(ninja.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(ninja);
        }

        //ninjaform page
        public IActionResult NinjaFormView()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NinjaFormView(Ninja ninja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ninja);
                _context.SaveChanges();

                TempData["AddNinjaMessage"] = $"<strong>{ninja.Name}</strong> has been added.";
                return RedirectToAction(nameof(Index));
            }

            return View(ninja);
        }

        //ninja delete page
        public async Task<IActionResult> DeleteNinjaView(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ninja = await _context.Ninjas.FindAsync(id);
            if (ninja == null)
            {
                return NotFound();
            }

            return View(ninja);
        }

        [HttpPost, ActionName("DeleteNinja")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteNinjaViewConfirmed(int id)
        {
            var ninja = await _context.Ninjas.Include(n => n.Inventories)
                                             .FirstOrDefaultAsync(n => n.Id == id);

            _context.Inventories.RemoveRange(ninja.Inventories);

            // Remove the ninja itself
            _context.Ninjas.Remove(ninja);

            await _context.SaveChangesAsync();

            TempData["DeletedNinjaMessage"] = $"<strong>{ninja.Name}</strong> has been deleted.";
            return RedirectToAction("Index");
        }


        //checks if the ninja exsists in db
        private bool NinjaExists(int id)
        {
            return (_context.Ninjas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
