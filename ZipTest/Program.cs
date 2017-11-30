using System;
using Zippopotamus;


namespace ZipTest
{
    class Program
    {
        static public void DisplayInput()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("  Zippopotamus API Sample App");
            Console.WriteLine("  1. for Zip Lookup");
            Console.WriteLine("  2. for City Lookup");
            Console.WriteLine("====================================================");
            Console.Write("Zippopotamus\\>  ");
        }
        static string GetInput(string prompt)
        {
            string ret = string.Empty;
            while (string.IsNullOrEmpty(ret))
            {
                Console.Write(prompt);
                ret = Console.ReadLine();
            }
            return ret;
        }
        static private void DoZipLookup()
        {
            try
            {
                string country = GetInput("Country Abbreviation:  ");
                string zipcode = GetInput("Zip Code:  ");
                ZipData zipData = ZipCodeApi.GetDataByCountryAndPostalCode(country, zipcode);
                if (zipData != null)
                {
                    Console.WriteLine("==========================================");
                    Console.WriteLine("Search Parameters");
                    Console.WriteLine("Country:     " + country);
                    Console.WriteLine("Postal Code: " + zipcode);
                    Console.WriteLine("==========================================");

                    Console.WriteLine("  Country: " + zipData.Country);
                    Console.WriteLine("  Abbr:    " + zipData.CountryAbbr);
                    Console.WriteLine("  ZipCode: " + zipData.PostCode);
                    foreach (ZipPlace zp in zipData.Places)
                    {
                        Console.WriteLine("\tName:       " + zp.Name);
                        Console.WriteLine("\tState:      " + zp.State);
                        Console.WriteLine("\tState Abbr: " + zp.Abbr);
                        Console.WriteLine("\tLongtitude: " + zp.Long);
                        Console.WriteLine("\tLatitude:   " + zp.Lat);
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        static private void DoCityLookup()
        {
            try
            {
                string country = GetInput("Country Abbreviation:  ");
                string state = GetInput("State Abbrevation:  ");
                string city = GetInput("City:  ");
                CityData CityData = ZipCodeApi.GetDataByCountryStateAndCity(country, state, city);
                if (CityData != null)
                {
                    Console.WriteLine("==========================================");
                    Console.WriteLine("Search Parameters");
                    Console.WriteLine("Country:     " + country);
                    Console.WriteLine("State Abbr:  " + state);
                    Console.WriteLine("City:        " + city);
                    Console.WriteLine("==========================================");

                    Console.WriteLine("  Country:      " + CityData.Country);
                    Console.WriteLine("  Country Abbr: " + CityData.CountryAbbr);
                    Console.WriteLine("  State:        " + CityData.State);
                    Console.WriteLine("  State Abbr:   " + CityData.StateAbbr);
                    Console.WriteLine("  City:         " + CityData.City);
                    foreach (CityPlace zp in CityData.Places)
                    {
                        Console.WriteLine("\tName:       " + zp.Name);
                        Console.WriteLine("\tZip Code:   " + zp.PostCode);
                        Console.WriteLine("\tLongtitude: " + zp.Long);
                        Console.WriteLine("\tLatitude:   " + zp.Lat);
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            string cmd = string.Empty;
            DisplayInput();
            while ((cmd = Console.ReadLine()).ToUpper() != "X")
            {
                switch (cmd)
                {
                    case "1":
                        Console.WriteLine();
                        DoZipLookup();
                        break;
                    case "2":
                        Console.WriteLine();
                        DoCityLookup();
                        break;
                }
                DisplayInput();
            }
        }
    }
}
