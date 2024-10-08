using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Web_DAL
{
    public class DatabaseConnection : IDisposable
    {
        private string connectionString = "Data Source=DESKTOP-MEUMH4V;Initial Catalog=DoAnQuanLyQuanBida1;Integrated Security=True";
        private SqlConnection connection;
        private SqlCommand command;

        public DatabaseConnection()
        {       
            connection = new SqlConnection(connectionString);
        }
        public SqlCommand CreateCommand(string query)
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                Open(); // Mở lại kết nối nếu cần
            }
            return new SqlCommand(query, connection); // Liên kết đúng kết nối đang mở với lệnh
        }

        public SqlConnection Open()
        {
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
            }

            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error opening connection: " + ex.Message);
                    throw;  // Ném lại lỗi để xử lý ở cấp cao hơn
                }
            }

            return connection;
        }

        public void Close()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

     

        public SqlDataReader ExecuteReader()
        {
            if (command == null)
                throw new InvalidOperationException("Command is not initialized. Call CreateCommand first.");

            return command.ExecuteReader();
        }

        public int ExecuteNonQuery()
        {
            if (command == null)
                throw new InvalidOperationException("Command is not initialized. Call CreateCommand first.");

            return command.ExecuteNonQuery();
        }

        public object ExecuteScalar()
        {
            if (command == null)
                throw new InvalidOperationException("Command is not initialized. Call CreateCommand first.");

            return command.ExecuteScalar();
        }

        public void Dispose()
        {
            Close();
            if (command != null)
            {
                command.Dispose();
            }
            if (connection != null)
            {
                connection.Dispose();
            }
        }
    }
}
