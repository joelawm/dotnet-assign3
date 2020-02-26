using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Assign_3
{
    public partial class Form1 : Form
    {
        public static Community DekalbCommunity;
        public static Community SycamoreCommunity;

        public Form1()
        {
            InitializeComponent();
            InitializeCommunity();
        }

        private void InitializeCommunity()
        {
            ActiveDekalb activeDekalb = new ActiveDekalb();
            DekalbCommunity = activeDekalb.ActiveDekalb_Files();

            ActiveSycamore activeSycamore = new ActiveSycamore();
            SycamoreCommunity = activeSycamore.ActiveSycamore_Files();

        }
        
        // Cleck forsale dropdown and show all the properties
        private void ForSaleCombobox_DropDown(object sender, EventArgs e)
        {
            ForSaleCombobox.Items.Clear();
            string[] propertyList = FindProperties(DekalbCommunity);
            ForSaleCombobox.Items.Add("Dekalb:");
            ForSaleCombobox.Items.Add("----------");
            foreach (var stAddr in propertyList)
            {
                if (stAddr != null)
                    ForSaleCombobox.Items.Add(stAddr);
            }

            ForSaleCombobox.Items.Add("");

            propertyList = FindProperties(SycamoreCommunity);
            ForSaleCombobox.Items.Add("Sycamore:");
            ForSaleCombobox.Items.Add("----------");
            foreach (var stAddr in propertyList)
            {
                if (stAddr != null)
                    ForSaleCombobox.Items.Add(stAddr);
            }
        }

        private string[] FindProperties(Community comm)
        {
            string[] propertyList = new string[30];
            ushort index = 0;

            var houseProperty = from property in comm.Props
                                where (property is House)
                                select property;

            foreach (var property in houseProperty)
                propertyList[index++] = property.StreetAddr;

            propertyList[index++] = "";

            var apartmentProperty = from property in comm.Props
                                    where (property is Apartment)
                                    select property;

            foreach (var property in apartmentProperty)
                propertyList[index++] = property.StreetAddr + " # " + ((Apartment)property).Unit;

            return propertyList;
        }

        // action after clicking the 3th query button
        private void BusinessQueryButton_Click(object sender, EventArgs e)
        {
            if (ForSaleCombobox.SelectedItem == null)
                return;

            string[] stAddr = ForSaleCombobox.SelectedItem.ToString().Split(new[] { " # " }, StringSplitOptions.None);
            ushort distance = Convert.ToUInt16(BusinessDistanceUpDown.Value);

            QueryOutputTextbox.Text = string.Format("Hiring Businesses within {0} unit of distance\r\n\tfrom {1}\r\n" +
                                                    "------------------------------------------------------------------------------------------\r\n", distance, stAddr[0]);

            Community comm;

            if (ForSaleCombobox.SelectedIndex > (DekalbCommunity.Population + 5))
                comm = SycamoreCommunity;
            else
                comm = DekalbCommunity;

            SortedList<int, CommunityInfo> propertyList = new SortedList<int, CommunityInfo>();
            List<Community> communities = new List<Community>();
            communities.Add(DekalbCommunity);
            communities.Add(SycamoreCommunity);

            var list = from res in comm.Props
                        where (res is House) || (res is Apartment)
                        where (res.StreetAddr == stAddr[0])
                        from n in communities
                        from pro in n.Props
                        where (pro is Business)
                        where pro.ForSale.Split(':')[0] == "T"
                        let x = Math.Pow((int)(res.X - pro.X), 2)
                        let y = Math.Pow((int)(res.Y - pro.Y), 2)
                        where (x + y) < Math.Pow(distance, 2)
                        from n1 in n.Residents
                        where n1.Id == pro.OwnerId
                        orderby (x + y) ascending
                        select new CommunityInfo()
                        {
                            id = pro.Id,
                            property = pro,
                            FullName = n1.FullName,
                            distance = (int)Math.Sqrt(x + y),
                            type = (pro is House) ? 0 : 1
                        };

            PrintNearbyBusiness(list);

            QueryOutputTextbox.AppendText("\r\n### END OUTPUT ###");
        }

        private void PrintNearbyBusiness(IEnumerable<CommunityInfo> selector)
        {
            foreach (var bus in selector)
            {

                QueryOutputTextbox.AppendText(string.Format("{0} {1}, {2} {3}\r\n",
                    bus.property.StreetAddr, bus.property.City, bus.property.State, bus.property.Zip));

                QueryOutputTextbox.AppendText(string.Format("Ownwe: {0} |  ", bus.FullName));


                QueryOutputTextbox.AppendText(string.Format("{0} units away, with {1} open positions \r\n{2}, " +
                        "a {3} type of business, established in {4}\r\n\r\n",
                        bus.distance, (bus.property as Business).ActiveRecruitment, (bus.property as Business).Name, (bus.property as Business).Type, (bus.property as Business).YearEstablished
                        ));
            }
        }

        // this displays the value of the min trace bar
        private void MinPriceTrackBar_Scroll(object sender, EventArgs e)
        {
            MinPriceLabel.Text = "Min Price: " + String.Format("{0:C0}", MinPriceTrackBar.Value);

            //if track bar is less than this the disable and set value equal to it

            if (MinPriceTrackBar.Value >= MaxPriceTrackBar.Value)
            {
                MaxPriceTrackBar.Enabled = false;
                MaxPriceTrackBar.Value = MinPriceTrackBar.Value;
                MaxPriceLabel.Text = "Max Price: " + String.Format("{0:C0}", MaxPriceTrackBar.Value);
            }
            else
            {
                MaxPriceTrackBar.Enabled = true;
            }
        }

        // this displays the value of the max trace bar
        private void MaxPriceTrackBar_Scroll(object sender, EventArgs e)
        {
            MaxPriceLabel.Text = "Max Price: " + String.Format("{0:C0}", MaxPriceTrackBar.Value);
            if (MaxPriceTrackBar.Value <= MinPriceTrackBar.Value)
            {
                MinPriceTrackBar.Enabled = false;
                MinPriceTrackBar.Value = MaxPriceTrackBar.Value;
                MinPriceLabel.Text = "Max Price: " + String.Format("{0:C0}", MaxPriceTrackBar.Value);
            }
            else
            {
                MinPriceTrackBar.Enabled = true;
            }
        }

        private void ParametersQueryButton_Click(object sender, EventArgs e)
        {
            ushort numOfBath = Convert.ToUInt16(BathUpDown.Value);
            ushort numOfBed = Convert.ToUInt16(BedUpDown.Value);
            ushort numOfSpace = Convert.ToUInt16(SqFtUpDown.Value);
            bool garageCheck = GarageCheckBox.Checked;

            QueryOutputTextbox.Text = string.Format("House with at least {0} bed, {1} bath, and {2} sq. foot {3}\r\n" +
                "-----------------------------------------------------------------------------------------\r\n",
                numOfBed, numOfBath, numOfSpace, (garageCheck) ? "with garage." : "without garage.");

            //counter 
            int results = 0;

            //create both of the list
            List<residentialInfo>  DList = ResidentialPara(DekalbCommunity);
            List<residentialInfo> SList = ResidentialPara(SycamoreCommunity);

            //combine the 2 lists
            DList.AddRange(SList);

            //reorder the list
            //DList = DList.OrderBy(i => i.ForSale).ToList();

            //go throught the list and print if needed
            foreach (var pro in DList)
            {
                //split the first and last name for output
                string[] splitted = pro.FullName.Split(' ');

                if (HouseCheckBox.Checked == true && pro.proType == true && pro.Bath >= BathUpDown.Value && pro.Bed >= BedUpDown.Value && pro.Sqft >= SqFtUpDown.Value)
                {
                    if(GarageCheckBox.Checked == true && DetachedGarageCheckBox.Checked == false && pro.Garage == true && pro.AttachedGarage == false)
                    {
                        QueryOutputTextbox.AppendText(string.Format("{0} {1}, {2} {3} \r\nOwner: {4}, {5} | {6}, {7} baths, {8} sq.ft. \r\n {9} : {10}     {11:C0}\r\n\r\n",
                           pro.StreetAddr, pro.City, pro.State, pro.Zip, splitted[1], splitted[0].Trim(new char[] { ',' }), (pro.Bed == 1) ? " bed " : pro.Bed + " beds ", pro.Bath, pro.Sqft,
                           (!pro.Garage) ? "With out garage" : (pro.AttachedGarage == true) ? "With attach Garage" : "With  detatched garage",
                           (pro.Flood == 1) ? pro.Flood + " floor." : pro.Flood + " floors.", Convert.ToUInt32(pro.ForSale)
                           ));
                        results += 1;
                    }
                    else if(GarageCheckBox.Checked == true && DetachedGarageCheckBox.Checked == true && pro.Garage == true && pro.AttachedGarage == true)
                    {
                        QueryOutputTextbox.AppendText(string.Format("{0} {1}, {2} {3} \r\nOwner: {4}, {5} | {6}, {7} baths, {8} sq.ft. \r\n {9} : {10}     {11:C0}\r\n\r\n",
                           pro.StreetAddr, pro.City, pro.State, pro.Zip, splitted[1], splitted[0].Trim(new char[] { ',' }), (pro.Bed == 1) ? " bed " : pro.Bed + " beds ", pro.Bath, pro.Sqft,
                           (!pro.Garage) ? "With out garage" : (pro.AttachedGarage == true) ? "With attach Garage" : "With  detatched garage",
                           (pro.Flood == 1) ? pro.Flood + " floor." : pro.Flood + " floors.", Convert.ToUInt32(pro.ForSale)
                           ));
                        results += 1;
                    }
                    else if (GarageCheckBox.Checked == false)
                    {
                        QueryOutputTextbox.AppendText(string.Format("{0} {1}, {2} {3} \r\nOwner: {4}, {5} | {6}, {7} baths, {8} sq.ft. \r\n {9} : {10}     {11:C0}\r\n\r\n",
                           pro.StreetAddr, pro.City, pro.State, pro.Zip, splitted[1], splitted[0].Trim(new char[] { ',' }), (pro.Bed == 1) ? " bed " : pro.Bed + " beds ", pro.Bath, pro.Sqft,
                           (!pro.Garage) ? "With out garage" : (pro.AttachedGarage == true) ? "With attach Garage" : "With  detatched garage",
                           (pro.Flood == 1) ? pro.Flood + " floor." : pro.Flood + " floors.", Convert.ToUInt32(pro.ForSale)
                           ));
                        results += 1;
                    }
                }
                else if (ApartmentCheckBox.Checked == true && pro.proType == false && pro.Bath >= BathUpDown.Value && pro.Bed >= BedUpDown.Value && pro.Sqft >= SqFtUpDown.Value && GarageCheckBox.Checked == false)
                {
                    QueryOutputTextbox.AppendText(string.Format("{0} Apt. # {1} {2}, {3} {4} \r\nOwner: {5}, {6} | {7}, {8} baths, {9} sq.ft. {10:C0}\r\n\r\n\r\n",
                           pro.StreetAddr, pro.apt, pro.City, pro.State, pro.Zip, splitted[1], splitted[0].Trim(new char[] { ',' }), (pro.Bed == 1) ? " bed " : pro.Bed + " beds ", pro.Bath, pro.Sqft, Convert.ToUInt32(pro.ForSale)));
                    results += 1;
                }
            }

            if (results == 0)
            {
                QueryOutputTextbox.AppendText("Your query yielded no matches.\r\n");
            }

            QueryOutputTextbox.AppendText("\r\n### END OUTPUT ###");
        }

        private List<residentialInfo> ResidentialPara(Community comm)
        {
            var property = from pro in comm.Props
                           where (pro is House) || (pro is Apartment)
                           let pr = pro.ForSale.Split(':')
                           where (pr[0] == "T")
                           let price = Convert.ToInt32(pr[1])
                           let proType = (pro is House) ? true : false
                           let garage = (proType) ? (pro as House).Garage : false
                           let attachGarage = (garage) ? (pro as House).AttatchedGarage : false
                           from res in comm.Residents
                           where (res.Id == pro.OwnerId)
                           orderby price ascending
                           select new residentialInfo()
                           {
                               StreetAddr = pro.StreetAddr,
                               City = pro.City,
                               State = pro.State,
                               Zip = pro.Zip,
                               AttachedGarage = attachGarage,
                               Garage = garage,
                               Bed = (pro as Residential).Bedrooms,
                               Bath = (pro as Residential).Baths,
                               Sqft = (pro as Residential).Sqft,
                               Flood = (proType) ? (pro as House).Flood : 0,
                               ForSale = pro.ForSale.Split(':')[1],
                               FullName = res.FullName,
                               proType = proType,
                               apt = (proType) ? null : (pro as Apartment).Unit
                           };

            return property.ToList();
        }

        private void SchoolCombobox_DropDown(object sender, EventArgs e)
        {
            SchoolCombobox.Items.Clear();
            string[] propertyList = FindSchool(DekalbCommunity);
            SchoolCombobox.Items.Add("Dekalb:");
            SchoolCombobox.Items.Add("----------");
            foreach (var stAddr in propertyList)
            {
                if (stAddr != null)
                    SchoolCombobox.Items.Add(stAddr);
            }

            SchoolCombobox.Items.Add("");

            propertyList = FindSchool(SycamoreCommunity);
            SchoolCombobox.Items.Add("Sycamore:");
            SchoolCombobox.Items.Add("----------");
            foreach (var stAddr in propertyList)
            {
                if (stAddr != null)
                    SchoolCombobox.Items.Add(stAddr);
            }
        }

        private string[] FindSchool(Community comm)
        {
            string[] schoolList = new string[10];
            ushort index = 0;

            var schoolProperty = from property in comm.Props
                                 where (property is School)
                                 select property;

            foreach (var property in schoolProperty)
                schoolList[index++] = ((School)property).Name;

            return schoolList;
        }

        private void SchoolQueryButton_Click(object sender, EventArgs e)
        {
            if (SchoolCombobox.SelectedItem == null)
                return;

            string schoolName = SchoolCombobox.Text.ToString();
            int distance = Convert.ToInt32(SchoolDistanceUpDown.Value);

            QueryOutputTextbox.Text = string.Format("Residences for sale within {1} units of distance\r\n\tfrom {0}\r\n" +
                "------------------------------------------------------------------------------------------\r\n", schoolName, distance);

            int index = 0;
            foreach (var v in SchoolCombobox.Items)
                if (v.ToString() != "")
                    index++;
                else
                    break;

            SortedList<int, CommunityInfo> propertyList = new SortedList<int, CommunityInfo>();

            List<Community> communities = new List<Community>();
            communities.Add(DekalbCommunity);
            communities.Add(SycamoreCommunity);

            Community comm;
            if (SchoolCombobox.SelectedIndex < index)
                comm = DekalbCommunity;
            else
                comm = SycamoreCommunity;

            var list = from school in comm.Props
                        where (school is School) && ((school as School).Name == schoolName)
                        from n in communities
                        from pro in n.Props
                        where (pro is Apartment) || (pro is House)
                        where pro.ForSale.Split(':')[0] == "T"
                        let x = Math.Pow((int)(school.X - pro.X), 2)
                        let y = Math.Pow((int)(school.Y - pro.Y), 2)
                        where (x + y) < Math.Pow(distance, 2)
                        from n1 in n.Residents
                        where n1.Id == pro.OwnerId
                        orderby (x + y) ascending
                        select new CommunityInfo()
                        {
                            FullName = n1.FullName,
                            id = pro.OwnerId,
                            property = pro,
                            distance = (int)Math.Sqrt(x + y),
                            type = (pro is House) ? 0 : 1
                        };

            PrintNearbyForSale(list);
        }

        private void PrintNearbyForSale(IEnumerable <CommunityInfo> selector)
        {
            foreach (var pro in selector)
            {

                QueryOutputTextbox.AppendText(string.Format("{0}{1} {2}, {3} {4}   {5} units away\r\n",
                            pro.property.StreetAddr, (pro.type == 0) ? "" : " #Apt " + (pro.property as Apartment).Unit + ' ', 
                            pro.property.City, pro.property.State, pro.property.Zip, pro.distance
                            ));

                QueryOutputTextbox.AppendText(string.Format("Owner: {0} | ", pro.FullName));

                QueryOutputTextbox.AppendText(string.Format("{0} bed, {1} bath, {2} sq.ft \r\n {3} : {4}   ${5}\r\n\r\n",
                            (pro.property as Residential).Bedrooms, (pro.property as Residential).Baths, (pro.property as Residential).Sqft,
                            (pro.type == 1) ? "With out garage" : ((pro.property as House).AttatchedGarage == true) ? "With attach Garage" : "With garage",
                            (pro.type == 1) ? "" : (pro.property as House).Flood + " floors.", pro.property.ForSale.Split(':')[1]
                            ));
            }
            QueryOutputTextbox.AppendText("\r\n### END OUTPUT ###");
        }
        
        class CommunityInfo
        { 
            string fullName = "N/A";
            public uint id { get; set; }
            public string FullName { get; set; }
            public Property property { get; set; }
            public int type { get; set; }
            public int distance;
        }

        //Click of the first price button Displaying price info on different properties.
        private void PriceQueryButton_Click(object sender, EventArgs e)
        {
            QueryOutputTextbox.Text = string.Format("Properties for sale within [ {0}, {1} ] price range.\r\n" +
                "------------------------------------------------------------------------------------------\r\n", 
                String.Format("{0:C0}", MinPriceTrackBar.Value), String.Format("{0:C0}", MaxPriceTrackBar.Value));


            List<Community> communities = new List<Community>();
            communities.Add(DekalbCommunity);
            communities.Add(SycamoreCommunity);


            var l = communities.GroupBy(p => p.Name);

            var List =           from n2 in communities
                                 from n in n2.Props
                                 let forsale = n.ForSale.Split(':')
                                 where forsale[0] == "T"
                                 let price = Convert.ToInt32(forsale[1])
                                 where (price >= MinPriceTrackBar.Value) && (price <= MaxPriceTrackBar.Value)
                                 from n1 in n2.Residents
                                 where n1.Id == n.OwnerId
                                 orderby price ascending
                                 select new CommunityInfo()
                                 {
                                     FullName = n1.FullName,
                                     property = n,
                                     type = (n is Business) ? 0 : (n is School) ? 1 : (n is House) ? 2 : 3
                                 };

            var fullList = List.GroupBy(p => p.property.City);
            printList(fullList);
            
        }

        private void printList(IEnumerable<IGrouping<string, CommunityInfo> > comm)
        {
            foreach (var community in comm)
            {
                QueryOutputTextbox.AppendText(string.Format("\r\n\t\t*** {0} ***\r\n", community.Key));
                foreach (var pro in community)
                if (ResidentialtCheckBox.Checked == true && (pro.type == 2 || pro.type == 3))
                {
                    QueryOutputTextbox.AppendText(string.Format("{0}{1} {2}, {3} {4}\r\n",
                            pro.property.StreetAddr, (pro.type == 2) ? "" : " #Apt " + (pro.property as Apartment).Unit + ' ', pro.property.City, pro.property.State, pro.property.Zip
                            ));

                    QueryOutputTextbox.AppendText(string.Format("Owner: {0} | ", pro.FullName));

                    QueryOutputTextbox.AppendText(string.Format("{0} bed, {1} bath, {2} sq.ft \r\n {3} : {4}   ${5}\r\n\r\n",
                            (pro.property as Residential).Bedrooms, (pro.property as Residential).Baths, (pro.property as Residential).Sqft,
                            (pro.type == 3) ? "With out garage" : ((pro.property as House).AttatchedGarage == true) ? "With attach Garage" : "With garage",
                            (pro.type == 3) ? "" : (pro.property as House).Flood + " floors.", pro.property.ForSale.Split(':')[1]
                            ));
                }
                else if (SchoolCheckBox.Checked == true && pro.type == 1)
                {
                    QueryOutputTextbox.AppendText(string.Format("{0} {1}, {2} {3} Ownwer: {4}\r\n",
                    pro.property.StreetAddr, pro.property.City, pro.property.State, pro.property.Zip, pro.FullName));

                    QueryOutputTextbox.AppendText(string.Format("{0}, established in {1}\r\n",
                            (pro.property as School).Name, (pro.property as School).YearEstablished));

                    QueryOutputTextbox.AppendText(string.Format("{0} students enrooled  ${1}\r\n",
                            (pro.property as School).Enrolled, pro.property.ForSale.Split(':')[1]));
                }
                else if (BusinessCheckBox.Checked && pro.type == 0)
                {
                    QueryOutputTextbox.AppendText(string.Format("{0} {1}, {2} {3}\r\n",
                    pro.property.StreetAddr, pro.property.City, pro.property.State, pro.property.Zip));

                    QueryOutputTextbox.AppendText(string.Format("Ownwer: {0} |  ${1}\r\n", pro.FullName, pro.property.ForSale.Split(':')[1]));


                    QueryOutputTextbox.AppendText(string.Format("{0}, a {1} type of business, established in {2}\r\n\r\n",
                            (pro.property as Business).Name, (pro.property as Business).Type, (pro.property as Business).YearEstablished
                            ));
                }
            }
            QueryOutputTextbox.AppendText("\r\n### END OUTPUT ###");
        }


        class CommunityInfo2
        {
            string fullName = "N/A";
            public uint id { get; set; }
            public string FullName { get; set; }
            public string city { get; set; }
            public Property property { get; set; }
            public int type { get; set; }
            public uint[] lds { get; set; }
        }

        //out of towners button click
        private void TownersQueryButton_Click(object sender, EventArgs e)
        {
            QueryOutputTextbox.Text = string.Format("Properties Ownded by Out-Of-Towners\r\n" +
                                                    "------------------------------------------------------------------------------------------\r\n");
            //output based on owner ids
            List<uint> test = DekalbCommunity.CompareResidenceToJob();

            foreach (int i in test)
            {
                QueryOutputTextbox.AppendText(i.ToString() + " ");
            }
            /*
            var dekalbSaleList = from n in DekalbCommunity.Props
                                 where (n is Business)
                                 select new CommunityInfo2()
                                 {
                                     id = n.OwnerId,
                                     property = n,
                                     type = (n is Business) ? 0 : (n is School) ? 1 : (n is House) ? 2 : 3,
                                     city = n.City
                                 };
                                 */

            //lookup the Owner id
            //PrintOOT(dekalbSaleList.ToList());

            QueryOutputTextbox.AppendText("\r\n### END OUTPUT ###");
        }
    }
}