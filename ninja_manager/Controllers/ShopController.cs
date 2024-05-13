using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ninja_manager.Models;

namespace ninja_manager.Controllers
{
    public class ShopController : Controller
    {
        private readonly NinjaContext _context;

        public ShopController(NinjaContext context)
        {
            _context = context;
        }

        public IActionResult Index(int ninjaId)
        {
            var categories = _context.Categories.ToList();

            var equipments = _context.Equipments.Where(e => e.CategoryName == categories[0].Name).ToList();

            var shop = new ShopModelView
            {
                NinjaId = ninjaId,
                StandardCategorie = categories[0].Name,
                Categories = categories,
                Equipments = equipments
            };

            return View(shop);
        }

        [HttpPost]
        public IActionResult FilterEquipment(int ninjaId, string selectedCategory)
        {
            var categories = _context.Categories.ToList();

            var filteredEquipments = _context.Equipments
                                    .Where(e => e.CategoryName == selectedCategory)
                                    .ToList();

            var shop = new ShopModelView
            {
                NinjaId = ninjaId,
                StandardCategorie = selectedCategory,
                Categories = categories,
                Equipments = filteredEquipments
            };

            return View("Index", shop);
        }

        public IActionResult BuyItem(int ninjaId, int equipmentId)
        {
            var ninja = _context.Ninjas.Find(ninjaId);
            var equipment = _context.Equipments.Find(equipmentId);

            var existingEquipment = _context.Inventories
                                .Where(i => i.NinjaId == ninjaId)
                                .Select(i => i.Equipment)
                                .Where(e => e.CategoryName == equipment.CategoryName)
                                .FirstOrDefault();

            if (existingEquipment != null)
            {
                TempData["DuplicateCategoryMessage"] = $"You already have an equipment in the <strong>{equipment.CategoryName}</strong> category.";
                return RedirectToAction("Index", new { ninjaId });
            }

            if (ninja.Gold >= equipment.Gold)
            {
                var newInventory = new Inventory
                {
                    NinjaId = ninjaId,
                    EquipmentId = equipmentId,
                    Gold = equipment.Gold
                };

                ninja.Gold -= equipment.Gold;

                _context.Inventories.Add(newInventory);
                _context.SaveChanges();

                TempData["BoughtItemMessage"] = $"You have bought <strong>{equipment.Name}</strong>.";
                return RedirectToAction("Index", new { ninjaId });
            }
            else
            {
                TempData["NotEnoughGoldMessage"] = $"You don't have enough gold to buy <strong>{equipment.Name}</strong>.";
                return RedirectToAction("Index", new { ninjaId });
            }
        }

        public IActionResult MyEquipment(int ninjaId)
        {
            var ninja = _context.Ninjas.Find(ninjaId);

            var equipmentList = _context.Inventories
                                        .Where(i => i.NinjaId == ninjaId)
                                        .Select(i => i.Equipment)
                                        .ToList();

            var inventoryRecords = _context.Inventories
                               .Where(i => i.NinjaId == ninjaId)
                               .ToList();

            foreach (var equipment in equipmentList)
            {
                var correspondingInventory = inventoryRecords.FirstOrDefault(i => i.EquipmentId == equipment.Id);
                if (correspondingInventory != null)
                {
                    equipment.Gold = correspondingInventory.Gold;
                }
            }


            var ninjaEquipmentviewModel = new NinjaEquipmentViewModel
            {
                NinjaId = ninjaId,
                Gold = ninja.Gold,
                EquipmentList = equipmentList.Count > 0 ? equipmentList : new List<Equipment>()
            };

            return View(ninjaEquipmentviewModel);
        }

        public IActionResult SellEquipmentView(int ninjaId, int equipmentId)
        {
            var ninja = _context.Ninjas.Find(ninjaId);
            var equipment = _context.Equipments.FirstOrDefault(e => e.Id == equipmentId);

            var inventoryRecords = _context.Inventories
                   .Where(i => i.NinjaId == ninjaId);

            var correspondingInventory = inventoryRecords.FirstOrDefault(i => i.EquipmentId == equipment.Id);

            equipment.Gold = correspondingInventory.Gold;

            var sellItemViewModel = new SellItemViewModel
            {
                Ninja = ninja,
                Equipment = equipment
            };

            return View(sellItemViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmSellEquipment(int ninjaId, int equipmentId)
        {
            var equipment = _context.Equipments.Where(e => e.Id == equipmentId).FirstOrDefault();

            var inventory = _context.Inventories
                                    .FirstOrDefault(i => i.NinjaId == ninjaId && i.EquipmentId == equipmentId);

            var ninja = _context.Ninjas.Find(ninjaId);

            ninja.Gold += inventory.Gold;

            _context.Inventories.Remove(inventory);
            _context.SaveChanges();

            TempData["SoldEquipment"] = $"{ninja.Name} has sold <strong>{equipment.Name}</strong> and <strong>{inventory.Gold} </strong> gold has been added back.";

            return RedirectToAction("MyEquipment", new { ninjaId });
        }
    }
}
