using csillagterkep.Models;

namespace csillagterkep
{
    public partial class Form1 : Form
    {
        Models.hajosContext context = new Models.hajosContext();


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var stars = (from s in context.StarData select new { s.Hip, s.X, s.Y, s.Magnitude }).ToList();

            Graphics g = this.CreateGraphics();
            g.Clear(Color.Black);
            Color c = Color.FromArgb(252, 239, 145);
            Pen toll = new Pen(Color.White, 1/10);
            Brush brush = new SolidBrush(c);

            double nagyitas = 300;
            float cx = ClientRectangle.Width / 2;
            float cy = ClientRectangle.Height / 2;


            foreach (var star in stars)
            {
                if (star.Magnitude > 10) continue;
                if (Math.Sqrt(Math.Pow(star.X,2) + Math.Pow(star.Y, 2)) > 1) continue;

                float x = (float)(star.X * nagyitas + cx);
                float y = (float)(star.Y * nagyitas + cy);

                double size = 20 * Math.Pow(10, star.Magnitude / -2.5);

                g.FillEllipse(brush, x, y, (float)size, (float)size);
            }

            var lines = context.ConstellationLines.ToList();

            foreach (var line in lines)
            {

                var star1 = (from x in stars
                             where x.Hip == line.Star1
                             select x).FirstOrDefault();

                var star2 = (from x in stars
                             where x.Hip == line.Star2
                             select x).FirstOrDefault();

                if(star1 == null || star2 == null) continue;    

                float x1 = (float)(star1.X * nagyitas + cx);
                float y1 = (float)(star1.Y * nagyitas + cy);

                float x2 = (float)(star2.X * nagyitas + cx);
                float y2 = (float)(star2.Y * nagyitas + cy);

                g.DrawLine(toll, x1, y1, x2, y2); 
            }

        }
    }
}