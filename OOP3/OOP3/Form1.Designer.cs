namespace OOP3
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonShow = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.зданияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeisureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MuseumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CinemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpecialBuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HospitalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MilitiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FactoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HousesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MultistroyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrivateHouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 32);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(459, 503);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(500, 32);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(100, 30);
            this.buttonShow.TabIndex = 1;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.зданияToolStripMenuItem,
            this.FactoryToolStripMenuItem,
            this.HousesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1134, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // зданияToolStripMenuItem
            // 
            this.зданияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LeisureToolStripMenuItem,
            this.StoreToolStripMenuItem,
            this.SpecialBuildToolStripMenuItem});
            this.зданияToolStripMenuItem.Name = "зданияToolStripMenuItem";
            this.зданияToolStripMenuItem.Size = new System.Drawing.Size(280, 29);
            this.зданияToolStripMenuItem.Text = "Государственные учереждения";
            // 
            // LeisureToolStripMenuItem
            // 
            this.LeisureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MuseumToolStripMenuItem,
            this.CinemaToolStripMenuItem});
            this.LeisureToolStripMenuItem.Name = "LeisureToolStripMenuItem";
            this.LeisureToolStripMenuItem.Size = new System.Drawing.Size(308, 30);
            this.LeisureToolStripMenuItem.Text = "Досуг";
            // 
            // MuseumToolStripMenuItem
            // 
            this.MuseumToolStripMenuItem.Name = "MuseumToolStripMenuItem";
            this.MuseumToolStripMenuItem.Size = new System.Drawing.Size(136, 30);
            this.MuseumToolStripMenuItem.Text = "Музей";
            this.MuseumToolStripMenuItem.Click += new System.EventHandler(this.MuseumToolStripMenuItem_Click);
            // 
            // CinemaToolStripMenuItem
            // 
            this.CinemaToolStripMenuItem.Name = "CinemaToolStripMenuItem";
            this.CinemaToolStripMenuItem.Size = new System.Drawing.Size(136, 30);
            this.CinemaToolStripMenuItem.Text = "Кино";
            this.CinemaToolStripMenuItem.Click += new System.EventHandler(this.CinemaToolStripMenuItem_Click);
            // 
            // StoreToolStripMenuItem
            // 
            this.StoreToolStripMenuItem.Name = "StoreToolStripMenuItem";
            this.StoreToolStripMenuItem.Size = new System.Drawing.Size(308, 30);
            this.StoreToolStripMenuItem.Text = "Магазин";
            this.StoreToolStripMenuItem.Click += new System.EventHandler(this.StoreToolStripMenuItem_Click);
            // 
            // SpecialBuildToolStripMenuItem
            // 
            this.SpecialBuildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HospitalToolStripMenuItem,
            this.MilitiaToolStripMenuItem});
            this.SpecialBuildToolStripMenuItem.Name = "SpecialBuildToolStripMenuItem";
            this.SpecialBuildToolStripMenuItem.Size = new System.Drawing.Size(308, 30);
            this.SpecialBuildToolStripMenuItem.Text = "Специальные учереждения";
            // 
            // HospitalToolStripMenuItem
            // 
            this.HospitalToolStripMenuItem.Name = "HospitalToolStripMenuItem";
            this.HospitalToolStripMenuItem.Size = new System.Drawing.Size(163, 30);
            this.HospitalToolStripMenuItem.Text = "Больница";
            this.HospitalToolStripMenuItem.Click += new System.EventHandler(this.HospitalToolStripMenuItem_Click);
            // 
            // MilitiaToolStripMenuItem
            // 
            this.MilitiaToolStripMenuItem.Name = "MilitiaToolStripMenuItem";
            this.MilitiaToolStripMenuItem.Size = new System.Drawing.Size(163, 30);
            this.MilitiaToolStripMenuItem.Text = "Милиция";
            this.MilitiaToolStripMenuItem.Click += new System.EventHandler(this.MilitiaToolStripMenuItem_Click);
            // 
            // FactoryToolStripMenuItem
            // 
            this.FactoryToolStripMenuItem.Name = "FactoryToolStripMenuItem";
            this.FactoryToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.FactoryToolStripMenuItem.Text = "Завод";
            this.FactoryToolStripMenuItem.Click += new System.EventHandler(this.FactoryToolStripMenuItem_Click);
            // 
            // HousesToolStripMenuItem
            // 
            this.HousesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MultistroyToolStripMenuItem,
            this.PrivateHouseToolStripMenuItem});
            this.HousesToolStripMenuItem.Name = "HousesToolStripMenuItem";
            this.HousesToolStripMenuItem.Size = new System.Drawing.Size(129, 29);
            this.HousesToolStripMenuItem.Text = "Жилые дома";
            // 
            // MultistroyToolStripMenuItem
            // 
            this.MultistroyToolStripMenuItem.Name = "MultistroyToolStripMenuItem";
            this.MultistroyToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.MultistroyToolStripMenuItem.Text = "Многоэтажный дом";
            this.MultistroyToolStripMenuItem.Click += new System.EventHandler(this.MultistroyToolStripMenuItem_Click);
            // 
            // PrivateHouseToolStripMenuItem
            // 
            this.PrivateHouseToolStripMenuItem.Name = "PrivateHouseToolStripMenuItem";
            this.PrivateHouseToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.PrivateHouseToolStripMenuItem.Text = "Частный дом";
            this.PrivateHouseToolStripMenuItem.Click += new System.EventHandler(this.PrivateHouseToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 596);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "OOP 3";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem зданияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LeisureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MuseumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CinemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SpecialBuildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HospitalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MilitiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FactoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HousesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MultistroyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrivateHouseToolStripMenuItem;
    }
}

