using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flat_agency_2
{
    [Serializable]
    public class Flat
    {
        public string Region { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int Rooms { get; set; }
        public int Floor { get; set; }

        public Flat() { }

        public Flat(string Region, string Address, decimal Price, int Rooms, int Floor)
        {
            this.Region = Region;
            this.Address = Address;
            this.Price = Price;
            this.Rooms = Rooms;
            this.Floor = Floor;
        }
    }
}
