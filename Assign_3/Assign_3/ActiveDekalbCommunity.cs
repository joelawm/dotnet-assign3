namespace Assign_3
{
    public class ActiveDekalb
    {
        //input data for Deklab and Sycamore 
        private const string DekalbPersonFile = "../../Dekalb/p.txt";
        private const string DekalbHouseFile = "../../Dekalb/r.txt";
        private const string DekalbApartmentFile = "../../Dekalb/a.txt";
        private const string DekalbBusinessFile = "../../Dekalb/b.txt";
        private const string DekalbSchoolFile = "../../Dekalb/s.txt";

        //set the comunity to active
        public Community ActiveDekalb_Files()
        {
            ActiveCommunity active = new ActiveCommunity();
            return active.Active_Files(DekalbPersonFile, DekalbHouseFile, DekalbApartmentFile, DekalbBusinessFile, DekalbSchoolFile, "Dekalb");
        }
    }
}