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
            return 0;
        }
    }
}
