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
        string server = "sql7.freesqldatabase.com";
        string database = "sql7303248";
        string uid = "sql7303248";
        string password = "1YmcWz82Sy";
        string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);
        connection.Open();
    }

    public void InsertCard(string name, int cost,string playedBy, string mode,string desc = "NONE")
    {
        string query = "INSERT INTO card (name, cost, played_by, mode, desc) VALUES('" + name + "','" + cost + "','" + playedBy
            + "','" + mode + "','" + desc + "',)";


        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.ExecuteNonQuery();
    }
}
