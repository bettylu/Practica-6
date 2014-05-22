using System;
using MySql.Data.MySqlClient;

namespace Practica_6
{
// programa
	class Program
	{
		public static void Main(string[] args)
		{
			int opc = 5;
			do{
		
				Console.WriteLine("Menu\n");
				Console.WriteLine("1) Ver \n");
				Console.WriteLine("2) Agregar \n");
				Console.WriteLine("3) Editar \n");
				Console.WriteLine("4) Eliminar \n");
				Console.WriteLine("5) Salir \n");
				
				opc = int.Parse(Console.ReadLine());
				Profesor maestro = new Profesor();
				
				switch(opc)
				{
						case 1:
									Console.Write(" **Ver** \n");
									maestro.mostrarTodos();
									break;
						
						case 2:
									Console.Write(" **Agregar** \n");
									Console.WriteLine("Introduce el codigo ");
									String codigo = Console.ReadLine();
									Console.WriteLine("Introduce el nombre ");
									String nombre = Console.ReadLine();
									maestro.insertarRegistroNuevo(codigo, nombre);
						
									break;
						
						case 3:
									Console.Write(" **Editar** \n");
									Console.WriteLine("Dame el id de registro ");
									string id = Console.ReadLine();
									
									
									if(maestro.Buscarid(id)){
										Console.WriteLine("codigo ");
										Console.WriteLine(" nombre ");
										Console.WriteLine("Seguro que desea editarlo ");
										string resp = Console.ReadLine();
										if(resp == "s"){
											Console.WriteLine("Introduce el codigo ");
											codigo = Console.ReadLine();
											Console.WriteLine("Introduce el nombre ");
											nombre = Console.ReadLine();
											maestro.editarNombreCodigo(id, codigo, nombre);						
										}
									}
									else {
										Console.WriteLine( "Id no existe");
										Console.ReadLine();
									}
									break;
						
						case 4:
									Console.Write(" **Eliminar** \n");
									Console.WriteLine("Dame el id de registro ");
									id = Console.ReadLine();
									if(maestro.Buscarid(id)){
										codigo = Console.ReadLine();
										nombre = Console.ReadLine();
										
										Console.WriteLine("Seguro que desea eliminarlo ");
										string resp = Console.ReadLine();
										if(resp == "s")
											maestro.eliminarRegistroPorId(id);
									}
									else {
										Console.WriteLine( "Id no existe");
										Console.ReadLine();
									}
									break;
						
						case 5:
									break;
			
				}
				Console.WriteLine("Presiona una tecla para continuar ");
			Console.ReadLine();
			}while(opc < 5);
		}
	}
}