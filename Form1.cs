using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Timer = System.Windows.Forms.Timer;
using Ionic.Zip;
using System.Net.Http;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SkyMpLauncher
{
    public partial class Form1 : Form
    {
        string skyrimSE = "SkyrimSE.exe";
        string skyMP = "Data\\SweetPie.esp";

        public Form1()
        {

            InitializeComponent();

            if (File.Exists("Setting.ini") == false)
            {
                if (MessageBox.Show("Вы запустили этот лаунчер в первый раз. Для нормальной работы лаунчера нужно его разместить в удобную вам папку или же расположить его рядом с Skyrim.exe (корень игры). Как только вы всё правильно сделали, нажмите Да и мы начнем адаптацию.", "Предупреждение!", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    Environment.Exit(0);
                }
            }

            launcherUpdate();
            AutchDataNoLoad();
            ManagerProfileName();

            /*webBrowser1.Navigate("http://strayder911.hopto.org:8000/");*/

            playerPingCheck();
            System.Windows.Forms.Timer playerpingcheck = new System.Windows.Forms.Timer();
            playerpingcheck.Tick += new EventHandler(playerPingCheck);
            playerpingcheck.Interval = 10000;
            playerpingcheck.Start();

            if (File.Exists("Setting.ini") == false)
            {
                IniFile INI = new IniFile("Setting.ini");
                checkSettingsOff();
            }

            label6.Visible = false;

            if (File.Exists("AnimList-1.txt") == true)
            {
                batAnimToolStripMenuItem.Checked = true;
            }
            else if (File.Exists("AnimList-1.txt") == false)
            {
                batAnimToolStripMenuItem.Checked = false;
            }

            if (File.Exists("DotNetZip.dll") == false)
            {
                WebClient dotNetZipDownload1 = new WebClient();
                dotNetZipDownload1.DownloadFileAsync(new Uri("https://www.dropbox.com/scl/fi/okmxftedc41qp8rnpvlcq/DotNetZip.dll?rlkey=xcxf00gqguq2k098hjrgwn95e&dl=1"), "DotNetZip.dll");
            }

            if (File.Exists(skyrimSE) == true && File.Exists(skyMP) == true && File.Exists("Setting") == false)
            {
                Directory.CreateDirectory("Setting");

                if (File.Exists("Setting\\Skyrim.INI") == false)
                {
                    WebClient dotNetZipDownload = new WebClient();
                    dotNetZipDownload.DownloadFileAsync(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/i/rw_zKxLMxDY3mg"), "Setting\\Skyrim.INI", true);
                }
                if (File.Exists("Setting\\SkyrimPrefs - Low.ini") == false)
                {
                    WebClient dotNetZipDownload = new WebClient();
                    dotNetZipDownload.DownloadFileAsync(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/IwF6WBuMGEINnA"), "Setting\\SkyrimPrefs - Low.ini", true);
                }
                if (File.Exists("Setting\\SkyrimPrefs - Normal.ini") == false)
                {
                    WebClient dotNetZipDownload = new WebClient();
                    dotNetZipDownload.DownloadFileAsync(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/oU7NSM04sDiklg"), "Setting\\SkyrimPrefs - Normal.ini", true);
                }
                if (File.Exists("Setting\\SkyrimPrefs - High.ini") == false)
                {
                    WebClient dotNetZipDownload = new WebClient();
                    dotNetZipDownload.DownloadFileAsync(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/hvHZzljlpESLCQ"), "Setting\\SkyrimPrefs - High.ini", true);
                }
                if (File.Exists("Setting\\SkyrimPrefs - Ultra.ini") == false)
                {
                    WebClient dotNetZipDownload = new WebClient();
                    dotNetZipDownload.DownloadFileAsync(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/6YZYYmJpVcQ9Ww"), "Setting\\SkyrimPrefs - Ultra.ini", true);
                }
                if (File.Exists("Setting\\Plugins.txt") == false)
                {
                    WebClient dotNetZipDownload = new WebClient();
                    dotNetZipDownload.DownloadFileAsync(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/h3oCpdRcEqQUfw"), "Setting\\Plugins.txt", true);
                }

            }

            profileCheck();

            if (File.Exists(skyrimSE) == true && FileVersionInfo.GetVersionInfo(skyrimSE).FileVersion == null)
            {
                FileInfo DelSkyrim = new FileInfo(skyrimSE);
                DelSkyrim.Delete();
            }

            if (File.Exists(skyrimSE) == true)
            {

                if (FileVersionInfo.GetVersionInfo(skyrimSE).FileVersion == "1.6.640.0")
                {
                    label3.Text = "Версия " + FileVersionInfo.GetVersionInfo(skyrimSE).FileVersion;

                    if (File.Exists(skyMP) == true)
                    {
                        label4.Text = "SkyMP установлен";
                        button1.Enabled = false;
                    }
                    else
                    {
                        label4.ForeColor = Color.Red;
                        label4.Text = "Отсутствует SkyMP";
                        Start.Enabled = false;

                        checkCashToolStripMenuItem.Enabled = false;
                        profileEnableToolStripMenuItem.Enabled = false;
                        GraphiscResolutionToolStripMenuItem.Enabled = false;
                        modManagerToolStripMenuItem.Enabled = false;
                    }
                }
                else
                {
                    label3.ForeColor = Color.Red;
                    label3.Text = "Версия " + FileVersionInfo.GetVersionInfo(skyrimSE).FileVersion;

                    Start.Enabled = false;


                    checkCashToolStripMenuItem.Enabled = false;
                    profileEnableToolStripMenuItem.Enabled = false;
                    GraphiscResolutionToolStripMenuItem.Enabled = false;
                    modManagerToolStripMenuItem.Enabled = false;
                }

            }
            else
            {
                Start.Enabled = false;
                label4.Text = "Необходимая версия 1.6.640.0";
                label3.ForeColor = Color.Red;
                label3.Text = "Версия неизвестна!";

                checkCashToolStripMenuItem.Enabled = false;
                profileEnableToolStripMenuItem.Enabled = false;
                GraphiscResolutionToolStripMenuItem.Enabled = false;
                modManagerToolStripMenuItem.Enabled = false;
            }

            Start.Visible = true;
            skyMPUpdate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Хз что...


            Timer timer = new Timer();
            timer.Interval = (10 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        Form settingsForm = new Form3();

        private void timer_Tick(object sender, EventArgs e)
        {
            AutchDataNoLoad();
        }

        private void Instatall_Click(object sender, EventArgs e)
        {
            if (File.Exists(skyrimSE) == true)
            {
                FileVersionInfo skyrimInfo = FileVersionInfo.GetVersionInfo(skyrimSE);

                if (skyrimInfo.FileVersion == "1.6.640.0")
                {
                    if (File.Exists(skyMP) != true)
                    {
                        //Отсутствует SkyMP
                        skyMPDownload();
                    }
                }
                else
                {
                    //Некорректная версия Skyrim
                    clientDownload();
                }
            }
            else
            {
                //Пустая папка, ну и хуй с ним.

                if (MessageBox.Show("Будет запущен скачивание Skyrim, но хочу предупредить! Будет установлена ПИРАТКА, если вы же не хотите это делать, будьте добры, купите игру в Steam (если есть возможность) или же приобрести игру на сторонних магазинах! Если вам всё равно, просто нажмите ДА и начнется процесс нелегального скачивания.", "Предупреждение!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clientDownload();
                }
            }
        }

        private void Start_Load(object sender, EventArgs e)
        {
            //Запуск игры

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Skyrim Special Edition\\Skyrim.INI") == false || File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Skyrim Special Edition\\SkyrimPrefs.ini") == false)
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Skyrim Special Edition");

                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Skyrim Special Edition\\Skyrim.INI") == false)
                {
                    File.Copy("Setting\\Skyrim.INI", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Skyrim Special Edition\\Skyrim.INI", true);
                }

                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Skyrim Special Edition\\SkyrimPrefs.ini") == false)
                {
                    File.Copy("Setting\\SkyrimPrefs - Low.ini", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Skyrim Special Edition\\SkyrimPrefs.ini", true);

                    settingsForm.Show();
                }

                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Local\\Skyrim Special Edition");

                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Local\\Skyrim Special Edition\\Plugins.txt") == false)
                {
                    string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string skyrimFolder = Path.Combine(appDataFolder, "Skyrim Special Edition");
                    string pluginsFilePath = Path.Combine(skyrimFolder, "Plugins.txt");

                    string requiredText = "*ccBGSSSE001-Fish.esm\r\n*ccBGSSSE025-AdvDSGS.esm\r\n*CombatSettings.esp\r\n*SweetPie.esp";

                    if (!Directory.Exists(skyrimFolder))
                    {
                        Directory.CreateDirectory(skyrimFolder);
                    }

                    File.WriteAllText(pluginsFilePath, requiredText, Encoding.UTF8);
                }
            }
            else
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Local\\Skyrim Special Edition");

                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Local\\Skyrim Special Edition\\Plugins.txt") == false)
                {
                    string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string skyrimFolder = Path.Combine(appDataFolder, "Skyrim Special Edition");
                    string pluginsFilePath = Path.Combine(skyrimFolder, "Plugins.txt");

                    string requiredText = "*ccBGSSSE001-Fish.esm\r\n*ccBGSSSE025-AdvDSGS.esm\r\n*CombatSettings.esp\r\n*SweetPie.esp";

                    if (!Directory.Exists(skyrimFolder))
                    {
                        Directory.CreateDirectory(skyrimFolder);
                    }

                    File.WriteAllText(pluginsFilePath, requiredText, Encoding.UTF8);
                }

                var Setting = new IniFile("Setting.ini");
                string ProfileEnableCheck = Setting.Read("ProfileEnable", "Setting");
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-EN"));

                if (ProfileEnableCheck == "Off")
                {
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                    checkBox8.Checked = false;
                    checkBox9.Checked = false;
                    checkBox10.Checked = false;

                    Process.Start("skse64_loader.exe");
                }
                else if (ProfileEnableCheck == "Lite")
                {
                    if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false)
                    {
                        MessageBox.Show("Вы не выбрали ни один профиль!", "Ошибка", MessageBoxButtons.OK);
                    }
                    else
                    {
                        Process.Start("skse64_loader.exe");
                    }
                }
                else if (ProfileEnableCheck == "Prof")
                {
                    if (checkBox1.Checked == true)
                    {
                        Process.Start("start.bat");
                        Thread.Sleep(100);
                    }
                    if (checkBox2.Checked == true)
                    {
                        Process.Start("ProfileSave\\1\\start.bat");
                        Thread.Sleep(100);
                    }
                    if (checkBox3.Checked == true)
                    {
                        Process.Start("ProfileSave\\2\\start.bat");
                        Thread.Sleep(100);
                    }
                    if (checkBox4.Checked == true)
                    {
                        Process.Start("ProfileSave\\3\\start.bat");
                        Thread.Sleep(100);
                    }
                    if (checkBox5.Checked == true)
                    {
                        Process.Start("ProfileSave\\4\\start.bat");
                        Thread.Sleep(100);
                    }
                    if (checkBox6.Checked == true)
                    {
                        Process.Start("ProfileSave\\5\\start.bat");
                        Thread.Sleep(100);
                    }
                    if (checkBox7.Checked == true)
                    {
                        Process.Start("ProfileSave\\6\\start.bat");
                        Thread.Sleep(100);
                    }
                    if (checkBox8.Checked == true)
                    {
                        Process.Start("ProfileSave\\7\\start.bat");
                        Thread.Sleep(100);
                    }
                    if (checkBox9.Checked == true)
                    {
                        Process.Start("ProfileSave\\8\\start.bat");
                        Thread.Sleep(100);
                    }
                    if (checkBox10.Checked == true)
                    {
                        Process.Start("ProfileSave\\9\\start.bat");
                    }
                    if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false)
                    {
                        MessageBox.Show("Вы не выбрали ни один профиль!", "Ошибка", MessageBoxButtons.OK);
                    }

                }

            }
        }

        private void Profile1_Click(object sender, EventArgs e)
        {
            //Отсутствующие буковы

            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileEnable", "Setting");

            if (ProfileEnableCheck == "Lite")
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;

                if (checkBox1.Checked == true)
                {
                    File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-1.js", "Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                }
                else if (checkBox1.Checked == false)
                {
                    File.Copy("Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-1.js", true);
                }

            }
        }

        private void Profile2_Click(object sender, EventArgs e)
        {
            //Отсутствующие буковы
            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileEnable", "Setting");
            if (ProfileEnableCheck == "Lite")
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;

                if (checkBox2.Checked == true)
                {
                    File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-2.js", "Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                }
                else if (checkBox2.Checked == false)
                {
                    File.Copy("Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-2.js", true);
                }
            }
        }

        private void Profile3_Click(object sender, EventArgs e)
        {
            //Отсутствующие буковы
            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileEnable", "Setting");
            if (ProfileEnableCheck == "Lite")
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;

                if (checkBox3.Checked == true)
                {
                    File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-3.js", "Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                }
                else if (checkBox3.Checked == false)
                {
                    File.Copy("Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-3.js", true);
                }
            }
        }

        private void Profile4_Click(object sender, EventArgs e)
        {
            //Отсутствующие буковы
            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileEnable", "Setting");
            if (ProfileEnableCheck == "Lite")
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;

                if (checkBox4.Checked == true)
                {
                    File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-4.js", "Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                }
                else if (checkBox4.Checked == false)
                {
                    File.Copy("Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-4.js", true);
                }
            }
        }

        private void Profile5_Click(object sender, EventArgs e)
        {
            //Отсутствующие буковы
            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileEnable", "Setting");
            if (ProfileEnableCheck == "Lite")
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;

                if (checkBox5.Checked == true)
                {
                    File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-5.js", "Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                }
                else if (checkBox5.Checked == false)
                {
                    File.Copy("Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-5.js", true);
                }
            }
        }

        private void Profile6_Click(object sender, EventArgs e)
        {
            //Отсутствующие буковы
            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileEnable", "Setting");
            if (ProfileEnableCheck == "Lite")
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;

                if (checkBox6.Checked == true)
                {
                    File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-6.js", "Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                }
                else if (checkBox6.Checked == false)
                {
                    File.Copy("Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-6.js", true);
                }
            }
        }

        private void Profile7_Click(object sender, EventArgs e)
        {
            //Отсутствующие буковы
            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileEnable", "Setting");
            if (ProfileEnableCheck == "Lite")
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;

                if (checkBox7.Checked == true)
                {
                    File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-7.js", "Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                }
                else if (checkBox7.Checked == false)
                {
                    File.Copy("Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-7.js", true);
                }
            }
        }

        private void Profile8_Click(object sender, EventArgs e)
        {
            //Отсутствующие буковы
            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileEnable", "Setting");
            if (ProfileEnableCheck == "Lite")
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;

                if (checkBox8.Checked == true)
                {
                    File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-8.js", "Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                }
                else if (checkBox8.Checked == false)
                {
                    File.Copy("Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-8.js", true);
                }
            }
        }

        private void Profile9_Click(object sender, EventArgs e)
        {
            //Отсутствующие буковы
            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileEnable", "Setting");
            if (ProfileEnableCheck == "Lite")
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox10.Checked = false;

                if (checkBox9.Checked == true)
                {
                    File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-9.js", "Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                }
                else if (checkBox9.Checked == false)
                {
                    File.Copy("Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-9.js", true);
                }
            }
        }

        private void Profile10_Click(object sender, EventArgs e)
        {
            //Отсутствующие буковы
            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileEnable", "Setting");
            if (ProfileEnableCheck == "Lite")
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;

                if (checkBox10.Checked == true)
                {
                    File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-10.js", "Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                }
                else if (checkBox10.Checked == false)
                {
                    File.Copy("Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-10.js", true);
                }
            }
        }

        public void AutchDataNoLoad()
        {
            var Setting = new IniFile("Setting.ini");

            string ProfileName1 = Setting.Read("ProfileName-1", "Profile");
            string ProfileName2 = Setting.Read("ProfileName-2", "Profile");
            string ProfileName3 = Setting.Read("ProfileName-3", "Profile");
            string ProfileName4 = Setting.Read("ProfileName-4", "Profile");
            string ProfileName5 = Setting.Read("ProfileName-5", "Profile");
            string ProfileName6 = Setting.Read("ProfileName-6", "Profile");
            string ProfileName7 = Setting.Read("ProfileName-7", "Profile");
            string ProfileName8 = Setting.Read("ProfileName-8", "Profile");
            string ProfileName9 = Setting.Read("ProfileName-9", "Profile");
            string ProfileName10 = Setting.Read("ProfileName-10", "Profile");

            string ProfileEnableCheck = Setting.Read("ProfileEnable", "Setting");

            if (ProfileEnableCheck == "Off")
            {
                string profile1 = "Data\\Platform\\Plugins\\auth-data-no-load.js";

                // Основной Профиль

                if (File.Exists("ProfileSave\\ProfileName\\auth-data-no-load-1.js") == true)
                {
                    File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-1.js", "Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                }

                if (File.Exists(profile1) == true)
                {
                    string dataProfile1 = File.ReadLines(profile1).Skip(0).First();

                    string autchDataNoLoadProfile1 = Regex.Match(dataProfile1, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile1.Contains("//null"))
                    {
                        label5.Text = "Пусто";
                    }
                    else
                    {
                        label5.Text = autchDataNoLoadProfile1;
                    }
                }
                else
                {
                    label5.Text = "Пусто";
                }
            }
            else if (ProfileEnableCheck == "Lite")
            {
                string profile1 = "ProfileSave\\ProfileName\\auth-data-no-load-1.js";
                string profile2 = "ProfileSave\\ProfileName\\auth-data-no-load-2.js";
                string profile3 = "ProfileSave\\ProfileName\\auth-data-no-load-3.js";
                string profile4 = "ProfileSave\\ProfileName\\auth-data-no-load-4.js";
                string profile5 = "ProfileSave\\ProfileName\\auth-data-no-load-5.js";
                string profile6 = "ProfileSave\\ProfileName\\auth-data-no-load-6.js";
                string profile7 = "ProfileSave\\ProfileName\\auth-data-no-load-7.js";
                string profile8 = "ProfileSave\\ProfileName\\auth-data-no-load-8.js";
                string profile9 = "ProfileSave\\ProfileName\\auth-data-no-load-9.js";
                string profile10 = "ProfileSave\\ProfileName\\auth-data-no-load-10.js";

                if (ProfileName1 != "")
                {
                    checkBox1.Text = ProfileName1;

                }
                else if (File.Exists(profile1) == true)
                {
                    string dataProfile1 = File.ReadLines(profile1).Skip(0).First();

                    string autchDataNoLoadProfile1 = Regex.Match(dataProfile1, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile1.Contains("//null"))
                    {
                        checkBox1.Text = "Пусто";
                    }
                    else
                    {
                        checkBox1.Text = autchDataNoLoadProfile1;
                    }

                }
                else
                {
                    checkBox1.Text = "Пусто";
                }

                //Профиль 2

                if (ProfileName2 != "")
                {
                    checkBox2.Text = ProfileName2;

                }
                else if (File.Exists(profile2) == true)
                {
                    string dataProfile2 = File.ReadLines(profile2).Skip(0).First();

                    string autchDataNoLoadProfile2 = Regex.Match(dataProfile2, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile2.Contains("//null"))
                    {
                        checkBox2.Text = "Пусто";
                    }
                    else
                    {
                        checkBox2.Text = autchDataNoLoadProfile2;
                    }
                }
                else
                {
                    checkBox2.Text = "Пусто";
                }

                //Профиль 3

                if (ProfileName3 != "")
                {
                    checkBox3.Text = ProfileName3;

                }
                else if (File.Exists(profile3) == true)
                {
                    string dataProfile3 = File.ReadLines(profile3).Skip(0).First();

                    string autchDataNoLoadProfile3 = Regex.Match(dataProfile3, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile3.Contains("//null"))
                    {
                        checkBox3.Text = "Пусто";
                    }
                    else
                    {
                        checkBox3.Text = autchDataNoLoadProfile3;
                    }
                }
                else
                {
                    checkBox3.Text = "Пусто";
                }

                //Профиль 4

                if (ProfileName4 != "")
                {
                    checkBox4.Text = ProfileName4;

                }
                else if (File.Exists(profile4) == true)
                {
                    string dataProfile4 = File.ReadLines(profile4).Skip(0).First();

                    string autchDataNoLoadProfile4 = Regex.Match(dataProfile4, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile4.Contains("//null"))
                    {
                        checkBox4.Text = "Пусто";
                    }
                    else
                    {
                        checkBox4.Text = autchDataNoLoadProfile4;
                    }
                }
                else
                {
                    checkBox4.Text = "Пусто";
                }

                //Профиль 5

                if (ProfileName5 != "")
                {
                    checkBox5.Text = ProfileName5;

                }
                else if (File.Exists(profile5) == true)
                {
                    string dataProfile5 = File.ReadLines(profile5).Skip(0).First();

                    string autchDataNoLoadProfile5 = Regex.Match(dataProfile5, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile5.Contains("//null"))
                    {
                        checkBox5.Text = "Пусто";
                    }
                    else
                    {
                        checkBox5.Text = autchDataNoLoadProfile5;
                    }
                }
                else
                {
                    checkBox5.Text = "Пусто";
                }

                //Профиль 6

                if (ProfileName6 != "")
                {
                    checkBox6.Text = ProfileName6;

                }
                else if (File.Exists(profile6) == true)
                {
                    string dataProfile6 = File.ReadLines(profile6).Skip(0).First();

                    string autchDataNoLoadProfile6 = Regex.Match(dataProfile6, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile6.Contains("//null"))
                    {
                        checkBox6.Text = "Пусто";
                    }
                    else
                    {
                        checkBox6.Text = autchDataNoLoadProfile6;
                    }
                }
                else
                {
                    checkBox6.Text = "Пусто";
                }

                //Профиль 7

                if (ProfileName7 != "")
                {
                    checkBox7.Text = ProfileName7;

                }
                else if (File.Exists(profile7) == true)
                {
                    string dataProfile7 = File.ReadLines(profile7).Skip(0).First();

                    string autchDataNoLoadProfile7 = Regex.Match(dataProfile7, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile7.Contains("//null"))
                    {
                        checkBox7.Text = "Пусто";
                    }
                    else
                    {
                        checkBox7.Text = autchDataNoLoadProfile7;
                    }
                }
                else
                {
                    checkBox7.Text = "Пусто";
                }

                //Профиль 8

                if (ProfileName8 != "")
                {
                    checkBox8.Text = ProfileName8;

                }
                else if (File.Exists(profile8) == true)
                {
                    string dataProfile8 = File.ReadLines(profile8).Skip(0).First();

                    string autchDataNoLoadProfile8 = Regex.Match(dataProfile8, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile8.Contains("//null"))
                    {
                        checkBox8.Text = "Пусто";
                    }
                    else
                    {
                        checkBox8.Text = autchDataNoLoadProfile8;
                    }
                }
                else
                {
                    checkBox8.Text = "Пусто";
                }

                //Профиль 9

                if (ProfileName9 != "")
                {
                    checkBox9.Text = ProfileName9;

                }
                else if (File.Exists(profile9) == true)
                {
                    string dataProfile9 = File.ReadLines(profile9).Skip(0).First();

                    string autchDataNoLoadProfile9 = Regex.Match(dataProfile9, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile9.Contains("//null"))
                    {
                        checkBox9.Text = "Пусто";
                    }
                    else
                    {
                        checkBox9.Text = autchDataNoLoadProfile9;
                    }
                }
                else
                {
                    checkBox9.Text = "Пусто";
                }

                //Профиль 10

                if (ProfileName10 != "")
                {
                    checkBox10.Text = ProfileName10;

                }
                else if (File.Exists(profile10) == true)
                {
                    string dataProfile10 = File.ReadLines(profile10).Skip(0).First();

                    string autchDataNoLoadProfile10 = Regex.Match(dataProfile10, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile10.Contains("//null"))
                    {
                        checkBox10.Text = "Пусто";
                    }
                    else
                    {
                        checkBox10.Text = autchDataNoLoadProfile10;
                    }
                }
                else
                {
                    checkBox10.Text = "Пусто";
                }
            }
            else if (ProfileEnableCheck == "Prof")
            {
                string profile1 = "Data\\Platform\\Plugins\\auth-data-no-load.js";
                string profile2 = "ProfileSave\\1\\Data\\Platform\\Plugins\\auth-data-no-load.js";
                string profile3 = "ProfileSave\\2\\Data\\Platform\\Plugins\\auth-data-no-load.js";
                string profile4 = "ProfileSave\\3\\Data\\Platform\\Plugins\\auth-data-no-load.js";
                string profile5 = "ProfileSave\\4\\Data\\Platform\\Plugins\\auth-data-no-load.js";
                string profile6 = "ProfileSave\\5\\Data\\Platform\\Plugins\\auth-data-no-load.js";
                string profile7 = "ProfileSave\\6\\Data\\Platform\\Plugins\\auth-data-no-load.js";
                string profile8 = "ProfileSave\\7\\Data\\Platform\\Plugins\\auth-data-no-load.js";
                string profile9 = "ProfileSave\\8\\Data\\Platform\\Plugins\\auth-data-no-load.js";
                string profile10 = "ProfileSave\\9\\Data\\Platform\\Plugins\\auth-data-no-load.js";

                if (ProfileName1 != "")
                {
                    checkBox1.Text = ProfileName1;
                }
                else if (File.Exists(profile1) == true)
                {
                    string dataProfile1 = File.ReadLines(profile1).Skip(0).First();

                    string autchDataNoLoadProfile1 = Regex.Match(dataProfile1, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile1.Contains("//null"))
                    {
                        checkBox1.Text = "Пусто";
                    }
                    else
                    {
                        checkBox1.Text = autchDataNoLoadProfile1;
                    }
                }
                else
                {
                    checkBox1.Text = "Пусто";
                }

                //Профиль 2

                if (ProfileName2 != "")
                {
                    checkBox2.Text = ProfileName2;

                }
                else if (File.Exists(profile2) == true)
                {
                    string dataProfile2 = File.ReadLines(profile2).Skip(0).First();

                    string autchDataNoLoadProfile2 = Regex.Match(dataProfile2, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile2.Contains("//null"))
                    {
                        checkBox2.Text = "Пусто";
                    }
                    else
                    {
                        checkBox2.Text = autchDataNoLoadProfile2;
                    }
                }
                else
                {
                    checkBox2.Text = "Пусто";
                }

                //Профиль 3

                if (ProfileName3 != "")
                {
                    checkBox3.Text = ProfileName3;

                }
                else if (File.Exists(profile3) == true)
                {
                    string dataProfile3 = File.ReadLines(profile3).Skip(0).First();

                    string autchDataNoLoadProfile3 = Regex.Match(dataProfile3, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile3.Contains("//null"))
                    {
                        checkBox3.Text = "Пусто";
                    }
                    else
                    {
                        checkBox3.Text = autchDataNoLoadProfile3;
                    }
                }
                else
                {
                    checkBox3.Text = "Пусто";
                }

                //Профиль 4

                if (ProfileName4 != "")
                {
                    checkBox4.Text = ProfileName4;

                }
                else if (File.Exists(profile4) == true)
                {
                    string dataProfile4 = File.ReadLines(profile4).Skip(0).First();

                    string autchDataNoLoadProfile4 = Regex.Match(dataProfile4, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile4.Contains("//null"))
                    {
                        checkBox4.Text = "Пусто";
                    }
                    else
                    {
                        checkBox4.Text = autchDataNoLoadProfile4;
                    }
                }
                else
                {
                    checkBox4.Text = "Пусто";
                }

                //Профиль 5

                if (ProfileName5 != "")
                {
                    checkBox5.Text = ProfileName5;

                }
                else if (File.Exists(profile5) == true)
                {
                    string dataProfile5 = File.ReadLines(profile5).Skip(0).First();

                    string autchDataNoLoadProfile5 = Regex.Match(dataProfile5, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile5.Contains("//null"))
                    {
                        checkBox5.Text = "Пусто";
                    }
                    else
                    {
                        checkBox5.Text = autchDataNoLoadProfile5;
                    }
                }
                else
                {
                    checkBox5.Text = "Пусто";
                }

                //Профиль 6

                if (ProfileName6 != "")
                {
                    checkBox6.Text = ProfileName6;

                }
                else if (File.Exists(profile6) == true)
                {
                    string dataProfile6 = File.ReadLines(profile6).Skip(0).First();

                    string autchDataNoLoadProfile6 = Regex.Match(dataProfile6, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile6.Contains("//null"))
                    {
                        checkBox6.Text = "Пусто";
                    }
                    else
                    {
                        checkBox6.Text = autchDataNoLoadProfile6;
                    }
                }
                else
                {
                    checkBox6.Text = "Пусто";
                }

                //Профиль 7

                if (ProfileName7 != "")
                {
                    checkBox7.Text = ProfileName7;

                }
                else if (File.Exists(profile7) == true)
                {
                    string dataProfile7 = File.ReadLines(profile7).Skip(0).First();

                    string autchDataNoLoadProfile7 = Regex.Match(dataProfile7, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile7.Contains("//null"))
                    {
                        checkBox7.Text = "Пусто";
                    }
                    else
                    {
                        checkBox7.Text = autchDataNoLoadProfile7;
                    }
                }
                else
                {
                    checkBox7.Text = "Пусто";
                }

                //Профиль 8

                if (ProfileName8 != "")
                {
                    checkBox8.Text = ProfileName8;

                }
                else if (File.Exists(profile8) == true)
                {
                    string dataProfile8 = File.ReadLines(profile8).Skip(0).First();

                    string autchDataNoLoadProfile8 = Regex.Match(dataProfile8, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile8.Contains("//null"))
                    {
                        checkBox8.Text = "Пусто";
                    }
                    else
                    {
                        checkBox8.Text = autchDataNoLoadProfile8;
                    }
                }
                else
                {
                    checkBox8.Text = "Пусто";
                }

                //Профиль 9

                if (ProfileName9 != "")
                {
                    checkBox9.Text = ProfileName9;

                }
                else if (File.Exists(profile9) == true)
                {
                    string dataProfile9 = File.ReadLines(profile9).Skip(0).First();

                    string autchDataNoLoadProfile9 = Regex.Match(dataProfile9, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile9.Contains("//null"))
                    {
                        checkBox9.Text = "Пусто";
                    }
                    else
                    {
                        checkBox9.Text = autchDataNoLoadProfile9;
                    }
                }
                else
                {
                    checkBox9.Text = "Пусто";
                }

                //Профиль 10

                if (ProfileName10 != "")
                {
                    checkBox10.Text = ProfileName10;

                }
                else if (File.Exists(profile10) == true)
                {
                    string dataProfile10 = File.ReadLines(profile10).Skip(0).First();

                    string autchDataNoLoadProfile10 = Regex.Match(dataProfile10, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile10.Contains("//null"))
                    {
                        checkBox10.Text = "Пусто";
                    }
                    else
                    {
                        checkBox10.Text = autchDataNoLoadProfile10;
                    }
                }
                else
                {
                    checkBox10.Text = "Пусто";
                }
            }
        }

        private void checkSettingsOff()
        {
            var Setting = new IniFile("Setting.ini");
            Setting.Write("ProfileEnable", "Off", "Setting");
        }

        private void checkSettingsLite()
        {
            var Setting = new IniFile("Setting.ini");
            Setting.Write("ProfileEnable", "Lite", "Setting");
        }

        private void checkSettingsProf()
        {
            var Setting = new IniFile("Setting.ini");
            Setting.Write("ProfileEnable", "Prof", "Setting");
        }

        private void profileEnableCheck()
        {
            label5.Enabled = true;
            label5.Visible = true;

            checkBox1.Enabled = false;
            checkBox1.Visible = false;

            checkBox2.Enabled = false;
            checkBox2.Visible = false;

            checkBox3.Enabled = false;
            checkBox3.Visible = false;

            checkBox4.Enabled = false;
            checkBox4.Visible = false;

            checkBox5.Enabled = false;
            checkBox5.Visible = false;

            checkBox6.Enabled = false;
            checkBox6.Visible = false;

            checkBox7.Enabled = false;
            checkBox7.Visible = false;

            checkBox8.Enabled = false;
            checkBox8.Visible = false;

            checkBox9.Enabled = false;
            checkBox9.Visible = false;

            checkBox10.Enabled = false;
            checkBox10.Visible = false;
        }

        private void profileDisableCheck()
        {
            label5.Enabled = false;
            label5.Visible = false;

            checkBox1.Enabled = true;
            checkBox1.Visible = true;

            checkBox2.Enabled = true;
            checkBox2.Visible = true;

            checkBox3.Enabled = true;
            checkBox3.Visible = true;

            checkBox4.Enabled = true;
            checkBox4.Visible = true;

            checkBox5.Enabled = true;
            checkBox5.Visible = true;

            checkBox6.Enabled = true;
            checkBox6.Visible = true;

            checkBox7.Enabled = true;
            checkBox7.Visible = true;

            checkBox8.Enabled = true;
            checkBox8.Visible = true;

            checkBox9.Enabled = true;
            checkBox9.Visible = true;

            checkBox10.Enabled = true;
            checkBox10.Visible = true;
        }

        private void playerPingCheck()
        {
            WebClient web7Zdll = new WebClient();
            string readver = web7Zdll.DownloadString(new Uri("https://sweetpie.nic11.xyz/api/servers"));

            var ping = new Ping();
            PingReply res = ping.Send("sweetpie.nic11.xyz");

            string autchDataNoLoadProfile7 = Regex.Match(readver, @"(?<=""online"":)(.*)(?=},{""ip"":""51.158.236.73"")").ToString();

            label7.Text = "Онлайн: " + autchDataNoLoadProfile7 + " Ping: " + res.RoundtripTime;
        }

        private void playerPingCheck(object sender, EventArgs e)
        {
            WebClient web7Zdll = new WebClient();
            string readver = web7Zdll.DownloadString(new Uri("https://sweetpie.nic11.xyz/api/servers"));

            var ping = new Ping();
            PingReply res = ping.Send("sweetpie.nic11.xyz");

            string autchDataNoLoadProfile7 = Regex.Match(readver, @"(?<=""online"":)(.*)(?=},{""ip"":""51.158.236.73"")").ToString();

            label7.Text = "Онлайн: " + autchDataNoLoadProfile7 + " Ping: " + res.RoundtripTime;
        }

        private void SkyMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WebClient uninstallDownload = new WebClient())
            {
                uninstallDownload.DownloadFile(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/o41SzD4PCKqabA"), "unins000.dat");
                uninstallDownload.DownloadFile(new Uri("https://www.dropbox.com/scl/fi/xclx83ouds1akiiw3zdbe/unins000.exe?rlkey=czbp5kujtsb1v8bzmlreocxd0&dl=1"), "unins000.exe");

                Thread.Sleep(3000);

                Process.Start("unins000.exe");

                Thread.Sleep(10000);

                if (MessageBox.Show("Вы удалили SkyMP с помощью Деинсталятора?", "Удаление SkyMP", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    skyMPDownload();
                }
            }
        }

        private void launcherUpdate()
        {
            string curver = Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
            string exename = AppDomain.CurrentDomain.FriendlyName;
            string exepath = Assembly.GetExecutingAssembly().Location;

            using (WebClient launcherDownload = new WebClient())
            {
                string readver = launcherDownload.DownloadString(new Uri("https://www.dropbox.com/scl/fi/i3wv671a8xtsohy22ed55/Update.txt?rlkey=fj8k8nn0g3vo4bzadbo9gn9u4&dl=1"));

                if (Convert.ToDouble(curver, CultureInfo.InvariantCulture) == Convert.ToDouble(readver, CultureInfo.InvariantCulture))
                {
                    //Последняя версия
                }
                else
                {
                    if (MessageBox.Show("Доступная новая версия. Обновить?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        launcherDownload.DownloadFile("https://www.dropbox.com/scl/fi/i3wv671a8xtsohy22ed55/Update.txt?rlkey=fj8k8nn0g3vo4bzadbo9gn9u4&dl=1", "SkyMpLauncherNew.exe");

                        Cmd($"taskill /f /im \"{exename}\" && timeout /t 1 && del \"{exepath}\" && ren SkyMpLauncherNew.exe \"{exename}\" && \"{exepath}\"");
                    }
                }
            }
        }

        private void skyMPUpdate()
        {
            string curver = "0.2";

            using (WebClient launcherDownload = new WebClient())
            {
                string readver = launcherDownload.DownloadString(new Uri("https://www.dropbox.com/s/m3moshhmgmsxuw1/Version.txt?dl=1"));

                if (Convert.ToDouble(curver, CultureInfo.InvariantCulture) == Convert.ToDouble(readver, CultureInfo.InvariantCulture))
                {
                    //Последняя версия
                }
                else
                {
                    if (MessageBox.Show("Доступная новая версия SkyMP!", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        File.Delete("SkyMP.z01");
                        File.Delete("SkyMP.z02");
                        File.Delete("SkyMP.z03");
                        File.Delete("SkyMP.z04");
                        File.Delete("SkyMP.zip");

                        Thread.Sleep(3000);

                        skyMPDownload();
                    }
                    else
                    {
                        label4.ForeColor = Color.Red;
                        label4.Text = "Старая версия SkyMP!";
                    }
                }
            }
        }

        public void Cmd(string line)
        {
        }

        private void GraphiscResolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm.Show();
        }

        private void OffProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Произойдет полное отключение Менеджера Аккаунтов", "Отключение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OffProfileToolStripMenuItem.Checked = true;
                LiteToolStripMenuItem.Checked = false;
                ProfToolStripMenuItem.Checked = false;

                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;

                SettingProfileToolStripMenuItem.Visible = false;
                label1.Text = "Профиль:";
                checkSettingsOff();
                profileEnableCheck();

                if (File.Exists("Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-1.js", true);
                }
                if (File.Exists("ProfileSave\\1\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\1\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-2.js", true);
                }
                if (File.Exists("ProfileSave\\2\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\2\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-3.js", true);
                }
                if (File.Exists("ProfileSave\\3\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\3\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-4.js", true);
                }
                if (File.Exists("ProfileSave\\4\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\4\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-5.js", true);
                }
                if (File.Exists("ProfileSave\\5\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\5\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-6.js", true);
                }
                if (File.Exists("ProfileSave\\6\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\6\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-7.js", true);
                }
                if (File.Exists("ProfileSave\\7\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\7\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-8.js", true);
                }
                if (File.Exists("ProfileSave\\8\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\8\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-9.js", true);
                }
                if (File.Exists("ProfileSave\\9\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\9\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-10.js", true);
                }

                Thread.Sleep(1000);

                string[] foldersToRemove = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

                foreach (string folderName in foldersToRemove)
                {
                    string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "ProfileSave\\" + folderName);

                    if (Directory.Exists(folderPath))
                    {
                        DirectoryInfo directory = new DirectoryInfo(folderPath);
                        foreach (FileInfo file in directory.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                        {
                            subDirectory.Delete(true);
                        }
                        Directory.Delete(folderPath);
                    }
                }

                OffProfileToolStripMenuItem.Checked = true;
                LiteToolStripMenuItem.Checked = false;
                ProfToolStripMenuItem.Checked = false;
                SettingProfileToolStripMenuItem.Visible = false;

                label1.Text = "Профиль:";
                checkSettingsOff();
                profileEnableCheck();
                AutchDataNoLoad();

                if (File.Exists("Start.bat") == true)
                    File.Delete("Start.bat");

                string profile1 = "Data\\Platform\\Plugins\\auth-data-no-load.js";

                if (File.Exists(profile1) == true)
                {
                    string dataProfile1 = File.ReadLines(profile1).Skip(0).First();

                    string autchDataNoLoadProfile1 = Regex.Match(dataProfile1, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile1.Contains("//null"))
                    {
                        label5.Text = "Пусто";
                    }
                    else
                    {
                        label5.Text = autchDataNoLoadProfile1;
                    }
                }
                else
                {
                    label5.Text = "Пусто";
                }

            }
        }

        private void LiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Произойдет созданий копий профилей!\nLite не поддерживает запуск нескольких SkyMP одновременно, но он без проблем работает с модами.", "Менеджер Аккаунтов Lite", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OffProfileToolStripMenuItem.Checked = false;
                LiteToolStripMenuItem.Checked = true;
                ProfToolStripMenuItem.Checked = false;

                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;

                SettingProfileToolStripMenuItem.Visible = true;
                label1.Text = "Выберите профиль:";
                checkSettingsLite();
                profileDisableCheck();
                AutchDataNoLoad();

                if (File.Exists("ProfileSave\\ProfileName") == false)
                    Directory.CreateDirectory("ProfileSave\\ProfileName");

                string profile1 = "ProfileSave\\ProfileName\\auth-data-no-load-1.js";
                string profile2 = "ProfileSave\\ProfileName\\auth-data-no-load-2.js";
                string profile3 = "ProfileSave\\ProfileName\\auth-data-no-load-3.js";
                string profile4 = "ProfileSave\\ProfileName\\auth-data-no-load-4.js";
                string profile5 = "ProfileSave\\ProfileName\\auth-data-no-load-5.js";
                string profile6 = "ProfileSave\\ProfileName\\auth-data-no-load-6.js";
                string profile7 = "ProfileSave\\ProfileName\\auth-data-no-load-7.js";
                string profile8 = "ProfileSave\\ProfileName\\auth-data-no-load-8.js";
                string profile9 = "ProfileSave\\ProfileName\\auth-data-no-load-9.js";
                string profile10 = "ProfileSave\\ProfileName\\auth-data-no-load-10.js";

                if (File.Exists("Data\\Platform\\Plugins\\auth-data-no-load.js") == false)
                {
                    File.WriteAllText("Data\\Platform\\Plugins\\auth-data-no-load.js", "//null");
                }

                if (File.Exists(profile1) == false)
                {
                    File.Copy("Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-1.js", true);
                }
                if (File.Exists(profile2) == false)
                {
                    File.WriteAllText(profile2, "//null");
                }
                if (File.Exists(profile3) == false)
                {
                    File.WriteAllText(profile3, "//null");
                }
                if (File.Exists(profile4) == false)
                {
                    File.WriteAllText(profile4, "//null");
                }
                if (File.Exists(profile5) == false)
                {
                    File.WriteAllText(profile5, "//null");
                }
                if (File.Exists(profile6) == false)
                {
                    File.WriteAllText(profile6, "//null");
                }
                if (File.Exists(profile7) == false)
                {
                    File.WriteAllText(profile7, "//null");
                }
                if (File.Exists(profile8) == false)
                {
                    File.WriteAllText(profile8, "//null");
                }
                if (File.Exists(profile9) == false)
                {
                    File.WriteAllText(profile9, "//null");
                }
                if (File.Exists(profile10) == false)
                {
                    File.WriteAllText(profile10, "//null");
                }

                if (File.Exists("ProfileSave\\2\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\2\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-3.js", true);
                }
                if (File.Exists("ProfileSave\\3\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\3\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-4.js", true);
                }
                if (File.Exists("ProfileSave\\4\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\4\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-5.js", true);
                }
                if (File.Exists("ProfileSave\\5\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\5\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-6.js", true);
                }
                if (File.Exists("ProfileSave\\6\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\6\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-7.js", true);
                }
                if (File.Exists("ProfileSave\\7\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\7\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-8.js", true);
                }
                if (File.Exists("ProfileSave\\8\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\8\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-9.js", true);
                }
                if (File.Exists("ProfileSave\\9\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("ProfileSave\\9\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-10.js", true);
                }

                Thread.Sleep(1000);

                string[] foldersToRemove = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

                foreach (string folderName in foldersToRemove)
                {
                    string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "ProfileSave\\" + folderName);

                    if (Directory.Exists(folderPath))
                    {
                        DirectoryInfo directory = new DirectoryInfo(folderPath);
                        foreach (FileInfo file in directory.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                        {
                            subDirectory.Delete(true);
                        }
                        Directory.Delete(folderPath);
                    }
                }

                if (File.Exists("Start.bat") == true)
                    File.Delete("Start.bat");
            }
        }

        private void ProfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Произейдет созданий копий Skyrim и SkyMP!\nProf поддерживает запуск игры в несколько окн, но если стоят сторонние моды, могу быть проблемы с работой.", "Менеджер Акканутов Prof", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OffProfileToolStripMenuItem.Checked = false;
                LiteToolStripMenuItem.Checked = false;
                ProfToolStripMenuItem.Checked = true;

                SettingProfileToolStripMenuItem.Visible = true;
                label1.Text = "Выберите профиль:";
                checkSettingsProf();

                progressBar1.Visible = true;
                progressBar1.Value = 10;

                Start.Enabled = false;
                checkCashToolStripMenuItem.Enabled = false;
                profileEnableToolStripMenuItem.Enabled = false;
                button1.Text = "Идет копирование SkyMP";

                if (File.Exists("ProfileSave\\ProfileName") == false)
                    Directory.CreateDirectory("ProfileSave\\ProfileName");

                string profileLite1 = "ProfileSave\\ProfileName\\auth-data-no-load-1.js";
                string profileLite2 = "ProfileSave\\ProfileName\\auth-data-no-load-2.js";
                string profileLite3 = "ProfileSave\\ProfileName\\auth-data-no-load-3.js";
                string profileLite4 = "ProfileSave\\ProfileName\\auth-data-no-load-4.js";
                string profileLite5 = "ProfileSave\\ProfileName\\auth-data-no-load-5.js";
                string profileLite6 = "ProfileSave\\ProfileName\\auth-data-no-load-6.js";
                string profileLite7 = "ProfileSave\\ProfileName\\auth-data-no-load-7.js";
                string profileLite8 = "ProfileSave\\ProfileName\\auth-data-no-load-8.js";
                string profileLite9 = "ProfileSave\\ProfileName\\auth-data-no-load-9.js";
                string profileLite10 = "ProfileSave\\ProfileName\\auth-data-no-load-10.js";

                HashSet<string> excludedItems = new HashSet<string>
                {
                    "SweetPie.esp",
                    "CombatSettings.esp",
                    "Platform",
                    "Interface",
                    "lodsettings",
                    "MCM",
                    "Scripts",
                    "SKSE",
                    "Strings",
                };

                Thread thread = new Thread(() =>
                {

                    for (int i = 1; i <= 10; i++)
                    {
                        if (i <= 9)
                        {
                            Directory.CreateDirectory("ProfileSave\\" + i + "\\Data\\");
                            Directory.CreateDirectory("ProfileSave\\" + i + "\\Data\\ShaderCache");
                            Directory.CreateDirectory("ProfileSave\\" + i + "\\Data\\Video");
                            Directory.CreateDirectory("ProfileSave\\" + i + "\\Skyrim");
                            Directory.CreateDirectory("ProfileSave\\" + i + "\\Data\\lodsettings");

                            CopyAllExceptCertainFolders(".", "ProfileSave\\" + i + "\\");

                            //CreateHardLinkExcludeFolder("Data", "ProfileSave\\" + i + "\\Data");

                            CreateHardLinks("Data", "ProfileSave\\" + i + "\\Data", excludedItems);

                            CopyFilesRecursively("Data", "ProfileSave\\" + i + "\\Data");

                            File.Copy("Data\\CombatSettings.esp", "ProfileSave\\" + i + "\\Data\\CombatSettings.esp", true);
                            File.Copy("Data\\SweetPie.esp", "ProfileSave\\" + i + "\\Data\\SweetPie.esp", true);

                            File.Copy("Data\\lodsettings\\Hall.lod", "ProfileSave\\" + i + "\\Data\\lodsettings\\Hall.lod", true);
                            File.Copy("Data\\lodsettings\\Tamriel.LOD", "ProfileSave\\" + i + "\\Data\\lodsettings\\Tamriel.LOD", true);

                            File.WriteAllText("ProfileSave\\" + i + "\\Start.bat", "if \"1\"==\"1\" (\r\ncls\r\ncd /d \"%~dp0\"\r\nstart skse64_loader.exe\r\n)");

                            progressBar1.Value = progressBar1.Value + 10;
                        }
                        else if (i == 10)
                        {
                            File.WriteAllText("Start.bat", "if \"1\"==\"1\" (\r\ncls\r\ncd /d \"%~dp0\"\r\nstart skse64_loader.exe\r\n)");

                            if (File.Exists(profileLite1) == true)
                            {
                                File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-1.js", "Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                            }
                            if (File.Exists(profileLite2) == true)
                            {
                                File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-2.js", "ProfileSave\\1\\Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                            }
                            if (File.Exists(profileLite3) == true)
                            {
                                File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-3.js", "ProfileSave\\2\\Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                            }
                            if (File.Exists(profileLite4) == true)
                            {
                                File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-4.js", "ProfileSave\\3\\Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                            }
                            if (File.Exists(profileLite5) == true)
                            {
                                File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-5.js", "ProfileSave\\4\\Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                            }
                            if (File.Exists(profileLite6) == true)
                            {
                                File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-6.js", "ProfileSave\\5\\Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                            }
                            if (File.Exists(profileLite7) == true)
                            {
                                File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-7.js", "ProfileSave\\6\\Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                            }
                            if (File.Exists(profileLite8) == true)
                            {
                                File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-8.js", "ProfileSave\\7\\Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                            }
                            if (File.Exists(profileLite9) == true)
                            {
                                File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-9.js", "ProfileSave\\8\\Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                            }
                            if (File.Exists(profileLite10) == true)
                            {
                                File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-10.js", "ProfileSave\\9\\Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                            }

                            checkCashToolStripMenuItem.Enabled = true;
                            progressBar1.Visible = false;
                            Start.Enabled = true;
                            profileEnableToolStripMenuItem.Enabled = true;
                            profileDisableCheck();
                            AutchDataNoLoad();
                            button1.Text = "Установлено";
                        }
                    }
                });
                thread.Start();
            }
        }

        public static void CopyAllExceptCertainFolders(string sourceDir, string destinationDir)
        {
            string[] excludeDirectories = { "Data", "ProfileSave", "Setting", "Setup", "app.publish" };

            string[] excludeFiles = { "SkyMpLauncher.exe", "Mono.Nat.dll", "MonoTorrent.dll", "ReusableTasks.dll", "DotNetZip.dll" };

            CopyDirectory(sourceDir, destinationDir, excludeDirectories, excludeFiles);
        }

        static void CopyDirectory(string sourceDir, string destinationDir, string[] excludeDirectories, string[] excludeFiles)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);

            // Copy all files in the directory
            foreach (FileInfo file in dir.GetFiles())
            {
                // Skip files that match the exclude list
                if (!excludeFiles.Contains(file.Name))
                {
                    string tempPath = Path.Combine(destinationDir, file.Name);
                    file.CopyTo(tempPath, true);
                }
            }

            // Copy all subdirectories in the directory
            foreach (DirectoryInfo subdir in dir.GetDirectories())
            {
                // Skip subdirectories that match the exclude list
                if (!excludeDirectories.Contains(subdir.Name))
                {
                    string tempPath = Path.Combine(destinationDir, subdir.Name);
                    Directory.CreateDirectory(tempPath);
                    CopyDirectory(subdir.FullName, tempPath, excludeDirectories, excludeFiles);
                }
            }
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool CreateHardLink(string lpFileName, string lpExistingFileName, IntPtr lpSecurityAttributes);

        private static void CreateHardLinks(string sourceDirectory, string targetDirectory, HashSet<string> excludedItems)
        {
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            foreach (var directory in Directory.GetDirectories(sourceDirectory))
            {
                var dirInfo = new DirectoryInfo(directory);
                if (!excludedItems.Contains(dirInfo.Name))
                {
                    string targetSubDir = Path.Combine(targetDirectory, dirInfo.Name);
                    CreateHardLinks(directory, targetSubDir, excludedItems);
                }
            }

            foreach (var file in Directory.GetFiles(sourceDirectory))
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!excludedItems.Contains(fileInfo.Name))
                {
                    string targetFile = Path.Combine(targetDirectory, fileInfo.Name);
                    if (!CreateHardLink(targetFile, file, IntPtr.Zero))
                    {
                        throw new Exception($"Failed to create hard link. Source: '{file}', Target: '{targetFile}', Error: {Marshal.GetLastWin32Error()}");
                    }
                }
            }
        }

        private static void CopyFilesRecursively(string sourceDir, string targetDir)
        {
            // список директорий, которые необходимо скопировать
            string[] dirsToCopy = new string[] { "Platform", "Interface", "lodsettings", "MCM", "Scripts", "SKSE", "Strings" };

            foreach (string dirName in dirsToCopy)
            {
                string sourcePath = Path.Combine(sourceDir, dirName);
                string targetPath = Path.Combine(targetDir, dirName);

                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }

                // копирование файлов и директорий
                foreach (string sourceFileName in Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories))
                {
                    string targetFileName = sourceFileName.Replace(sourcePath, targetPath);
                    Directory.CreateDirectory(Path.GetDirectoryName(targetFileName));
                    File.Copy(sourceFileName, targetFileName, true);
                }
            }
        }

        private void profileCheck()
        {
            var Setting = new IniFile("Setting.ini");
            string ProfileEnableCheck = Setting.Read("ProfileEnable", "Setting");

            if (ProfileEnableCheck == "Off")
            {
                OffProfileToolStripMenuItem.Checked = true;
                LiteToolStripMenuItem.Checked = false;
                ProfToolStripMenuItem.Checked = false;
                SettingProfileToolStripMenuItem.Visible = false;

                label1.Text = "Профиль:";
                checkSettingsOff();
                profileEnableCheck();

                string profile1 = "Data\\Platform\\Plugins\\auth-data-no-load.js";

                if (File.Exists("ProfileSave\\ProfileName\\auth-data-no-load-1.js") == true)
                {
                    File.Copy("ProfileSave\\ProfileName\\auth-data-no-load-1.js", "Data\\Platform\\Plugins\\auth-data-no-load.js", true);
                }

                if (File.Exists(profile1) == true)
                {
                    string dataProfile1 = File.ReadLines(profile1).Skip(0).First();

                    string autchDataNoLoadProfile1 = Regex.Match(dataProfile1, @"(?<=""discordUsername"":"")(.*)(?="",""discordDiscriminator"")").ToString();

                    if (dataProfile1.Contains("//null"))
                    {
                        label5.Text = "Пусто";
                    }
                    else
                    {
                        label5.Text = autchDataNoLoadProfile1;
                    }
                }
                else
                {
                    label5.Text = "Пусто";
                }
            }
            else if (ProfileEnableCheck == "Lite")
            {
                OffProfileToolStripMenuItem.Checked = false;
                LiteToolStripMenuItem.Checked = true;
                ProfToolStripMenuItem.Checked = false;

                SettingProfileToolStripMenuItem.Visible = true;
                label1.Text = "Выберите профиль:";
                checkSettingsLite();
                profileDisableCheck();
            }
            else if (ProfileEnableCheck == "Prof")
            {
                OffProfileToolStripMenuItem.Checked = false;
                LiteToolStripMenuItem.Checked = false;
                ProfToolStripMenuItem.Checked = true;

                SettingProfileToolStripMenuItem.Visible = true;
                label1.Text = "Выберите профиль:";
                checkSettingsProf();
                profileDisableCheck();
            }
        }

        Form2 txtf2;

        private void SettingProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtf2 = new Form2(this);

            txtf2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/RtzVaJJw");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/pYAvYUHW");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/dRzS4Nnp");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/rD47Den2");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/aSxKEJf6");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Скоро", "Хыы...", MessageBoxButtons.OK);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/BUDBfcaGyz");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/B694VsSa7k");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/CpB4CZ96CS");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/p75HXBDP");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/4jmjU9tht8");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/c5cJjfHu");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/overheardskymp");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/RtzVaJJw");
        }

        private void ManagerProfileName()
        {
            if (File.Exists("Profile") == true)
            {
                if (File.Exists("Profile\\1\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("Profile\\1\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-2.js", true);
                }
                if (File.Exists("Profile\\2\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("Profile\\2\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-3.js", true);
                }
                if (File.Exists("Profile\\3\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("Profile\\3\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-4.js", true);
                }
                if (File.Exists("Profile\\4\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("Profile\\4\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-5.js", true);
                }
                if (File.Exists("Profile\\5\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("Profile\\5\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-6.js", true);
                }
                if (File.Exists("Profile\\6\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("Profile\\6\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-7.js", true);
                }
                if (File.Exists("Profile\\7\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("Profile\\7\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-8.js", true);
                }
                if (File.Exists("Profile\\8\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("Profile\\8\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-9.js", true);
                }
                if (File.Exists("Profile\\9\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    File.Copy("Profile\\9\\Data\\Platform\\Plugins\\auth-data-no-load.js", "ProfileSave\\ProfileName\\auth-data-no-load-10.js", true);
                }

                var Setting = new IniFile("Setting.ini");

                if (File.Exists("ProfileName.txt") == true)
                {
                    string text = File.ReadAllText("ProfileName.txt", Encoding.GetEncoding(1251));
                    Setting.Write("ProfileName-1", text, "Profile");
                }
                if (File.Exists("Profile\\1\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    string text = File.ReadAllText("Profile\\1\\Data\\Platform\\Plugins\\auth-data-no-load.js", Encoding.GetEncoding(1251));
                    Setting.Write("ProfileName-2", text, "Profile");
                }
                if (File.Exists("Profile\\2\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    string text = File.ReadAllText("Profile\\2\\Data\\Platform\\Plugins\\auth-data-no-load.js", Encoding.GetEncoding(1251));
                    Setting.Write("ProfileName-3", text, "Profile");
                }
                if (File.Exists("Profile\\3\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    string text = File.ReadAllText("Profile\\3\\Data\\Platform\\Plugins\\auth-data-no-load.js", Encoding.GetEncoding(1251));
                    Setting.Write("ProfileName-4", text, "Profile");
                }
                if (File.Exists("Profile\\4\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    string text = File.ReadAllText("Profile\\4\\Data\\Platform\\Plugins\\auth-data-no-load.js", Encoding.GetEncoding(1251));
                    Setting.Write("ProfileName-5", text, "Profile");
                }
                if (File.Exists("Profile\\5\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    string text = File.ReadAllText("Profile\\5\\Data\\Platform\\Plugins\\auth-data-no-load.js", Encoding.GetEncoding(1251));
                    Setting.Write("ProfileName-6", text, "Profile");
                }
                if (File.Exists("Profile\\6\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    string text = File.ReadAllText("Profile\\6\\Data\\Platform\\Plugins\\auth-data-no-load.js", Encoding.GetEncoding(1251));
                    Setting.Write("ProfileName-7", text, "Profile");
                }
                if (File.Exists("Profile\\7\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    string text = File.ReadAllText("Profile\\7\\Data\\Platform\\Plugins\\auth-data-no-load.js", Encoding.GetEncoding(1251));
                    Setting.Write("ProfileName-8", text, "Profile");
                }
                if (File.Exists("Profile\\8\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    string text = File.ReadAllText("Profile\\8\\Data\\Platform\\Plugins\\auth-data-no-load.js", Encoding.GetEncoding(1251));
                    Setting.Write("ProfileName-9", text, "Profile");
                }
                if (File.Exists("Profile\\9\\Data\\Platform\\Plugins\\auth-data-no-load.js") == true)
                {
                    string text = File.ReadAllText("Profile\\9\\Data\\Platform\\Plugins\\auth-data-no-load.js", Encoding.GetEncoding(1251));
                    Setting.Write("ProfileName-10", text, "Profile");
                }

                Thread.Sleep(1000);

                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Profile");

                if (Directory.Exists(folderPath))
                {
                    DirectoryInfo directory = new DirectoryInfo(folderPath);
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                    {
                        subDirectory.Delete(true);
                    }
                    Directory.Delete(folderPath);
                }

                File.Delete("SkyMp-Profile.bat");
                File.Delete("Editor.bat");
                File.Delete("Update.bat");
                File.Delete("ProfileName.txt");
            }

        }

        private void batAnimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (batAnimToolStripMenuItem.Checked == true)
            {
                WebClient AnimZip = new WebClient();
                AnimZip.DownloadFileAsync(new Uri("https://www.dropbox.com/scl/fi/s2au0ko111is1mgd82i01/Anim.zip?rlkey=4e7zk68nhgwd5kg4f9r7fclq7&dl=1"), "Anim.zip");
                Thread.Sleep(5000);

                using (ZipFile zip = ZipFile.Read("Anim.zip"))
                {
                    foreach (ZipEntry entry in zip)
                    {
                        entry.Extract(ExtractExistingFileAction.OverwriteSilently);
                    }
                }

                Thread.Sleep(5000);

                if (File.Exists("ProfileSave\\1") == true)
                {
                    for(int i = 1; i <= 9; i++)
                    {
                        CopyDirectory("Anim", "ProfileSave\\" + i, true);
                    }
                }

                File.Delete("Anim.zip");
            }
            else if (batAnimToolStripMenuItem.Checked == false)
            {
                File.Delete("AnimList-1.txt");
                File.Delete("AnimList-2.txt");

                if (File.Exists("ProfileSave\\1") == true)
                {
                    for (int i = 1; i <= 9; i++)
                    {
                        Directory.Delete("ProfileSave\\" + i + "\\Anim", true);
                    }
                }

                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "anim");

                if (Directory.Exists(folderPath))
                {
                    DirectoryInfo directory = new DirectoryInfo(folderPath);
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                    {
                        subDirectory.Delete(true);
                    }
                    Directory.Delete(folderPath);
                }
            }

        }

        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////

        int ClientFIle;

        private void clientDownload()
        {
            progressBar1.Enabled = true;
            button1.Enabled = false;
            progressBar1.Visible = true;
            label4.Visible = false;

            Directory.CreateDirectory("Data\\ShaderCache");
            Directory.CreateDirectory("Data\\Video");
            Directory.CreateDirectory("Skyrim");
            Directory.CreateDirectory("ProfileSave\\ProfileName");

            Dictionary<Uri, string> dict = new Dictionary<Uri, string>();

            if (File.Exists("Data\\Video\\BGS_Logo.bik") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/ZxLA11uUdSQQtQ"), "Data\\Video\\BGS_Logo.bik");
            }

            if (File.Exists("Data\\ccBGSSSE001-Fish.bsa") == true && new FileInfo("Data\\ccBGSSSE001-Fish.bsa").Length != 377673669)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/xhXbkfdgcQKwtg"), "Data\\ccBGSSSE001-Fish.bsa");
            }
            else if (File.Exists("Data\\ccBGSSSE001-Fish.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/xhXbkfdgcQKwtg"), "Data\\ccBGSSSE001-Fish.bsa");
            }

            if (File.Exists("Data\\ccBGSSSE001-Fish.esm") == true && new FileInfo("Data\\ccBGSSSE001-Fish.esm").Length != 1425350)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/VEkXgDAZyD17Dw"), "Data\\ccBGSSSE001-Fish.esm");
            }
            else if (File.Exists("Data\\ccBGSSSE001-Fish.esm") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/VEkXgDAZyD17Dw"), "Data\\ccBGSSSE001-Fish.esm");
            }

            if (File.Exists("Data\\ccBGSSSE025-AdvDSGS.bsa") == true && new FileInfo("Data\\ccBGSSSE025-AdvDSGS.bsa").Length != 1092876206)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/64z055cvr_sADg"), "Data\\ccBGSSSE025-AdvDSGS.bsa");
            }
            else if (File.Exists("Data\\ccBGSSSE025-AdvDSGS.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/64z055cvr_sADg"), "Data\\ccBGSSSE025-AdvDSGS.bsa");
            }

            if (File.Exists("Data\\ccBGSSSE025-AdvDSGS.esm") == true && new FileInfo("Data\\ccBGSSSE025-AdvDSGS.esm").Length != 812763)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/RTDdF49Rot04xQ"), "Data\\ccBGSSSE025-AdvDSGS.esm");
            }
            else if (File.Exists("Data\\ccBGSSSE025-AdvDSGS.esm") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/RTDdF49Rot04xQ"), "Data\\ccBGSSSE025-AdvDSGS.esm");
            }

            if (File.Exists("Data\\ccBGSSSE037-Curios.bsa") == true && new FileInfo("Data\\ccBGSSSE037-Curios.bsa").Length != 111740475)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/PBp_RIp3WDtSzA"), "Data\\ccBGSSSE037-Curios.bsa");
            }
            else if (File.Exists("Data\\ccBGSSSE037-Curios.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/PBp_RIp3WDtSzA"), "Data\\ccBGSSSE037-Curios.bsa");
            }

            if (File.Exists("Data\\ccBGSSSE037-Curios.esl") == true && new FileInfo("Data\\ccBGSSSE037-Curios.esl").Length != 37476)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/h__6NGFUYVh-qw"), "Data\\ccBGSSSE037-Curios.esl");
            }
            else if (File.Exists("Data\\ccBGSSSE037-Curios.esl") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/h__6NGFUYVh-qw"), "Data\\ccBGSSSE037-Curios.esl");
            }

            if (File.Exists("Data\\ccQDRSSE001-SurvivalMode.bsa") == true && new FileInfo("Data\\ccQDRSSE001-SurvivalMode.bsa").Length != 12835601)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/Xib62GX_UWcKjw"), "Data\\ccQDRSSE001-SurvivalMode.bsa");
            }
            else if (File.Exists("Data\\ccQDRSSE001-SurvivalMode.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/Xib62GX_UWcKjw"), "Data\\ccQDRSSE001-SurvivalMode.bsa");
            }

            if (File.Exists("Data\\ccQDRSSE001-SurvivalMode.esl") == true && new FileInfo("Data\\ccQDRSSE001-SurvivalMode.esl").Length != 240724)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/E1EtSxXNiw2sWw"), "Data\\ccQDRSSE001-SurvivalMode.esl");
            }
            else if (File.Exists("Data\\ccQDRSSE001-SurvivalMode.esl") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/E1EtSxXNiw2sWw"), "Data\\ccQDRSSE001-SurvivalMode.esl");
            }

            if (File.Exists("Data\\Dawnguard.esm") == true && new FileInfo("Data\\Dawnguard.esm").Length != 25884627)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/U26FoLGKcHOn9w"), "Data\\Dawnguard.esm");
            }
            else if (File.Exists("Data\\Dawnguard.esm") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/U26FoLGKcHOn9w"), "Data\\Dawnguard.esm");
            }

            if (File.Exists("Data\\Dragonborn.esm") == true && new FileInfo("Data\\Dragonborn.esm").Length != 64663944)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/tc3nxmatsHBlRA"), "Data\\Dragonborn.esm");
            }
            else if (File.Exists("Data\\Dragonborn.esm") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/tc3nxmatsHBlRA"), "Data\\Dragonborn.esm");
            }

            if (File.Exists("Data\\HearthFires.esm") == true && new FileInfo("Data\\HearthFires.esm").Length != 3977660)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/OUy1sG_o0v4JLw"), "Data\\HearthFires.esm");
            }
            else if (File.Exists("Data\\HearthFires.esm") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/OUy1sG_o0v4JLw"), "Data\\HearthFires.esm");
            }

            if (File.Exists("Data\\Skyrim - Animations.bsa") == true && new FileInfo("Data\\Skyrim - Animations.bsa").Length != 65101236)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/9x0pDK_qj3taxQ"), "Data\\Skyrim - Animations.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Animations.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/9x0pDK_qj3taxQ"), "Data\\Skyrim - Animations.bsa");
            }

            if (File.Exists("Data\\Skyrim - Interface.bsa") == true && new FileInfo("Data\\Skyrim - Interface.bsa").Length != 105751175)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/0uNLESdO8zgMXQ"), "Data\\Skyrim - Interface.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Interface.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/0uNLESdO8zgMXQ"), "Data\\Skyrim - Interface.bsa");
            }

            if (File.Exists("Data\\Skyrim - Meshes0.bsa") == true && new FileInfo("Data\\Skyrim - Meshes0.bsa").Length != 1153090124)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/1eNANEz6IckrdQ"), "Data\\Skyrim - Meshes0.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Meshes0.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/1eNANEz6IckrdQ"), "Data\\Skyrim - Meshes0.bsa");
            }

            if (File.Exists("Data\\Skyrim - Meshes1.bsa") == true && new FileInfo("Data\\Skyrim - Meshes1.bsa").Length != 378853391)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/yU3WjNd4_Ohj_g"), "Data\\Skyrim - Meshes1.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Meshes1.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/yU3WjNd4_Ohj_g"), "Data\\Skyrim - Meshes1.bsa");
            }

            if (File.Exists("Data\\Skyrim - Misc.bsa") == true && new FileInfo("Data\\Skyrim - Misc.bsa").Length != 204987429)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/QsK3rYxsKUUVyA"), "Data\\Skyrim - Misc.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Misc.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/QsK3rYxsKUUVyA"), "Data\\Skyrim - Misc.bsa");
            }

            if (File.Exists("Data\\Skyrim - Shaders.bsa") == true && new FileInfo("Data\\Skyrim - Shaders.bsa").Length != 67308970)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/B4OEeEbIJ5gwCg"), "Data\\Skyrim - Shaders.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Shaders.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/B4OEeEbIJ5gwCg"), "Data\\Skyrim - Shaders.bsa");
            }

            if (File.Exists("Data\\Skyrim - Sounds.bsa") == true && new FileInfo("Data\\Skyrim - Sounds.bsa").Length != 1538656059)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/1elFgRkcSoW8ow"), "Data\\Skyrim - Sounds.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Sounds.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/1elFgRkcSoW8ow"), "Data\\Skyrim - Sounds.bsa");
            }

            if (File.Exists("Data\\Skyrim - Textures0.bsa") == true && new FileInfo("Data\\Skyrim - Textures0.bsa").Length != 652401558)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/p-yOffuzQWV6IQ"), "Data\\Skyrim - Textures0.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Textures0.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/p-yOffuzQWV6IQ"), "Data\\Skyrim - Textures0.bsa");
            }

            if (File.Exists("Data\\Skyrim - Textures1.bsa") == true && new FileInfo("Data\\Skyrim - Textures1.bsa").Length != 1511504224)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/qWyskTixrvZzhA"), "Data\\Skyrim - Textures1.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Textures1.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/qWyskTixrvZzhA"), "Data\\Skyrim - Textures1.bsa");
            }

            if (File.Exists("Data\\Skyrim - Textures2.bsa") == true && new FileInfo("Data\\Skyrim - Textures2.bsa").Length != 1346030841)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/smEZET9xv32G1Q"), "Data\\Skyrim - Textures2.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Textures2.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/smEZET9xv32G1Q"), "Data\\Skyrim - Textures2.bsa");
            }

            if (File.Exists("Data\\Skyrim - Textures3.bsa") == true && new FileInfo("Data\\Skyrim - Textures3.bsa").Length != 1401677791)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/sb82Yfdx9e1-cg"), "Data\\Skyrim - Textures3.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Textures3.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/sb82Yfdx9e1-cg"), "Data\\Skyrim - Textures3.bsa");
            }

            if (File.Exists("Data\\Skyrim - Textures4.bsa") == true && new FileInfo("Data\\Skyrim - Textures4.bsa").Length != 1265325033)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/22oGBSYtqYUXGA"), "Data\\Skyrim - Textures4.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Textures4.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/22oGBSYtqYUXGA"), "Data\\Skyrim - Textures4.bsa");
            }

            if (File.Exists("Data\\Skyrim - Textures5.bsa") == true && new FileInfo("Data\\Skyrim - Textures5.bsa").Length != 809121183)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/CE5pZnfDBdfrkQ"), "Data\\Skyrim - Textures5.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Textures5.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/CE5pZnfDBdfrkQ"), "Data\\Skyrim - Textures5.bsa");
            }

            if (File.Exists("Data\\Skyrim - Textures6.bsa") == true && new FileInfo("Data\\Skyrim - Textures6.bsa").Length != 107211187)
            {
                FileInfo Del = new FileInfo("Data\\Skyrim - Textures6.bsa");
                Del.Delete();

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/MJmIpJapYI58dw"), "Data\\Skyrim - Textures6.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Textures6.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/MJmIpJapYI58dw"), "Data\\Skyrim - Textures6.bsa");
            }

            if (File.Exists("Data\\Skyrim - Textures7.bsa") == true && new FileInfo("Data\\Skyrim - Textures7.bsa").Length != 700733354)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/DtR9ilNB-CCF1Q"), "Data\\Skyrim - Textures7.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Textures7.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/DtR9ilNB-CCF1Q"), "Data\\Skyrim - Textures7.bsa");
            }

            if (File.Exists("Data\\Skyrim - Textures78.bsa") == true && new FileInfo("Data\\Skyrim - Textures8.bsa").Length != 214496000)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/Ds5YSFyEsv0TcQ"), "Data\\Skyrim - Textures8.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Textures8.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/Ds5YSFyEsv0TcQ"), "Data\\Skyrim - Textures8.bsa");
            }

            if (File.Exists("Data\\Skyrim - Voices_en0.bsa") == true && new FileInfo("Data\\Skyrim - Voices_en0.bsa").Length != 1807969854)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/iAKOlNzRHTb7Tg"), "Data\\Skyrim - Voices_en0.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Voices_en0.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/iAKOlNzRHTb7Tg"), "Data\\Skyrim - Voices_en0.bsa");
            }

            if (File.Exists("Data\\Skyrim - Voices_ru0.bsa") == true && new FileInfo("Data\\Skyrim - Voices_ru0.bsa").Length != 2033032883)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/61VGGjdDvEHNAw"), "Data\\Skyrim - Voices_ru0.bsa");
            }
            else if (File.Exists("Data\\Skyrim - Voices_ru0.bsa") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/61VGGjdDvEHNAw"), "Data\\Skyrim - Voices_ru0.bsa");
            }

            if (File.Exists("Data\\Skyrim.esm") == true && new FileInfo("Data\\Skyrim.esm").Length != 249753351)
            {

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/NfbZjqWtqnLxJQ"), "Data\\Skyrim.esm");
            }
            else if (File.Exists("Data\\Skyrim.esm") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/NfbZjqWtqnLxJQ"), "Data\\Skyrim.esm");
            }

            if (File.Exists("Data\\Update.esm") == true && new FileInfo("Data\\Update.esm").Length != 18857707)
            {
                FileInfo Del = new FileInfo("Data\\Update.esm");
                Del.Delete();

                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/LPdtdosIovZu7g"), "Data\\Update.esm");
            }
            else if (File.Exists("Data\\Update.esm") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/LPdtdosIovZu7g"), "Data\\Update.esm");
            }

            if (File.Exists("Skyrim\\Skyrim.ini") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/CQ6sOrufF2erkw"), "Skyrim\\Skyrim.ini");
            }

            if (File.Exists("Skyrim\\SkyrimPrefs.ini") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/i/4pzQOvHe-AGdIw"), "Skyrim\\SkyrimPrefs.ini");
            }

            if (File.Exists("bink2w64.dll") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/09DQ5YzaUj_nSA"), "bink2w64.dll");
            }

            if (File.Exists("High.ini") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/i/RpV9ba9A6rQoHQ"), "High.ini");
            }

            if (File.Exists("installscript.vdf") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/BOIJyFnw_QWZsQ"), "installscript.vdf");
            }

            if (File.Exists("Low.ini") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/i/2vA51-b1Rhh5Rg"), "Low.ini");
            }

            if (File.Exists("Medium.ini") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/i/kW-aVmL4Aa0IbA"), "Medium.ini");
            }

            if (File.Exists("Skyrim.ccc") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/948WJQi0C9crvA"), "Skyrim.ccc");
            }

            if (File.Exists("Skyrim_Default.ini") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/i/G9LdInrOPut_Jw"), "Skyrim_Default.ini");
            }

            if (File.Exists("Ultra.ini") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/hcuFO4mdAaQqzQ"), "Ultra.ini");
            }

            if (File.Exists("SkyrimSELauncher.exe") != true)
            {
                ClientFIle++;
                dict.Add(new Uri("https://www.dropbox.com/scl/fi/dkge1g0c32elnaky89d9b/SkyrimSELauncher.exe?rlkey=o8gcvlo459vj9n4r5la22yo2t&dl=1"), "SkyrimSELauncher.exe");
            }

            if (File.Exists("SkyrimSE.exe") != true || FileVersionInfo.GetVersionInfo("SkyrimSE.exe").FileVersion != "1.6.640.0")
            {
                if (File.Exists("SkyrimSE.exe") == true && FileVersionInfo.GetVersionInfo("SkyrimSE.exe").FileVersion != "1.6.640.0")
                {
                    FileInfo Del = new FileInfo("SkyrimSE.exe");
                    Del.Delete();
                }

                ClientFIle++;
                dict.Add(new Uri("https://www.dropbox.com/scl/fi/snuy0wlex0zk1eunywjem/SkyrimSE.exe?rlkey=su7mmawjcxaenbezwf6kzcdi4&dl=1"), "SkyrimSE.exe");

                ClientFIle++;
                dict.Add(new Uri("https://www.dropbox.com/scl/fi/omxu1mgprswim25x0jxls/steam_emu.ini?rlkey=bdj1rczmq7y90uy2bx1i21dqy&dl=1"), "steam_emu.ini");

                ClientFIle++;
                dict.Add(new Uri("https://www.dropbox.com/scl/fi/wrkabvemg7lqdysgv9hz9/steam_api64.dll?rlkey=ynvuqdjob8pbwwfqmmxroi0sp&dl=1"), "steam_api64.dll");

                ClientFIle++;
                dict.Add(new Uri("https://www.dropbox.com/scl/fi/6t2cw5w2btwrm2ndla0q9/steam_api64.cdx?rlkey=8zdf3eso4j0id1cbbpyh6bi14&dl=1"), "steam_api64.cdx");
            }

            DownloadManyFilesClient(dict);

        }

        public async Task DownloadManyFilesClient(Dictionary<Uri, string> files)
        {
            WebClient wc1 = new WebClient();
            wc1.DownloadProgressChanged += (s, e) => progressBar1.Value = e.ProgressPercentage;
            int number = 0;

            label6.Visible = true;

            foreach (KeyValuePair<Uri, string> pair in files)
            {

                label6.Text = "Cкачено " + number++ + "/" + ClientFIle;

                button1.Text = "Скачивается: " + pair.Value;
                await wc1.DownloadFileTaskAsync(pair.Key, pair.Value);
            }

            wc1.Dispose();

            label3.ForeColor = Color.White;
            label3.Text = "Версия " + FileVersionInfo.GetVersionInfo("SkyrimSE.exe").FileVersion;

            progressBar1.Enabled = false;
            button1.Enabled = true;
            progressBar1.Visible = false;
            label4.Visible = true;
            modManagerToolStripMenuItem.Enabled = true;

            if (!File.Exists("Data\\CombatSettings.esp") && !File.Exists("Data\\SweetPie.esp"))
            {
                skyMPDownload();
            }
        }

        int ServerFile;

        private void skyMPDownload()
        {

            progressBar1.Enabled = true;
            button1.Enabled = false;
            progressBar1.Visible = true;
            label4.Visible = false;

            Directory.CreateDirectory("Setup");

            Dictionary<Uri, string> dict2 = new Dictionary<Uri, string>();

            if (File.Exists("Setup\\SkyMP.z01") == true && new FileInfo("Setup\\SkyMP.z01").Length != 1073741824)
            {
                ServerFile++;
                dict2.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/kQIeDAuHWWa6EA"), "Setup\\SkyMP.z01");
            }
            else if (File.Exists("Setup\\SkyMP.z01") != true)
            {
                ServerFile++;
                dict2.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/kQIeDAuHWWa6EA"), "Setup\\SkyMP.z01");
            }

            if (File.Exists("Setup\\SkyMP.z02") == true && new FileInfo("Setup\\SkyMP.z02").Length != 1073741824)
            {
                ServerFile++;
                dict2.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/1EuxfnvfLgKAHg"), "Setup\\SkyMP.z02");
            }
            else if (File.Exists("Setup\\SkyMP.z02") != true)
            {
                ServerFile++;
                dict2.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/1EuxfnvfLgKAHg"), "Setup\\SkyMP.z02");
            }

            if (File.Exists("Setup\\SkyMP.z03") == true && new FileInfo("Setup\\SkyMP.z03").Length != 1073741824)
            {
                ServerFile++;
                dict2.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/w2T5uixjugp_YA"), "Setup\\SkyMP.z03");
            }
            else if (File.Exists("Setup\\SkyMP.z03") != true)
            {
                ServerFile++;
                dict2.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/w2T5uixjugp_YA"), "Setup\\SkyMP.z03");
            }

            if (File.Exists("Setup\\SkyMP.z04") == true && new FileInfo("Setup\\SkyMP.z04").Length != 1073741824)
            {
                ServerFile++;
                dict2.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/jP6pXMoCq5JJ_Q"), "Setup\\SkyMP.z04");
            }
            else if (File.Exists("Setup\\SkyMP.z04") != true)
            {
                ServerFile++;
                dict2.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/jP6pXMoCq5JJ_Q"), "Setup\\SkyMP.z04");
            }

            if (File.Exists("Setup\\SkyMP.zip") == true && new FileInfo("Setup\\SkyMP.zip").Length != 760353068)
            {
                ServerFile++;
                dict2.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/932d8xrJ5b6Zfg"), "Setup\\SkyMP.zip");
            }
            else if (File.Exists("Setup\\SkyMP.zip") != true)
            {
                ServerFile++;
                dict2.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://disk.yandex.ru/d/932d8xrJ5b6Zfg"), "Setup\\SkyMP.zip");
            }
            DownloadManyFilesSkymp(dict2);
        }

        public async Task DownloadManyFilesSkymp(Dictionary<Uri, string> files)
        {
            WebClient wc2 = new WebClient();
            wc2.DownloadProgressChanged += (s, e) => progressBar1.Value = e.ProgressPercentage;
            int number = 0;

            label6.Visible = true;

            foreach (KeyValuePair<Uri, string> pair in files)
            {
                label6.Text = "Cкачено " + (number++) + "/" + ServerFile;

                button1.Text = "Скачивается: " + pair.Value;
                await wc2.DownloadFileTaskAsync(pair.Key, pair.Value);
            }
            wc2.Dispose();

            button1.Enabled = false;
            progressBar1.Visible = true;
            label6.Visible = true;
            label4.Visible = false;

            Control.CheckForIllegalCrossThreadCalls = false;

            Thread thread = new Thread(() =>
            {

                using (ZipFile zip = ZipFile.Read("Setup\\SkyMP.zip"))
                {

                    zip.ExtractProgress += new EventHandler<ExtractProgressEventArgs>(Zip_ExtractProgress);

                    int n1 = 0;

                    foreach (ZipEntry entry in zip)
                    {
                        label6.Text = n1++ + "/" + zip.Count;
                        button1.Text = "Распаковка: " + entry.FileName;
                        entry.Extract(ExtractExistingFileAction.OverwriteSilently);

                    }

                    progressBar1.Visible = false;
                    button1.Enabled = false;
                    button1.Text = "Установлено";
                    label4.Visible = true;
                    Start.Enabled = true;
                    label6.Visible = false;
                    modManagerToolStripMenuItem.Enabled = true;

                    label4.Text = "SkyMP установлен";

                    checkCashToolStripMenuItem.Enabled = true;
                    GraphiscResolutionToolStripMenuItem.Enabled = true;

                    var Setting = new IniFile("Setting.ini");
                    string ProfileEnableCheck = Setting.Read("ProfileEnable", "Setting");
                }
            });
            thread.Start();
        }

        void Zip_ExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            if (e.TotalBytesToTransfer > 0)
            {
                progressBar1.Value = Convert.ToInt32(100 * e.BytesTransferred / e.TotalBytesToTransfer);

            }
        }

        Form modManagerForm = new Form4();

        private void modManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modManagerForm.Show();
        }
    }

}
