namespace ninja_manager.Models
{
    public partial class Categorie
    {
        public string Name { get; set; } = null!;

        public virtual ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}
