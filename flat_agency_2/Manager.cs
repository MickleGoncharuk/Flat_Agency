using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace flat_agency_2
{
    class Manager
    {
        public List<Flat> list;
        XmlSerializer xs;

        public Manager()
        {
            list = new List<Flat>();
            xs = new XmlSerializer(typeof(List<Flat>));
        }

        public void SaveData()
        {
            FileStream fs = new FileStream("data.xml", FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, list);
            fs.Close();
        }

        public void LoadData()
        {
            FileStream fs = new FileStream("data.xml", FileMode.Open, FileAccess.Read);
            list = (List<Flat>)xs.Deserialize(fs);
            fs.Close();
        }
    }
}
