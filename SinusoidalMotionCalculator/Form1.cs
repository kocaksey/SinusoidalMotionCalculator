using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinusoidalMotionCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbFF.SelectedIndex = 0;
        }
        double f = 0;
        double d = 0;
        double v = 0;
        double a = 0;
        
        private void cmbFF_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbFF.SelectedItem.ToString() == "Frequency, Displacement")
            {
                lbCh1.Text = "Frequency";
                lbCh2.Text = "Displacement (peak-to-peak)";
                lb11.Text = "Hz";
                lb21.Text = "mm";
            }
            if (cmbFF.SelectedItem.ToString() == "Frequency, Velocity")
            {
                lbCh1.Text = "Frequency";
                lbCh2.Text = "Velocity (peak)";
                lb11.Text = "Hz";
                lb21.Text = "mm/s";
            }
            if (cmbFF.SelectedItem.ToString() == "Frequency, Acceleration")
            {
                lbCh1.Text = "Frequency";
                lbCh2.Text = "Acceleration (peak)";
                lb11.Text = "Hz";
                lb21.Text = "g";
            }
            if (cmbFF.SelectedItem.ToString() == "Displacement, Velocity")
            {
                lbCh1.Text = "Displacement (peak-to-peak)";
                lbCh2.Text = "Velocity (peak)";
                lb11.Text = "mm";
                lb21.Text = "mm/s";
            }
            if (cmbFF.SelectedItem.ToString() == "Displacement, Acceleration")
            {
                lbCh1.Text = "Displacement (peak-to-peak)";
                lbCh2.Text = "Acceleration (peak)";
                lb11.Text = "mm";
                lb21.Text = "g";
            }
            if (cmbFF.SelectedItem.ToString() == "Velocity, Acceleration")
            {
                lbCh1.Text = "Velocity (peak)";
                lbCh2.Text = "Acceleration (peak)";
                lb11.Text = "mm/s";
                lb21.Text = "g";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double disp;
            double freq;
            double acc;
            double vel;
            freq = 0;
            disp = 0;
            acc = 0;
            vel = 0;

            if (lbCh1.Text == "Frequency")
            {
                double.TryParse(txt1.Text, out freq);
            }

            if (lbCh1.Text == "Velocity (peak)")
            {
                double.TryParse(txt1.Text, out vel);
            }
            if (lbCh1.Text == "Displacement (peak-to-peak)")
            {
                double.TryParse(txt1.Text, out disp);
            }
            if (lbCh2.Text == "Displacement (peak-to-peak)")
            {
                double.TryParse(txt2.Text, out disp);
            }
            if (lbCh2.Text == "Velocity (peak)")
            {
                double.TryParse(txt2.Text, out vel);
            }
            if (lbCh2.Text == "Acceleration (peak)")
            {
                double.TryParse(txt2.Text, out acc);
            }
            if (freq == 0)
            {
                freq = vel / (disp * Math.PI);
            }



            if (txt2.Text == "" || txt1.Text == "" || cmbFF.SelectedItem == null)
            {
                MessageBox.Show("Please enter values!", "Warning!");
            }
            else
            {
                freq = Math.Round(freq, 3);
                lbF.Text = Convert.ToString(freq);

                d = disp * Math.Sin(2 * Math.PI * freq) / 2;
                d = Math.Round(d, 3);
                lbD.Text = Convert.ToString(d);


                v = (Math.PI) * freq * disp;
                v = Math.Round(v, 3);
                lbV.Text = Convert.ToString(v);
                a = (2 * Math.Pow((Math.PI * freq), 2) * disp) / 9805;
                a = Math.Round(a, 3);
                lbA.Text = Convert.ToString(a);
                if (lbCh1.Text == "Displacement (peak-to-peak)" || lbCh2.Text == "Displacement (peak-to-peak)")
                {
                    lbD.Text = Convert.ToString(disp);
                }
                if (lbCh1.Text == "Velocity (peak)" || lbCh2.Text == "Velocity (peak)")
                {
                    lbV.Text = Convert.ToString(vel);
                }
                if (lbCh1.Text == "Acceleration (peak)" || lbCh2.Text == "Acceleration (peak)")
                {
                    lbA.Text = Convert.ToString(acc);
                }
                if (lbCh1.Text == "Velocity (peak)" && lbCh2.Text == "Acceleration (peak)")
                {
                    f = ((acc / vel) * 9805) / (2 * Math.PI);
                    f = Math.Round(f, 3);
                    lbF.Text = Convert.ToString(f);
                    d = vel / (Math.PI * f);
                    d = Math.Round(d, 3);
                    lbD.Text = Convert.ToString(d);
                }

                if (cmbFF.SelectedItem.ToString() == "Frequency, Velocity")
                {
                    d = vel / (freq * Math.PI);
                    d = Math.Round(d, 3);
                    lbD.Text = Convert.ToString(d);
                    a = 2 * Math.Pow((Math.PI * freq), 2) * d / 9805;
                    a = Math.Round(a, 3);
                    lbA.Text = Convert.ToString(a);
                }
                if (cmbFF.SelectedItem.ToString() == "Frequency, Acceleration")
                {
                    d = acc / (2 * (Math.Pow(Math.PI * freq, 2))) * 9805;
                    d = Math.Round(d, 3);
                    lbD.Text = Convert.ToString(d);
                    v = d * Math.PI * freq;
                    v = Math.Round(v, 3);
                    lbV.Text = Convert.ToString(v);
                }
                if (cmbFF.SelectedItem.ToString() == "Displacement, Acceleration")
                {
                    f = Math.Sqrt((acc * 9805) / (2 * Math.PI * Math.PI * disp));
                    f = Math.Round(f, 3);
                    lbF.Text = Convert.ToString(f);
                    v = disp * f * Math.PI;
                    v = Math.Round(v, 3);
                    lbV.Text = Convert.ToString(v);
                }
                hz1.Visible = true;
                hz2.Visible = true;
                hz3.Visible = true;
                hz4.Visible = true;

            }
        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46);
            if (txt1.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txt1.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (txt1.Text.StartsWith("0") && !txt1.Text.StartsWith("0.") && e.KeyChar != '\b' && e.KeyChar != (int)'.')
            {
                e.Handled = true;
            }
        }

        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46);
            if (txt2.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txt2.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (txt2.Text.StartsWith("0") && !txt2.Text.StartsWith("0.") && e.KeyChar != '\b' && e.KeyChar != (int)'.')
            {
                e.Handled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbFF.SelectedIndex = 0;
            txt1.Text = "";
            txt2.Text = "";
            lbA.Text = "";
            lbV.Text = "";
            lbF.Text = "";
            lbD.Text = "";
            hz1.Visible = false;
            hz2.Visible = false;
            hz3.Visible = false;
            hz4.Visible = false;

        }
    }
}