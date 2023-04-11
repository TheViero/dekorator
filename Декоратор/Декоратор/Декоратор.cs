using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Декоратор
{
    internal class Декоратор
    {
        public class Tree
        {
            private readonly string _name;
            private readonly int _height;
            private readonly int _age;

            public Tree(string name, int height, int age)
            {
                _name = name;
                _height = height;
                _age = age;
            }

            public virtual void Display()
            {
                MessageBox.Show($"Tree name: {_name}, height: {_height}, age: {_age}");
            }
        }

        public abstract class TreeDisplayDecorator : Tree
        {
            protected Tree _tree;

            public TreeDisplayDecorator(Tree tree) : base("", 0, 0)
            {
                _tree = tree;
            }

            public override void Display()
            {
                _tree.Display();
            }

            public abstract void Display(PictureBox pictureBox);
        }

        public class TreeImageDecorator : TreeDisplayDecorator
        {
            private readonly Image _image;

            public TreeImageDecorator(Tree tree, Image image) : base(tree)
            {
                _image = image;
            }

            public override void Display(PictureBox pictureBox)
            {
                pictureBox.Image = _image;
                base.Display();
            }
        }

        public class TreeHeightDecorator : TreeDisplayDecorator
        {
            private readonly Font _font;

            public TreeHeightDecorator(Tree tree, Font font) : base(tree)
            {
                _font = font;
            }

            public override void Display(PictureBox pictureBox)
            {
                base.Display();

                using (var graphics = Graphics.FromImage(pictureBox.Image))
                {
                    graphics.DrawString($"Height: {_tree.GetType().GetProperty("Height").GetValue(_tree)}", _font, Brushes.Black, 0, 0);
                }
            }
        }
    }
}
