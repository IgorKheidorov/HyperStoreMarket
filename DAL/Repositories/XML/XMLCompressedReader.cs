using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.DAL.Interfaces;
using HyperStoreEntities.DAL.Repositories.XML.XMLEntities;
using System.Xml.Serialization;

namespace HyperStoreEntities.DAL.Repositories.XML;

public class XMLCompressedReader : IRepositoryRead
{
    const string PRODUCTS_XML_PATH = "..\\..\\..\\Data\\compressed_products.xml";
    const string PRODUCTS_IDS_PATH = "..\\..\\..\\Data\\product_ids.txt";

    XmlSerializer _productSerializer = new XmlSerializer(typeof(List<CompressedProduct>));
    XmlSerializer _idSerializer = new XmlSerializer(typeof(List<int>));

    public XMLCompressedReader()
    {
        _productSerializer = new XmlSerializer(typeof(List<CompressedProduct>));
        _idSerializer = new XmlSerializer(typeof(List<int>));
    }

    public XMLCompressedReader(XmlSerializer productSerializer, XmlSerializer idSerializer)
    {
        _productSerializer = productSerializer;
        _idSerializer = idSerializer;
    }

    public List<Product> GetProducts()
    {
        List<CompressedProduct> compressedProducts;

        using (FileStream fsRead = new FileStream(PRODUCTS_XML_PATH, FileMode.Open))
        {
            compressedProducts = _productSerializer.Deserialize(fsRead) as List<CompressedProduct> ?? new List<CompressedProduct>();            
        }

        List<int> idList;

        using (StreamReader fsWrite = new StreamReader(PRODUCTS_IDS_PATH))
        {
            string? ids = fsWrite.ReadLine();
            idList = ids?.Split(",").ToList().Select(x => int.Parse(x)).ToList() ?? new List<int>();
        }

        return idList.Select(x => compressedProducts.Where(y => y.ID == x).First().GetProduct()).ToList(); 

    }
}
