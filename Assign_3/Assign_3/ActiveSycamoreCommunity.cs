using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_3
{
    class ActiveSycamore
    {
        //load sycamore files
        private const string SycamorePersonFile = "../../Sycamore/p.txt"; //person text file
        private const string SycamoreHouseFile = "../../Sycamore/r.txt"; //resident text file
        private const string SycamoreApartmentFile = "../../Sycamore/a.txt"; //apartment text file
        private const string SycamoreBusinessFile = "../../Sycamore/b.txt"; //buisness text file
        private const string SycamoreSchoolFile = "../../Sycamore/s.txt"; //school text file

        //set community to active
        public Community ActiveSycamore_Files()
        {
            ActiveCommunity active = new ActiveCommunity();
            return active.Active_Files(SycamorePersonFile, SycamoreHouseFile, SycamoreApartmentFile, SycamoreBusinessFile, SycamoreSchoolFile, "Sycamore");
        }
    }
}
