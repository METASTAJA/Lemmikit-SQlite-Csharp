namespace Lemmikit_SQlite_Csharp;

using System.Data;
using Microsoft.Data.Sqlite;

public class LemmikkiDB
{
    private string _connectionstring = "Data Source = lemmikki.db";

    //Rakentaja
    public LemmikkiDB()
    {
        //Luodaan yhteys tietokantaan
        using var connection = new SqliteConnection(_connectionstring);
        //avaa yhteyden tietokantaan
        connection.Open();
        //luodaan taulut, jos niitä ei vielä ole
        //Omistajat taulu
        var commandForOmistjat = connection.CreateCommand();
        commandForOmistjat.CommandText = "CREATE TABLE IF NOT EXISTS Omistajat (id INTEGER PRIMARY KEY,nimi TEXT,puhelin TEXT)";
        commandForOmistjat.ExecuteNonQuery(); //emmen odota vastausta tältä komennolta

        //Lemmitikit taulu
        var commandForLemmikit = connection.CreateCommand();
        commandForLemmikit.CommandText = "CREATE TABLE IF NOT EXISTS Lemmikit (id INTEGER PRIMARY KEY,nimi TEXT,laji TEXT,omistajan_id INTEGER)";
        commandForLemmikit.ExecuteNonQuery(); //emmen odota vastausta tältä komennolta
    }

    //Lisää omistjan
    public void LisaaOmistaja(string nimi, string puhelin)
    {
        //Luodaan yhteys tietokantaan
        using (var connection = new SqliteConnection(_connectionstring))
        {
            connection.Open();
            //Lisätään omistaja tietokantaan
            var commandForInsert = connection.CreateCommand();
            commandForInsert.CommandText = "INSERT INTO Omistajat (nimi, puhelin) VALUES (@Nimi, @Puhelin)";
            commandForInsert.Parameters.AddWithValue("Nimi", nimi);
            commandForInsert.Parameters.AddWithValue("Puhelin", puhelin);
            commandForInsert.ExecuteNonQuery();

             Console.WriteLine("Omistaja lisätty");
        }
        
    }

    //Lisää lemmikin
    public void LisaaLemmikki(string nimi, string laji, string omistajannimi)
    {
        //Luodaan yhteys tietokantaan
        using (var connection = new SqliteConnection(_connectionstring))
        {
            connection.Open();
            //Haetaan omistajan id
            var command1 = connection.CreateCommand();
            command1.CommandText = "SELECT id FROM Omistajat WHERE nimi = @Nimi";
            command1.Parameters.AddWithValue("Nimi", omistajannimi);
            object? idObj = command1.ExecuteScalar();

            if (idObj == null)
            {
                Console.WriteLine("Omistajaa ei löytynyt!");
                return;
            }

            int omistajanid = Convert.ToInt32(idObj);

            //Lisätään lemmikki tietokantaan
            var command2 = connection.CreateCommand();
            command2.CommandText = "INSERT INTO Lemmikit (nimi, laji, omistajan_id) VALUES (@Nimi, @Laji, @Omistajanid)";
            command2.Parameters.AddWithValue("Nimi", nimi);
            command2.Parameters.AddWithValue("Laji", laji);
            command2.Parameters.AddWithValue("Omistajaid", omistajanid);
            command2.ExecuteNonQuery();
            
             Console.WriteLine("Lemmikki lisätty");
        }
    }

}