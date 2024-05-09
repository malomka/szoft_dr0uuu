namespace zh3_gyak
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl userControl1 = new UserControl1();
            panel1.Controls.Add(userControl1);
            userControl1.Dock= DockStyle.Fill;
        }
    }
}