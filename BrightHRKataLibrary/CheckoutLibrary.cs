using System;
using System.Collections.Generic;
using System.Linq;

namespace BrightHRKataLibrary
{
    public interface ICheckoutLibrary
    {
        void Scan(string item, ref List<Tuple<string,int>> list);

        int GetTotal(ref List<Tuple<string, int>> list);
    }

    public class Checkout : ICheckoutLibrary
    {
        void ICheckoutLibrary.Scan(string item, ref List<Tuple<string, int>> list)
        {
            if (list.Any(m => m.Item1 == item))
            {

                list[list.FindIndex(m => m.Item1 == item)] = new Tuple<string, int>(item, list[list.FindIndex(m => m.Item1 == item)].Item2 + 1);
            }
            else
            {
                list.Add(new Tuple<string, int>(item, 1));
            }
        }

        int ICheckoutLibrary.GetTotal(ref List<Tuple<string, int>> list)
        {

            int totalCost = 0;
            if (list.Any())
            {
                foreach (Tuple<string, int> item in list)
                {
                    switch (item.Item1)
                    {
                        case "A":
                            totalCost += ((item.Item2 / 3) * 130);
                            totalCost += (item.Item2 % 3) * 50;
                            break;

                        case "B":
                            totalCost += ((item.Item2 / 2) * 45);
                            totalCost += (item.Item2 % 2) * 30;
                            break;

                        case "C":
                            totalCost += (item.Item2 * 20);
                            break;

                        case "D":
                            totalCost += (item.Item2 * 15);
                            break;
                    }

                }
                return totalCost; 
            }
            else
            {
                return totalCost;
            }
        }
    }
}
