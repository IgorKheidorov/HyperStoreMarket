namespace FirstLanguageSampleMexico.MarkerEntities;

public class Product
{
    public string Name { get; set; }
    public float Price { get; set; }

    public Product(string name, float price)
    {
        Price = price;
        Name = name;
    }

    public override bool Equals(object? obj)
    {
        return (obj is Product product) ? product.Name == Name && product.Price == Price : false;
    }

    public override int GetHashCode()
    {
        return Name.Length ^ Price.GetHashCode();
    }

    public override string ToString()
    {
        return $"Product: {Name}, {Price}$";
    }

}
