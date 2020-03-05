using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;


namespace Cwiczenie1
{


    public class Student
    {
        //Wlasciwosci (skrocona) -> prom -> Tba -> Tab
        public string Nazwisko{ get; set; }

        private String naziwsko;
        private String imie;
        private String Imie
        {
            get { return imie; }
            set
            {
                if (value == null) throw new AccessViolationException();
                imie = value;
            }
        }


        public String getNazwisko()
        {
            return naziwsko;
        }

        public void setNazwisko(String n)
        {
            this.naziwsko = n;
        }
    }




   public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var st = new Student();
                st.Nazwisko = "Kowalski";


                var url = args.Length > 0 ? args[0] : "http://www.pja.edu.pl";

                if (args.Length == 0)
                    return;


                var client = new HttpClient();
                var result = await client.GetAsync("http://www.pja.edu.pl");
                //new Thread().Start();
                //ThreadPool()
                if (!result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error");
                    return;
                }


                if (result.IsSuccessStatusCode)
                {
                    string html = await result.Content.ReadAsStringAsync();
                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+");
                    var matches = regex.Matches(html);

                    //Kolekcje
                    var set = new HashSet<String>();
                    //LINQ

                    var list = new List<String>();
                    var elementy = from e in list
                                   where e.StartsWith("A")
                                   select e;
                    var elementy2 = list.Where(s => s.StartsWith("A"));


                    var slownik = new Dictionary<String, String>();

                    foreach (var m in matches)
                    {
                        Console.WriteLine(m);
                    }

                }

            }
            catch(Exception exc)
            {
                //Logowanie
               // string.Format("wystapil blad {0}", exc.ToString());
                Console.WriteLine($"Wystapil blad! {exc.ToString()}");
            }

            Console.WriteLine("Finish!");
        }
    }
}
