using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Wallbase
{
    public partial class Preview : Form
    {
        public Preview()
        {
            InitializeComponent();
        }

        private void wallpaper_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.TopMost = false;
            this.SendToBack();

            MessageBox.Show(
                "Press OK to close preview.",
                "Wallbase - Preview",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);

            Close();
        }
    }
}
