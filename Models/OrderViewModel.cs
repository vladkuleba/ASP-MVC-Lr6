namespace ASP_MVC_Lr6.Models
{
    public class OrderViewModel
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public int[] SelectedProductIds { get; set; }
    }
}
