using System.Windows.Forms;

namespace hajos_kviz
{
    public partial class Form1 : Form
    {

        List<K�rd�s> �sszesK�rd�s;
        List<K�rd�s> Aktu�lisK�rd�sek;

        V�laszGomb V�laszGomb1;
        V�laszGomb V�laszGomb2;
        V�laszGomb V�laszGomb3;

        int Aktu�lisK�rd�s = 6;

        public Form1()
        {
            InitializeComponent();
            V�laszGomb1 = new V�laszGomb();
            V�laszGomb1.Top = 70;
            Controls.Add(V�laszGomb1);

            V�laszGomb2 = new V�laszGomb();
            V�laszGomb2.Top = 170;
            Controls.Add(V�laszGomb2);

            V�laszGomb3 = new V�laszGomb();
            V�laszGomb3.Top = 270;
            Controls.Add(V�laszGomb3);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            �sszesK�rd�s = K�rd�sBet�lt�s();
            Aktu�lisK�rd�sek = new List<K�rd�s>();

            for (int i = 0; i < 7; i++)
            {
                Aktu�lisK�rd�sek.Add(�sszesK�rd�s[0]);
                �sszesK�rd�s.RemoveAt(0);
            }

            dataGridView1.DataSource = Aktu�lisK�rd�sek;

            K�rd�smegjelen�t�s(Aktu�lisK�rd�sek[Aktu�lisK�rd�s]);
        }

        void K�rd�smegjelen�t�s(K�rd�s k�rd�s)
        {
            label1.Text = k�rd�s.K�rd�sSz�veg;
            V�laszGomb1.Text = k�rd�s.V�lasz1;
            V�laszGomb2.Text = k�rd�s.V�lasz2;
            V�laszGomb3.Text = k�rd�s.V�lasz3;

            if (string.IsNullOrEmpty(k�rd�s.URL))
            {
                pictureBox1.Visible = false;
            }
            else
            {
                pictureBox1.Visible = true;
                pictureBox1.Load("https://storage.altinum.hu/hajo/" + k�rd�s.URL);
            }
        }

        List<K�rd�s> K�rd�sBet�lt�s()
        {
            List<K�rd�s> k�rd�sek = new List<K�rd�s>();

            StreamReader sr = new StreamReader("hajozasi_szabalyzat_kerdessor_BOM.txt", true);

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine() ?? "--";
                string[] t�mb = sor.Split("\t");

                if (t�mb.Length != 7) continue;

                K�rd�s k = new K�rd�s();
                k.K�rd�sSz�veg = t�mb[1];
                k.V�lasz1 = t�mb[2];
                k.V�lasz2 = t�mb[3];
                k.V�lasz3 = t�mb[4];
                k.URL = t�mb[5];

                int x = 0;
                int.TryParse(t�mb[6], out x);
                k.HelyesV�lasz = x;
                k�rd�sek.Add(k);

            }

            sr.Close();


            return k�rd�sek;
        }
    }
}