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

            //var property = from n in 

            if (ForSaleCombobox.SelectedIndex > (DekalbCommunity.Population + 5))
                PrintNearbyBusiness(SycamoreCommunity, stAddr, distance);
            else
                PrintNearbyBusiness(DekalbCommunity, stAddr, distance);

            QueryOutputTextbox.AppendText("\r\n### END OUTPUT ###");
        }

        private void PrintNearbyBusiness(Community comm, string[] stAddr, ushort distance)
        {
            var property = from n in comm.Props
                           where (n.StreetAddr == stAddr[0])
                           select n;

            var business = from n1 in property
                           from n in comm.Props
                           where (n is Business) && (Math.Pow(n1.X - n.X, 2) + Math.Pow(n1.Y - n.Y, 2) <= Math.Pow(distance, 2))
                           select n;

            foreach (var pro in business)
                MessageBox.Show(pro.StreetAddr);
                    //QueryOutputTextbox.AppendText(string.Format("{0}{1}{2}{3}{4}",
                        //bus.StreetAddr, bus.City, bus.State, bus.Zip, distance));
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
                "-----------------------------------------------------------------------------------------",
                numOfBed, numOfBath, numOfSpace, (garageCheck) ? "with garage." : "without garage.");

            if (HouseCheckBox.Checked)
            {
            }
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

            Community comm;
            if (SchoolCombobox.SelectedIndex < index)
                comm = DekalbCommunity;
            else
                comm = SycamoreCommunity;

            foreach (var pro in FindNearbyForSale(comm, schoolName, distance))
            {
                var school = from n in comm.Props
                             where (n is School) && ((n as School).Name == schoolName)
                             select n;

                foreach (var s in school)
                    QueryOutputTextbox.AppendText(string.Format("{0} {1}, {2} {3}   {4} units away\r\n",
                            pro.StreetAddr, pro.City, pro.State, pro.Zip, Math.Sqrt((Math.Pow(s.X - pro.X, 2) + Math.Pow(s.Y - pro.Y, 2)))
                            ));

                var nameInfo = from person in comm.Residents
                               where pro.OwnerId == person.Id
                               select person;

                foreach (var person in nameInfo)
                    QueryOutputTextbox.AppendText(string.Format("Owner: {0} | {1} bed, {2} bath, {3} sq.ft \r\n {4} : {5} floors.   ${6}\r\n\r\n",
                         person.FullName, ((Residential)pro).Bedrooms, ((Residential)pro).Baths, ((Residential)pro).Sqft,
                         ((pro is Apartment)?
                            "With out garage":(((House)pro).Garage?
                            (((House)pro).AttatchedGarage != true?"With attached garage":"With garage"):"With out garage")),
                         (pro is House)?((House)pro).Flood:0, pro.ForSale.Split(':')[1]
                         ));
            }

            QueryOutputTextbox.AppendText("\r\n### END OUTPUT ###");

        }

        private IEnumerable<Property> FindNearbyForSale(Community comm, string schoolName, int distance)
        {
            return  from school in comm.Props
                    from pro in comm.Props
                    where (school is School) && ((school as School).Name == schoolName)
                    where (pro.ForSale.Split(':')[0] == "T") && ((Math.Pow(school.X - pro.X, 2) + Math.Pow(school.X - pro.X, 2)) < Math.Pow(distance, 2))
                    where (pro is Apartment) || (pro is House)
                    select pro;
        }

        //Click of the first price button Displaying price info on different properties.
        private void PriceQueryButton_Click(object sender, EventArgs e)
        {
            QueryOutputTextbox.Text = string.Format("Properties for sale within [ {0}, {1} ] price range.\r\n" +
                "------------------------------------------------------------------------------------------\r\n", String.Format("{0:C0}", MinPriceTrackBar.Value), String.Format("{0:C0}", MaxPriceTrackBar.Value));

            //dekalb community
            QueryOutputTextbox.AppendText("\t#### DeKalb #### \r\n\r\n");
            foreach(var pro in FindForSaleInCost(DekalbCommunity, MinPriceTrackBar.Value, MaxPriceTrackBar.Value))
            {
                var nameInfo = from person in DekalbCommunity.Residents
                               where pro.OwnerId == person.Id
                               select person;

                foreach(var person in nameInfo)
                {
                    var houses = from props in DekalbCommunity.Props
                                 group props by (props is House) into housegroup
                                 select housegroup;

                    foreach (var housegroup in houses)
                    {
                        QueryOutputTextbox.AppendText(string.Format("{0} {1}, {2} {3}\r\n" +
                                 "Owner: {4} | {5} bed, {6} bath, {7} sq.ft \r\n {8} : {9} floors.   ${10}\r\n\r\n",
                                 pro.StreetAddr, "Dekalb", pro.State, pro.Zip, person.FullName, ((Residential)pro).Bedrooms, ((Residential)pro).Baths, ((Residential)pro).Sqft,
                                 ((pro is Apartment) ?
                                    "With out garage" : (((House)pro).Garage ?
                                    (((House)pro).AttatchedGarage != true ? "With attached garage" : "With garage") : "With out garage")),
                                 (pro is House) ? ((House)pro).Flood : 0, pro.ForSale.Split(':')[1]
                                 ));
                    }
                }


                /*
                if(ResidentialtCheckBox.Checked == true)
                {
                    var nameInfo = from person in DekalbCommunity.Residents
                                   where pro.OwnerId == person.Id
                                   select person;

                    foreach (var person in nameInfo)
                        QueryOutputTextbox.AppendText(string.Format("{0} {1}, {2} {3}\r\n" +
                             "Owner: {4} | {5} bed, {6} bath, {7} sq.ft \r\n {8} : {9} floors.   ${10}\r\n\r\n",
                             pro.StreetAddr, "Dekalb", pro.State, pro.Zip, person.FullName, ((Residential)pro).Bedrooms, ((Residential)pro).Baths, ((Residential)pro).Sqft,
                             ((pro is Apartment) ?
                                "With out garage" : (((House)pro).Garage ?
                                (((House)pro).AttatchedGarage != true ? "With attached garage" : "With garage") : "With out garage")),
                             (pro is House) ? ((House)pro).Flood : 0, pro.ForSale.Split(':')[1]
                             ));
                }
                else if (BusinessCheckBox.Checked == true)
                {

                }
                else if(SchoolCheckBox.Checked == true)
                {

                }
                */
            }

            //syacmore community
            QueryOutputTextbox.AppendText("\t#### Sycamore #### \r\n\r\n");

            QueryOutputTextbox.AppendText("\r\n### END OUTPUT ###");
        }

        private IEnumerable<Property> FindForSaleInCost(Community comm, int min, int max)
        {
            return from nearby in comm.Props
                   where (nearby.ForSale.Split(':')[0] == "T") && (Convert.ToInt32(nearby.ForSale.Split(':')[1]) >= min) && (Convert.ToInt32(nearby.ForSale.Split(':')[1]) <= max) &&
                   ((nearby is House) || (nearby is Apartment) || (nearby is School) || (nearby is Business))
                   select nearby;
        }

    }
}