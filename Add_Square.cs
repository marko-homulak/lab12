using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace lab11
{
    public partial class Add_Square : Form
    {

        private BindingList<IShape> shapes;

        public Add_Square(BindingList<IShape> shapes)
        {
            this.shapes = shapes;
            InitializeComponent();
        }
        
        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Get_Area_btn_Click(object sender, EventArgs e)
        {
            Shape shape;

            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    throw new Exception("Please fill in all fields.");
                }
                else
                {
                    double side1;

                    if (!double.TryParse(textBox1.Text, out side1) || side1 <= 0)
                    {
                        throw new ArgumentException("Side1 must be a positive number.");
                    }

                    shape = new Square(side1);
                }

                shapes.Add(shape);

                MessageBox.Show("Shape: " + shape.name + " successfully added");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
