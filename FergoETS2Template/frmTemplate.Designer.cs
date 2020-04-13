namespace FergoETS2Template {
	partial class frmTemplate {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTemplate));
			this.txtId = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chkTie = new System.Windows.Forms.CheckBox();
			this.cmbApply = new System.Windows.Forms.Button();
			this.txtText = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.cboIcon = new System.Windows.Forms.ComboBox();
			this.grpSelection = new System.Windows.Forms.GroupBox();
			this.cboAction = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panelAction = new System.Windows.Forms.Panel();
			this.lblColorOn = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cboTie = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbPageAdd = new System.Windows.Forms.Button();
			this.cmbPageRemove = new System.Windows.Forms.Button();
			this.lstPages = new System.Windows.Forms.ListBox();
			this.grpPage = new System.Windows.Forms.GroupBox();
			this.buttonPanel = new System.Windows.Forms.Panel();
			this.dlgColor = new System.Windows.Forms.ColorDialog();
			this.menu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuImport = new System.Windows.Forms.ToolStripMenuItem();
			this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			this.lblColorOff = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.grpSelection.SuspendLayout();
			this.panelAction.SuspendLayout();
			this.grpPage.SuspendLayout();
			this.menu.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtId
			// 
			this.txtId.Location = new System.Drawing.Point(17, 80);
			this.txtId.Name = "txtId";
			this.txtId.Size = new System.Drawing.Size(184, 20);
			this.txtId.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Button ID:";
			// 
			// chkTie
			// 
			this.chkTie.AutoSize = true;
			this.chkTie.Location = new System.Drawing.Point(17, 229);
			this.chkTie.Name = "chkTie";
			this.chkTie.Size = new System.Drawing.Size(148, 17);
			this.chkTie.TabIndex = 6;
			this.chkTie.Text = "Tie with telemetry variable";
			this.chkTie.UseVisualStyleBackColor = true;
			this.chkTie.CheckedChanged += new System.EventHandler(this.chkTie_CheckedChanged);
			// 
			// cmbApply
			// 
			this.cmbApply.Location = new System.Drawing.Point(17, 339);
			this.cmbApply.Name = "cmbApply";
			this.cmbApply.Size = new System.Drawing.Size(184, 23);
			this.cmbApply.TabIndex = 12;
			this.cmbApply.Text = "Apply";
			this.cmbApply.UseVisualStyleBackColor = true;
			this.cmbApply.Click += new System.EventHandler(this.cmbApply_Click);
			// 
			// txtText
			// 
			this.txtText.Location = new System.Drawing.Point(17, 123);
			this.txtText.Name = "txtText";
			this.txtText.Size = new System.Drawing.Size(184, 20);
			this.txtText.TabIndex = 13;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(14, 107);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(31, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Text:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(14, 165);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(31, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "Icon:";
			// 
			// cboIcon
			// 
			this.cboIcon.FormattingEnabled = true;
			this.cboIcon.Location = new System.Drawing.Point(70, 154);
			this.cboIcon.Name = "cboIcon";
			this.cboIcon.Size = new System.Drawing.Size(131, 21);
			this.cboIcon.TabIndex = 16;
			// 
			// grpSelection
			// 
			this.grpSelection.Controls.Add(this.lblColorOff);
			this.grpSelection.Controls.Add(this.label5);
			this.grpSelection.Controls.Add(this.cboAction);
			this.grpSelection.Controls.Add(this.label2);
			this.grpSelection.Controls.Add(this.panelAction);
			this.grpSelection.Controls.Add(this.cboIcon);
			this.grpSelection.Controls.Add(this.label7);
			this.grpSelection.Controls.Add(this.label6);
			this.grpSelection.Controls.Add(this.txtText);
			this.grpSelection.Controls.Add(this.cmbApply);
			this.grpSelection.Controls.Add(this.chkTie);
			this.grpSelection.Controls.Add(this.label1);
			this.grpSelection.Controls.Add(this.txtId);
			this.grpSelection.Enabled = false;
			this.grpSelection.Location = new System.Drawing.Point(668, 135);
			this.grpSelection.Name = "grpSelection";
			this.grpSelection.Size = new System.Drawing.Size(224, 375);
			this.grpSelection.TabIndex = 0;
			this.grpSelection.TabStop = false;
			this.grpSelection.Text = "Settings";
			// 
			// cboAction
			// 
			this.cboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAction.FormattingEnabled = true;
			this.cboAction.Location = new System.Drawing.Point(17, 37);
			this.cboAction.Name = "cboAction";
			this.cboAction.Size = new System.Drawing.Size(184, 21);
			this.cboAction.TabIndex = 20;
			this.cboAction.SelectedIndexChanged += new System.EventHandler(this.cboAction_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "Action:";
			// 
			// panelAction
			// 
			this.panelAction.Controls.Add(this.lblColorOn);
			this.panelAction.Controls.Add(this.label4);
			this.panelAction.Controls.Add(this.cboTie);
			this.panelAction.Controls.Add(this.label3);
			this.panelAction.Location = new System.Drawing.Point(17, 252);
			this.panelAction.Name = "panelAction";
			this.panelAction.Size = new System.Drawing.Size(184, 79);
			this.panelAction.TabIndex = 18;
			// 
			// lblColorOn
			// 
			this.lblColorOn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblColorOn.Location = new System.Drawing.Point(81, 50);
			this.lblColorOn.Name = "lblColorOn";
			this.lblColorOn.Size = new System.Drawing.Size(103, 20);
			this.lblColorOn.TabIndex = 16;
			this.lblColorOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblColorOn.Click += new System.EventHandler(this.lblColor_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(-3, 53);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Color when on:";
			// 
			// cboTie
			// 
			this.cboTie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTie.FormattingEnabled = true;
			this.cboTie.Location = new System.Drawing.Point(0, 19);
			this.cboTie.Name = "cboTie";
			this.cboTie.Size = new System.Drawing.Size(184, 21);
			this.cboTie.TabIndex = 13;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(-3, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Action:";
			// 
			// cmbPageAdd
			// 
			this.cmbPageAdd.Location = new System.Drawing.Point(121, 25);
			this.cmbPageAdd.Name = "cmbPageAdd";
			this.cmbPageAdd.Size = new System.Drawing.Size(80, 26);
			this.cmbPageAdd.TabIndex = 1;
			this.cmbPageAdd.Text = "Add";
			this.cmbPageAdd.UseVisualStyleBackColor = true;
			this.cmbPageAdd.Click += new System.EventHandler(this.cmbPageAdd_Click);
			// 
			// cmbPageRemove
			// 
			this.cmbPageRemove.Location = new System.Drawing.Point(121, 56);
			this.cmbPageRemove.Name = "cmbPageRemove";
			this.cmbPageRemove.Size = new System.Drawing.Size(80, 26);
			this.cmbPageRemove.TabIndex = 2;
			this.cmbPageRemove.Text = "Remove";
			this.cmbPageRemove.UseVisualStyleBackColor = true;
			this.cmbPageRemove.Click += new System.EventHandler(this.cmbPageRemove_Click);
			// 
			// lstPages
			// 
			this.lstPages.FormattingEnabled = true;
			this.lstPages.Items.AddRange(new object[] {
            "Page 1"});
			this.lstPages.Location = new System.Drawing.Point(17, 25);
			this.lstPages.Name = "lstPages";
			this.lstPages.Size = new System.Drawing.Size(98, 56);
			this.lstPages.TabIndex = 2;
			this.lstPages.SelectedIndexChanged += new System.EventHandler(this.lstPages_SelectedIndexChanged);
			// 
			// grpPage
			// 
			this.grpPage.Controls.Add(this.lstPages);
			this.grpPage.Controls.Add(this.cmbPageRemove);
			this.grpPage.Controls.Add(this.cmbPageAdd);
			this.grpPage.Location = new System.Drawing.Point(668, 35);
			this.grpPage.Name = "grpPage";
			this.grpPage.Size = new System.Drawing.Size(224, 94);
			this.grpPage.TabIndex = 1;
			this.grpPage.TabStop = false;
			this.grpPage.Text = "Page";
			// 
			// buttonPanel
			// 
			this.buttonPanel.AutoSize = true;
			this.buttonPanel.Location = new System.Drawing.Point(12, 27);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(140, 119);
			this.buttonPanel.TabIndex = 2;
			// 
			// menu
			// 
			this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menu.Location = new System.Drawing.Point(0, 0);
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(912, 24);
			this.menu.TabIndex = 3;
			this.menu.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuImport,
            this.menuExport,
            this.toolStripMenuItem1,
            this.menuExit});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// menuImport
			// 
			this.menuImport.Name = "menuImport";
			this.menuImport.Size = new System.Drawing.Size(169, 22);
			this.menuImport.Text = "Import template...";
			this.menuImport.Click += new System.EventHandler(this.menuImport_Click);
			// 
			// menuExport
			// 
			this.menuExport.Name = "menuExport";
			this.menuExport.Size = new System.Drawing.Size(169, 22);
			this.menuExport.Text = "Export template...";
			this.menuExport.Click += new System.EventHandler(this.menuExport_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 6);
			// 
			// menuExit
			// 
			this.menuExit.Name = "menuExit";
			this.menuExit.Size = new System.Drawing.Size(169, 22);
			this.menuExit.Text = "Exit...";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// ofd
			// 
			this.ofd.FileName = "template.json";
			this.ofd.Filter = "template.json|template.json";
			// 
			// sfd
			// 
			this.sfd.FileName = "template.json";
			this.sfd.Filter = "template.json|template.json";
			// 
			// lblColorOff
			// 
			this.lblColorOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblColorOff.Location = new System.Drawing.Point(70, 203);
			this.lblColorOff.Name = "lblColorOff";
			this.lblColorOff.Size = new System.Drawing.Size(131, 20);
			this.lblColorOff.TabIndex = 22;
			this.lblColorOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblColorOff.Click += new System.EventHandler(this.lblColor_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(14, 207);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 13);
			this.label5.TabIndex = 21;
			this.label5.Text = "Color:";
			// 
			// frmTemplate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(912, 575);
			this.Controls.Add(this.buttonPanel);
			this.Controls.Add(this.grpPage);
			this.Controls.Add(this.grpSelection);
			this.Controls.Add(this.menu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menu;
			this.MaximizeBox = false;
			this.Name = "frmTemplate";
			this.Text = "Fergo ETS2 Virtual Button Box - Template Tool";
			this.Load += new System.EventHandler(this.frmTemplate_Load);
			this.grpSelection.ResumeLayout(false);
			this.grpSelection.PerformLayout();
			this.panelAction.ResumeLayout(false);
			this.panelAction.PerformLayout();
			this.grpPage.ResumeLayout(false);
			this.menu.ResumeLayout(false);
			this.menu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtId;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkTie;
		private System.Windows.Forms.Button cmbApply;
		private System.Windows.Forms.TextBox txtText;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cboIcon;
		private System.Windows.Forms.GroupBox grpSelection;
		private System.Windows.Forms.Button cmbPageAdd;
		private System.Windows.Forms.Button cmbPageRemove;
		private System.Windows.Forms.ListBox lstPages;
		private System.Windows.Forms.GroupBox grpPage;
		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.ColorDialog dlgColor;
		private System.Windows.Forms.Panel panelAction;
		private System.Windows.Forms.Label lblColorOn;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cboTie;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboAction;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.MenuStrip menu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuImport;
		private System.Windows.Forms.ToolStripMenuItem menuExport;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem menuExit;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.SaveFileDialog sfd;
		private System.Windows.Forms.Label lblColorOff;
		private System.Windows.Forms.Label label5;
	}
}

