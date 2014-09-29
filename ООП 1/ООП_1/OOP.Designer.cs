namespace OOP_1
{
    partial class OOP
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.фигурыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LineStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.EllipseStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.Rectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.PolygonStrip = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фигурыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(528, 45);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // фигурыToolStripMenuItem
            // 
            this.фигурыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LineStrip,
            this.EllipseStrip,
            this.Rectangle,
            this.ClearPicture,
            this.PolygonStrip});
            this.фигурыToolStripMenuItem.Name = "фигурыToolStripMenuItem";
            this.фигурыToolStripMenuItem.Size = new System.Drawing.Size(123, 41);
            this.фигурыToolStripMenuItem.Text = "Фигуры";
            // 
            // LineStrip
            // 
            this.LineStrip.Name = "LineStrip";
            this.LineStrip.Size = new System.Drawing.Size(290, 42);
            this.LineStrip.Text = "Линия";
            this.LineStrip.Click += new System.EventHandler(this.Line_Click);
            // 
            // EllipseStrip
            // 
            this.EllipseStrip.Name = "EllipseStrip";
            this.EllipseStrip.Size = new System.Drawing.Size(290, 42);
            this.EllipseStrip.Text = "Эллипс";
            this.EllipseStrip.Click += new System.EventHandler(this.EllipseStrip_Click);
            // 
            // Rectangle
            // 
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(290, 42);
            this.Rectangle.Text = "Прямоугольник";
            this.Rectangle.Click += new System.EventHandler(this.Rectangle_Click);
            // 
            // ClearPicture
            // 
            this.ClearPicture.Name = "ClearPicture";
            this.ClearPicture.Size = new System.Drawing.Size(290, 42);
            this.ClearPicture.Text = "Очистить";
            this.ClearPicture.Click += new System.EventHandler(this.ClearPicture_Click);
            // 
            // PolygonStrip
            // 
            this.PolygonStrip.Name = "PolygonStrip";
            this.PolygonStrip.Size = new System.Drawing.Size(290, 42);
            this.PolygonStrip.Text = "Многоульник";
            this.PolygonStrip.Click += new System.EventHandler(this.PolygonStrip_Click);
            // 
            // OOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 558);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OOP";
            this.Text = "OOP 1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem фигурыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LineStrip;
        private System.Windows.Forms.ToolStripMenuItem EllipseStrip;
        private System.Windows.Forms.ToolStripMenuItem Rectangle;
        private System.Windows.Forms.ToolStripMenuItem ClearPicture;
        private System.Windows.Forms.ToolStripMenuItem PolygonStrip;



    }
}

