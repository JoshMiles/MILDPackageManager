using System;
using MySql.Data.MySqlClient;

namespace FileDB
{
	class DBConnect
	{
		private MySqlConnection connection;
		private string server;
		private string database;
		private string uid;
		private string password;

		public DBConnect ()
		{
			Initialize ();
		}

		private void Initialize ()
		{
			server = "localhost";
			database = "db";
			uid = "username";
			password = "password";
			string connectionString;
			connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
		database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

			connection = new MySqlConnection (connectionString);
		}

private bool OpenConnection()
{
    try
    {
        connection.Open();
        return true;
    }
    catch (MySqlException ex)
    {
        switch (ex.Number)
        {
            case 0:
                MessageBox.Show("Cannot connect to server.  Contact administrator");
                break;

            case 1045:
                MessageBox.Show("Invalid username/password, please try again");
                break;
        }
        return false;
    }
}

private bool CloseConnection()
{
    try
    {
        connection.Close();
        return true;
    }
    catch (MySqlException ex)
    {
        MessageBox.Show(ex.Message);
        return false;
    }
}

		public void Insert (string tablename, string parameters, string modifications)
		{
			    string query = "INSERT INTO "+tablename+" ("+parameters+") VALUES("+modifications+")";

    
    if (this.OpenConnection() == true)
    {
      
        MySqlCommand cmd = new MySqlCommand(query, connection);
        
        cmd.ExecuteNonQuery();

        
        this.CloseConnection();
    }
		}

		public void Update (string table, string sets, string _where )
		{
			    string query = "UPDATE "+table+" SET "+sets+" WHERE "+_where;
    if (this.OpenConnection() == true)
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = query;
        cmd.Connection = connection;
        cmd.ExecuteNonQuery();
        this.CloseConnection();
    }
		}

		public void Delete (string table, string _where)
		{
			string query = "DELETE FROM "+table+" WHERE "+_where;

    if (this.OpenConnection() == true)
    {
        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.ExecuteNonQuery();
        this.CloseConnection();
    }
		}

		public List <string> [] Select (string table)
		{
			    string query = "SELECT * FROM "+table;
    List< string >[] list = new List< string >[3];
    list[0] = new List< string >();
    list[1] = new List< string >();
    list[2] = new List< string >();
    if (this.OpenConnection() == true)
    {
        MySqlCommand cmd = new MySqlCommand(query, connection);
        MySqlDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            list[0].Add(dataReader["id"] + "");
            list[1].Add(dataReader["name"] + "");
            list[2].Add(dataReader["age"] + "");
        }
        dataReader.Close();
        this.CloseConnection();
        return list;
    }
    else
    {
        return list;
    }
		}

		public int Count (string table)
		{
			
    string query = "SELECT Count(*) FROM "+table;
    int Count = -1;
    if (this.OpenConnection() == true)
    {
        MySqlCommand cmd = new MySqlCommand(query, connection);
        Count = int.Parse(cmd.ExecuteScalar()+"");
        this.CloseConnection();

        return Count;
    }
    else
    {
        return Count;
    }
		}

		public void Backup ()
		{
			//to be added
		}

		public void Restore ()
		{
			//to be added
		}
	}
}

