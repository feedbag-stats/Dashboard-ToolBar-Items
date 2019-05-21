using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class DashboardSettingsForm : Form
    {
        public DashboardSettingsForm()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        // cancle button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // save button
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        // feedback only, generic interaction data
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private bool checkBox10checked = false;
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox10checked)
            {
                this.checkBoxResearchGenericInteraction.Enabled = true;
                this.checkBox2ResearchProjectSpecific.Enabled = true;
                this.checkBoxResearchSourceCode.Enabled = true;
                this.checkBoxOpenDataSourceCode.Enabled = true;
                this.checkBoxOpenDataProjectSpecific.Enabled = true;
                this.checkBoxOpenDataGenericInteraction.Enabled = true;
                checkBox10checked = true;

            }
            else
            {
                this.checkBoxResearchGenericInteraction.Enabled = false;
                this.checkBox2ResearchProjectSpecific.Enabled = false;
                this.checkBoxResearchSourceCode.Enabled = false;
                this.checkBoxOpenDataSourceCode.Enabled = false;
                this.checkBoxOpenDataProjectSpecific.Enabled = false;
                this.checkBoxOpenDataGenericInteraction.Enabled = false;
                checkBox10checked = false;

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
