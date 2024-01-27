using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLinqUnitests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string name  ="DonauDampfSchiffFahrtsKapitän";
        public static List<string> stringList = new List<string> { "Andi", "Berta", "Caesar",
        "Dieter", "Emil", "Franz", "Gerlinde" };

        public static int[] numbers = new int[] { 1, 3, 6, 7, 9, 12, 13, 17 };

        public static List<string> PatientenStringList = new List<string> { "Gustav Gips", "Hans Halsweh", "Gunther Grippe", "Giesela Grippe","Birgit Bauchweh"};
        public MainWindow()
        {
            InitializeComponent();
        }
        public static int AnzahlUnterschiedlicheBuchstaben_Lambda(string name)
        {
            var lb = name.Select(x=>x.ToString().ToLower()).Distinct().ToList();
            return lb.Count();
        } 
        public static List<string> AnzahlmitMax5Buchstaben_Lambda(List<string> name)
        {
            var lb = name.Where(x=>x.Count() <= 5).OrderByDescending(x=>x.ToLower()).Select(x=>x.ToUpper()).ToList();
            return lb;
        }
        public static List<string> AnzahlmitMax5Buchstaben_Querry(List<string> name)
        {
            var lb = from x in name where x.Count() <= 5 orderby x.ToLower() descending select x.ToUpper() ;
                //name.Where(x=>x.Count() <= 5).OrderByDescending(x=>x.ToLower()).Select(x=>x.ToUpper()).ToList();
            return lb.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int numOfChars = AnzahlUnterschiedlicheBuchstaben_Lambda(name);
            lboOutputs.Items.Add($"Anzahl der unterschiedlichen Buchstaben: {numOfChars}");
            lboOutputs.Items.Add($"////////////////////////////////////////////////////");
            lboOutputs.Items.Add($"");
            List<string> names5 = AnzahlmitMax5Buchstaben_Lambda(stringList);

           foreach (var item in names5)
            {
                lboOutputs.Items.Add(item);
            }

            lboOutputs.Items.Add($"////////////////////////////////////////////////////");
            lboOutputs.Items.Add($"");
             names5 = AnzahlmitMax5Buchstaben_Querry(stringList);

            foreach (var item in names5)
            {
                lboOutputs.Items.Add(item);
            }

            lboOutputs.Items.Add($"////////////////////////////////////////////////////");
            lboOutputs.Items.Add($"");
            
            int nums = AnzahlUngeradeZahlen_Lambda(numbers);

            lboOutputs.Items.Add($"{nums}");


            lboOutputs.Items.Add($"////////////////////////////////////////////////////");
            lboOutputs.Items.Add($"");
            nums = AnzahlUngeradeZahlen_Query(numbers);

            lboOutputs.Items.Add($"{nums}");


            lboOutputs.Items.Add($"////////////////////////////////////////////////////");
            lboOutputs.Items.Add($"");
            List<double> numLists = ZweistelligeZahlen_Lambda(numbers);

            foreach (var item in numLists)
            {
                lboOutputs.Items.Add(item);
            }

            lboOutputs.Items.Add($"////////////////////////////////////////////////////");
            lboOutputs.Items.Add($"");
            numLists = ZweistelligeZahlen_Query(numbers);

            foreach (var item in numLists)
            {
                lboOutputs.Items.Add(item);
            }

            lboOutputs.Items.Add($"////////////////////////////////////////////////////");
            lboOutputs.Items.Add($"");
            
            string[] nameList = NamenStringArray_Lambda(PatientenStringList);

            foreach (var item in nameList)
            {
                lboOutputs.Items.Add(item);
            }

            lboOutputs.Items.Add($"////////////////////////////////////////////////////");
            lboOutputs.Items.Add($"");

            nameList = NamenStringArray_Query(PatientenStringList);

            foreach (var item in nameList)
            {
                lboOutputs.Items.Add(item);
            }

            lboOutputs.Items.Add($"////////////////////////////////////////////////////");
            lboOutputs.Items.Add($"");
            Dictionary<char, int> names = KrankheitCountDictionary_Lambda(PatientenStringList);
            foreach (var item in names)
            {
                lboOutputs.Items.Add(item.ToString());
            }
        }

        public static int AnzahlUngeradeZahlen_Lambda(int[] num)
        {
            var lb = num.Where(x=> x%2==1).ToList();

            return lb.Count();
        }
        public static int AnzahlUngeradeZahlen_Query(int[] num)
        {
            var lb = from x in num where x%2==1 select x;
            return lb.ToList().Count();
        }

        public static List<double> ZweistelligeZahlen_Lambda(int[] num)
        {
            var lb = num.Where(x => Math.Abs(x).ToString().Count() == 2).Select(x => x * 2.5).ToList();
            return lb;
        }
        public static List<double> ZweistelligeZahlen_Query(int[] num)
        {
            var lb = from x in num where Math.Abs(x).ToString().Count() == 2 select x * 2.5;
            return lb.ToList();
        }
        public static string[] NamenStringArray_Lambda(List<string> namen)
        {
            var lb = namen.OrderBy(x => x.Split(' ')[1][1]).Select(x=>$"{x.Split(' ')[1]} bei {x.Split(' ')[0]}").ToArray();

            return lb;

        }
        public static string[] NamenStringArray_Query(List<string> namen)
        {

            var lb = from x in namen orderby x.Split(' ')[1][1] ascending select $"{x.Split(' ')[1]} bei {x.Split(' ')[0]}";

            return lb.ToArray();
        }
        public static Dictionary<char, int> KrankheitCountDictionary_Lambda(List<string> namen)
        {
            var lb = namen.GroupBy(x => x.Split(' ')[1][0]).ToDictionary(x=> x.Key, x=>x.Count());

            return lb;
        }




    }
}
