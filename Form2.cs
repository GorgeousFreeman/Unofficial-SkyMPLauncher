using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyMpLauncher
{
    public partial class Form2 : Form
    {
        Form1 txtf1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            txtf1 = form1;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void profile1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            profile1ToolStripMenuItem1.Checked = true;
            profile2ToolStripMenuItem.Checked = false;
            profile3ToolStripMenuItem.Checked = false;
            profile4ToolStripMenuItem.Checked = false;
            profile5ToolStripMenuItem.Checked = false;
            profile6ToolStripMenuItem.Checked = false;
            profile7ToolStripMenuItem.Checked = false;
            profile8ToolStripMenuItem.Checked = false;
            profile9ToolStripMenuItem.Checked = false;
            profile10ToolStripMenuItem.Checked = false;

            Profile1ToolStripMenuItem.Text = "Профиль - 1";

            richTextBox1.Clear();

            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileName-1", "Profile");

            richTextBox1.AppendText(ProfileEnableCheck);
        }

        private void profile2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile1ToolStripMenuItem1.Checked = false;
            profile2ToolStripMenuItem.Checked = true;
            profile3ToolStripMenuItem.Checked = false;
            profile4ToolStripMenuItem.Checked = false;
            profile5ToolStripMenuItem.Checked = false;
            profile6ToolStripMenuItem.Checked = false;
            profile7ToolStripMenuItem.Checked = false;
            profile8ToolStripMenuItem.Checked = false;
            profile9ToolStripMenuItem.Checked = false;
            profile10ToolStripMenuItem.Checked = false;

            Profile1ToolStripMenuItem.Text = "Профиль - 2";

            richTextBox1.Clear();

            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileName-2", "Profile");

            richTextBox1.AppendText(ProfileEnableCheck);
        }

        private void profile3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile1ToolStripMenuItem1.Checked = false;
            profile2ToolStripMenuItem.Checked = false;
            profile3ToolStripMenuItem.Checked = true;
            profile4ToolStripMenuItem.Checked = false;
            profile5ToolStripMenuItem.Checked = false;
            profile6ToolStripMenuItem.Checked = false;
            profile7ToolStripMenuItem.Checked = false;
            profile8ToolStripMenuItem.Checked = false;
            profile9ToolStripMenuItem.Checked = false;
            profile10ToolStripMenuItem.Checked = false;

            Profile1ToolStripMenuItem.Text = "Профиль - 3";

            richTextBox1.Clear();

            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileName-3", "Profile");

            richTextBox1.AppendText(ProfileEnableCheck);
        }

        private void profile4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile1ToolStripMenuItem1.Checked = false;
            profile2ToolStripMenuItem.Checked = false;
            profile3ToolStripMenuItem.Checked = false;
            profile4ToolStripMenuItem.Checked = true;
            profile5ToolStripMenuItem.Checked = false;
            profile6ToolStripMenuItem.Checked = false;
            profile7ToolStripMenuItem.Checked = false;
            profile8ToolStripMenuItem.Checked = false;
            profile9ToolStripMenuItem.Checked = false;
            profile10ToolStripMenuItem.Checked = false;

            Profile1ToolStripMenuItem.Text = "Профиль - 4";

            richTextBox1.Clear();

            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileName-4", "Profile");

            richTextBox1.AppendText(ProfileEnableCheck);
        }

        private void profile5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile1ToolStripMenuItem1.Checked = false;
            profile2ToolStripMenuItem.Checked = false;
            profile3ToolStripMenuItem.Checked = false;
            profile4ToolStripMenuItem.Checked = false;
            profile5ToolStripMenuItem.Checked = true;
            profile6ToolStripMenuItem.Checked = false;
            profile7ToolStripMenuItem.Checked = false;
            profile8ToolStripMenuItem.Checked = false;
            profile9ToolStripMenuItem.Checked = false;
            profile10ToolStripMenuItem.Checked = false;

            Profile1ToolStripMenuItem.Text = "Профиль - 5";

            richTextBox1.Clear();

            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileName-5", "Profile");

            richTextBox1.AppendText(ProfileEnableCheck);
        }

        private void profile6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile1ToolStripMenuItem1.Checked = false;
            profile2ToolStripMenuItem.Checked = false;
            profile3ToolStripMenuItem.Checked = false;
            profile4ToolStripMenuItem.Checked = false;
            profile5ToolStripMenuItem.Checked = false;
            profile6ToolStripMenuItem.Checked = true;
            profile7ToolStripMenuItem.Checked = false;
            profile8ToolStripMenuItem.Checked = false;
            profile9ToolStripMenuItem.Checked = false;
            profile10ToolStripMenuItem.Checked = false;

            Profile1ToolStripMenuItem.Text = "Профиль - 6";

            richTextBox1.Clear();

            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileName-6", "Profile");

            richTextBox1.AppendText(ProfileEnableCheck);
        }

        private void profile7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile1ToolStripMenuItem1.Checked = false;
            profile2ToolStripMenuItem.Checked = false;
            profile3ToolStripMenuItem.Checked = false;
            profile4ToolStripMenuItem.Checked = false;
            profile5ToolStripMenuItem.Checked = false;
            profile6ToolStripMenuItem.Checked = false;
            profile7ToolStripMenuItem.Checked = true;
            profile8ToolStripMenuItem.Checked = false;
            profile9ToolStripMenuItem.Checked = false;
            profile10ToolStripMenuItem.Checked = false;

            Profile1ToolStripMenuItem.Text = "Профиль - 7";

            richTextBox1.Clear();

            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileName-7", "Profile");

            richTextBox1.AppendText(ProfileEnableCheck);
        }

        private void profile8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile1ToolStripMenuItem1.Checked = false;
            profile2ToolStripMenuItem.Checked = false;
            profile3ToolStripMenuItem.Checked = false;
            profile4ToolStripMenuItem.Checked = false;
            profile5ToolStripMenuItem.Checked = false;
            profile6ToolStripMenuItem.Checked = false;
            profile7ToolStripMenuItem.Checked = false;
            profile8ToolStripMenuItem.Checked = true;
            profile9ToolStripMenuItem.Checked = false;
            profile10ToolStripMenuItem.Checked = false;

            Profile1ToolStripMenuItem.Text = "Профиль - 8";

            richTextBox1.Clear();

            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileName-8", "Profile");

            richTextBox1.AppendText(ProfileEnableCheck);
        }

        private void profile9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile1ToolStripMenuItem1.Checked = false;
            profile2ToolStripMenuItem.Checked = false;
            profile3ToolStripMenuItem.Checked = false;
            profile4ToolStripMenuItem.Checked = false;
            profile5ToolStripMenuItem.Checked = false;
            profile6ToolStripMenuItem.Checked = false;
            profile7ToolStripMenuItem.Checked = false;
            profile8ToolStripMenuItem.Checked = false;
            profile9ToolStripMenuItem.Checked = true;
            profile10ToolStripMenuItem.Checked = false;

            Profile1ToolStripMenuItem.Text = "Профиль - 9";

            richTextBox1.Clear();

            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileName-9", "Profile");

            richTextBox1.AppendText(ProfileEnableCheck);
        }

        private void profile10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile1ToolStripMenuItem1.Checked = false;
            profile2ToolStripMenuItem.Checked = false;
            profile3ToolStripMenuItem.Checked = false;
            profile4ToolStripMenuItem.Checked = false;
            profile5ToolStripMenuItem.Checked = false;
            profile6ToolStripMenuItem.Checked = false;
            profile7ToolStripMenuItem.Checked = false;
            profile8ToolStripMenuItem.Checked = false;
            profile9ToolStripMenuItem.Checked = false;
            profile10ToolStripMenuItem.Checked = true;

            Profile1ToolStripMenuItem.Text = "Профиль - 10";

            richTextBox1.Clear();

            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileName-10", "Profile");

            richTextBox1.AppendText(ProfileEnableCheck);
        }

        //

        private void button1_Click(object sender, EventArgs e)
        {
            var Setting = new IniFile("Setting.ini");
            richTextBox1.SaveFile("ProfileName", RichTextBoxStreamType.PlainText);
            string text = File.ReadAllText("ProfileName", Encoding.GetEncoding(1251));

            if (profile1ToolStripMenuItem1.Checked == true)
            {
                Setting.Write("ProfileName-1", text, "Profile");

                txtf1.checkBox1.Text = text;
                txtf1.label5.Text = text;
            }
            else if (profile2ToolStripMenuItem.Checked == true)
            {
                Setting.Write("ProfileName-2", text, "Profile");

                txtf1.checkBox2.Text = text;
            }
            else if (profile3ToolStripMenuItem.Checked == true)
            {
                Setting.Write("ProfileName-3", text, "Profile");
                txtf1.checkBox3.Text = text;
            }
            else if (profile4ToolStripMenuItem.Checked == true)
            {
                Setting.Write("ProfileName-4", text, "Profile");
                txtf1.checkBox4.Text = text;
            }
            else if (profile5ToolStripMenuItem.Checked == true)
            {
                Setting.Write("ProfileName-5", text, "Profile");
                txtf1.checkBox5.Text = text;
            }
            else if (profile6ToolStripMenuItem.Checked == true)
            {
                Setting.Write("ProfileName-6", text, "Profile");
                txtf1.checkBox6.Text = text;
            }
            else if (profile7ToolStripMenuItem.Checked == true)
            {
                Setting.Write("ProfileName-7", text, "Profile");
                txtf1.checkBox7.Text = text;
            }
            else if (profile8ToolStripMenuItem.Checked == true)
            {
                Setting.Write("ProfileName-8", text, "Profile");
                txtf1.checkBox8.Text = text;
            }
            else if (profile9ToolStripMenuItem.Checked == true)
            {
                Setting.Write("ProfileName-9", text, "Profile");
                txtf1.checkBox9.Text = text;
            }
            else if (profile10ToolStripMenuItem.Checked == true)
            {
                Setting.Write("ProfileName-10", text, "Profile");
                txtf1.checkBox10.Text = text;
            }

            File.Delete("ProfileName");

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
