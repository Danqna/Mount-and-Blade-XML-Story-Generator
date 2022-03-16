using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mount_and_Blade_XML_Story_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //See if the user has saved a file path
            try
            {
                string gamepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "storypath.txt";
                StreamReader reader = new StreamReader(gamepath);
                textSteam.Text = reader.ReadLine();
            }
            catch { }

            // Set all the defaults here
            comboComplex.SelectedIndex = 0;
            MakeSimpleScreen();
        }

        private void comboComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboComplex.SelectedIndex == 0)
            {
                MakeSimpleScreen();
            }
            else
            {
                MakeComplexScreen();
            }
        }

        private void MakeComplexScreen()
        {
            label24.Visible = true;
            textQuestGiver.Visible = true;
            label5.Visible = true;
            comboTesto.Visible = true;
            label6.Visible = true;
            comboOccupation.Visible = true;            
            label8.Visible = true;
            comboTargetTesto.Visible = true;
            label9.Visible = true;
            comboFaction.Visible = true;
            label18.Visible = true;
            textOptStartQPD.Visible = true;
            label19.Visible = true;
            textOptStartQNPCD.Visible = true;
            label20.Visible = true;
            textIntQPD.Visible = true;
            label21.Visible = true;
            textIntQNPCD.Visible = true;
            label22.Visible = true;
            textIntOptQNPCD.Visible = true;
            label23.Visible = true;
            textIntOptQPD.Visible = true;
            label31.Visible = true;
            textOptEndQPD.Visible = true;
            label30.Visible = true;
            textOptEndQNPCD.Visible = true;
            label32.Visible = true;
            label33.Visible = true;
            label34.Visible = true;
            label35.Visible = true;
            comboMultiPart.Visible = true;
            textUniqueKey.Visible = true;
            numericMulti.Visible = true;
            numericMultiTotal.Visible = true;                      
            label15.Visible = true;
            numericDays.Visible = true;
            label39.Visible = true;
            comboRelation.Visible = true;
        }

        private void MakeSimpleScreen()
        {
            label24.Visible = false;
            textQuestGiver.Visible = false;
            label5.Visible = false;
            comboTesto.Visible = false;
            label6.Visible = false;
            comboOccupation.Visible = false;            
            label8.Visible = false;
            comboTargetTesto.Visible = false;
            label9.Visible = false;
            comboFaction.Visible = false;
            label18.Visible = false;
            textOptStartQPD.Visible = false;
            label19.Visible = false;
            textOptStartQNPCD.Visible = false;
            label20.Visible = false;
            textIntQPD.Visible = false;
            label21.Visible = false;
            textIntQNPCD.Visible = false;
            label22.Visible = false;
            textIntOptQNPCD.Visible = false;
            label23.Visible = false;
            textIntOptQPD.Visible = false;
            label31.Visible = false;
            textOptEndQPD.Visible = false;
            label30.Visible = false;
            textOptEndQNPCD.Visible = false;
            label32.Visible = false;
            label33.Visible = false;
            label34.Visible = false;
            label35.Visible = false;
            comboMultiPart.Visible = false;
            textUniqueKey.Visible = false;
            numericMulti.Visible = false;
            numericMultiTotal.Visible = false;                   
            label15.Visible = false;
            numericDays.Visible = false;
            label39.Visible = false;
            comboRelation.Visible = false;
        }

        private bool CheckRequiredFields()
        {
            // We start by assuming everything is fine
            bool success = true;

            if(textQuestName.Text.Trim() == string.Empty)
            {
                success = false;
                labelWarning.Text = "No quest name specified";
            }

            if(comboDisposition.Text.Trim() == string.Empty)
            {
                success = false;
                labelWarning.Text = "No disposition specified";
            }

            if(comboType.Text.Trim() == string.Empty)
            {
                success = false;
                labelWarning.Text = "No quest type specified";
            }

            if(comboType.Text == "DELIVERY")
            {
                if(textItem.Text.Trim() == string.Empty)
                {
                    success = false;
                    labelWarning.Text = "No delivery item specified";
                }
            }

            if (comboReward.Text.Trim() == string.Empty)
            {
                success = false;
                labelWarning.Text = "No reward type specified";
            }

            if(textStartQPD.Text.Trim() == string.Empty)
            {
                success = false;
                labelWarning.Text = "Missing start quest player dialogue";
            }

            if (textStartQNPCD.Text.Trim() == string.Empty)
            {
                success = false;
                labelWarning.Text = "Missing start quest NPC dialogue";
            }

            if (textEndQPD.Text.Trim() == string.Empty)
            {
                success = false;
                labelWarning.Text = "Missing end quest player dialogue";
            }

            if (textEndQNPCD.Text.Trim() == string.Empty)
            {
                success = false;
                labelWarning.Text = "Missing end quest NPC dialogue";
            }

            return success;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Fix the quest name as it'll be the saved file
            string reformmatedquestname = string.Concat(textQuestName.Text.Where(char.IsLetterOrDigit));
            labelWarning.Visible = false;
            labelWarning.ForeColor = Color.Red;
            labelWarning.Text = "Failed to save!";
            if (CheckRequiredFields())
            {
                // Fix up our strings here
                string testo;
                if(comboTesto.Text == "false")
                {
                    testo = "FALSE";
                }
                else if (comboTesto.Text == "true")
                {
                    testo = "TRUE";
                }
                else
                {
                    testo = "NEUTRAL";
                }

                string targettesto;
                if (comboTargetTesto.Text == "false")
                {
                    targettesto = "FALSE";
                }
                else if (comboTargetTesto.Text == "true")
                {
                    targettesto = "TRUE";
                }
                else
                {
                    targettesto = "NEUTRAL";
                }

                string TargetSameFaction;
                if (comboFaction.Text == "Same faction as player")
                {
                    TargetSameFaction = "TRUE";
                }
                else if (comboFaction.Text == "Not in players faction")
                {
                    TargetSameFaction = "FALSE";
                }
                else
                {
                    TargetSameFaction = "NEUTRAL";
                }

                string XMLBuilder = string.Empty;
                // Standard start
                XMLBuilder = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + Environment.NewLine;
                XMLBuilder += "<storyteller>" + Environment.NewLine;
                XMLBuilder += " <story" + Environment.NewLine;

                // Fields start here

                XMLBuilder += "QuestName=\"" + textQuestName.Text + "\"" + Environment.NewLine;
                XMLBuilder += "PlayerDisposition=\"" + comboDisposition.Text + "\"" + Environment.NewLine;
                XMLBuilder += "SpecificInitiator=\"" + textQuestGiver.Text + "\"" + Environment.NewLine;
                XMLBuilder += "InitiatorTestosteroneDominant=\"" + testo + "\"" + Environment.NewLine;
                XMLBuilder += "Occupation=\"" + comboOccupation.Text + "\"" + Environment.NewLine;
                XMLBuilder += "SpecificTarget=\"" + textTarget.Text + "\"" + Environment.NewLine;
                XMLBuilder += "TargetTestosteroneDominant=\"" + targettesto + "\"" + Environment.NewLine;
                XMLBuilder += "TargetSameFaction=\"" + TargetSameFaction + "\"" + Environment.NewLine;
                XMLBuilder += "RelationRequirement=\"" + comboRelation.Text + "\"" + Environment.NewLine;
                XMLBuilder += "QuestType=\"" + comboType.Text + "\"" + Environment.NewLine;
                XMLBuilder += "Item=\"" + textItem.Text + "\"" + Environment.NewLine;
                XMLBuilder += "ItemQty=\"" + numericItem.Text + "\"" + Environment.NewLine;
                XMLBuilder += "RewardType=\"" + comboReward.Text + "\"" + Environment.NewLine;
                XMLBuilder += "RewardQty=\"" + numericReward.Text + "\"" + Environment.NewLine;
                XMLBuilder += "TimeDays=\"" + numericDays.Text + "\"" + Environment.NewLine;
                XMLBuilder += "StartQuestPlayerDialogue=\"" + textStartQPD.Text + "\"" + Environment.NewLine;
                XMLBuilder += "StartQuestNPCDialogue=\"" + textStartQNPCD.Text + "\"" + Environment.NewLine;
                XMLBuilder += "OptionalStartQuestPlayerDialogue=\"" + textOptStartQPD.Text + "\"" + Environment.NewLine;
                XMLBuilder += "OptionalStartQuestNPCDialogue=\"" + textOptStartQNPCD.Text + "\"" + Environment.NewLine;
                XMLBuilder += "InterimQuestPlayerDialogue=\"" + textIntQPD.Text + "\"" + Environment.NewLine;
                XMLBuilder += "InterimQuestNPCDialogue=\"" + textIntQNPCD.Text + "\"" + Environment.NewLine;
                XMLBuilder += "OptionalInterimQuestPlayerDialogue=\"" + textIntOptQPD.Text + "\"" + Environment.NewLine;
                XMLBuilder += "OptionalInterimQuestNPCDialogue=\"" + textIntOptQNPCD.Text + "\"" + Environment.NewLine;
                XMLBuilder += "EndQuestPlayerDialogue=\"" + textEndQPD.Text + "\"" + Environment.NewLine;
                XMLBuilder += "EndQuestNPCDialogue=\"" + textEndQNPCD.Text + "\"" + Environment.NewLine;
                XMLBuilder += "OptionalEndQuestPlayerDialogue=\"" + textOptEndQPD.Text + "\"" + Environment.NewLine;
                XMLBuilder += "OptionalEndQuestNPCDialogue=\"" + textOptEndQNPCD.Text + "\"" + Environment.NewLine;
                XMLBuilder += "MultiPart=\"" + comboMultiPart.Text + "\"" + Environment.NewLine;
                XMLBuilder += "MultiKey=\"" + textUniqueKey.Text + "\"" + Environment.NewLine;
                XMLBuilder += "PartNumber=\"" + numericMulti.Text + "\"" + Environment.NewLine;
                XMLBuilder += "TotalParts=\"" + numericMultiTotal.Text + "\"" + Environment.NewLine;
                XMLBuilder += "LogStart=\"" + textJournalStart.Text + "\"" + Environment.NewLine;
                XMLBuilder += "LogFinish=\"" + textJournalEnd.Text + "\"" + Environment.NewLine;

                // Standard End
                if (textAuthor.Text != string.Empty)
                {
                    XMLBuilder += "Author=\"" + textAuthor.Text + "\"" + Environment.NewLine;
                }
                XMLBuilder += "/>" + Environment.NewLine;
                XMLBuilder += "</storyteller>";
                string datetext = DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
                datetext = string.Concat(datetext.Where(char.IsLetterOrDigit));
                string savefile;
                if (textSteam.Text != null && textSteam.Text != string.Empty && Directory.Exists(textSteam.Text))
                {
                    savefile = textSteam.Text + "\\" + reformmatedquestname + datetext + ".xml";
                }
                else
                {
                    savefile = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + reformmatedquestname + datetext + ".xml";
                }
                StreamWriter writer = new StreamWriter(new FileStream(savefile, FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8);
                writer.Write(XMLBuilder);
                writer.Close();

                labelWarning.Text = "File saved successfully";
                labelWarning.Visible = true;
                labelWarning.ForeColor = Color.Black;
                Utilities.ResetAllControls(this);
            }
            else { labelWarning.Visible = true; }            
        }

        public class Utilities
        {
            public static void ResetAllControls(Control form)
            {
                foreach (Control control in form.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox textBox = (TextBox)control;
                        textBox.Text = null;
                    }

                    if (control is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)control;
                        if (comboBox.Items.Count > 0)
                            comboBox.SelectedIndex = 0;
                    }

                    if (control is CheckBox)
                    {
                        CheckBox checkBox = (CheckBox)control;
                        checkBox.Checked = false;
                    }

                    if (control is ListBox)
                    {
                        ListBox listBox = (ListBox)control;
                        listBox.ClearSelected();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();            
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string gamepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "storypath.txt";                
                StreamWriter writer = new StreamWriter(gamepath);
                writer.WriteLine(folder.SelectedPath);
                writer.Close();
                textSteam.Text = folder.SelectedPath;
            }
        }
    }
}
