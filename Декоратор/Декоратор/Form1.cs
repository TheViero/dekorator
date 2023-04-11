using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Декоратор.Декоратор;

namespace Декоратор
{
    public partial class Form1 : Form
    {
        private readonly Tree _tree;
        public Form1()
        {
            InitializeComponent();

            _tree = new Tree("Oak", 10, 50);

            DisplayTree();
        }

        private void DisplayTree()
        {
            var pictureBox = new PictureBox
            {
                Width = 300,
                Height = 300,
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            Controls.Add(pictureBox);

            var image = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = image;

            var treeImageDecorator = new TreeImageDecorator(_tree, Properties.Resources.tree);
            var treeHeightDecorator = new TreeHeightDecorator(treeImageDecorator, new Font("Arial", 14, FontStyle.Regular));

            treeHeightDecorator.Display(pictureBox);
        }

    }
}