﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace lab11
{
    public partial class Add_Parallelogram : Form
    {

        private BindingList<IShape> shapes;

        public Add_Parallelogram(BindingList<IShape> shapes)
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
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                {
                    throw new Exception("Please fill in all fields.");
                }
                else
                {
                    double side1, height;

                    if (!double.TryParse(textBox1.Text, out side1) || side1 <= 0)
                    {
                        throw new ArgumentException("Side1 must be a positive number.");
                    }

                    if (!double.TryParse(textBox2.Text, out height) || height <= 0 || height > side1)
                    {
                        throw new ArgumentException("Height must be a positive number and less than Side1");
                    }
                   
                    shape = new Parallelogram(side1, height);
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
