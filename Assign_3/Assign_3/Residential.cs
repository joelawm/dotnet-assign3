using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_3
{
    //residential class
    public class Residential : Property
    {
        //variables
        private uint bedrooms;
        private uint baths;
        private uint sqft;

        //creating the residential object
        protected Residential(uint id, uint x, uint y, uint o,
            string sa, string c, string st, string z, string fs, uint bedroom, uint bath, uint sq)
            : base(id, x, y, o, sa, c, st, z, fs)
        {
            Bedrooms = bedroom;
            Baths = bath;
            Sqft = sq;
        }


        //all the GET/SET methods for The class.
        public uint Bedrooms
        {
            get => bedrooms;
            set => bedrooms = value;
        }

        public uint Baths
        {
            get => baths;
            set => baths = value;
        }

        public uint Sqft
        {
            get => sqft;
            set => sqft = value;
        }
    }


    //House class which is based off the Residential class but with a few added variables
    class House : Residential
    {
        //variables added over the residential
        private bool garage;
        private bool? attatchedGarage;
        private uint flood;

        //creating the residential house object
        public House(uint id, uint x, uint y, uint o, string sa, string c,
            string st, string z, string fs, uint bedroom, uint bath, uint sq,
            bool gar, bool aGar, uint fl)
            : base(id, x, y, o, sa, c, st, z, fs, bedroom, bath, sq)
        {
            AttatchedGarage = null;
            Garage = gar;
            AttatchedGarage = aGar;
            Flood = fl;
        }

        //These are the GET/Set methods for the Hosue class
        public bool Garage
        {
            get => garage;
            set => garage = value;
        }

        public uint Flood
        {
            get => flood;
            set => flood = value;
        }

        public bool? AttatchedGarage
        {
            get => attatchedGarage;
            set => attatchedGarage = value;
        }
    }

    //Apartment class based off the Residential class
    public class Apartment : Residential
    {
        //variables
        private string unit;

        //Apartment creating object
        public Apartment(uint id, uint x, uint y, uint o, string sa, string c,
            string st, string z, string fs, uint bedroom, uint bath, uint sq, string u)
            : base(id, x, y, o, sa, c, st, z, fs, bedroom, bath, sq)
        {
            Unit = u;
        }


        //GET/SET for Apartment
        public string Unit
        {
            get => unit;
            set => unit = value;
        }
    }
}
