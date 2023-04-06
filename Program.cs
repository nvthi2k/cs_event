// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace CS_Event // Note: actual namespace depends on the project name.
{
    public delegate void Sukiennhapvao(int a);
    class Dulieunhap : EventArgs
    {
        public int data { get; set; }
        public Dulieunhap(int x) => data = x;
    }
    public class NhapSo
    {
        //public event Sukiennhapvao sknv;
        public event EventHandler? sknv;
        public void NhanSoTuBP()
        {
            do
            {
                try
                {
                    string? s = Console.ReadLine();
                    if (s != null)
                    {
                        int i = Int32.Parse(s);
                        sknv?.Invoke(this, new Dulieunhap(i));
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (true);
        }
    }
    class TinhCan
    {
        public void Sub(NhapSo ns)
        {
            ns.sknv += CanBac2;
        }
        public void CanBac2(object? sender, EventArgs e)
        {
            Dulieunhap dulieunhap = (Dulieunhap)e;
            int i = dulieunhap.data;
            Console.WriteLine($"Can bac 2 cua {i}: {Math.Sqrt(i)}");
        }
    }

    class BinhPhuong
    {
        public void Sub(NhapSo ns)
        {
            ns.sknv += BP;
        }
        public void BP(object? sender, EventArgs e)
        {
            Dulieunhap dulieunhap = (Dulieunhap)e;
            int i = dulieunhap.data;
            Console.WriteLine($"Binh phuong cua {i}: {i * i}");
        }
    }
    // Mo rong phuong thuc / Extention Method
    static class Abc
    {
        public static void Print(this string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }

    //Dinh nghia toan tu

    class Vector
    {
        public double x { get; set; }
        public double y { get; set; }

        public Vector(double _x, double _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public Vector()
        {
        }

        public void ShowInfo()
        {
            Console.WriteLine($"x = {x}; y = {y}");
        }

        public static Vector operator +(Vector x1, Vector x2)
        {
            return new Vector(x1.x + x2.x, x1.y + x2.y);
        }

        public static Vector operator +(Vector x0, double a)
        {
            return new Vector(x0.x + a, x0.y + a);
        }

        //Xay dung Indexer[int]
        public double this[int i]
        {
            set
            {
                switch (i)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    default:
                        throw new Exception("Chi so sai");

                }
            }
            get
            {
                switch (i)
                {
                    case 0:
                        return x;

                    case 1:
                        return y;

                    default:
                        throw new Exception("Chi so sai");

                }
            }
        }

        public double this[string s]
        {
            set
            {
                switch (s)
                {
                    case "x":
                        x = value;
                        break;
                    case "y":
                        y = value;
                        break;
                    default:
                        throw new Exception("Chi so sai");

                }
            }
            get
            {
                switch (s)
                {
                    case "x":
                        return x;

                    case "y":
                        return y;

                    default:
                        throw new Exception("Chi so sai");

                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // // publisher
            // NhapSo ns = new NhapSo();

            // // subcriber
            // ns.sknv += (sender,e) => 
            // {
            //     Dulieunhap dulieunhap = (Dulieunhap)e;
            //     Console.WriteLine($"Ban vua nhap so {dulieunhap.data}");
            // };

            // TinhCan tc = new TinhCan();
            // tc.Sub(ns);
            // BinhPhuong bp = new BinhPhuong();
            // bp.Sub(ns);

            // ns.NhanSoTuBP();
            // "Lo".Print(ConsoleColor.Blue);


            // Thiet lap toan tu va Indexer[int]
            // Vector x = new Vector(2,3);
            // Vector y = new Vector(4,5);
            // Vector z = x + y;
            // z.ShowInfo();
            // z = x + 3;
            // z.ShowInfo();
            // z[0] = 2;
            // z[1] = 10;
            // z.ShowInfo();
            // //z[3] = 2;
            // z["x"] = 10;
            // z["y"] = 29;
            // z.ShowInfo();


            // int a = 5;
            // int b = 4;
            // Console.WriteLine($"{(double)(a/b)}");

            // string s = "2";
            // string.IsNullOrEmpty(s);


            //LIST
            // List<int> ds1 = new List<int>();
            // ds1.AddRange(new int[] {3,4,5,6,3,2,1});

            // foreach(var i in ds1){
            //     Console.WriteLine($"{i}");    
            // }

            // var v = ds1.Find(
            //     (p) => {
            //         return p > 3;
            //     }
            // );
            // Console.WriteLine(v);

            // ds1.Sort(
            //     (i1,i2) => {
            //         if (i1==i2) return 0;
            //         if (i1<i2) return 1;
            //         return -1;
            //     } 
            // );
            // foreach(var i in ds1){
            //     Console.WriteLine($"{i}");    
            // }


            //SortedList
            // SortedList<string,Vector> dsi = new SortedList<string, Vector>();
            // dsi["1"] = new Vector(2,2);
            // dsi["2"] = new Vector(){x = 5, y = 4};

            // foreach (KeyValuePair<string,Vector> i in dsi){
            //     Console.WriteLine($"Vector {i.Key}: ({i.Value.x},{i.Value.y})");
            // }


            //File
            // string path = "abc.txt";

            // string content = "tiếng việt" + Environment.NewLine;
            // string content2 = "tiếng anh";
            // File.AppendAllTextAsync(path,content,Encoding.UTF8,default);

            // using var stream = new FileStream("new.dat",FileMode.Create);

            // byte[] buffer = {1,2,3};
            // int offset = 0;
            // int count = 3;

            // stream.Write(buffer,offset,count); 

            // int sobytedocduoc = stream.Read(buffer,offset,count);
            // Console.WriteLine($"{sobytedocduoc}");


            //Async - Await
            // for (int i = 0; i<5; i++){
            //     Thread.Sleep(1000);
            //     Console.WriteLine($"Hello lan {i, 3}" );
            // }


            // Action<char> s = (s) => Console.WriteLine(s);

            // char c = Convert.ToChar("c");

            // s(c);

            // Func<int, int, int> Tong =
            //     (T1, T2) =>
            //     {
            //         return T1 + T2;
            //     };
            // Console.WriteLine($"Tong cua 4 va 99 la: {Tong(4, 99)}");


            Regex reg = new Regex(@".");
            Match result = reg.Match("ancdjad - 4129494");
            Action<Match> ss = (result) =>
            {
                do
                {
                    Console.WriteLine(result.ToString());
                    result = result.NextMatch();
                }
                while (result != Match.Empty);


            };
            ss(result);
            //AttributeName

            

        }
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property)]
        class MotaAttribute : Attribute{
                public string Thongtinchitiet { get; set; }
                public MotaAttribute(string name)
                {
                    Thongtinchitiet = name;
                }
        }
        class User{
            public string Name { get; set; }

            public int Age { get; set; }

            public string PhoneNumber { get; set; }
            
            public string Email { get; set; }

            public User(string name, int age, string phoneNumber, string email){
                Name = name;
                Age = age;
                PhoneNumber = phoneNumber;
                Email = email;
            }
        }
    }
}