namespace Assign_3
{
    public class ActiveDekalb
    {
        //input data for Deklab and Sycamore 
        private const string DekalbPersonFile = "../../Dekalb/p.txt";
        private const string DekalbHouseFile = "../../Dekalb/r.txt";
        private const string DekalbApartmentFile = "../../Dekalb/a.txt";

        //set the comunity to active
        public Community ActiveDekalb_Files()
        {
            ActiveCommunity active = new ActiveCommunity();
            return active.Active_Files(DekalbPersonFile, DekalbHouseFile, DekalbApartmentFile, "Dekalb");
        }
    }
}