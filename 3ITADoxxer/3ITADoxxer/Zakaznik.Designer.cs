namespace _3ITADoxxer
{
    partial class Zakaznik
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.adresaLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cisloLabel = new System.Windows.Forms.Label();
            this.jmenoLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // adresaLabel
            // 
            this.adresaLabel.AutoSize = true;
            this.adresaLabel.Location = new System.Drawing.Point(250, 3);
            this.adresaLabel.Name = "adresaLabel";
            this.adresaLabel.Size = new System.Drawing.Size(55, 20);
            this.adresaLabel.TabIndex = 0;
            this.adresaLabel.Text = "Adresa";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 65);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // cisloLabel
            // 
            this.cisloLabel.AutoSize = true;
            this.cisloLabel.Location = new System.Drawing.Point(250, 48);
            this.cisloLabel.Name = "cisloLabel";
            this.cisloLabel.Size = new System.Drawing.Size(58, 20);
            this.cisloLabel.TabIndex = 2;
            this.cisloLabel.Text = "Telefon";
            // 
            // jmenoLabel
            // 
            this.jmenoLabel.AutoSize = true;
            this.jmenoLabel.Location = new System.Drawing.Point(74, 3);
            this.jmenoLabel.Name = "jmenoLabel";
            this.jmenoLabel.Size = new System.Drawing.Size(52, 20);
            this.jmenoLabel.TabIndex = 3;
            this.jmenoLabel.Text = "Jméno";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.emailLabel.Location = new System.Drawing.Point(97, 23);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(45, 20);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "Email";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(351, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "✔";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(351, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "❌";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Zakaznik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.jmenoLabel);
            this.Controls.Add(this.cisloLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.adresaLabel);
            this.Name = "Zakaznik";
            this.Size = new System.Drawing.Size(398, 73);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label adresaLabel;
        private PictureBox pictureBox1;
        private Label cisloLabel;
        private Label jmenoLabel;
        private Label emailLabel;
        private Button button1;
        private Button button2;
    }
}
