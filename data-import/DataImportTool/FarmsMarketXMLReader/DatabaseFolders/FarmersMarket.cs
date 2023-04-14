using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmsMarketXMLReader.DatabaseFolders
{
    public class FarmersMarket
    {
        public int id { get; set; }
        public bool isSnapFriendly { get; set; }
        public string name { get; set; }
        public ContactInfo contact { get; set; }

        public int contactId => contact.Id;
    }
}
