namespace ninja_manager.Models
{
    public class ShopModelView
    {
        public int NinjaId { get; set; }

        public string StandardCategorie { get; set; }

        public List <Categorie> Categories { get; set; }

        public List<Equipment> Equipments { get; set; }
    }
}
