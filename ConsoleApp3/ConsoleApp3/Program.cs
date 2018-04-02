using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            bool ba = true;
            bool b = a.functie(!ba);
            Person p = new Person("aaa", "111");
            Console.WriteLine(p);
            string s = "   1 - 3   ";
            string s1 = s.Trim();
            Console.WriteLine(s1);
            a.f1(5);
            a.f1(true);
            float floatNumber = 2.5F;
            decimal decimalNumber = (decimal)floatNumber;
            Console.WriteLine(decimalNumber);
            Console.WriteLine(ExampleEnum.G);

            float floarNr = 3.23456788F;
            string stringNr = floarNr.ToString("##.##");
            float floatNr2 = float.Parse(floarNr.ToString("##.##"));
            Console.WriteLine(floatNr2);
            Console.WriteLine("------------------------------------");
            IA iA = new C();
            iA.F1();
            D d = new D();
            d.F1();
            Console.WriteLine("------------------------------------");
            int x = 2, y = 10;
            string result = x > y ? "x is greater than y" : x < y ?
                                                        "x is less than y" : x == y ?
                                                                    "x is equal to y" : "No result";
            Console.WriteLine(result);
            Console.WriteLine("------------------------------------");
            float number = 12.3456789F;
            float rounded = (float)(Math.Round((double)number, 2));
            Console.WriteLine(rounded);

            IEnumerable<object> list = new List<string>() { "1", "2", "3", "4", "5" };
            int index = list.ToList().IndexOf("4");

            Utils utils = new Utils();
            string description = utils.GetDescription(EnumWithDescription.Element1);

            var aaa = EnumWithDescription.Element1.ToString();

            var data = DateTime.Now.Date.AddHours(12);

            var middayToday = new DateTimeOffset(DateTimeOffset.Now.Date.AddHours(12), new TimeSpan(0));

            A aaaa;
            B bbbb = new B();
            aaaa = bbbb;
            bbbb.AnrPublic = 10;

            Colors itemEnum = (Colors)Enum.Parse(typeof(Colors), "Green");
            Colors itemEnum2;
            Enum.TryParse("Red", out itemEnum2);

            string pattern = null;
            string message;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (Regex.IsMatch("feedback.@net-informations.com", pattern))
            {
                message = "Valid Email address ";
            }
            else
            {
                message = "Not a valid Email address ";
            }

            String replace = "abc_def";
            replace = replace.Replace("a", "A");
            List<string> list1 = new List<string>() { "aaa", "bbb", "ccc", "ddd" };

            List<string> list2 = new List<string>() { "ccc", "aaa-bbb-aaa", "aaa-bbb" };
            var s3 = list2.Where(_ => _.Contains("aaa")).ToList();
            //string s3 = "aaa-bbb-aaa";
            int counter = 0;
            s3.ForEach(_ => counter += Regex.Matches(_, "aaa").Cast<Match>().Count());
            //s3.Where(_ => Regex.Matches(_, "aaa").Cast<Match>().Count() > 1);
            var b1 = Regex.Matches(s3.First(), "aaa").Cast<Match>().Count();
            //var b3 = s3.Count(_ => _ == "a");
            //var b3 = b1.Count(_ => _.Contains("aaa"));
            //var b2 = list2.First(_ => _.Contains("aaa"));

            var result1 = list1.Where(_ => _ == "aaa").ToList();

            Console.ReadKey();
        }
    }

    class A
    {
        private int AnrPrivat;
        public int AnrPublic;
        protected int AnrProtected;

        public bool functie(bool b)
        {
            return b;
        }

        public void f1(int a)
        {
            Console.WriteLine("f1-int");
        }

        public void f1(bool a)
        {
            Console.WriteLine("f1-bool");
        }
    }

    class B : A
    {
        private int BnrPrivat;
        public int BnrPublic;
        protected int BnrProtected;
    }

    public enum ExampleEnum
    {
        N, i = 7, G
    };

    public interface IA
    {
        void F1();
    }

    public class C : IA
    {
        public void F1()
        {
            Console.WriteLine("F1 - C:IA");
        }
    }

    public abstract class AbstractClass
    {
        virtual public void F1()
        {
            Console.WriteLine("F1 - AbstractClass");
        }
    }

    public class D : AbstractClass
    {
        override public void F1()
        {
            Console.WriteLine("F1 - D:AbstractClass");
        }
    }

    public enum EnumWithDescription
    {
        [Description("First (Element)")]
        Element1,
        [Description("SecondElement")]
        Element2,
        [Description("ThirdElement")]
        Element3
    };

    public class Utils
    {
        public string GetDescription(object enumValue)
        {
            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());

            if (null != fi)
            {
                object[] attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return string.Empty;
        }
    }

    public enum Colors { None = 0, Red = 1, Green = 2, Blue = 4 };

}
