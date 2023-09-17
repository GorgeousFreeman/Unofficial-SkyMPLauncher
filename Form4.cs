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

namespace SkyMpLauncher
{
    public partial class Form4 : Form
    {
        private readonly List<FileInfo> _espFiles = new List<FileInfo>(); // список FileInfo файлов
        private readonly List<bool> _isEnabled = new List<bool>(); // список для хранения состояний файлов
        public Form4()
        {
            InitializeComponent();
            
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            
        }

        private void CheckBoxChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var fileIndex = (int)checkBox.Tag;
            _isEnabled[fileIndex] = checkBox.Checked;
        }

        private void Up_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string listBoxItemText = listBox1.SelectedItem.ToString();
            if(index > 0)
            {
                listBox1.Items.RemoveAt(index);
                listBox1.Items.Insert(index-1, listBoxItemText);
                listBox1.SetSelected(index - 1, true);
            }
        }

        private void Down_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string listBoxItemText = listBox1.SelectedItem.ToString();
            if (index < listBox1.Items.Count-1)
            {
                listBox1.Items.RemoveAt(index);
                listBox1.Items.Insert(index + 1, listBoxItemText);
                listBox1.SetSelected(index + 1, true);

            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Local\\Skyrim Special Edition");

            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string skyrimFolder = Path.Combine(appDataFolder, "Skyrim Special Edition");
            string pluginsFilePath = Path.Combine(skyrimFolder, "Plugins.txt");

            string filePath = "Data\\plugin.txt";

            using (StreamWriter writer = new StreamWriter(pluginsFilePath))
            {
                writer.WriteLine("*ccBGSSSE001-Fish.esm");
                writer.WriteLine("*ccBGSSSE025-AdvDSGS.esm");
                writer.WriteLine("*CombatSettings.esp");
                writer.WriteLine("*SweetPie.esp");

                for (int i = 0; i < _espFiles.Count; i++)
                {
                    string line = _isEnabled[i] ? $"*{_espFiles[i].Name}" : _espFiles[i].Name;
                    writer.WriteLine(line);
                }
            }

            MessageBox.Show($"Список файлов сохранен в файл {filePath}");
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.FormClosing += Form4_FormClosing;

            // Указываем путь к директории, где находятся файлы
            var scanDir = new DirectoryInfo("Data");

            // Получить все файлы с расширением .esp в директории
            _espFiles.AddRange(scanDir.GetFiles("*.esp")
                .Where(fileInfo => fileInfo.Name != "CombatSettings.esp" && fileInfo.Name != "SweetPie.esp"));

            // Добавить сформированный список в ListBox
            listBox1.Items.AddRange(_espFiles.Select(fileInfo => fileInfo.Name).ToArray());

            // Установить значения по умолчанию для всех файлов (включены)
            for (int i = 0; i < _espFiles.Count; i++)
            {
                _isEnabled.Add(true);
            }

            // Добавить CheckBox элементы в FlowLayoutPanel для каждого файла
            for (int i = 0; i < _espFiles.Count; i++)
            {
                var checkBox = new CheckBox
                {
                    Text = _espFiles[i].Name,
                    Checked = true,
                    Tag = i,
                    Margin = new Padding(0)
                };
                checkBox.CheckedChanged += CheckBoxChanged;
                flowLayoutPanel1.Controls.Add(checkBox);
            }

            label1.Text = "Тут можно включить или выключить не нужный мод или же настроить распорядок запуска.\nМоды которые необходимы для SkyMP уже встроены в конфиг, поэтому в списках видны только те моды которые вы хотите дополнить.\nP.S - Некоторые моды могут конфликтовать с SkyMP!";
        }
    }
    public static class ListExtensions
    {
        public static void Move<T>(this List<T> list, int oldIndex, int newIndex)
        {
            if (oldIndex == newIndex)
            {
                return;
            }

            var item = list[oldIndex];
            list.RemoveAt(oldIndex);
            // при необходимости расширяем список
            if (newIndex > oldIndex) newIndex--;
            list.Insert(newIndex, item);
        }
    }
}
