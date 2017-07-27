using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TelegramAlbionFarmAlert.Db.Model;

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

        public void AddTimer(string Island, string Culture)
        {
            _document.Root?.Element("Timers")?.Add(new XElement("Item",new XAttribute("Id",Guid.NewGuid()),new XAttribute("Island",Island),new XAttribute("Culture",Culture)));
        }
        
        public void AddIsland(string name)
        {
            _document.Root?.Element("Islands")?.Add(new XElement("Item", new XAttribute("Id", Guid.NewGuid()), new XAttribute("Name", name)));
        }

        public List<Island> GetIslands()
        {
            return _document.Root?.Element("Islands")?.Elements("Item").Select(x =>
                new Island(Guid.Parse(x.Attribute("Id").Value), x.Attribute("Name")?.Value)).ToList();
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
