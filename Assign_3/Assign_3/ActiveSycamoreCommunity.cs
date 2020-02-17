namespace Assign_2
{
    class ActiveSycamore
    {
        //load sycamore files
        private const string SycamorePersonFile = "../../sp.txt";
        private const string SycamoreHouseFile = "../../sr.txt";
        private const string SycamoreApartmentFile = "../../sa.txt";

        //set community to active
        public Community ActiveSycamore_Files()
        {
            ActiveCommunity active = new ActiveCommunity();
            return active.Active_Files(SycamorePersonFile, SycamoreHouseFile, SycamoreApartmentFile, "Sycamore");
        }

    }
}
