namespace ninja_manager.Models
{
    public class NinjaEquipmentViewModel
    {
        public int NinjaId { get; set; }

        public string NinjaName { get; set; }

        public double Gold { get; set; }

        public string? imageUrl { get; set; }

        public List<Equipment> EquipmentList { get; set; }
    }
}
