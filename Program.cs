using static System.Reflection.Metadata.BlobBuilder;

namespace Konzolos_1.feladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.Feladat
            // Lista letrehozasa es fajl beolvasasa
            List<Books> books_list = new List<Books>();
            string[] lines = File.ReadAllLines("books.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(',');
                Books books_object = new Books(values[0], values[1], values[2], values[3], values[4]);
                books_list.Add(books_object);
            }

            Console.WriteLine("4.Feladat");
            foreach (var item in books_list)
            {
                Console.WriteLine($"{item.sorszam} {item.kategoria} {item.konyv} {item.ar} {item.db}");
            }
            Console.WriteLine("5.Feladat");
            //2.Feladat
            //ciklussal vegigmegy a tombon es az item ertekhez hozzaadja a db "erteket"
            int osszdb = 0;
            foreach (var item in books_list)
            {

                osszdb += item.db;


            }
            Console.WriteLine($"Az össz darabszám: {osszdb} db");

            Console.WriteLine("6.Feladat");
            //ciklussal vegig megy a tombon a book.cs-ben hasznalt konstruktor segitsegevel 
            foreach (var book in books_list)
            {
                if (book.kategoria.Equals("Regény"))
                {

                    Console.WriteLine($"A regény kategóriában lévő könyv címe és ára: {book.kategoria},  {book.konyv}, {book.ar} ");
                }
            }

            Console.WriteLine("7.Feladat");
            //kulcs-ertek tarolas ciklussal
            Dictionary<string, int> kategoriak = new Dictionary<string, int>();

            foreach (var item in books_list)
            {
                if (kategoriak.ContainsKey(item.kategoria))
                {
                    kategoriak[item.kategoria]++;
                }
                else
                {
                    kategoriak[item.kategoria] = 1;
                }
            }

            Console.WriteLine("\nKategóriák és termékek száma:");
            foreach (var kvp in kategoriak)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} termék");
            }



            Console.WriteLine("8.Feladat");
            //lista letrehozasa legolcsobb konyveknek amit ciklussal keressuk meg
            List<Books> legolcsobbak = new List<Books>(); 
            Books legolcsobb = books_list[0];
            legolcsobbak.Add(legolcsobb); 

            foreach (var termek in books_list)
            {
                if (termek.ar < legolcsobb.ar)
                {
                    legolcsobb = termek;
                    legolcsobbak.Clear(); 
                    legolcsobbak.Add(legolcsobb);
                }
                else if (termek.ar == legolcsobb.ar)
                {
                    
                    legolcsobbak.Add(termek);
                }
            }

            Console.WriteLine("\nLegolcsóbb termek(ek) adatai:");
            foreach (var legolcsobbTermek in legolcsobbak)
            {
                Console.WriteLine($"Kategória: {legolcsobbTermek.kategoria}, {legolcsobbTermek.konyv}, Ár: {legolcsobbTermek.ar}");
            }


            Console.ReadKey();
        }
    }
}