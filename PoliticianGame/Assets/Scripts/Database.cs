using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    MySqlConnection connection;

    private void Awake()
    {
        Connect();
    }

    private void Connect()
    {
        string server = "37.59.55.185";
        string database = "P0xE7ZdVqX";
        string uid = "P0xE7ZdVqX";
        string password = "TR9qJm94di";
        string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);
        connection.Open();
    }

    public void InsertCard(string name, int cost,string playedBy, string mode,string desc = "NONE")
    {
        string query = "INSERT INTO cards (name, cost, played_by) VALUES('" + name + "','" + cost + "','" + playedBy + "');";


        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.ExecuteNonQuery();
    }
}
