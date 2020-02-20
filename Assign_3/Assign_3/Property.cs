using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_3
{
    public class Property : IComparable
    {
        //variables for class
        private readonly uint _id;
        private readonly uint _x;
        private readonly uint _y;

        private uint ownerID;
        private string streetAddr;
        private string city;
        private string state;
        private string zip;
        private string forSale;

        //Property Object
        protected Property()
        {
            Console.WriteLine("Property() are using...");
            _id = 0;
            _y = 0;
            _x = 0;
            ownerID = 0;
            streetAddr = "";
            city = "";
            state = "";
            zip = "";
            forSale = "";
        }

        //creating the Property Object
        public Property(uint id, uint x, uint y, uint o, string sa, string c, string st, string z, string fs)
        {
            _id = id;
            _x = x;
            _y = y;
            ownerID = o;
            streetAddr = sa;
            city = c;
            state = st;
            zip = z;
            forSale = fs;
        }


        //All of the GET/SET methods
        public uint OwnerId
        {
            get => ownerID;
            set => ownerID = value;
        }

        public string StreetAddr
        {
            get => streetAddr;
            set => streetAddr = value;
        }

        public string State
        {
            get => state;
            set => state = value;
        }

        public string City
        {
            get => city;
            set => city = value;
        }

        public string Zip
        {
            get => zip;
            set => zip = value;
        }

        public string ForSale
        {
            get => forSale;
            set => forSale = value;
        }

        public uint Id => _id;

        public uint X => _x;

        public uint Y => _y;

        //compare for the property
        public int CompareTo(object alpha)
        {
            if (alpha == null)
            {
                return 1;
            }

            Property otherP = alpha as Property;

            if (this.OwnerId == otherP.Id)
            {
                return 0;
            }

            var stateResult = this.state.CompareTo(otherP.State);
            if (stateResult != 0)
            {
                return stateResult;
            }

            var cityResult = this.city.CompareTo(otherP.city);
            if (cityResult != 0)
            {
                return cityResult;
            }

            var streetResult = this.StreetAddr.CompareTo(otherP.StreetAddr);
            if (streetResult != 0)
            {
                return streetResult;
            }

            return 1;
        }
    }
}
