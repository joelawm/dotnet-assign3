using System;
using System.IO;

namespace Assign_3
{
    class ActiveCommunity
    {
        public Community Active_Files(string personFile, string houseFile, string apartmentFile, string commName)
        {
            //Dekalb and Sycamore Community
            Community Community = new Community(99999, commName, 0);

            // if PersonFile exists
            if (File.Exists(personFile))
            {
                // PersonFile declares here
                using (StreamReader sr = File.OpenText(personFile))
                {
                    // Split the data by '\n' and save them as 1d array
                    string[] input = sr.ReadToEnd().Split('\n');
                    int i = 0;

                    do
                    {
                        // Split the data from input[] and save them in iInput[]
                        string[] iInput = input[i].Split('\t');

                        var id = UInt32.Parse(iInput[0]);
                        var lName = iInput[1];
                        var fName = iInput[2];
                        var occ = iInput[3];
                        var year = Int32.Parse(iInput[4]);
                        var month = Int32.Parse(iInput[5]);
                        var day = Int32.Parse(iInput[6]);
                        var dt = new DateTime(year, month, day);
                        var resId = iInput[7];

                        Community.Residents.Add(new Person(id, dt, lName, fName, occ, resId));
                        i++;
                    } while (i < input.Length); // if i less than input[]'s length

                    sr.Close();
                }
            }

            // if HouseFile exists
            if (File.Exists(houseFile))
            {
                using (StreamReader sr = File.OpenText(houseFile))
                {
                    // split data by '\n' and save them in input array
                    string[] input = sr.ReadToEnd().Split('\n');
                    int i = 0;

                    do
                    {
                        // split data by '\t' and save them in iInput array
                        string[] iInput = input[i].Split('\t');
                        var id = UInt32.Parse(iInput[0]);
                        var oId = UInt32.Parse(iInput[1]);
                        var x = UInt32.Parse(iInput[2]);
                        var y = UInt32.Parse(iInput[3]);
                        var stAddr = iInput[4];
                        var city = iInput[5];
                        var state = iInput[6];
                        var zip = iInput[7];
                        var forSale = iInput[8].Equals("T");
                        var bedRoom = UInt32.Parse(iInput[9]);
                        var bath = UInt32.Parse(iInput[10]);
                        var sqft = UInt32.Parse(iInput[11]);
                        var garage = iInput[12].Equals("T");
                        var aGarage = iInput[13].Equals("T");
                        var floor = UInt32.Parse(iInput[14]);

                        House house = new House(id, x, y, oId, stAddr, city, state,
                            zip, forSale, bedRoom, bath, sqft, garage, aGarage, floor);
                        Community.Props.Add(house);
                        i++;
                    } while (i < input.Length); // if i less than input array's length

                    sr.Close();
                }
            }

            // if ApartmentFile exists
            if (File.Exists(apartmentFile))
            {
                using (StreamReader sr = File.OpenText(apartmentFile))
                {
                    // split data by '\n' and save them in input array
                    string[] input = sr.ReadToEnd().Split('\n');
                    int i = 0;

                    do
                    {
                        // split data by '\t' and save them in input array
                        string[] iInput = input[i].Split('\t');
                        var id = UInt32.Parse(iInput[0]);
                        var oId = UInt32.Parse(iInput[1]);
                        var x = UInt32.Parse(iInput[2]);
                        var y = UInt32.Parse(iInput[3]);
                        var stAddr = iInput[4];
                        var city = iInput[5];
                        var state = iInput[6];
                        var zip = iInput[7];
                        var forSale = iInput[8].Equals("T");
                        var bedRoom = UInt32.Parse(iInput[9]);
                        var bath = UInt32.Parse(iInput[10]);
                        var sqft = UInt32.Parse(iInput[11]);
                        var unit = iInput[12];

                        Apartment apartment = new Apartment(id, x, y, oId, stAddr, city, state, zip, forSale, bedRoom,
                            bath, sqft, unit);
                        Community.Props.Add(apartment);
                        i++;
                    } while (i < input.Length); // do if i less than input array's length

                    sr.Close();
                }
            }

            return Community;
        }
    }
}
