using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Ex05.FourInARowUI
{
    class Program
    {
        public static void Main()
        {
            FormGameSettings fourInARowSettings = new FormGameSettings();
            fourInARowSettings.ShowDialog();
        }
    }
}