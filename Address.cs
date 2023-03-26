using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHW
{
    internal class Address
    {
        private string m_country;
        private string m_city;
        private string m_street;
        private string m_houseNumber;    

        public Address(string country = "", string city = "", string street = "", string houseNumber = "")
        {
            m_country = country;
            m_city = city;
            m_street = street;
            m_houseNumber = houseNumber;
            Console.WriteLine("Address created");
        }

        public string GetCountry() { return m_country; }
        public string GetCity() { return m_city; }
        public string GetStreet() { return m_street; }
        public string GetHouseNumber() { return m_houseNumber; }
        public override string ToString()
        {
            return "\t\tAddress\nCountry:" + m_country + "\t\tCity: " + m_city + "\nStreet: " + m_street + "\t\tHouseNumber: " + m_houseNumber;
        }
    }
}
