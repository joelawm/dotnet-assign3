using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_3
{
    class ActiveDekalb
    {
        //input data for Deklab and Sycamore 
        private const string DekalbPersonFile = "../../Dekalb/p.txt"; //Person text file
        private const string DekalbHouseFile = "../../Dekalb/r.txt"; //resident text file
        private const string DekalbApartmentFile = "../../Dekalb/a.txt"; //apartments text file
        private const string DekalbBusinessFile = "../../Dekalb/b.txt"; //buisness text file
        private const string DekalbSchoolFile = "../../Dekalb/s.txt"; //School text file

        //set the comunity to active
        public Community ActiveDekalb_Files()
        {
            ActiveCommunity active = new ActiveCommunity();
            return active.Active_Files(DekalbPersonFile, DekalbHouseFile, DekalbApartmentFile, DekalbBusinessFile, DekalbSchoolFile, "Dekalb");
        }
    }
}
