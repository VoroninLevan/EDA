using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseReplacement : MonoBehaviour
{
    private Dictionary<string, string[]> _database;

    private void Start()
    {
        if (_database != null) return;
        PopulateDatabase();
    }

    private void PopulateDatabase()
    {
        _database = new Dictionary<string, string[]>();
        _database.Add("Mercury", new []{DictEntries.Merc_Count, DictEntries.Merc_Info1});
        _database.Add("Venus", new []{DictEntries.Ven_Count, DictEntries.Ven_Info1});
        _database.Add("Earth", new []{DictEntries.Earth_Count, DictEntries.Earth_Info1});
        _database.Add("Mars", new []{DictEntries.Mars_Count, DictEntries.Mars_Info1});
        _database.Add("Jupiter", new []{DictEntries.Jupiter_Count, DictEntries.Jupiter_Info1});
        _database.Add("Saturn", new []{DictEntries.Sat_Count, DictEntries.Sat_Info1});
        _database.Add("Uranus", new []{DictEntries.Ura_Count, DictEntries.Ura_Info1});
        _database.Add("Neptune", new []{DictEntries.Nep_Count, DictEntries.Nep_Info1});
        _database.Add("Moon", new []{DictEntries.Moo_Count, DictEntries.Moo_Info1, DictEntries.Moo_Info2, DictEntries.Moo_Info3});
    }

    public int GetCount(string name)
    {
        return Int32.Parse(_database[name][0]);
    }

    public string GetInfo(string name, int index)
    {
        return _database[name][index];
    }
}
