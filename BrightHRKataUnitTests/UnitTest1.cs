using NUnit.Framework;
using BrightHRKataLibrary;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        Checkout checkout; 
        List<Tuple<string, int>> list;

        [SetUp]
        public void Setup()
        {
            checkout = new Checkout();
            list = new List<Tuple<string, int>>();

        }

        [Test]
        public void Scan_TestAddingNewItemToEmptyList()
        {
            List<Tuple<string, int>> controlList = new List<Tuple<string, int>>();
            controlList.Add(new Tuple<string, int>("A", 1));

            string item = "A";

            ((ICheckoutLibrary)checkout).Scan(item, ref list);
            

            Assert.AreEqual(list, controlList);
        }

        [Test]
        public void Scan_TestAddingNewItemToListWithOtherItems()
        {
            List<Tuple<string, int>> controlList = new List<Tuple<string, int>>();
            controlList.Add(new Tuple<string, int>("B", 1));
            controlList.Add(new Tuple<string, int>("A", 1));

            list.Add(new Tuple<string, int>("B", 1));

            string item = "A";

            ((ICheckoutLibrary)checkout).Scan(item, ref list);

            Assert.AreEqual(list, controlList);
        }

        [Test]
        public void Scan_TestAddingExistingItemToList()
        {
            List<Tuple<string, int>> controlList = new List<Tuple<string, int>>();
            controlList.Add(new Tuple<string, int>("A", 2));

            list.Add(new Tuple<string, int>("A", 1));

            string item = "A";

            ((ICheckoutLibrary)checkout).Scan(item, ref list);

            Assert.AreEqual(list, controlList);
        }


        [Test]
        public void GetTotal_TestSingleItem()
        {
            int controlPrice = 15;
            string item = "D";

            ((ICheckoutLibrary)checkout).Scan(item,ref list);

            Assert.AreEqual(((ICheckoutLibrary)checkout).GetTotal(ref list), controlPrice);
        }

        [Test]
        public void GetTotal_TestMultiItems()
        {
            int controlPrice = 65;
            string item1 = "D";
            string item2 = "A";

            ((ICheckoutLibrary)checkout).Scan(item1, ref list);
            ((ICheckoutLibrary)checkout).Scan(item2, ref list);

            Assert.AreEqual(((ICheckoutLibrary)checkout).GetTotal(ref list), controlPrice);
        }

        [Test]
        public void GetTotal_TestBulkSpecialItems()
        {
            int controlPrice = 130;
            string item1 = "A";

            ((ICheckoutLibrary)checkout).Scan(item1, ref list);
            ((ICheckoutLibrary)checkout).Scan(item1, ref list);
            ((ICheckoutLibrary)checkout).Scan(item1, ref list);

            Assert.AreEqual(((ICheckoutLibrary)checkout).GetTotal(ref list), controlPrice);
        }

        [Test]
        public void GetTotal_TestBulkSpecialItemsUneven()
        {
            int controlPrice = 180;
            string item1 = "A";

            ((ICheckoutLibrary)checkout).Scan(item1, ref list);
            ((ICheckoutLibrary)checkout).Scan(item1, ref list);
            ((ICheckoutLibrary)checkout).Scan(item1, ref list);
            ((ICheckoutLibrary)checkout).Scan(item1, ref list);

            Assert.AreEqual(((ICheckoutLibrary)checkout).GetTotal(ref list), controlPrice);
        }
    }
}