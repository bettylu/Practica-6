using System;
using MySql.Data.MySqlClient;

namespace Practica_6
{
	
	public class Profesor:MySQL
	{
		public Profesor()
		{
		}
		public void mostrarTodos(){
			this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(this.querySelect(),myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();	
			while (myReader.Read()){
				string id = myReader["id"].ToString();
				string codigo = myReader["codigo"].ToString();
				string nombre = myReader["nombre"].ToString();
				Console.WriteLine("ID: " + id +
				" Código: " + codigo +
				" Nombre: " + nombre);
			}

        	myReader.Close();
        	myReader = null;
       	 	myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
		}

		public void insertarRegistroNuevo(string codigo, string nombre){
			this.abrirConexion();
			string sql = "INSERT INTO `maestros` (`codigo`, `nombre`) VALUES ('" + codigo + "', '" + nombre + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}

		public void editarCodigoRegistro(string id, string codigo){
			this.abrirConexion();
			string sql = "UPDATE `maestros` SET `codigo`='" + codigo + "' WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}

		public void editarNombreCodigo(string id, string Codigo, string nombre){
			this.abrirConexion();
			string sql = "UPDATE `maestros` SET `nombre`='" + nombre + "', codigo='"+Codigo+"' WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}

		public void eliminarRegistroPorId(string id){
			this.abrirConexion();
			string sql = "DELETE FROM `maestros` WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
		private int ejecutarComando(string sql){
			MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
			int afectadas = myCommand.ExecuteNonQuery();
			myCommand.Dispose();
			myCommand = null;
			return afectadas;
		}

		private string querySelect(){
			return "SELECT * " +
			"FROM maestros";
		}
		private string queryBuscar( string id ){
			return "SELECT * "  +
			"FROM maestros where id = '"+id+"' ";
		}
		
		public bool Buscarid( string id ){
			this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(this.queryBuscar( id ),myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();	
			bool retorno = myReader.HasRows;

        	myReader.Close();
        	myReader = null;
       	 	myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
			return retorno;
		}
	}
}

		
