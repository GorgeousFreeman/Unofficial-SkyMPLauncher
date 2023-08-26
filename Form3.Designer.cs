namespace SkyMpLauncher
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.graphicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.x720toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x800toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x810toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x900toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1050ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1080ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1440ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Настройка графики";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Настройка графики";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphicsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(86, 34);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(121, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // graphicsToolStripMenuItem
            // 
            this.graphicsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lowToolStripMenuItem,
            this.normalToolStripMenuItem,
            this.highToolStripMenuItem,
            this.ultraToolStripMenuItem});
            this.graphicsToolStripMenuItem.Name = "graphicsToolStripMenuItem";
            this.graphicsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.graphicsToolStripMenuItem.Text = "Графика";
            // 
            // lowToolStripMenuItem
            // 
            this.lowToolStripMenuItem.Name = "lowToolStripMenuItem";
            this.lowToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.lowToolStripMenuItem.Text = "Минимальная";
            this.lowToolStripMenuItem.Click += new System.EventHandler(this.LowToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.normalToolStripMenuItem.Text = "Средняя";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // highToolStripMenuItem
            // 
            this.highToolStripMenuItem.Name = "highToolStripMenuItem";
            this.highToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.highToolStripMenuItem.Text = "Максимальная";
            this.highToolStripMenuItem.Click += new System.EventHandler(this.highToolStripMenuItem_Click);
            // 
            // ultraToolStripMenuItem
            // 
            this.ultraToolStripMenuItem.Name = "ultraToolStripMenuItem";
            this.ultraToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ultraToolStripMenuItem.Text = "Ультра";
            this.ultraToolStripMenuItem.Click += new System.EventHandler(this.ultraToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Графика: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Разрешение:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(86, 68);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(121, 24);
            this.menuStrip2.TabIndex = 4;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x720toolStripMenuItem,
            this.x800toolStripMenuItem,
            this.x810toolStripMenuItem,
            this.x900toolStripMenuItem,
            this.x1050ToolStripMenuItem,
            this.x1080ToolStripMenuItem,
            this.x1440ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(87, 20);
            this.toolStripMenuItem1.Text = "Разрешение";
            // 
            // x720toolStripMenuItem
            // 
            this.x720toolStripMenuItem.Name = "x720toolStripMenuItem";
            this.x720toolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.x720toolStripMenuItem.Text = "1280x720";
            this.x720toolStripMenuItem.Click += new System.EventHandler(this.x720toolStripMenuItem_Click);
            // 
            // x800toolStripMenuItem
            // 
            this.x800toolStripMenuItem.Name = "x800toolStripMenuItem";
            this.x800toolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.x800toolStripMenuItem.Text = "1280x800";
            this.x800toolStripMenuItem.Click += new System.EventHandler(this.x800toolStripMenuItem_Click);
            // 
            // x810toolStripMenuItem
            // 
            this.x810toolStripMenuItem.Name = "x810toolStripMenuItem";
            this.x810toolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.x810toolStripMenuItem.Text = "1440x810";
            this.x810toolStripMenuItem.Click += new System.EventHandler(this.x810toolStripMenuItem_Click);
            // 
            // x900toolStripMenuItem
            // 
            this.x900toolStripMenuItem.Name = "x900toolStripMenuItem";
            this.x900toolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.x900toolStripMenuItem.Text = "1440x900";
            this.x900toolStripMenuItem.Click += new System.EventHandler(this.x900toolStripMenuItem_Click);
            // 
            // x1050ToolStripMenuItem
            // 
            this.x1050ToolStripMenuItem.Name = "x1050ToolStripMenuItem";
            this.x1050ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.x1050ToolStripMenuItem.Text = "1680x1050";
            this.x1050ToolStripMenuItem.Click += new System.EventHandler(this.x1050ToolStripMenuItem_Click);
            // 
            // x1080ToolStripMenuItem
            // 
            this.x1080ToolStripMenuItem.Name = "x1080ToolStripMenuItem";
            this.x1080ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.x1080ToolStripMenuItem.Text = "1920x1080";
            this.x1080ToolStripMenuItem.Click += new System.EventHandler(this.x1080ToolStripMenuItem_Click);
            // 
            // x1440ToolStripMenuItem
            // 
            this.x1440ToolStripMenuItem.Name = "x1440ToolStripMenuItem";
            this.x1440ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.x1440ToolStripMenuItem.Text = "2560x1440";
            this.x1440ToolStripMenuItem.Click += new System.EventHandler(this.x1440ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(12, 102);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 23);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Полный экран";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(252, 137);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.Text = "Настройка";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem graphicsToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem lowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ultraToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem x720toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x800toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x810toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x900toolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem x1080ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x1050ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x1440ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}