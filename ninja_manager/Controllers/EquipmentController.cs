using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ninja_manager.Models;

namespace ninja_manager.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly NinjaContext _context;

        public EquipmentController(NinjaContext context)
        {
            _context = context;
        }

        // index view
        public async Task<IActionResult> Index()
        {
            return _context.Equipments != null ?
                        View(await _context.Equipments.OrderBy(e => e.CategoryName).ToListAsync()) :
                        Problem("Entity set 'EquipmentContext.Equipment'  is null.");
        }

        [HttpPost]
        public IActionResult FilterEquipment(string selectedCategory)
        {
            var categories = _context.Categories.ToList();

            var filteredEquipments = _context.Equipments
                                    .Where(e => e.CategoryName == selectedCategory)
                                    .ToList();

            var equipment = new EquipmentViewModel
            {
                StandardCategorie = selectedCategory,
                Categories = categories,
                Equipments = filteredEquipments
            };

            return View("Index", equipment);
        }

        //details page
        public async Task<IActionResult> DetailsEquipmentView(int? id)
        {
            if (id == null || _context.Equipments == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        //equipment edit page
        public async Task<IActionResult> EditEquipmentView(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            var categories = await _context.Categories.ToListAsync();
            var equipmentFormModel = new EquipmentFormModel()
            {
                equipment = equipment,
                categorieList = categories.Select(c => new SelectListItem { Value = c.Name, Text = c.Name }).ToList()
            };
            return View(equipmentFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEquipmentView(int id, Equipment equipment)
        {
            if (id != equipment.Id)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(equipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(equipment.Id))
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

        //equipment create form page
        public async Task<IActionResult> EquipmentFormView()
        {
            var equipment = new Equipment();
            var categories = await _context.Categories.ToListAsync();
            var equipmentFormModel = new EquipmentFormModel()
            {
                equipment = equipment,
                categorieList = categories.Select(c => new SelectListItem { Value = c.Name, Text = c.Name }).ToList()
            };

            return View(equipmentFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EquipmentFormView(Equipment equipment)
        {
            _context.Add(equipment);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //equipment delete page
        public async Task<IActionResult> DeleteEquipmentView(int id)
        {
            var equipment = await _context.Equipments.FirstOrDefaultAsync(e => e.Id == id);

            return View(equipment);
        }

        [HttpPost, ActionName("DeleteEquipment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEquipmentViewConfirmed(int id)
        {
            var equipment = await _context.Equipments.FindAsync(id);

            var numberOfNinjas = await _context.Inventories.CountAsync(i => i.EquipmentId == id);

            if (numberOfNinjas != 0)
            {
                TempData["UnableToDeleteMessage"] = $"<strong>{numberOfNinjas} ninjas </strong> have <strong>{equipment.Name}</strong> equipped. Are you sure you want to delete this?";
                return RedirectToAction("DeleteEquipmentView", equipment);
            }

            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();

            TempData["DeletedEquipment"] = $"<strong>{equipment.Name}</strong> has been deleted";
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("ForceDeleteEquipment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForceDeleteEquipment(int id)
        {
            var equipment = await _context.Equipments.FindAsync(id);

            var relatedInventories = await _context.Inventories.Where(i => i.EquipmentId == id).ToListAsync();

            foreach (var inventory in relatedInventories)
            {
                var ninja = await _context.Ninjas.FindAsync(inventory.NinjaId);
                if (ninja != null)
                {
                    ninja.Gold += inventory.Gold;
                }

                _context.Inventories.Remove(inventory);
            }

            _context.Equipments.Remove(equipment);

            // Save all changes
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        //checks if the Equipment exsists in db
        private bool EquipmentExists(int id)
        {
            return (_context.Equipments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
