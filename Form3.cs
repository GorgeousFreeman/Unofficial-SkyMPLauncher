using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyMpLauncher
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();

            var Setting = new IniFile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Skyrim Special Edition\\SkyrimPrefs.ini");
            if (checkBox1.Checked == true)
            {
                Setting.Write("bFull Screen", "1", "Display");
            }
        }

        private void resolutionStart()
        {
            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();

            var Setting = new IniFile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Skyrim Special Edition\\SkyrimPrefs.ini");
            Setting.Write("iSize H", screenHeight, "Display");
            Setting.Write("iSize W", screenWidth, "Display");

            toolStripMenuItem1.Text = screenWidth+"x"+ screenHeight;
        }

        private void LowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicsToolStripMenuItem.Text = "Минимальная";
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicsToolStripMenuItem.Text = "Средняя";
        }

        private void highToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicsToolStripMenuItem.Text = "Высокая";
        }

        private void ultraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicsToolStripMenuItem.Text = "Ультра";
        }

        ///////////////////////
        
        private void x720toolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Text = "1280x720";
        }

        private void x800toolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Text = "1280x800";
        }

        private void x810toolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Text = "1440x810";
        }

        private void x900toolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Text = "1440x900";
        }

        private void x1050ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Text = "1680x1050";

        }

        private void x1080ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Text = "1920x1080";

        }

        private void x1440ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Text = "2560x1440";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Setting = new IniFile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Skyrim Special Edition\\SkyrimPrefs.ini");

            //Графика

            if (lowToolStripMenuItem.Checked == true)
            {
                File.Copy("Setting\\SkyrimPrefs - Low.ini", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Skyrim Special Edition\\SkyrimPrefs.ini", true);
                resolutionStart();
            }
            else if (normalToolStripMenuItem.Checked == true)
            {
                File.Copy("Setting\\SkyrimPrefs - Normal.ini", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Skyrim Special Edition\\SkyrimPrefs.ini", true);
                resolutionStart();
            } 
            else if (highToolStripMenuItem.Checked == true)
            {
                File.Copy("Setting\\SkyrimPrefs - High.ini", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Skyrim Special Edition\\SkyrimPrefs.ini", true);
                resolutionStart();
            }
            else if (ultraToolStripMenuItem.Checked == true)
            {
                File.Copy("Setting\\SkyrimPrefs - Ultra.ini", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Skyrim Special Edition\\SkyrimPrefs.ini", true);
                resolutionStart();
            }

            if(x720toolStripMenuItem.Checked == true)
            {
                
                Setting.Write("iSize H", "720", "Display");
                Setting.Write("iSize W", "1280", "Display");
            }
            else if (x800toolStripMenuItem.Checked == true)
            {
                Setting.Write("iSize H", "800", "Display");
                Setting.Write("iSize W", "1280", "Display");
            }
            else if (x810toolStripMenuItem.Checked == true) 
            {
                Setting.Write("iSize H", "810", "Display");
                Setting.Write("iSize W", "1440", "Display");
            }
            else if (x900toolStripMenuItem.Checked == true)
            {
                Setting.Write("iSize H", "900", "Display");
                Setting.Write("iSize W", "1440", "Display");
            }
            else if (x1050ToolStripMenuItem.Checked == true)
            {
                Setting.Write("iSize H", "1050", "Display");
                Setting.Write("iSize W", "1680", "Display");
            }
            else if (x1080ToolStripMenuItem.Checked == true)
            {
                Setting.Write("iSize H", "1080", "Display");
                Setting.Write("iSize W", "1920", "Display");
            }
            else if (x1440ToolStripMenuItem.Checked == true)
            {
                Setting.Write("iSize H", "1440", "Display");
                Setting.Write("iSize W", "2560", "Display");

            }




            if (checkBox1.Checked == true)
            {
                Setting.Write("bFull Screen", "1", "Display");
            }
            else if (checkBox1.Checked == false)
            {
                Setting.Write("bFull Screen", "0", "Display");
            }

            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
