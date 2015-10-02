namespace FreyaPrototipo
{
    partial class frmFreya
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFreya));
            this.timerSave = new System.Windows.Forms.Timer(this.components);
            this.timerReload = new System.Windows.Forms.Timer(this.components);
            this.wbContainer = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // timerSave
            // 
            this.timerSave.Tick += new System.EventHandler(this.timerSave_Tick);
            // 
            // timerReload
            // 
            this.timerReload.Tick += new System.EventHandler(this.timerReload_Tick);
            // 
            // wbContainer
            // 
            this.wbContainer.Location = new System.Drawing.Point(12, 12);
            this.wbContainer.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbContainer.Name = "wbContainer";
            this.wbContainer.Size = new System.Drawing.Size(891, 677);
            this.wbContainer.TabIndex = 4;
            // 
            // frmFreya
            // 
            this.ClientSize = new System.Drawing.Size(905, 704);
            this.Controls.Add(this.wbContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFreya";
            this.Text = "Freya v1 - www.wappenware.com.br";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFreya_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerSave;
        private System.Windows.Forms.Timer timerReload;
        private System.Windows.Forms.WebBrowser wbContainer;
    }
}

