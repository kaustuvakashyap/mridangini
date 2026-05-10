namespace BackendMridangini.eShop.Core.Products.Entities;



public class Products
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public bool IsActive { get; set; } = true;

     public CategoryEnum TypeCategory { get; set; } // only lets to choose  specific categories
    public DateTime CreatedAtUtc { get; set; }

    public DateTime UpdatedAtUtc { get; set; }
}

public enum CategoryEnum
{
    Aerophone, //instruments played by blowing with mouth or synchronising the flow of air through it
    Membranophone, // Wooden or metallic shell covered with animal skin
    Audiphone, //intrument made of bamboo, metal, earth played by striking it
    Cordophone // Instruments played by striking the string or rubbing with a bow
}