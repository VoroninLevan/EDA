using System;
using System.Data;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    
    // Create database
    private string _connection;
    private IDbConnection _dbCon;
    private IDbCommand _dbCommand;
    private IDataReader _reader;
    
    // CMDs
    private string _createTable = "CREATE TABLE IF NOT EXISTS e_entries (id INTEGER PRIMARY KEY, entries INTEGER, item TEXT, info1 TEXT, info2 TEXT, info3 TEXT)";
    
    // Start is called before the first frame update
    private void Start()
    {
        _connection = "URI=file:" + Application.persistentDataPath + Path.DirectorySeparatorChar + "ECA_DB";
        CreateDB();
    }

    private void CreateDB()
    {
        if (File.Exists(_connection.Substring(_connection.IndexOf(':') + 1))) return;
        _dbCon = new SqliteConnection(_connection);
        _dbCon.Open();

        // Create table
        _dbCommand = _dbCon.CreateCommand();
        _dbCommand.CommandText = _createTable;
        _dbCommand.ExecuteReader();

        PopulateDB();
        
        _dbCon.Close();
    }

    public void PopulateDB()
    {
        using var reader = new StreamReader(Application.dataPath + Path.DirectorySeparatorChar + "DBSetup" + Path.DirectorySeparatorChar + "db_values.csv");
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(';');
            
            _dbCommand = _dbCon.CreateCommand();

            string insertCmd =
                String.Format("INSERT INTO e_entries (id, entries, item, info1, info2, info3) VALUES ({0}, {1}, '{2}', '{3}', '{4}', '{5}')", values[0],
                    values[1], values[2], values[3], values[4], values[5]);
            Debug.Log(insertCmd);
            
            _dbCommand.CommandText = insertCmd;

            _dbCommand.ExecuteNonQuery();
        }
    }

    public string GetDBEntryItem(string entryName)
    {
        _dbCon = new SqliteConnection(_connection);
        _dbCon.Open();
        
        _dbCommand = _dbCon.CreateCommand();
        string query ="SELECT item FROM e_entries WHERE item=\"" + entryName + "\"";
        _dbCommand.CommandText = query;
        _reader = _dbCommand.ExecuteReader();

        string response = _reader[0].ToString();
        _dbCon.Close();
        
        return response;
    }
    
    public string GetDBEntryInfo(string entryName, int index)
    {
        _dbCon = new SqliteConnection(_connection);
        _dbCon.Open();
        
        _dbCommand = _dbCon.CreateCommand();
        string query = String.Format("SELECT info{0} FROM e_entries WHERE item=\"{1}\"", index, entryName);
        _dbCommand.CommandText = query;
        _reader = _dbCommand.ExecuteReader();

        string response = _reader[0].ToString();
        _dbCon.Close();

        return response;
    }

    public int GetEntryCount(string entryName)
    {
        _connection = "URI=file:" + Application.persistentDataPath + Path.DirectorySeparatorChar + "ECA_DB";
        _dbCon = new SqliteConnection(_connection);
        _dbCon.Open();
        
        _dbCommand = _dbCon.CreateCommand();
        string query = String.Format("SELECT entries FROM e_entries WHERE item=\"{0}\"", entryName);
        _dbCommand.CommandText = query;
        _reader = _dbCommand.ExecuteReader();

        int response = Int32.Parse(_reader[0].ToString());
        _dbCon.Close();

        return response;
    }
}
