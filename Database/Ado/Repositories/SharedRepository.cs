using System.Data;
using Microsoft.Data.SqlClient;

namespace DormAPI.Database.Ado.Repositories
{
    public class SharedRepository 
    {
        private readonly string _connectionString;

        public SharedRepository(IConfiguration configuration) {

            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Dictionary<string, dynamic> GetStudentCountsOverview()
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SP_GetStudentCountsOverview", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                var dict = new Dictionary<string, dynamic>();
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dict["TotalStudents"] = reader.IsDBNull(reader.GetOrdinal("TotalStudents")) ? 0 : reader.GetInt32(reader.GetOrdinal("TotalStudents"));
                            dict["ActiveStudents"] = reader.IsDBNull(reader.GetOrdinal("ActiveStudents")) ? 0 : reader.GetInt32(reader.GetOrdinal("ActiveStudents"));
                            dict["StudentsWithoutContract"] = reader.IsDBNull(reader.GetOrdinal("StudentsWithoutContract")) ? 0 : reader.GetInt32(reader.GetOrdinal("StudentsWithoutContract"));
                            dict["UnpaidInstallmentsTotal"] = reader.IsDBNull(reader.GetOrdinal("UnpaidInstallmentsTotal")) ? 0 : reader.GetDecimal(reader.GetOrdinal("UnpaidInstallmentsTotal"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                return dict;
            }
        }
    }
}
