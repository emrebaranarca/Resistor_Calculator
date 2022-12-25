using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resistor_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void changeColor(string color, Button button)
        {
            switch (color)
            {
                case "black": button.BackColor = Color.Black; break;
                case "brown": button.BackColor = Color.Brown; break;
                case "red": button.BackColor = Color.Red; break;
                case "orange": button.BackColor = Color.Orange; break;
                case "yellow": button.BackColor = Color.Yellow; break;
                case "green": button.BackColor = Color.Green; break;
                case "blue": button.BackColor = Color.Blue; break;
                case "purple": button.BackColor = Color.Purple; break;
                case "gray": button.BackColor = Color.Gray; break;
                default:
                    break;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeColor(comboBox1.SelectedItem.ToString(), band1);
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeColor(comboBox4.SelectedItem.ToString(), band2);
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeColor(comboBox3.SelectedItem.ToString(), band3);
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeColor(comboBox5.SelectedItem.ToString(), band4);
        }

       string[] colors = new string[] {"black", "brown", "red", "orange", "yellow", "green", "blue", "purple",
            "gray","white"};
       
        public void createColorArray(Clr[] clr)
        {

            for (int i = 0; i < clr.Length; i++)
            {
                clr[i] = new Clr();
                clr[i].number = i;
                clr[i].multiplier = (int)Math.Pow(10, clr[i].number);
                clr[i].color = colors[i];
            }
        }
        public Clr getColor(Clr[] clrs, string[] col, ComboBox comboBox)
        {
            int i = 0;
            while (comboBox.SelectedItem.ToString() != col[i])
            {
                i++;
            }
            return clrs[i];
        }
        public Clr searchColor(string txt, Clr[] clrs)
        {
            for (int j = 0; j < clrs.Length; j++)
            {
                if (clrs[j].color.ToString() == txt)
                {
                    return clrs[j];
                }
            }
            return null;
        }
        public void setTolerance(Clr band)
        {
            switch (band.color)
            {
                case "black":band.tolerance = 20; break;
                case "brown":band.tolerance = 1;break;
                case "red": band.tolerance = 2; break;
                case "orange": band.tolerance = 0; break;
                case "yellow": band.tolerance = 0; break;
                case "green": band.tolerance = 0.5; break;
                case "blue": band.tolerance = 0; break;
                case "purple": band.tolerance = 0; break;
                case "gray": band.tolerance = 0; break;
                case "white": band.tolerance = 10; break;
                default:
                    break;
            }
        }
        private void calculate_Click(object sender, EventArgs e)
        {
            Clr[] clrs = new Clr[10];
            createColorArray(clrs);
            int i = 0;
            Clr N1 = null, N2 = null, Mul = null, Tol = null;
            if (comboBox1.SelectedIndex > -1)
            {
                N1 = getColor(clrs, colors, comboBox1);
            }
            if (comboBox4.SelectedIndex > -1)
            {
                N2 = getColor(clrs, colors, comboBox4);
            }
            if (comboBox3.SelectedIndex > -1)
            {
                Mul = getColor(clrs, colors, comboBox3);
            }
            if (comboBox5.SelectedIndex > -1)
            {
                Tol = getColor(clrs, colors, comboBox5);
            }

            string color1 = N1.color.ToString();
            string color2 = N2.color.ToString();
            string color3 = Mul.multiplier.ToString(); //multipler
            string color4 = Tol.tolerance.ToString();


            Clr band1 = searchColor(color1, clrs);
            Clr band2 = searchColor(color2, clrs);
           
            string twodigit=band1.number.ToString() + band2.number.ToString();

            double resistor = (Convert.ToDouble(twodigit) * Convert.ToDouble(color3))/1000;

            Clr band4 = Tol;
            setTolerance(band4);       
            
            label12.Text= resistor.ToString()+ " kΩ";
            label15.Text = "%" + band4.tolerance.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
    public class Clr
    {
        public string color { get; set; }
        public int number { get; set; }
        public int multiplier { get; set; }
        public double tolerance { get; set; }
        
    }
}
