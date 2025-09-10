namespace Lemmikit_SQlite_Csharp;

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
    public void LisaaOmistja(string nimi, string puhelin)
    {
        //Luodaan yhteys tietokantaan
        using var connection = new SqliteConnection(_connectionstring);
        connection.Open();
        //Lisätään omistaja tietokantaan
        var commandForInsert = connection.CreateCommand();
        commandForInsert.CommandText = "INSERT INTO Omistajat (nimi, puhelin) VALUES (@Nimi, @Puhelin)";
        commandForInsert.Parameters.AddWithValue("Nimi", nimi);
        commandForInsert.Parameters.AddWithValue("Puhelin", puhelin);
        commandForInsert.ExecuteNonQuery();
    }

    //Lisää lemmikin
    public void LisaaLemmikki(string nimi, string laji)
    {   
        //Luodaan yhteys tietokantaan
        using var connection = new SqliteConnection(_connectionstring);
        connection.Open();
        //Lisätään lemmikki tietokantaan
        var command = connection.CreateCommand();
        command.CommandText =
            "INSERT INTO Lemmikit (nimi, laji, omistajan_id) VALUES (@Nimi, @Laji)";
        command.Parameters.AddWithValue("Nimi", nimi);
        command.Parameters.AddWithValue("Laji", laji);
        command.ExecuteNonQuery();
    }

}