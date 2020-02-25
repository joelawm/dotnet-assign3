using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_3
{
    class residentialInfo
    {
        public string StreetAddr { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public double distance { get; set; }
        public bool? AttachedGarage { get; set; }
        public string FullName { get; set; }
        public bool Garage { get; set; }
        public uint Bed { get; set; }
        public uint Bath { get; set; }
        public uint Sqft { get; set; }
        public uint Flood { get; set; }
        public string ForSale { get; set; }
        public bool proType { get; set; }
        public string apt { get; set; }
    }

    //testing may not need this
    class residentialOOT
    {
        public string StreetAddr { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public double distance { get; set; }
        public bool? AttachedGarage { get; set; }
        public string FullName { get; set; }
        public bool Garage { get; set; }
        public uint Bed { get; set; }
        public uint Bath { get; set; }
        public uint Sqft { get; set; }
        public uint Flood { get; set; }
        public string ForSale { get; set; }
        public bool proType { get; set; }
        public string apt { get; set; }
        public uint[] Residencelds { get; set; }
        public string Name { get; set; }
        public string YearBuild { get; set; }
        public BusinessType Type { get; set; }
    }
}
