using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Wallbase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Size BoxWidth
        {
            get { return new Size(180, 140); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            label1.Text = "Fetching top collections...";
            Update();

            button1.Enabled = false;
            Cursor = Cursors.AppStarting;

            var collections = Wallbase.GetTopCollections();
            Random r = new Random();
            int rindex = r.Next(0, collections.Count);

            label1.Text = "Selecting random collection...";
            Update();

            Wallbase.Collection rcollection = collections[rindex];
            int id = rcollection.ID;
            var boxes = new List<PictureBox>();

            label1.Text = "Fetching wallpapers...";
            Update();

            Parallel.ForEach(Wallbase.GetImagesFromCollection(id), url =>
            {
                var picbox = new PictureBox()
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = BoxWidth,
                    ImageLocation = url,
                    BorderStyle = BorderStyle.FixedSingle,
                };

                picbox.Click += (pb, ea) =>
                {
                    var preview = new Preview();
                    preview.wallpaper.ImageLocation = ((PictureBox)pb).ImageLocation;
                    preview.ShowDialog();
                };

                lock (boxes)
                {
                    boxes.Add(picbox);
                }
            });

            label1.Text = "Loading wallpapers...";
            Update();

            flowLayoutPanel1.Controls.AddRange(boxes.ToArray());
            Cursor = Cursors.Arrow;
            label1.Text = rcollection.Title;
            button1.Enabled = true;
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (Control ctl in flowLayoutPanel1.Controls)
            {
                ctl.Size = BoxWidth;
            }
        }
    }
}
