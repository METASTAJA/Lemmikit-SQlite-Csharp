namespace Lemmikit_SQlite_Csharp;

using Microsoft.Data.Sqlite;

public class LemmikkiDB
{
    private string _connectionstring = "Data Source = lemmikki.db";

    //Rakentaja
    public LemmikkiDB()
    {
        //Luodaan yhteys tietokantaan
        var connection = new SqliteConnection(_connectionstring);
        //avaa yhteyden tietokantaan
        connection.Open();
        //luodaan taulut, jos niitä ei vielä ole
        //Omistajat taulu
        var commandForOmistjat = connection.CreateCommand();
        commandForOmistjat.CommandText = "CREATE TABLE IF NOT EXISTS Omistajat (id INTEGER PRIMARY KEY,nimi TEXT,puhelin INT)";
        commandForOmistjat.ExecuteNonQuery(); //emmen odota vastausta tältä komennolta

        //Lemmitikit taulu
        var commandForLemmikit = connection.CreateCommand();
        commandForLemmikit.CommandText = "CREATE TABLE IF NOT EXISTS Lemmikit (id INTEGER PRIMARY KEY,nimi TEXT,laji TEXT,omistajan_id INTEGER)";
        commandForLemmikit.ExecuteNonQuery(); //emmen odota vastausta tältä komennolta

        connection.Close();


    }

}