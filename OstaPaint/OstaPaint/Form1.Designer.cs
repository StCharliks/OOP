namespace OstaPaint
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LineButton = new System.Windows.Forms.ToolStripButton();
            this.SquareButton = new System.Windows.Forms.ToolStripButton();
            this.RectangleButton = new System.Windows.Forms.ToolStripButton();
            this.EllipceButton = new System.Windows.Forms.ToolStripButton();
            this.CircleButton = new System.Windows.Forms.ToolStripButton();
            this.triangleButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.ColorButton = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Button();
            this.toBack = new System.Windows.Forms.Button();
            this.toForward = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.choseModeButton = new System.Windows.Forms.Button();
            this.PluginBox = new System.Windows.Forms.ListBox();
            this.addPlagin_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(2, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1103, 551);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LineButton,
            this.SquareButton,
            this.RectangleButton,
            this.EllipceButton,
            this.CircleButton,
            this.triangleButton,
            this.toolStripButton7,
            this.toolStripButton8,
            this.ColorButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1310, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // LineButton
            // 
            this.LineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LineButton.Image = ((System.Drawing.Image)(resources.GetObject("LineButton.Image")));
            this.LineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(24, 24);
            this.LineButton.Text = "Line";
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // SquareButton
            // 
            this.SquareButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SquareButton.Image = ((System.Drawing.Image)(resources.GetObject("SquareButton.Image")));
            this.SquareButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SquareButton.Name = "SquareButton";
            this.SquareButton.Size = new System.Drawing.Size(24, 24);
            this.SquareButton.Text = "Square";
            this.SquareButton.Click += new System.EventHandler(this.SquareButton_Click);
            // 
            // RectangleButton
            // 
            this.RectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("RectangleButton.Image")));
            this.RectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(24, 24);
            this.RectangleButton.Text = "Rectangle";
            this.RectangleButton.Click += new System.EventHandler(this.RectangleButton_Click);
            // 
            // EllipceButton
            // 
            this.EllipceButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EllipceButton.Image = ((System.Drawing.Image)(resources.GetObject("EllipceButton.Image")));
            this.EllipceButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EllipceButton.Name = "EllipceButton";
            this.EllipceButton.Size = new System.Drawing.Size(24, 24);
            this.EllipceButton.Text = "Ellipce";
            this.EllipceButton.Click += new System.EventHandler(this.EllipceButton_Click);
            // 
            // CircleButton
            // 
            this.CircleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CircleButton.Image = ((System.Drawing.Image)(resources.GetObject("CircleButton.Image")));
            this.CircleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CircleButton.Name = "CircleButton";
            this.CircleButton.Size = new System.Drawing.Size(24, 24);
            this.CircleButton.Text = "Circle";
            this.CircleButton.Click += new System.EventHandler(this.CircleButton_Click);
            // 
            // triangleButton
            // 
            this.triangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.triangleButton.Image = ((System.Drawing.Image)(resources.GetObject("triangleButton.Image")));
            this.triangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.triangleButton.Name = "triangleButton";
            this.triangleButton.Size = new System.Drawing.Size(24, 24);
            this.triangleButton.Text = "Triangle";
            this.triangleButton.Click += new System.EventHandler(this.triangleButton_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton7.Text = "toolStripButton7";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton8.Text = "toolStripButton8";
            // 
            // ColorButton
            // 
            this.ColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ColorButton.Image = ((System.Drawing.Image)(resources.GetObject("ColorButton.Image")));
            this.ColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(24, 24);
            this.ColorButton.Text = "colorButton";
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(316, 2);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(45, 22);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 587);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 3;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(394, 2);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(133, 23);
            this.Clear.TabIndex = 4;
            this.Clear.Text = "Очистить лист";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // toBack
            // 
            this.toBack.Location = new System.Drawing.Point(550, 2);
            this.toBack.Name = "toBack";
            this.toBack.Size = new System.Drawing.Size(75, 23);
            this.toBack.TabIndex = 5;
            this.toBack.Text = "Назад";
            this.toBack.UseVisualStyleBackColor = true;
            this.toBack.Click += new System.EventHandler(this.toBack_Click);
            // 
            // toForward
            // 
            this.toForward.Location = new System.Drawing.Point(631, 2);
            this.toForward.Name = "toForward";
            this.toForward.Size = new System.Drawing.Size(75, 23);
            this.toForward.TabIndex = 6;
            this.toForward.Text = "Вперёд";
            this.toForward.UseVisualStyleBackColor = true;
            this.toForward.Click += new System.EventHandler(this.toForward_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(712, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(87, 23);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(805, 2);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(92, 23);
            this.OpenButton.TabIndex = 8;
            this.OpenButton.Text = "Загрузить";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // choseModeButton
            // 
            this.choseModeButton.Location = new System.Drawing.Point(914, 2);
            this.choseModeButton.Name = "choseModeButton";
            this.choseModeButton.Size = new System.Drawing.Size(120, 23);
            this.choseModeButton.TabIndex = 9;
            this.choseModeButton.Text = "Редактировать";
            this.choseModeButton.UseVisualStyleBackColor = true;
            this.choseModeButton.Click += new System.EventHandler(this.choseModeButton_Click);
            // 
            // PluginBox
            // 
            this.PluginBox.FormattingEnabled = true;
            this.PluginBox.ItemHeight = 16;
            this.PluginBox.Location = new System.Drawing.Point(1111, 85);
            this.PluginBox.Name = "PluginBox";
            this.PluginBox.Size = new System.Drawing.Size(199, 196);
            this.PluginBox.TabIndex = 10;
            this.PluginBox.Click += new System.EventHandler(this.PluginBox_Click);
            // 
            // addPlagin_button
            // 
            this.addPlagin_button.Location = new System.Drawing.Point(1151, 12);
            this.addPlagin_button.Name = "addPlagin_button";
            this.addPlagin_button.Size = new System.Drawing.Size(109, 53);
            this.addPlagin_button.TabIndex = 11;
            this.addPlagin_button.Text = "Подлючиь плагин";
            this.addPlagin_button.UseVisualStyleBackColor = true;
            this.addPlagin_button.Click += new System.EventHandler(this.addPlagin_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 613);
            this.Controls.Add(this.addPlagin_button);
            this.Controls.Add(this.PluginBox);
            this.Controls.Add(this.choseModeButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.toForward);
            this.Controls.Add(this.toBack);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton LineButton;
        private System.Windows.Forms.ToolStripButton SquareButton;
        private System.Windows.Forms.ToolStripButton RectangleButton;
        private System.Windows.Forms.ToolStripButton EllipceButton;
        private System.Windows.Forms.ToolStripButton CircleButton;
        private System.Windows.Forms.ToolStripButton triangleButton;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton ColorButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button toBack;
        private System.Windows.Forms.Button toForward;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button choseModeButton;
        private System.Windows.Forms.ListBox PluginBox;
        private System.Windows.Forms.Button addPlagin_button;
    }
}

