using FirstLanguageSampleMexico.MarkerEntities;

namespace HyperStoreEntities.DAL.Repositories.XML.XMLEntities
{
    public class CompressedProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        
        #pragma warning disable CS8618
        public CompressedProduct() { }

        public Product GetProduct() => new Product(Name, Price);
        public bool IsEqual(Product product) => product.Name == Name && product.Price == Price;
    }
}
