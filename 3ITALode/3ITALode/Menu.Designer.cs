namespace _3ITALode
{
    partial class Menu
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
            offlineBtn = new Button();
            onlineBtn = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            hostCheckBox = new CheckBox();
            textBox3 = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // offlineBtn
            // 
            offlineBtn.Location = new Point(12, 163);
            offlineBtn.Name = "offlineBtn";
            offlineBtn.Size = new Size(151, 29);
            offlineBtn.TabIndex = 0;
            offlineBtn.Text = "Hrát Offline";
            offlineBtn.UseVisualStyleBackColor = true;
            offlineBtn.Click += offlineBtn_Click;
            // 
            // onlineBtn
            // 
            onlineBtn.Location = new Point(12, 371);
            onlineBtn.Name = "onlineBtn";
            onlineBtn.Size = new Size(151, 29);
            onlineBtn.TabIndex = 1;
            onlineBtn.Text = "Hrát Online";
            onlineBtn.UseVisualStyleBackColor = true;
            onlineBtn.Click += onlineBtn_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 63);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 116);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 40);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 4;
            label1.Text = "Jméno Mého Hráče:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 93);
            label2.Name = "label2";
            label2.Size = new Size(168, 20);
            label2.TabIndex = 5;
            label2.Text = "Jméno Oponenta Hráče:";
            // 
            // hostCheckBox
            // 
            hostCheckBox.AutoSize = true;
            hostCheckBox.Location = new Point(12, 275);
            hostCheckBox.Name = "hostCheckBox";
            hostCheckBox.Size = new Size(69, 24);
            hostCheckBox.TabIndex = 6;
            hostCheckBox.Text = "Host?";
            hostCheckBox.UseVisualStyleBackColor = true;
            hostCheckBox.CheckedChanged += hostCheckBox_CheckedChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 324);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 301);
            label3.Name = "label3";
            label3.Size = new Size(122, 20);
            label3.TabIndex = 8;
            label3.Text = "Adresa Hostitele:";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(hostCheckBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(onlineBtn);
            Controls.Add(offlineBtn);
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button offlineBtn;
        private Button onlineBtn;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private CheckBox hostCheckBox;
        private TextBox textBox3;
        private Label label3;
    }
}