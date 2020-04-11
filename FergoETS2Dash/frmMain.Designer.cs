namespace FergoETS2Dash {
	partial class frmMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.cmbStartServer = new System.Windows.Forms.Button();
			this.lstLog = new System.Windows.Forms.ListBox();
			this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
			this.cmbMapear = new System.Windows.Forms.Button();
			this.dgvComandos = new System.Windows.Forms.DataGridView();
			this.colComando = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTecla = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblETS = new System.Windows.Forms.Label();
			this.lblServidor = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPort = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvComandos)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbStartServer
			// 
			this.cmbStartServer.Location = new System.Drawing.Point(12, 12);
			this.cmbStartServer.Name = "cmbStartServer";
			this.cmbStartServer.Size = new System.Drawing.Size(163, 45);
			this.cmbStartServer.TabIndex = 0;
			this.cmbStartServer.Text = "Start Web Server";
			this.cmbStartServer.UseVisualStyleBackColor = true;
			this.cmbStartServer.Click += new System.EventHandler(this.cmbStartServer_Click);
			// 
			// lstLog
			// 
			this.lstLog.FormattingEnabled = true;
			this.lstLog.Location = new System.Drawing.Point(12, 234);
			this.lstLog.Name = "lstLog";
			this.lstLog.Size = new System.Drawing.Size(489, 82);
			this.lstLog.TabIndex = 1;
			// 
			// tmrUpdate
			// 
			this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
			// 
			// cmbMapear
			// 
			this.cmbMapear.Enabled = false;
			this.cmbMapear.Location = new System.Drawing.Point(12, 63);
			this.cmbMapear.Name = "cmbMapear";
			this.cmbMapear.Size = new System.Drawing.Size(163, 45);
			this.cmbMapear.TabIndex = 3;
			this.cmbMapear.Text = "Map commands";
			this.cmbMapear.UseVisualStyleBackColor = true;
			this.cmbMapear.Click += new System.EventHandler(this.cmbMapear_Click);
			// 
			// dgvComandos
			// 
			this.dgvComandos.AllowUserToAddRows = false;
			this.dgvComandos.AllowUserToDeleteRows = false;
			this.dgvComandos.AllowUserToResizeColumns = false;
			this.dgvComandos.AllowUserToResizeRows = false;
			this.dgvComandos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvComandos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colComando,
            this.colTecla});
			this.dgvComandos.Location = new System.Drawing.Point(190, 12);
			this.dgvComandos.MultiSelect = false;
			this.dgvComandos.Name = "dgvComandos";
			this.dgvComandos.Size = new System.Drawing.Size(311, 216);
			this.dgvComandos.TabIndex = 6;
			this.dgvComandos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvComandos_KeyDown);
			// 
			// colComando
			// 
			this.colComando.HeaderText = "Command";
			this.colComando.Name = "colComando";
			this.colComando.ReadOnly = true;
			this.colComando.Width = 150;
			// 
			// colTecla
			// 
			this.colTecla.HeaderText = "Key Code";
			this.colTecla.MaxInputLength = 10;
			this.colTecla.Name = "colTecla";
			this.colTecla.ReadOnly = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblETS);
			this.groupBox1.Controls.Add(this.lblServidor);
			this.groupBox1.Location = new System.Drawing.Point(12, 140);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(163, 88);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Status";
			// 
			// lblETS
			// 
			this.lblETS.AutoSize = true;
			this.lblETS.Location = new System.Drawing.Point(15, 55);
			this.lblETS.Name = "lblETS";
			this.lblETS.Size = new System.Drawing.Size(97, 13);
			this.lblETS.TabIndex = 7;
			this.lblETS.Text = "ETS2 not detected";
			// 
			// lblServidor
			// 
			this.lblServidor.AutoSize = true;
			this.lblServidor.Location = new System.Drawing.Point(15, 28);
			this.lblServidor.Name = "lblServidor";
			this.lblServidor.Size = new System.Drawing.Size(105, 13);
			this.lblServidor.TabIndex = 6;
			this.lblServidor.Text = "Server disconnected";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 117);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "HTTP Port:";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(114, 114);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(61, 20);
			this.txtPort.TabIndex = 9;
			this.txtPort.Text = "8080";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(517, 335);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dgvComandos);
			this.Controls.Add(this.cmbMapear);
			this.Controls.Add(this.lstLog);
			this.Controls.Add(this.cmbStartServer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.Text = "Fergo ETS2 Virtual Button Box";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvComandos)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cmbStartServer;
		private System.Windows.Forms.ListBox lstLog;
		private System.Windows.Forms.Timer tmrUpdate;
		private System.Windows.Forms.Button cmbMapear;
		private System.Windows.Forms.DataGridView dgvComandos;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblETS;
		private System.Windows.Forms.Label lblServidor;
		private System.Windows.Forms.DataGridViewTextBoxColumn colComando;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTecla;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPort;
	}
}

