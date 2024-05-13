using Microsoft.AspNetCore.Mvc.Rendering;

namespace ninja_manager.Models
{
    public class EquipmentFormModel
    {
        public Equipment equipment { get; set; }
        public List<SelectListItem> categorieList { get; set;}
    }
}
