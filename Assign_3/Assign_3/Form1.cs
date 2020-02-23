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

            if (ForSaleCombobox.SelectedIndex > (DekalbCommunity.Population + 5))
                PrintNearbyBusiness(FindNearbyBusiness(SycamoreCommunity, stAddr, distance));
            else
                PrintNearbyBusiness(FindNearbyBusiness(DekalbCommunity, stAddr, distance));

            QueryOutputTextbox.AppendText("\r\n### END OUTPUT ###");
        }

        private List<BussinessInfo> FindNearbyBusiness(Community comm, string[] stAddr, ushort distance)
        {
            var selector = from pro in comm.Props
                           where (pro.StreetAddr == stAddr[0])
                           from busi in comm.Props
                           where (busi is Business)
                           let x = Math.Pow((int)(pro.X - busi.X), 2)
                           let y = Math.Pow((int)(pro.Y - busi.Y), 2)
                           let ownId = pro.OwnerId
                           where (busi as Business).ActiveRecruitment != 0
                           where (x + y) <= Math.Pow(distance, 2)
                           from res in comm.Residents
                           where (busi.OwnerId == res.Id)
                           orderby (busi as Business).YearEstablished ascending
                           select new BussinessInfo(){
                               FullName = res.FullName,
                               StreetAddr = busi.StreetAddr,
                               City = busi.City,
                               State = busi.State,
                               Zip = busi.Zip,
                               distance = Math.Sqrt(x + y),
                               OwnerId = ownId,
                               Name = (busi as Business).Name,
                               YearBuild = (busi as Business).YearEstablished,
                               Type = (busi as Business).Type,
                               Position = (busi as Business).ActiveRecruitment
                           };

            return selector.ToList();
        }

        private void PrintNearbyBusiness(List<BussinessInfo> selector)
        {
            foreach (var bus in selector)
            {
                QueryOutputTextbox.AppendText(string.Format("{0} {1}, {2} {3}\r\n",
                    bus.StreetAddr, bus.City, bus.State, bus.Zip));

                QueryOutputTextbox.AppendText(string.Format("Ownwe: {0} |  ", bus.FullName));


                QueryOutputTextbox.AppendText(string.Format("{0} units away, with {1} open positions \r\n{2}, " +
                        "a {3} type of business, established in {4}\r\n\r\n",
                        (int)bus.distance, bus.Position, bus.Name, bus.Type, bus.YearBuild
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

            PrintNearbyForSale(FindNearbyForSale(comm, schoolName, distance));
        }

        private List<residentialInfo> FindNearbyForSale(Community comm, string schoolName, int distance)
        {
            var a = from school in comm.Props
                    where (school is School) && ((school as School).Name == schoolName)
                    from pro in comm.Props
                    let x = Math.Pow((int)(school.X - pro.X), 2)
                    let y = Math.Pow((int)(school.X - pro.X), 2)
                    let proType = (pro is House) ? true : false
                    let garage = (proType) ? (pro as House).Garage : false
                    let attachGarage = (garage)? (pro as House).AttatchedGarage: false
                    where (pro.ForSale.Split(':')[0] == "T") && ((x + y) < Math.Pow(distance, 2))
                    where (pro is Apartment) || (pro is House)
                    from res in comm.Residents
                    where (res.Id == pro.OwnerId)
                    orderby (x + y) ascending
                    select new residentialInfo()
                    {
                        StreetAddr = pro.StreetAddr,
                        City = pro.City,
                        State = pro.State,
                        Zip = pro.Zip,
                        distance = Math.Sqrt(x + y),
                        AttachedGarage = attachGarage,
                        Garage = garage,
                        Bed = (pro as Residential).Bedrooms,
                        Bath = (pro as Residential).Baths,
                        Sqft = (pro as Residential).Sqft,
                        Flood = (proType)? (pro as House).Flood:0,
                        ForSale = pro.ForSale.Split(':')[1],
                        FullName = res.FullName,
                        proType = proType,
                        apt = (proType)?null:(pro as Apartment).Unit
                    };
            return a.ToList();
        }

        private void PrintNearbyForSale(List<residentialInfo> selector)
        {
            foreach (var pro in selector)
            {
                QueryOutputTextbox.AppendText(string.Format("{0}{1} {2}, {3} {4}   {5} units away\r\n",
                            pro.StreetAddr, (pro.proType) ? "" : " #Apt " + pro.apt + ' ', pro.City, pro.State, pro.Zip, (int)pro.distance
                            ));

                QueryOutputTextbox.AppendText(string.Format("Owner: {0} | ", pro.FullName));

                QueryOutputTextbox.AppendText(string.Format("{0} bed, {1} bath, {2} sq.ft \r\n {3} : {4}   ${5}\r\n\r\n",
                            pro.Bed, pro.Bath, pro.Sqft,
                            (!pro.Garage) ? "With out garage" : (pro.AttachedGarage == true) ? "With attach Garage" : "With garage",
                            (pro.Flood == 0) ? "" : pro.Flood + " floors.", pro.ForSale
                            ));
            }
            QueryOutputTextbox.AppendText("\r\n### END OUTPUT ###");
        }

        //Click of the first price button Displaying price info on different properties.
        private void PriceQueryButton_Click(object sender, EventArgs e)
        {
            QueryOutputTextbox.Text = string.Format("Properties for sale within [ {0}, {1} ] price range.\r\n" +
                "------------------------------------------------------------------------------------------\r\n", 
                String.Format("{0:C0}", MinPriceTrackBar.Value), String.Format("{0:C0}", MaxPriceTrackBar.Value));

            if (ResidentialtCheckBox.Checked)
                PrintResidential(ResidentialForSale(DekalbCommunity, MinPriceTrackBar.Value, MaxPriceTrackBar.Value));
            else if(BusinessCheckBox.Checked)
                PrintBusiness(BusinessForSale(DekalbCommunity, MinPriceTrackBar.Value, MaxPriceTrackBar.Value));
            else if (SchoolCheckBox.Checked)
                PrintSchool(SchoolForSale(DekalbCommunity, MinPriceTrackBar.Value, MaxPriceTrackBar.Value));
        }
        
        private List<residentialInfo> ResidentialForSale(Community comm, int min, int max)
        {
            var property = from pro in comm.Props
                           where (pro is House) || (pro is Apartment)
                           let pr = pro.ForSale.Split(':')
                           where (pr[0] == "T")
                           let price = Convert.ToInt32(pr[1])
                           let proType = (pro is House) ? true : false
                           let garage = (proType) ? (pro as House).Garage : false
                           let attachGarage = (garage) ? (pro as House).AttatchedGarage : false
                           where (price <= max) && (price >= min)
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

        private void PrintResidential(List<residentialInfo> selector)
        {
            foreach (var pro in selector)
            {
                QueryOutputTextbox.AppendText(string.Format("{0}{1} {2}, {3} {4}\r\n",
                            pro.StreetAddr, (pro.proType) ? "" : " #Apt " + pro.apt + ' ', pro.City, pro.State, pro.Zip
                            ));

                QueryOutputTextbox.AppendText(string.Format("Owner: {0} | ", pro.FullName));

                QueryOutputTextbox.AppendText(string.Format("{0} bed, {1} bath, {2} sq.ft \r\n {3} : {4}   ${5}\r\n\r\n",
                            pro.Bed, pro.Bath, pro.Sqft,
                            (!pro.Garage) ? "With out garage" : (pro.AttachedGarage == true) ? "With attach Garage" : "With garage",
                            (pro.Flood == 0) ? "" : pro.Flood + " floors.", pro.ForSale
                            ));
            }
        }

        private List<SchoolInfo> SchoolForSale(Community comm, int min, int max)
        {
            var property = from school in comm.Props
                           where (school is School)
                           let pr = school.ForSale.Split(':')
                           where (pr[0] == "T")
                           let price = Convert.ToInt32(pr[1])
                           from res in comm.Residents
                           where (school.OwnerId == res.Id)
                           orderby price ascending
                           select new SchoolInfo()
                           {
                               FullName = res.FullName,
                               StreetAddr = school.StreetAddr,
                               City = school.City,
                               State = school.State,
                               Zip = school.Zip,
                               Name = (school as School).Name,
                               YearBuild = (school as School).YearEstablished,
                               Type = (school as School).Type,
                               ForSale = price.ToString(),
                               enrroled = (school as School).Enrolled
                           };

            return property.ToList();
        }
        private void PrintSchool(List<SchoolInfo> selector)
        {
            foreach (var school in selector)
            {
                QueryOutputTextbox.AppendText(string.Format("{0} {1}, {2} {3} Ownwe: {4}\r\n",
                    school.StreetAddr, school.City, school.State, school.Zip, school.FullName));

                QueryOutputTextbox.AppendText(string.Format("{1}, established in {2}\r\n",
                        school.Name, school.YearBuild, school.ForSale));

                QueryOutputTextbox.AppendText(string.Format("{0} students enrooled  ${1}\r\n",
                        school.enrroled, school.ForSale));
            }
        }

        private List<BussinessInfo> BusinessForSale(Community comm, int min, int max)
        {
            var selector = from busi in comm.Props
                           where (busi is Business)
                           let pr = busi.ForSale.Split(':')
                           where (pr[0] == "T")
                           let price = Convert.ToInt32(pr[1])
                           from res in comm.Residents
                           where (busi.OwnerId == res.Id)
                           orderby price ascending
                           select new BussinessInfo()
                           {
                               FullName = res.FullName,
                               StreetAddr = busi.StreetAddr,
                               City = busi.City,
                               State = busi.State,
                               Zip = busi.Zip,
                               Name = (busi as Business).Name,
                               YearBuild = (busi as Business).YearEstablished,
                               Type = (busi as Business).Type,
                               Position = (busi as Business).ActiveRecruitment,
                               ForSale = price.ToString()
                           };

            return selector.ToList();
        }

        private void PrintBusiness(List<BussinessInfo> selector)
        {
            foreach (var bus in selector)
            {
                QueryOutputTextbox.AppendText(string.Format("{0} {1}, {2} {3}\r\n",
                    bus.StreetAddr, bus.City, bus.State, bus.Zip));

                QueryOutputTextbox.AppendText(string.Format("Ownwe: {0} |  ${1}\r\n", bus.FullName,bus.ForSale));


                QueryOutputTextbox.AppendText(string.Format("{2}, a {3} type of business, established in {4}\r\n\r\n",
                        (int)bus.distance, bus.Position, bus.Name, bus.Type, bus.YearBuild
                        ));
            }
        }
    }
}