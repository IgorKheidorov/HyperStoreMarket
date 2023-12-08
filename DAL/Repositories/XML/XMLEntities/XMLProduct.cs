using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperStoreEntities.DAL.Repositories.XML.XMLEntities
{
    public class XMLProduct
    {
        public string Name { get; set; }
        public float Price { get; set; }

        #pragma warning disable CS8618
        public XMLProduct() { }
    }
}
