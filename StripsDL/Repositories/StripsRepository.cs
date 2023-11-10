using System.Data;
using StripsBL.Interfaces;
using StripsBL.Model;
using System.Data.SqlClient;
using StripsDL.Exceptions;


namespace StripsDL.Repositories {
    public class StripsRepository : IStripsRepository {
        private string connectionString;

        public StripsRepository(string connectionString) {
            this.connectionString = connectionString;
        }

        public Reeks GeefStripreeks(int id) {
            string query = "SELECT Strip.Id, Strip.Titel, Strip.Nr, Reeks.Naam AS ReeksNaam, Reeks.Id AS ReeksId " +
                           "FROM Strip JOIN Reeks ON Strip.Reeks = Reeks.Id " +
                           "WHERE Strip.Reeks = @ReeksId;";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@ReeksId", id);
                    connection.Open();
                    using (SqlDataReader dr = command.ExecuteReader()) {
                        List<Strip> strips = new List<Strip>();
                        int reeksId = 0;
                        string reeksNaam = string.Empty;

                        while (dr.Read()) {
                            if (reeksId == 0) {
                                reeksId = dr.GetInt32(dr.GetOrdinal("ReeksId"));
                                reeksNaam = dr.GetString(dr.GetOrdinal("ReeksNaam"));
                            }

                            strips.Add(new Strip(
                                dr.GetInt32(dr.GetOrdinal("Id")),
                                dr.GetString(dr.GetOrdinal("Titel")),
                                dr.GetInt32(dr.GetOrdinal("Nr"))
                            ));
                        }

                        if (strips.Count == 0) {
                            // Handle the case where no strips are found
                            return null; // Or handle it as per your application's requirement
                        }

                        return new Reeks(reeksId, reeksNaam, strips);
                    }
                }
            }
        }
    }
}