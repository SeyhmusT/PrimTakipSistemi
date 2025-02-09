using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VeriTabaniProje
{
    public partial class İtirazListesi : Form
    {
        public İtirazListesi()
        {
            InitializeComponent();
        }

        private void İtirazListesi_Load(object sender, EventArgs e)
        {
            LoadİtirazList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void LoadİtirazList()
        {
            string connectionString = "Data Source=SEYHMUSPC;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
            string query = "SELECT Ay, Aciklama, Cevap, İtirazDurumID FROM dbo.İtirazlar WHERE AsistanId = @AsistanID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@AsistanID", LoginForm.ID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AsistanAnaEkran asistanAnaEkran = new AsistanAnaEkran();
            asistanAnaEkran.Show();
            Hide();
        }
    }
}
