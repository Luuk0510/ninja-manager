namespace ninja_manager.Models
{
    public partial class Inventory
    {
        public int NinjaId { get; set; }

        public int EquipmentId { get; set; }

        public double Gold { get; set; }

        public virtual Equipment Equipment { get; set; } = null!;

        public virtual Ninja Ninja { get; set; } = null!;
    }
}
