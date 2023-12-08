using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.DAL.Interfaces;
using HyperStoreEntities.DAL.Repositories.XML.XMLEntities;
using System.Xml.Serialization;

namespace HyperStoreEntities.DAL.Repositories.XML;

internal class XMLCompressedWriter : IRepositoryWrite
{
    const string PRODUCTS_XML_PATH = "..\\..\\..\\Data\\compressed_products.xml";
    const string PRODUCTS_IDS_PATH = "..\\..\\..\\Data\\product_ids.txt";

    XmlSerializer _productSerializer = new XmlSerializer(typeof(List<CompressedProduct>));
    XmlSerializer _idSerializer = new XmlSerializer(typeof(List<int>));

    public XMLCompressedWriter()
    {
        _productSerializer = new XmlSerializer(typeof(List<CompressedProduct>));
        _idSerializer = new XmlSerializer(typeof(List<int>));
    }

    public XMLCompressedWriter(XmlSerializer productSerializer, XmlSerializer idSerializer)
    {
        _productSerializer = productSerializer;
        _idSerializer = idSerializer;
    }

    public void SaveProducts(List<Product> products)
    {
        int id = 0;

        var compressedProducts = products.Distinct().Select(x => new CompressedProduct { ID = id++, Name = x.Name, Price = x.Price }).ToList();

        using (FileStream fsWrite = new FileStream(PRODUCTS_XML_PATH, FileMode.Create))
        {
            _productSerializer.Serialize(fsWrite, compressedProducts);
        }

        string ids  = string.Join(",",products.Select(x => compressedProducts.Where(y => y.IsEqual(x)).First().ID.ToString()).ToArray());

        using (StreamWriter fsWrite = new StreamWriter(PRODUCTS_IDS_PATH,false))
        {
            fsWrite.WriteLine(ids);
            fsWrite.Flush();
        }

    }
}
