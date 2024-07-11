using Microsoft.Data.SqlClient;

namespace WinFormsApp.Chapter08;

public class DatabaseManager : IDisposable
{
    private SqlConnection _connection;
    private bool _disposed = false;

    public DatabaseManager(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
        _connection.Open();
    }

    public SqlDataReader ExecuteQuery(string query)
    {
        using (SqlCommand command = new SqlCommand(query, _connection))
        {
            return command.ExecuteReader();
        }
    }

    // Implement the Dispose method to close the connection
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Dispose managed resources
                if (_connection != null)
                {
                    _connection.Close();
                    _connection = null;
                }
            }

            // Dispose unmanaged resources here if needed

            _disposed = true;
        }
    }

    ~DatabaseManager()
    {
        Dispose(false);
    }
}
