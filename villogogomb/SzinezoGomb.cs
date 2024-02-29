using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace villogogomb
{
    internal class SzinezoGomb : Button
    {
        public SzinezoGomb()
        {
            MouseClick += SzinezoGomb_MouseClick;
        }

        private void SzinezoGomb_MouseClick(object? sender, MouseEventArgs e)
        {
            BackColor = Color.Violet;
        }
    }
}
