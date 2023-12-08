using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.DAL.Interfaces;
using HyperStoreEntities.DAL.Repositories.XML.XMLEntities;
using System.Xml.Serialization;

namespace HyperStoreEntities.DAL.Repositories.XML;

public class XMLReader : IRepositoryRead
{
    const string PRODUCTS_XML_PATH = "..\\..\\..\\Data\\products.xml";
    XmlSerializer serializerReader = new XmlSerializer(typeof(List<XMLProduct>));

    public List<Product> GetProducts()
    {
        List<XMLProduct> deserializedList;
        using (FileStream fsRead = new FileStream(PRODUCTS_XML_PATH, FileMode.Open))
        {
            deserializedList = serializerReader.Deserialize(fsRead) as List<XMLProduct> ?? new List<XMLProduct>();
        }

        return deserializedList.Select( x => new Product(x.Name, x.Price)).ToList();
    }
}
