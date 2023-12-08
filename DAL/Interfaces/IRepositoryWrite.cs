using FirstLanguageSampleMexico.MarkerEntities;

namespace HyperStoreEntities.DAL.Interfaces
{
    internal interface IRepositoryWrite
    {
        void SaveProducts(List<Product> products);

    }
}
