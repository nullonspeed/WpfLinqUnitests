using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace UnitTestProjectLinq
{
    [TestClass]
    public class UnitTest1 
    {
        [TestMethod]
        public void TestMethod_AnzUntersch_Buchstaben()
        {
            int count = WpfLinqUnitests.MainWindow.AnzahlUnterschiedlicheBuchstaben_Lambda(WpfLinqUnitests.MainWindow.name);
            Assert.AreEqual(16, count);
        }
        [TestMethod]
        public void TestMethod_Max5_Buchstaben()
        {
            List<string> count = WpfLinqUnitests.MainWindow.AnzahlmitMax5Buchstaben_Lambda(WpfLinqUnitests.MainWindow.stringList);
            List<string> expectedList = new List<string> { "FRANZ", "EMIL", "BERTA", "ANDI" };
            Assert.AreEqual(expectedList.Count, count.Count);
            CollectionAssert.AreEqual(expectedList, count);
        }
        [TestMethod]
        public void TestMethod_Max5_Buchstaben_Querry()
        {
            List<string> count = WpfLinqUnitests.MainWindow.AnzahlmitMax5Buchstaben_Querry(WpfLinqUnitests.MainWindow.stringList);
            List<string> expectedList = new List<string> { "FRANZ", "EMIL", "BERTA", "ANDI" };
            Assert.AreEqual(expectedList.Count, count.Count);
            CollectionAssert.AreEqual(expectedList, count);
        }


        [TestMethod]
        public void TestMethod_UngeradeLambda()
        {
            int count = WpfLinqUnitests.MainWindow.AnzahlUngeradeZahlen_Lambda(WpfLinqUnitests.MainWindow.numbers);
            //List<string> expectedList = new List<string> { "FRANZ", "EMIL", "BERTA", "ANDI" };
            Assert.AreEqual(6, count);
            //CollectionAssert.AreEqual(expectedList, count);
        }
        [TestMethod]
        public void TestMethod_UngeradeQuerry()
        {
            int count = WpfLinqUnitests.MainWindow.AnzahlUngeradeZahlen_Query(WpfLinqUnitests.MainWindow.numbers);
            //List<string> expectedList = new List<string> { "FRANZ", "EMIL", "BERTA", "ANDI" };
            Assert.AreEqual(6, count);
            //CollectionAssert.AreEqual(expectedList, count);
        }
        [TestMethod]
        public void TestMethod_ZweistelligLambda()
        {
            List<double> count = WpfLinqUnitests.MainWindow.ZweistelligeZahlen_Lambda(WpfLinqUnitests.MainWindow.numbers);
            List<double> expList = new List<double> { 12 * 2.5, 13 * 2.5, 17 * 2.5 };
            Assert.AreEqual(expList.Count, count.Count);
            CollectionAssert.AreEqual(expList, count);
        }
        [TestMethod]
        public void TestMethod_ZweistelligQuerry()
        {
            List<double> count = WpfLinqUnitests.MainWindow.ZweistelligeZahlen_Query(WpfLinqUnitests.MainWindow.numbers);
            List<double> expList = new List<double> { 12 * 2.5, 13 * 2.5, 17 * 2.5 };
            Assert.AreEqual(expList.Count, count.Count);
            CollectionAssert.AreEqual(expList, count);
        }
        [TestMethod]
        public void TestMethod_stringArrayLambda()
        {
            string[] count = WpfLinqUnitests.MainWindow.NamenStringArray_Lambda(WpfLinqUnitests.MainWindow.PatientenStringList);

        string[] stringArrayExp = new string[] { "Halsweh bei Hans", "Bauchweh bei Birgit",
        "Gips bei Gustav", "Grippe bei Gunther", "Grippe bei Giesela" };

            Assert.AreEqual(stringArrayExp.Length, count.Length);
            CollectionAssert.AreEqual(stringArrayExp, count);
        }
        [TestMethod]
        public void TestMethod_StringArrayQuerry()
        {
            string[] count = WpfLinqUnitests.MainWindow.NamenStringArray_Query(WpfLinqUnitests.MainWindow.PatientenStringList);
        string[] stringArrayExp = new string[] { "Halsweh bei Hans", "Bauchweh bei Birgit",
        "Gips bei Gustav", "Grippe bei Gunther", "Grippe bei Giesela" };
            Assert.AreEqual(stringArrayExp.Length, count.Length);
            CollectionAssert.AreEqual(stringArrayExp, count);
        }

        [TestMethod]
        public void TestMethod_Dictionary_Querry()
        {
            Dictionary<char, int> count = WpfLinqUnitests.MainWindow.KrankheitCountDictionary_Lambda(WpfLinqUnitests.MainWindow.PatientenStringList);
            Dictionary<char, int> dic = new Dictionary<char, int>();
            dic.Add('G', 3); dic.Add('H', 1); dic.Add('B', 1);
            Assert.AreEqual(dic.Count, count.Count);
            CollectionAssert.AreEqual(dic, count);
        }




    }
}
