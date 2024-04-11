using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace AdatKötés
{
    public partial class Form1 : Form
    {
        BindingList<OrszagInfok> orszagLista = new();

        public Form1()
        {
            InitializeComponent();
            orszagInfokBindingSource.DataSource = orszagLista;
            dataGridView1.DataSource = orszagInfokBindingSource;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("european_countries.csv");
            var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
            var tömb = csv.GetRecords<OrszagInfok>();

            foreach (var item in tömb)
            {
                orszagLista.Add(item);
            }

            sr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            orszagInfokBindingSource.RemoveCurrent();
        }
    }
}