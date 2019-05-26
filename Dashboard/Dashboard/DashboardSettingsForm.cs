using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.Shell.TableControl;
using Newtonsoft.Json.Linq;

namespace Dashboard
{
    public partial class DashboardSettingsForm : Form
    {
        readonly dynamic myPrivacySettingJson = new JObject();
        private readonly object mySolutions;
        private string myCurrentSolutionId = "0";

        public DashboardSettingsForm()
        {
            InitializeComponent();
            mySolutions = this.comboBox1.Items;

            int id = 0;
            //initialize privacy settings JObject
            foreach (object solution in (IEnumerable) mySolutions)
            {
                dynamic privacySettings = new JObject();
                privacySettings.Solution = solution.ToString();
                privacySettings.Enabled = false;

                privacySettings.FeedBagGenericInteraction = false;
                privacySettings.FeedBagProjectSpecific = false;
                privacySettings.FeedBagSourceCode = false;

                privacySettings.ResearchGenericInteraction = false;
                privacySettings.ResearchProjectSpecific = false;
                privacySettings.ResearchSourceCode = false;

                privacySettings.OpenDataGenericInteraction = false;
                privacySettings.OpenDataProjectSpecific = false;
                privacySettings.OpenDataSourceCode = false;

                //TODO FIXME: add id as entry befor editing it.
                //myPrivacySettingJson.0 = null;
                myPrivacySettingJson.Add(id.ToString(), privacySettings);
                //myPrivacySettingJson[id] = privacySettings;
                id++;

            }   
        }

        // create and return a Json Object with the given content
        public void AddPrivacyJson(string solutionSelectionId, string solutionName, bool enabledSettingsForSolution, 
            bool researchGenericInteraction, bool researchProjectSpecific, bool researchSourceCode,
            bool openDataGenericInteraction, bool openDataProjectSpecific, bool openDataSourceCode)
        {
            dynamic privacySettings = new JObject();
            privacySettings.Solution = solutionName;
            privacySettings.Enabled = enabledSettingsForSolution;

            if (enabledSettingsForSolution)
            {
                privacySettings.FeedBagGenericInteraction = true;
                privacySettings.FeedBagProjectSpecific = true;
                privacySettings.FeedBagSourceCode = true;

                privacySettings.ResearchGenericInteraction = researchGenericInteraction;
                privacySettings.ResearchProjectSpecific = researchProjectSpecific;
                privacySettings.ResearchSourceCode = researchSourceCode;

                privacySettings.OpenDataGenericInteraction = openDataGenericInteraction;
                privacySettings.OpenDataProjectSpecific = openDataProjectSpecific;
                privacySettings.OpenDataSourceCode = openDataSourceCode;
            }
            else
            {
                privacySettings.FeedBagGenericInteraction = false;
                privacySettings.FeedBagProjectSpecific = false;
                privacySettings.FeedBagSourceCode = false;

                privacySettings.ResearchGenericInteraction = false;
                privacySettings.ResearchProjectSpecific = false;
                privacySettings.ResearchSourceCode = false;

                privacySettings.OpenDataGenericInteraction = false;
                privacySettings.OpenDataProjectSpecific = false;
                privacySettings.OpenDataSourceCode = false;
            }

            myPrivacySettingJson.SolutionSelectionId = privacySettings;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           myPrivacySettingJson[myCurrentSolutionId]["ResearchGenericInteraction"] = this.checkBoxResearchGenericInteraction.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            myPrivacySettingJson[myCurrentSolutionId]["ResearchProjectSpecific"] = this.checkBox2ResearchProjectSpecific.Checked;
        }

        // cancle button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // save button
        private void button1_Click(object sender, EventArgs e)
        {
            /*AddPrivacyJson("Solution 1", this.myCheckBox10Checked, this.checkBoxResearchGenericInteraction.Checked,
                this.checkBox2ResearchProjectSpecific.Checked, this.checkBoxResearchSourceCode.Checked,
                this.checkBoxOpenDataGenericInteraction.Checked, this.checkBoxOpenDataProjectSpecific.Checked,
                this.checkBoxOpenDataSourceCode.Checked);*/

            // get selected item of combobox
            /*int selectedIndex = comboBox1.SelectedIndex;
            Object selectedItem = comboBox1.SelectedItem;

            //remove preselected settings
            myPrivacySettingJson.Property(selectedIndex).Remove();

            //safe new settings
            AddPrivacyJson(selectedIndex, selectedItem.ToString(), this.myCheckBox10Checked, this.checkBoxResearchGenericInteraction.Checked,
                this.checkBox2ResearchProjectSpecific.Checked, this.checkBoxResearchSourceCode.Checked,
                this.checkBoxOpenDataGenericInteraction.Checked, this.checkBoxOpenDataProjectSpecific.Checked,
                this.checkBoxOpenDataSourceCode.Checked);*/

            //TODO: send Jarray to server

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
            myPrivacySettingJson[myCurrentSolutionId]["Enabled"] = myCheckBox10Checked;

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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: load settings for this solution


            // get selected item of combobox
            int selectedIndex = comboBox1.SelectedIndex;
            this.myCurrentSolutionId = selectedIndex.ToString();

            // Object selectedItem = comboBox1.SelectedItem;

            //remove preselected settings
            //myPrivacySettingJson.Property(selectedIndex).Remove();

            //safe new settings
            /*AddPrivacyJson(selectedIndex, selectedItem.ToString(), this.myCheckBox10Checked, this.checkBoxResearchGenericInteraction.Checked,
                this.checkBox2ResearchProjectSpecific.Checked, this.checkBoxResearchSourceCode.Checked,
                this.checkBoxOpenDataGenericInteraction.Checked, this.checkBoxOpenDataProjectSpecific.Checked,
                this.checkBoxOpenDataSourceCode.Checked);*/

            loadSettingsForSolution(selectedIndex.ToString());

         
        }

        private void loadSettingsForSolution(string solutionSettingsId)
        {
            JObject selectedSettings = myPrivacySettingJson[solutionSettingsId];

            this.checkBox10.Checked = (bool) selectedSettings["Enabled"];
            if (this.checkBox10.Checked)
            {
                this.checkBoxResearchGenericInteraction.Enabled = true;
                this.checkBox2ResearchProjectSpecific.Enabled = true; 
                this.checkBoxResearchSourceCode.Enabled = true;
                this.checkBoxOpenDataSourceCode.Enabled = true;
                this.checkBoxOpenDataProjectSpecific.Enabled = true;
                this.checkBoxOpenDataGenericInteraction.Enabled = true;
            }
            else
            {
                this.checkBoxResearchGenericInteraction.Enabled = false;
                this.checkBox2ResearchProjectSpecific.Enabled = false;
                this.checkBoxResearchSourceCode.Enabled = false;
                this.checkBoxOpenDataSourceCode.Enabled = false;
                this.checkBoxOpenDataProjectSpecific.Enabled = false;
                this.checkBoxOpenDataGenericInteraction.Enabled = false;
            }
            this.checkBoxResearchGenericInteraction.Checked = (bool) selectedSettings["ResearchGenericInteraction"];
            this.checkBox2ResearchProjectSpecific.Checked = (bool)selectedSettings["ResearchProjectSpecific"]; 
            this.checkBoxResearchSourceCode.Checked = (bool)selectedSettings["ResearchSourceCode"]; 
            this.checkBoxOpenDataSourceCode.Checked = (bool)selectedSettings["OpenDataSourceCode"]; 
            this.checkBoxOpenDataProjectSpecific.Checked = (bool)selectedSettings["OpenDataProjectSpecific"]; 
            this.checkBoxOpenDataGenericInteraction.Checked = (bool)selectedSettings["OpenDataGenericInteraction"]; 
        }

        private void checkBoxResearchSourceCode_CheckedChanged(object sender, EventArgs e)
        {
            myPrivacySettingJson[myCurrentSolutionId]["ResearchSourceCode"] = this.checkBoxResearchSourceCode.Checked;
        }

        private void checkBoxOpenDataGenericInteraction_CheckedChanged(object sender, EventArgs e)
        {
            myPrivacySettingJson[myCurrentSolutionId]["OpenDataGenericInteraction"] = this.checkBoxOpenDataGenericInteraction.Checked;
        }

        private void checkBoxOpenDataProjectSpecific_CheckedChanged(object sender, EventArgs e)
        {
            myPrivacySettingJson[myCurrentSolutionId]["OpenDataProjectSpecific"] = this.checkBoxOpenDataProjectSpecific.Checked;
        }

        private void checkBoxOpenDataSourceCode_CheckedChanged(object sender, EventArgs e)
        {
            myPrivacySettingJson[myCurrentSolutionId]["OpenDataSourceCode"] = this.checkBoxOpenDataSourceCode.Checked;
        }
    }
}
