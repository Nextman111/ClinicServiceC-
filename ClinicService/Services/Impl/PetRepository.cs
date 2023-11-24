using ClinicService.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace ClinicService.Services.Impl
{
    public class PetRepository : IPetRepository
    {
        private const string connectionString = "Data Source = clinic.db;";

        private static SqliteConnection GetSqliteConnection()
        {
            SqliteConnection connection = new SqliteConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }

        public int Create(Pet item)
        {
            using SqliteConnection connection = GetSqliteConnection();
            connection.Open();

            using SqliteCommand command = new SqliteCommand(
                "INSERT INTO pets(ClientId, Name, Birthday) " +
                "VALUES(@ClientId, @Name, @Birthday)", connection);
            command.Parameters.AddWithValue("@ClientId", item.ClientId);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Birthday", item.Birthday.Ticks);
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Update(Pet item)
        {
            using SqliteConnection connection = GetSqliteConnection();
            connection.Open();
            using SqliteCommand command =
                new SqliteCommand(
                    "UPDATE Pets SET ClientId = @ClientId, Name = @Name, Birthday = @Birthday" +
                    "WHERE PetId=@PetId", connection);
            command.Parameters.AddWithValue("@PetId", item.PetId);
            command.Parameters.AddWithValue("@ClientId", item.ClientId);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Birthday", item.Birthday);
            command.Prepare();
            return command.ExecuteNonQuery();
        }
        public int Delete(int id)
        {
            using SqliteConnection connection = GetSqliteConnection();
            connection.Open();
            using SqliteCommand command =
                new SqliteCommand("DELETE FROM Pets WHERE PetId=@PetId", connection);
            command.Parameters.AddWithValue("@PetId", id);
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public IList<Pet> GetAll()
        {

            SqliteConnection connection = GetSqliteConnection();
            connection.Open();

            using SqliteCommand command = new SqliteCommand(
                "SELECT * FROM Pets", connection
                );
            command.Prepare();

            using SqliteDataReader reader = command.ExecuteReader();

            List<Pet> list = new List<Pet>();
            
            while (reader.Read())
            {
                Pet entity = new Pet();
                entity.PetId = reader.GetInt32(0);
                entity.ClientId = reader.GetInt32(1);
                entity.Name = reader.GetString(2);
                entity.Birthday = new DateTime(reader.GetInt64(3));
                list.Add(entity);
            }
            return list;
        }

        public Pet GetById(int id)
        {
            using SqliteConnection connection = GetSqliteConnection();
            connection.Open();

            using SqliteCommand command =
                new SqliteCommand("SELECT * FROM Pets WHERE PetID=@PetID", connection);
            command.Parameters.AddWithValue("@PetID", id);
            command.Prepare();

            SqliteDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                Pet entity = new Pet();
                entity.PetId = reader.GetInt32(0);
                entity.ClientId = reader.GetInt32(1);
                entity.Name = reader.GetString(2);
                entity.Birthday = new DateTime(reader.GetInt64(3));
                return entity;
            }

            return null;
        }

    }
}
