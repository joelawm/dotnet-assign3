using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                                                    "------------------------------------------------------------------------------------------\r\n", distance, stAddr);


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

            

            foreach (var pro in FindNearbyForSale(DekalbCommunity, distance))
            {
                var nameInfo = from person in DekalbCommunity.Residents
                               where pro.OwnerId == person.Id
                               select person;

                foreach (var person in nameInfo)
                    QueryOutputTextbox.AppendText(string.Format("{0} {1}, {2} {3}   {4} units away\r\n" +
                         "Owner: {5} | {6} bed, {7} bath, {8} sq.ft \r\n {9} : {10} floors.   ${11}\r\n\r\n",
                         pro.StreetAddr, "Dekalb", pro.State, pro.Zip, (int)Math.Sqrt(Math.Pow(pro.X, 2) + Math.Pow(pro.Y, 2)),
                         person.FullName, ((Residential)pro).Bedrooms, ((Residential)pro).Baths, ((Residential)pro).Sqft,
                         ((pro is Apartment)?
                            "With out garage":(((House)pro).Garage?
                            (((House)pro).AttatchedGarage != true?"With attached garage":"With garage"):"With out garage")),
                         (pro is House)?((House)pro).Flood:0, pro.ForSale.Split(':')[1]
                         ));
            }
            QueryOutputTextbox.AppendText("\r\n### END OUTPUT ###");

        }

        private IEnumerable<Property> FindNearbyForSale(Community comm, int distance)
        {
            return from nearby in comm.Props
                   where (nearby.ForSale.Split(':')[0] == "T") &&
                   ((Math.Pow(nearby.X, 2) + Math.Pow(nearby.Y, 2)) < Math.Pow(distance, 2)) && 
                   ((nearby is House) || (nearby is Apartment))
                   select nearby;
        }

        //Click of the first price button
        private void PriceQueryButton_Click(object sender, EventArgs e)
        {
            QueryOutputTextbox.Text = string.Format("Properties for sale within [ {0}, {1} ] price range.\r\n" +
                "------------------------------------------------------------------------------------------\r\n", String.Format("{0:C0}", MinPriceTrackBar.Value), String.Format("{0:C0}", MaxPriceTrackBar.Value));

            //do all coomunitys that exist


            QueryOutputTextbox.AppendText("\r\n### END OUTPUT ###");
        }
    }
}