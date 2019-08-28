using System;

namespace BrightHRKataLibrary
{
    public class CheckoutLibrary
    {
        interface ICheckout
        {
            void Scan(string item);

            int GetTotalPrice();
        }

        void Scan (string item)
        {

        }

        int GetToalPrice()
        {

            return 0;
        }
    }
}
