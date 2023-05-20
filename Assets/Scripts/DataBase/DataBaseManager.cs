using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class DataBaseManager : MonoBehaviour
{
    
    // Create database
    private string _connection;
    private IDbConnection _dbCon;
    private IDbCommand _readCmd;
    private IDataReader _reader;
    
    // Start is called before the first frame update
    private void Start()
    {
        _connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Database";
        _dbCon = new SqliteConnection(_connection);
    }

    public void CreateTableDB()
    {
        string db = Application.persistentDataPath + "/" + "My_Database";
        if (File.Exists(db)) return;
        _dbCon.Open();
        
        _dbCon.Close();
    }

    public string GetDBEntryItem(string entryName)
    {
        _dbCon.Open();
        
        _readCmd = _dbCon.CreateCommand();
        string query ="SELECT item FROM e_entries WHERE item=\"" + entryName + "\"";
        _readCmd.CommandText = query;
        _reader = _readCmd.ExecuteReader();

        string response = _reader[0].ToString();
        _dbCon.Close();
        
        return response;
    }
    
    public string GetDBEntryInfo(string entryName)
    {
        _dbCon.Open();
        
        _readCmd = _dbCon.CreateCommand();
        string query ="SELECT info FROM e_entries WHERE item=\"" + entryName + "\"";
        _readCmd.CommandText = query;
        _reader = _readCmd.ExecuteReader();

        string response = _reader[0].ToString();
        _dbCon.Close();

        return response;
    }
}
