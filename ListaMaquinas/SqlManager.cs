
using System;
using System.Data.SqlClient;

namespace TuProyecto
{
    public class SqlManager
    {
        private readonly string connectionString;

        public SqlManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string EjecutarConsulta(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        // Verificar si el resultado no es nulo
                        if (result != null)
                        {
                            return result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la ejecución de la consulta
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
            }

            // Si la consulta no devuelve resultados o hay un error, retornar una cadena vacía o manejar de acuerdo a tus necesidades
            return string.Empty;
        }
    }
}
