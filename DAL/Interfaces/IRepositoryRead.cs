using FirstLanguageSampleMexico.MarkerEntities;

namespace HyperStoreEntities.DAL.Interfaces
{
    internal interface IRepositoryRead
    {
        List<Product> GetProducts();
    }
}
