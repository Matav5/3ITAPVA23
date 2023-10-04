namespace _3ITACtverecky
{
    partial class Form1
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

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.vtipnyCtverecek1 = new _3ITACtverecky.VtipnyCtverecek();
            this.zvetsovaciCtverecek1 = new _3ITACtverecky.ZvetsovaciCtverecek();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.zvetsovaciCtverecek1);
            this.panel1.Controls.Add(this.vtipnyCtverecek1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 426);
            this.panel1.TabIndex = 0;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // vtipnyCtverecek1
            // 
            this.vtipnyCtverecek1.BackColor = System.Drawing.Color.White;
            this.vtipnyCtverecek1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vtipnyCtverecek1.Location = new System.Drawing.Point(305, 165);
            this.vtipnyCtverecek1.Name = "vtipnyCtverecek1";
            this.vtipnyCtverecek1.Size = new System.Drawing.Size(100, 100);
            this.vtipnyCtverecek1.TabIndex = 0;
            // 
            // zvetsovaciCtverecek1
            // 
            this.zvetsovaciCtverecek1.BackColor = System.Drawing.Color.White;
            this.zvetsovaciCtverecek1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zvetsovaciCtverecek1.Location = new System.Drawing.Point(342, 64);
            this.zvetsovaciCtverecek1.Name = "zvetsovaciCtverecek1";
            this.zvetsovaciCtverecek1.Size = new System.Drawing.Size(48, 48);
            this.zvetsovaciCtverecek1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Ctverecky";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private VtipnyCtverecek vtipnyCtverecek1;
        private ZvetsovaciCtverecek zvetsovaciCtverecek1;
    }
}

