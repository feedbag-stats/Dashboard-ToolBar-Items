using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell.TableControl;
using Newtonsoft.Json.Linq;

namespace Dashboard
{
    public partial class DashboardSettingsForm : Form
    {
        private readonly JArray myPrivacySettingArray;

        public DashboardSettingsForm()
        {
            InitializeComponent();
            myPrivacySettingArray = new JArray();
        }

        // create and return a Json Object with the given content
        public void AddPrivacyJson(string solutionName, bool enabledSettingsForSolution, 
            bool researchGenericInteraction, bool researchProjectSpecific, bool researchSourceCode,
            bool openDataGenericInteraction, bool openDataProjectSpecific, bool openDataSourceCode)
        {
            dynamic privacySettingsJson = new JObject();
            privacySettingsJson.Solution = solutionName;
            privacySettingsJson.Enabled = enabledSettingsForSolution;

            if (enabledSettingsForSolution)
            {
                privacySettingsJson.ResearchGenericInteraction = researchGenericInteraction;
                privacySettingsJson.ResearchProjectSpecific = researchProjectSpecific;
                privacySettingsJson.ResearchSourceCode = researchSourceCode;

                privacySettingsJson.OpenDataGenericInteraction = openDataGenericInteraction;
                privacySettingsJson.OpenDataProjectSpecific = openDataProjectSpecific;
                privacySettingsJson.OpenDataSourceCode = openDataSourceCode;
            }
            else
            {
                privacySettingsJson.ResearchGenericInteraction = null;
                privacySettingsJson.ResearchProjectSpecific = null;
                privacySettingsJson.ResearchSourceCode = null;

                privacySettingsJson.OpenDataGenericInteraction = null;
                privacySettingsJson.OpenDataProjectSpecific = null;
                privacySettingsJson.OpenDataSourceCode = null;
            }

            myPrivacySettingArray.Add(privacySettingsJson);
            // test
            Console.WriteLine(privacySettingsJson.ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
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
            AddPrivacyJson("Solution 1", this.myCheckBox10Checked, this.checkBoxResearchGenericInteraction.Checked,
                this.checkBox2ResearchProjectSpecific.Checked, this.checkBoxResearchSourceCode.Checked,
                this.checkBoxOpenDataGenericInteraction.Checked, this.checkBoxOpenDataProjectSpecific.Checked,
                this.checkBoxOpenDataSourceCode.Checked);
            this.Close();

        }

        // feedback only, generic interaction data
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private bool myCheckBox10Checked = false;
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (!myCheckBox10Checked)
            {
                this.checkBoxResearchGenericInteraction.Enabled = true;
                this.checkBox2ResearchProjectSpecific.Enabled = true;
                this.checkBoxResearchSourceCode.Enabled = true;
                this.checkBoxOpenDataSourceCode.Enabled = true;
                this.checkBoxOpenDataProjectSpecific.Enabled = true;
                this.checkBoxOpenDataGenericInteraction.Enabled = true;
                myCheckBox10Checked = true;

            }
            else
            {
                this.checkBoxResearchGenericInteraction.Enabled = false;
                this.checkBox2ResearchProjectSpecific.Enabled = false;
                this.checkBoxResearchSourceCode.Enabled = false;
                this.checkBoxOpenDataSourceCode.Enabled = false;
                this.checkBoxOpenDataProjectSpecific.Enabled = false;
                this.checkBoxOpenDataGenericInteraction.Enabled = false;
                myCheckBox10Checked = false;

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
