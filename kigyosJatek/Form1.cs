namespace kigyosJatek
{
    public partial class Form1 : Form
    {

        int fejX = 100;
        int fejY = 100;
        int iranyX = 0;
        int iranyY = -1;
        int lepesSzam = 0;
        int hossz = 5;

        List<KigyoElem> kigyo = new List<KigyoElem>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lepesSzam++;

            fejX += iranyX * KigyoElem.Meret;
            fejY += iranyY * KigyoElem.Meret;

            foreach (KigyoElem item in Controls)
            {
                if (item is KigyoElem)
                {
                    KigyoElem k = (KigyoElem)item;

                    if (item.Top == fejY && item.Left == fejX)
                    {
                        timer1.Enabled = false;
                        return;
                    }
                }
            }

            KigyoElem fej = new KigyoElem();
            fej.Top = fejY;
            fej.Left = fejX;
            kigyo.Add(fej);
            Controls.Add(fej);

            if (kigyo.Count > hossz)
            {
                KigyoElem levagando = kigyo[0];
                kigyo.RemoveAt(0);
                Controls.Remove(levagando);
            }

            if (lepesSzam % 2 == 0)
            {
                fej.BackColor = Color.Black;
            }


            




            
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                iranyX = 0;
                iranyY = -1;
            }

            if (e.KeyCode == Keys.Right)
            {
                iranyX = 1;
                iranyY = 0;
            }

            if (e.KeyCode == Keys.Left)
            {
                iranyX = -1;
                iranyY = 0;
            }

            if (e.KeyCode == Keys.Down)
            {
                iranyX = 0;
                iranyY = 1;
            }
        }
    }
}