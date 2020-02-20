namespace Assign_3
{
    class ActiveSycamore
    {
        //load sycamore files
        private const string SycamorePersonFile = "../../Sycamore/p.txt";
        private const string SycamoreHouseFile = "../../Sycamore/r.txt";
        private const string SycamoreApartmentFile = "../../Sycamore/a.txt";
        private const string SycamoreBusinessFile = "../../Sycamore/b.txt";
        private const string SycamoreSchoolFile = "../../Sycamore/s.txt";

        //set community to active
        public Community ActiveSycamore_Files()
        {
            ActiveCommunity active = new ActiveCommunity();
            return active.Active_Files(SycamorePersonFile, SycamoreHouseFile, SycamoreApartmentFile, SycamoreBusinessFile, SycamoreSchoolFile, "Sycamore");
        }

    }
}
