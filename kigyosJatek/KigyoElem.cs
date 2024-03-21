using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kigyosJatek
{
    internal class KigyoElem: PictureBox
    {
        public static int Meret = 10;
        

        public KigyoElem()
        {
            Width = KigyoElem.Meret;
            Height = KigyoElem.Meret;
            BackColor = Color.Fuchsia;
        }
    }

}
