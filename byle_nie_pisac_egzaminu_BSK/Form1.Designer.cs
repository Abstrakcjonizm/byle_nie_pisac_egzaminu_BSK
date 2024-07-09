namespace byle_nie_pisac_egzaminu_BSK
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.IPSERVERBOX = new System.Windows.Forms.TextBox();
            this.PORTSERVERBOX = new System.Windows.Forms.TextBox();
            this.IPKLIENTBOX = new System.Windows.Forms.TextBox();
            this.PORTKLIENTBOX = new System.Windows.Forms.TextBox();
            this.MESSAGEBOX = new System.Windows.Forms.RichTextBox();
            this.SENDBOX = new System.Windows.Forms.RichTextBox();
            this.BUTONSTART = new System.Windows.Forms.Button();
            this.BUTONCONNECT = new System.Windows.Forms.Button();
            this.BUTONSEND = new System.Windows.Forms.Button();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // IPSERVERBOX
            // 
            this.IPSERVERBOX.Location = new System.Drawing.Point(109, 45);
            this.IPSERVERBOX.Name = "IPSERVERBOX";
            this.IPSERVERBOX.Size = new System.Drawing.Size(137, 22);
            this.IPSERVERBOX.TabIndex = 0;
            // 
            // PORTSERVERBOX
            // 
            this.PORTSERVERBOX.Location = new System.Drawing.Point(321, 45);
            this.PORTSERVERBOX.Name = "PORTSERVERBOX";
            this.PORTSERVERBOX.Size = new System.Drawing.Size(137, 22);
            this.PORTSERVERBOX.TabIndex = 1;
            // 
            // IPKLIENTBOX
            // 
            this.IPKLIENTBOX.Location = new System.Drawing.Point(109, 102);
            this.IPKLIENTBOX.Name = "IPKLIENTBOX";
            this.IPKLIENTBOX.Size = new System.Drawing.Size(137, 22);
            this.IPKLIENTBOX.TabIndex = 2;
            // 
            // PORTKLIENTBOX
            // 
            this.PORTKLIENTBOX.Location = new System.Drawing.Point(321, 102);
            this.PORTKLIENTBOX.Name = "PORTKLIENTBOX";
            this.PORTKLIENTBOX.Size = new System.Drawing.Size(137, 22);
            this.PORTKLIENTBOX.TabIndex = 3;
            // 
            // MESSAGEBOX
            // 
            this.MESSAGEBOX.Location = new System.Drawing.Point(21, 160);
            this.MESSAGEBOX.Name = "MESSAGEBOX";
            this.MESSAGEBOX.Size = new System.Drawing.Size(704, 268);
            this.MESSAGEBOX.TabIndex = 4;
            this.MESSAGEBOX.Text = "";
            // 
            // SENDBOX
            // 
            this.SENDBOX.Location = new System.Drawing.Point(21, 434);
            this.SENDBOX.Name = "SENDBOX";
            this.SENDBOX.Size = new System.Drawing.Size(510, 70);
            this.SENDBOX.TabIndex = 5;
            this.SENDBOX.Text = "";
            // 
            // BUTONSTART
            // 
            this.BUTONSTART.Location = new System.Drawing.Point(539, 44);
            this.BUTONSTART.Name = "BUTONSTART";
            this.BUTONSTART.Size = new System.Drawing.Size(130, 23);
            this.BUTONSTART.TabIndex = 6;
            this.BUTONSTART.Text = "Start";
            this.BUTONSTART.UseVisualStyleBackColor = true;
            this.BUTONSTART.Click += new System.EventHandler(this.BUTONSTART_Click);
            // 
            // BUTONCONNECT
            // 
            this.BUTONCONNECT.Location = new System.Drawing.Point(539, 101);
            this.BUTONCONNECT.Name = "BUTONCONNECT";
            this.BUTONCONNECT.Size = new System.Drawing.Size(130, 23);
            this.BUTONCONNECT.TabIndex = 7;
            this.BUTONCONNECT.Text = "Polacz";
            this.BUTONCONNECT.UseVisualStyleBackColor = true;
            this.BUTONCONNECT.Click += new System.EventHandler(this.BUTONCONNECT_Click);
            // 
            // BUTONSEND
            // 
            this.BUTONSEND.Location = new System.Drawing.Point(539, 434);
            this.BUTONSEND.Name = "BUTONSEND";
            this.BUTONSEND.Size = new System.Drawing.Size(186, 70);
            this.BUTONSEND.TabIndex = 8;
            this.BUTONSEND.Text = "Wyslij";
            this.BUTONSEND.UseVisualStyleBackColor = true;
            this.BUTONSEND.Click += new System.EventHandler(this.BUTONSEND_Click);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(759, 516);
            this.Controls.Add(this.BUTONSEND);
            this.Controls.Add(this.BUTONCONNECT);
            this.Controls.Add(this.BUTONSTART);
            this.Controls.Add(this.SENDBOX);
            this.Controls.Add(this.MESSAGEBOX);
            this.Controls.Add(this.PORTKLIENTBOX);
            this.Controls.Add(this.IPKLIENTBOX);
            this.Controls.Add(this.PORTSERVERBOX);
            this.Controls.Add(this.IPSERVERBOX);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPSERVER;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TextBox PORTSERVER;
        private System.Windows.Forms.RichTextBox TEXTVIEW;
        private System.Windows.Forms.TextBox IPKLIENT;
        private System.Windows.Forms.TextBox PORTKLIENT;
        private System.Windows.Forms.RichTextBox TEXTSEND;
        private System.Windows.Forms.Button BUTTONSTART;
        private System.Windows.Forms.Button BUTTONCONNECT;
        private System.Windows.Forms.Button BUTTONSEND;
        private System.Windows.Forms.TextBox IPSERVERBOX;
        private System.Windows.Forms.TextBox PORTSERVERBOX;
        private System.Windows.Forms.TextBox IPKLIENTBOX;
        private System.Windows.Forms.TextBox PORTKLIENTBOX;
        private System.Windows.Forms.RichTextBox MESSAGEBOX;
        private System.Windows.Forms.RichTextBox SENDBOX;
        private System.Windows.Forms.Button BUTONSTART;
        private System.Windows.Forms.Button BUTONCONNECT;
        private System.Windows.Forms.Button BUTONSEND;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
    }
}

