namespace Lemmikit_SQlite_Csharp;
using Microsoft.Data.Sqlite;

class Program
{
    static void Main(string[] args)
    {
        LemmikkiDB lemmikkiDB = new LemmikkiDB();
        bool jatka = true;

        while (jatka)
        {
            Console.WriteLine("Lisää omistja (1)");
            Console.WriteLine("Lisää lemmikki (2)");
            Console.WriteLine("Päivitä puhelinnumerota (3)");
            Console.WriteLine("Etsi lemmikin nimen perusteella omistjan puhelinnumero (4)");
            Console.WriteLine("Lopeta (5)");

            string? valinta = Console.ReadLine();

            switch (valinta)
            {
                case "1":
                    break;

                case "2":
                    break;

                case "3":
                    break;

                case "4":
                    break;

                case "5":
                    jatka = false;
                    Console.WriteLine("Ohjelma sulkeutuu...");
                    break;

                default:
                    Console.WriteLine("Anna oikea valinta");
                    break;

                
            }


        }
    }
}
