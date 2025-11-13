using System;

namespace Exam2_Review_Codes
{
    public class Customer
    {
        public int customerId;
        public string name;
        public string email;
        public string phone;
        public string address;

        public Customer(int id, string n, string e)
        {
            if (id > 0) customerId = id;
            else Console.WriteLine("CustomerId must be > 0");

            if (!string.IsNullOrWhiteSpace(n)) name = n;
            else Console.WriteLine("Name cannot be empty");

            if (!string.IsNullOrWhiteSpace(e) && e.Contains("@")) email = e;
            else Console.WriteLine("Invalid email");

            phone = "";
            address = "";
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Customer Id: " + customerId + ", Name: " + name + ", Email: " + email);
            Console.WriteLine("Phone: " + (string.IsNullOrEmpty(phone) ? "Not provided" : phone));
            Console.WriteLine("Address: " + (string.IsNullOrEmpty(address) ? "Not provided" : address));
        }
    }
}


