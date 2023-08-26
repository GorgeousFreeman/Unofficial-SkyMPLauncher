using System.Windows.Forms;

namespace SkyMpLauncher
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Profile1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profile1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.profile2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profile3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profile4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profile5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profile6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profile7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profile8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profile9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profile10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.MaximizeBox = false;
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(35, 81);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(318, 133);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Profile1ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(122, 41);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(151, 37);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "Профиль";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // Profile1ToolStripMenuItem
            // 
            this.Profile1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profile1ToolStripMenuItem1,
            this.profile2ToolStripMenuItem,
            this.profile3ToolStripMenuItem,
            this.profile4ToolStripMenuItem,
            this.profile5ToolStripMenuItem,
            this.profile6ToolStripMenuItem,
            this.profile7ToolStripMenuItem,
            this.profile8ToolStripMenuItem,
            this.profile9ToolStripMenuItem,
            this.profile10ToolStripMenuItem});
            this.Profile1ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Profile1ToolStripMenuItem.Name = "Profile1ToolStripMenuItem";
            this.Profile1ToolStripMenuItem.Size = new System.Drawing.Size(126, 33);
            this.Profile1ToolStripMenuItem.Text = "Выберите профиль";
            // 
            // profile1ToolStripMenuItem1
            // 
            this.profile1ToolStripMenuItem1.Name = "profile1ToolStripMenuItem1";
            this.profile1ToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.profile1ToolStripMenuItem1.Text = "Профиль - 1";
            this.profile1ToolStripMenuItem1.Click += new System.EventHandler(this.profile1ToolStripMenuItem1_Click);
            // 
            // profile2ToolStripMenuItem
            // 
            this.profile2ToolStripMenuItem.Name = "profile2ToolStripMenuItem";
            this.profile2ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.profile2ToolStripMenuItem.Text = "Профиль - 2";
            this.profile2ToolStripMenuItem.Click += new System.EventHandler(this.profile2ToolStripMenuItem_Click);
            // 
            // profile3ToolStripMenuItem
            // 
            this.profile3ToolStripMenuItem.Name = "profile3ToolStripMenuItem";
            this.profile3ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.profile3ToolStripMenuItem.Text = "Профиль - 3";
            this.profile3ToolStripMenuItem.Click += new System.EventHandler(this.profile3ToolStripMenuItem_Click);
            // 
            // profile4ToolStripMenuItem
            // 
            this.profile4ToolStripMenuItem.Name = "profile4ToolStripMenuItem";
            this.profile4ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.profile4ToolStripMenuItem.Text = "Профиль - 4";
            this.profile4ToolStripMenuItem.Click += new System.EventHandler(this.profile4ToolStripMenuItem_Click);
            // 
            // profile5ToolStripMenuItem
            // 
            this.profile5ToolStripMenuItem.Name = "profile5ToolStripMenuItem";
            this.profile5ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.profile5ToolStripMenuItem.Text = "Профиль - 5";
            this.profile5ToolStripMenuItem.Click += new System.EventHandler(this.profile5ToolStripMenuItem_Click);
            // 
            // profile6ToolStripMenuItem
            // 
            this.profile6ToolStripMenuItem.Name = "profile6ToolStripMenuItem";
            this.profile6ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.profile6ToolStripMenuItem.Text = "Профиль - 6";
            this.profile6ToolStripMenuItem.Click += new System.EventHandler(this.profile6ToolStripMenuItem_Click);
            // 
            // profile7ToolStripMenuItem
            // 
            this.profile7ToolStripMenuItem.Name = "profile7ToolStripMenuItem";
            this.profile7ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.profile7ToolStripMenuItem.Text = "Профиль - 7";
            this.profile7ToolStripMenuItem.Click += new System.EventHandler(this.profile7ToolStripMenuItem_Click);
            // 
            // profile8ToolStripMenuItem
            // 
            this.profile8ToolStripMenuItem.Name = "profile8ToolStripMenuItem";
            this.profile8ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.profile8ToolStripMenuItem.Text = "Профиль - 8";
            this.profile8ToolStripMenuItem.Click += new System.EventHandler(this.profile8ToolStripMenuItem_Click);
            // 
            // profile9ToolStripMenuItem
            // 
            this.profile9ToolStripMenuItem.Name = "profile9ToolStripMenuItem";
            this.profile9ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.profile9ToolStripMenuItem.Text = "Профиль - 9";
            this.profile9ToolStripMenuItem.Click += new System.EventHandler(this.profile9ToolStripMenuItem_Click);
            // 
            // profile10ToolStripMenuItem
            // 
            this.profile10ToolStripMenuItem.Name = "profile10ToolStripMenuItem";
            this.profile10ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.profile10ToolStripMenuItem.Text = "Профиль - 10";
            this.profile10ToolStripMenuItem.Click += new System.EventHandler(this.profile10ToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(387, 281);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Редактор имен";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Profile1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profile1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem profile2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profile3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profile4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profile5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profile6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profile7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profile8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profile9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profile10ToolStripMenuItem;
        private Button button2;
    }
}