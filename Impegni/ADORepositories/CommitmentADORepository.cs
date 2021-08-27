using Impegni.Entities;
using Impegni.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impegni.ADORepositories
{
    class CommitmentADORepository : ICommitmentDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = Impegni;" +
                                    "Integrated Security = true;";

        public void Delete(Commitment commitment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "delete from Impegno where Id = @id";
                command.Parameters.AddWithValue("@id", commitment.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Commitment> Fetch()
        {
            List<Commitment> commitments = new List<Commitment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from Impegno";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var date = (DateTime)reader["ExpirationDate"];
                    var importance = (EnumImportance)reader["Importance"];
                    var status = (bool)reader["Status"];
                    var id = (int)reader["Id"];

                    Commitment commitment = new Commitment(title, description, date, importance, status, id);

                    commitments.Add(commitment);
                }
            }
            return commitments;
        }

        public Commitment GetById(int? id)
        {
            Commitment commitment = new Commitment();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from Impegno where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var date = (DateTime)reader["ExpirationDate"];
                    var importance = (EnumImportance)reader["Importance"];
                    var status = (bool)reader["Status"];

                    commitment = new Commitment(title, description, date, importance, status, id);
                }
            }
            return commitment; 
        }

        public void Insert(Commitment commitment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Impegno values (@title,@description,@date,@importance,@status)";
                command.Parameters.AddWithValue("@title", commitment.Title);
                command.Parameters.AddWithValue("@description", commitment.Description);
                command.Parameters.AddWithValue("@date", commitment.ExpirationDate);
                command.Parameters.AddWithValue("@importance", (int)commitment.Importance);
                command.Parameters.AddWithValue("@status", commitment.Status);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Commitment commitment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Impegno set Title = @title, Description = @description, ExpirationDate = @date, Importance = @importance, Status = @status where Id = @id";
                command.Parameters.AddWithValue("@title", commitment.Title);
                command.Parameters.AddWithValue("@description", commitment.Description);
                command.Parameters.AddWithValue("@date", commitment.ExpirationDate);
                command.Parameters.AddWithValue("@importance", (int)commitment.Importance);
                command.Parameters.AddWithValue("@status", commitment.Status);
                command.Parameters.AddWithValue("@id", commitment.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
