using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMSrq2
{
    public partial class Form1 : Form
    {
        Model model;
        public Form1()
        {
            InitializeComponent();
            model = new Model();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            model.ResetModel(Convert.ToDouble(lambdaTB.Text), Convert.ToDouble(mu1TB.Text), Convert.ToDouble(mu2TB.Text), Convert.ToInt32(NTB.Text), Convert.ToDouble(sigmaTB.Text), Convert.ToDouble(pTB.Text));
            model.maxTime = Convert.ToDouble(modelTimeTB.Text);
            button1.Enabled = false;
            button2.Enabled = false;
            model.StartSimulation();
            MessageBox.Show("Симуляция завершена!");
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            model.OpenTab();
        }
    }
}
