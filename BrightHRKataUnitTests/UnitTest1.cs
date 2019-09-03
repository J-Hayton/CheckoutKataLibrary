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

            checkout.Scan(item, list);

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

            checkout.Scan(item, list);

            Assert.AreEqual(list, controlList);
        }

        [Test]
        public void Scan_TestAddingExistingItemToList()
        {
            List<Tuple<string, int>> controlList = new List<Tuple<string, int>>();
            controlList.Add(new Tuple<string, int>("A", 2));

            list.Add(new Tuple<string, int>("A", 1));

            string item = "A";

            checkout.Scan(item, list);

            Assert.AreEqual(list, controlList);
        }
    }
}