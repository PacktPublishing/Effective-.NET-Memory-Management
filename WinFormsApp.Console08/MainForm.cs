using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsApp.Chapter08;

public partial class MainForm : Form
{
    private DatabaseManager _dbManager;

    public MainForm()
    {
        InitializeComponent();
        string connectionString = "your-connection-string-here";
        _dbManager = new DatabaseManager(connectionString);
    }

    private void btnLoadData_Click(object sender, EventArgs e)
    {
        string query = "SELECT * FROM YourTable";
        using (SqlDataReader reader = _dbManager.ExecuteQuery(query))
        {
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            dataGridView1.DataSource = dataTable;
        }
    }

    // Ensure proper disposal when the form is closed
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _dbManager.Dispose();
        base.OnFormClosed(e);
    }
}
