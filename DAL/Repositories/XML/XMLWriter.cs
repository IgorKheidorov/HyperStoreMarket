using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.DAL.Interfaces;
using HyperStoreEntities.DAL.Repositories.XML.XMLEntities;
using System.Xml.Serialization;

namespace HyperStoreEntities.DAL.Repositories.XML;

internal class XMLWriter : IRepositoryWrite
{
    const string PRODUCTS_XML_PATH = "..\\..\\..\\Data\\products.xml";
    XmlSerializer _serializer = new XmlSerializer(typeof(List<XMLProduct>));

    public void SaveProducts(List<Product> products)
    {
        List<XMLProduct> readyToSerialize = products.Select(x => new XMLProduct { Name = x.Name, Price = x.Price }).ToList();
            
        using (FileStream fsRead = new FileStream(PRODUCTS_XML_PATH, FileMode.Create))
        {
            _serializer.Serialize(fsRead, readyToSerialize);
        }
    }
}
