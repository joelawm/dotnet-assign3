namespace Assign_2
{
    public class ActiveDekalb
    {
        //input data for Deklab and Sycamore 
        private const string DekalbPersonFile = "../../dp.txt";
        private const string DekalbHouseFile = "../../dr.txt";
        private const string DekalbApartmentFile = "../../da.txt";

        //set the comunity to active
        public Community ActiveDekalb_Files()
        {
            ActiveCommunity active = new ActiveCommunity();
            return active.Active_Files(DekalbPersonFile, DekalbHouseFile, DekalbApartmentFile, "Dekalb");
        }
    }
}