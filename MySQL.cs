using System;
using MySql.Data.MySqlClient;

namespace Practica_6
{
	
	public class MySQL
	{
		public MySqlConnection myConnection;
		public MySQL ()
		{
		}

		public void abrirConexion(){
			string connectionString =
           	"Server=localhost;" +
			"Database=profesores;" +
			"User ID=root;" +
			"Password=1234;" +
			"Pooling=false;";
			this.myConnection = new MySqlConnection(connectionString);
			this.myConnection.Open();
		}

		public void cerrarConexion(){
			this.myConnection.Close();
			this.myConnection = null;
		}
	}
}

