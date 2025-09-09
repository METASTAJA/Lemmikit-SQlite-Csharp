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
        var commandForTableCreation = connection.CreateCommand();
        commandForTableCreation.CommandText = "CREATE TABLE IF NOT EXISTS Omistajat (id INTEGER PRIMARY KEY,nimi TEXT,puhelin INT)";
        commandForTableCreation.ExecuteNonQuery(); //emmen odota vastausta tältä komennolta
        connection.Close();


    }

}