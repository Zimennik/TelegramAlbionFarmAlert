using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TelegramAlbionFarmAlert.Db
{
    public class XmlDbProvider : IDisposable
    {
        private readonly XDocument _document;
        private const string FileName = "./Db/AppData.xml";

        public XmlDbProvider()
        {
            _document = XDocument.Load(FileName);
        }

        public void AddIsland(string name)
        {
            _document.Root?.Element("Islands")?.Add(new XElement("Item", new XAttribute("Id", Guid.NewGuid()), new XAttribute("Name", name)));
        }

        public void SaveChanges()
        {
            _document.Save(FileName);
        }

        public void Dispose()
        {
            //todo
        }
    }
}
