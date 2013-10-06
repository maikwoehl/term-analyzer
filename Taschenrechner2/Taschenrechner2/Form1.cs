using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taschenrechner2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string term = textBox1.Text;
            Taschenrechner2.Taschenrechner myCalc = new Taschenrechner2.Taschenrechner();
            myCalc.Initialize();

            string[] result = myCalc.Analyze(term);
            label2.Text = result[0];
            label3.Text = result[1];
            if (myCalc.warning == true)
            {
                Warning();
            }
        }

        public void Warning()
        {
            //label3.Text = "<b>" + label3.Text + "</b>";
            label3.Font = new Font(label3.Font, FontStyle.Bold);
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
