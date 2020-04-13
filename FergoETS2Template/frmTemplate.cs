using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtensionMethods;
using Newtonsoft.Json;

namespace FergoETS2Template {
	public partial class frmTemplate : Form {
		//WinForms buttons
		Button[] buttons = new Button[16];

		List<Page> pages = new List<Page>();
		int currentPage = 0;
		Button clickedButton;
		private string templatePath = Path.Combine(Application.StartupPath, @"web\");

		public frmTemplate() {
			InitializeComponent();
		}

		private void SetupButtons() {
			Size buttonSize = new Size(96,118);
			int buttonSpacing = 10;

			//Setup an intial page
			Page page = new Page {
				ID = 0,
				Buttons = new VirtualButton[16]
			};

			pages.Add(page);

			//Setup a 4x4 grid of buttons and add to the form
			for (int i = 0; i < buttons.Length; i++) {
				int currentLine = i / 4;

				buttons[i] = new Button {
					Tag = i,
					Text = "Button " + i,
					Size = buttonSize,
					Left = (i % 4) * buttonSize.Width + buttonSpacing,
					Top = (i / 4) * buttonSize.Height + buttonSpacing,
					Visible = true,
					Enabled = true
				};

				buttons[i].Click += new EventHandler(this.button_Click);
				pages[0].Buttons[i] = new VirtualButton();
				pages[0].Buttons[i].id = "btn_" + i;
				pages[0].Buttons[i].name = buttons[i].Text;
			}

			buttonPanel.Controls.AddRange(buttons);
		}

		private void button_Click(object sender, EventArgs e) {
			clickedButton = (Button)sender;
			ShowButtonProperties(currentPage, Convert.ToInt32(clickedButton.Tag));

			grpSelection.Enabled = true;
			grpSelection.Text = "'" + clickedButton.Text + "' Properties";

		}

		private void cmbApply_Click(object sender, EventArgs e) {
			if (clickedButton != null)
				ApplyButtonProperties(currentPage, Convert.ToInt32(clickedButton.Tag));
		}

		private void ClearProps() {
			txtId.Text = "";
			txtText.Text = "";
			cboIcon.Text = "";
			cboAction.SelectedIndex = 0;
			chkTie.Checked = false;
			panelAction.Visible = false;

			cboTie.Text = "";
			lblColorOn.BackColor = Color.DarkGreen;
			lblColorOff.BackColor = Color.Black;

			lblColorOn.Text = "";
			lblColorOff.Text = "";

			grpSelection.Enabled = false;
			grpSelection.Text = "No selection";
		}

		private void ChangePage(int Page) {
			currentPage = Page;
			clickedButton = null;

			for (int i = 0; i < buttons.Length; i++) {
				buttons[i].Text = pages[Page].Buttons[i].name;
			}

			ClearProps();
		}

		private void ApplyButtonProperties(int Page, int Index) {
			pages[Page].Buttons[Index].id = txtId.Text;
			pages[Page].Buttons[Index].name = txtText.Text;
			pages[Page].Buttons[Index].icon = cboIcon.Text;
			pages[Page].Buttons[Index].Action = (VirtualButtonType)cboAction.SelectedIndex;
			pages[Page].Buttons[Index].Tie = chkTie.Checked;

			pages[Page].Buttons[Index].telemetry = chkTie.Checked == true ? cboTie.SelectedIndex : -1;
			pages[Page].Buttons[Index].colorOn = ColorTranslator.ToHtml(lblColorOn.BackColor);
			pages[Page].Buttons[Index].colorOff = ColorTranslator.ToHtml(lblColorOff.BackColor);

			buttons[Index].Text = txtText.Text;
		}

		private void ShowButtonProperties(int Page, int Index) {
			txtId.Text = pages[Page].Buttons[Index].id;
			txtText.Text = pages[Page].Buttons[Index].name;
			cboIcon.Text = pages[Page].Buttons[Index].icon;
			cboAction.SelectedIndex = (int)pages[Page].Buttons[Index].Action;
			chkTie.Checked = pages[Page].Buttons[Index].Tie;

			if (chkTie.Checked)
				cboTie.SelectedIndex = pages[Page].Buttons[Index].telemetry;

			lblColorOn.BackColor = ColorTranslator.FromHtml(pages[Page].Buttons[Index].colorOn);
			lblColorOff.BackColor = ColorTranslator.FromHtml(pages[Page].Buttons[Index].colorOff);

			lblColorOn.Text = pages[Page].Buttons[Index].colorOn;
			lblColorOff.Text = pages[Page].Buttons[Index].colorOff;

			if (chkTie.Checked) 
				panelAction.Visible = true;
			else
				panelAction.Visible = false;
		}

		private void PopulateCombos() {

			//Button actions
			cboAction.Items.AddRange(new string[] {
				"Command",
				"Next page",
				"Previous page",
			});

			cboAction.SelectedIndex = 0;

			//Telemetry variables
			cboTie.Items.AddRange(new string[] {
				"CruiseControlOn",
				"WipersOn",
				"ParkBrakeOn",
				"MotorBrakeOn",
				"EngineOn",
				"ElectricOn",
				"BlinkerLeftActive",
				"BlinkerRightActive",
				"BlinkerLeftOn",
				"BlinkerRightOn",
				"LightsParkingOn",
				"LightsBeamLowOn",
				"LightsBeamHighOn",
				"LightsAuxFrontOn",
				"LightsAuxRoofOn",
				"LightsBeaconOn",
				"LightsBrakeOn",
				"LightsReverseOn",
				"BatteryVoltageWarningOn",
				"AirPressureWarningOn",
				"AirPressureEmergencyOn",
				"AdblueWarningOn",
				"OilPressureWarningOn",
				"WaterTemperatureWarningOn",
				"HazardLightsOn"
			});

			//Icons


			Font iconFont = null;
			try {
				iconFont = new Font(new FontFamily("Fergo ETS2"), 20);
				cboIcon.Font = iconFont;
			} catch {
				DialogResult dlgResult = MessageBox.Show("It looks like you don't have the dashboard symbols font installed.\r\n" +
														"Please install the font by clicking 'Install' on the window that will open next",
														"Font not found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


				Process process = Process.Start("icones.otf");
				process.WaitForExit();

				Process.Start(Application.ExecutablePath);
				Application.Exit();
			} 
			
			
			cboIcon.Items.AddRange(new string[] {
				"\uf100",
				"\uf101",
				"\uf102",
				"\uf103",
				"\uf104",
				"\uf105",
				"\uf106",
				"\uf107",
				"\uf108",
				"\uf109",
				"\uf10A",
				"\uf10B",
				"\uf10C",
				"\uf10D",
				"\uf10E",
				"\uf10F",
				"\uf110",
				"\uf111",
				"\uf112",
				"\uf113",
				"\uf114",
				"\uf115",
				"\uf116",
				"\uf117",
				"\uf118",
				"\uf119",
				"\uf11A",
				"\uf11B",
				"\uf11C",
				"\uf11D",
				"\uf11E",
				"\uf11F",
				"\uf120",
				"\uf121",
				"\uf122",
				"\uf123",
				"\uf124"
			});
		}

		private void frmTemplate_Load(object sender, EventArgs e) {
			SetupButtons();
			PopulateCombos();

			int positionLeft = buttonPanel.Left + buttonPanel.Width + 10;

			grpPage.Left = positionLeft;
			grpSelection.Left = positionLeft;

			this.Width = grpPage.Left + grpPage.Width + 40;
			this.Height = grpSelection.Top + grpSelection.Height + 60;

			this.Text += " v" + Assembly.GetExecutingAssembly().GetName().Version;
		}

		private void lblColor_Click(object sender, EventArgs e) {
			if (dlgColor.ShowDialog() == DialogResult.OK) {
				((Label)sender).BackColor = dlgColor.Color;
				((Label)sender).Text = dlgColor.Color.ToHex();
			}
		}

		private void chkTie_CheckedChanged(object sender, EventArgs e) {
			panelAction.Visible = chkTie.Checked;
		}

		private void cboAction_SelectedIndexChanged(object sender, EventArgs e) {
			if (cboAction.SelectedIndex == (int)VirtualButtonType.NextPage) {
				txtId.Text = "next_page";
				txtId.ReadOnly = true;
				chkTie.Enabled = false;
			} else if (cboAction.SelectedIndex == (int)VirtualButtonType.PreviousPage) {
				txtId.Text = "prev_page";
				txtId.ReadOnly = true;
				chkTie.Enabled = false;
			} else {
				txtId.ReadOnly = false;
				chkTie.Enabled = true;
			}
		}

		private void lstPages_SelectedIndexChanged(object sender, EventArgs e) {
			currentPage = lstPages.SelectedIndex;

			ChangePage(currentPage);
		}

		private void cmbPageAdd_Click(object sender, EventArgs e) {
			Page page = new Page {
				ID = pages.Count,
				Buttons = new VirtualButton[16]
			};

			for (int i = 0; i < page.Buttons.Length; i++)
				page.Buttons[i] = new VirtualButton();

			pages.Add(page);

			RefreshPages();
		}

		private void cmbPageRemove_Click(object sender, EventArgs e) {
			if (pages.Count > 1)
				pages.RemoveAt(pages.Count - 1);
			RefreshPages();
		}

		private void RefreshPages() {
			lstPages.Items.Clear();

			foreach(var page in pages)
				lstPages.Items.Add("Page " + page.ID);

			lstPages.SelectedIndex = 0;
			currentPage = 0;

			ChangePage(currentPage);
		}

		private void LoadTemplate(string Path) {
			string JSONText = File.ReadAllText(Path);

			currentPage = 0;
			pages = JsonConvert.DeserializeObject<List<Page>>(JSONText);
			RefreshPages();
		}


		private void SaveTemplate(string Path) {
			string JSONText = JsonConvert.SerializeObject(pages);

			File.WriteAllText(Path, JSONText);

			MessageBox.Show("Template successfully saved!", "Save template", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void menuImport_Click(object sender, EventArgs e) {
			if (Directory.Exists(templatePath))
				ofd.InitialDirectory = templatePath;

			if (ofd.ShowDialog() == DialogResult.OK)
				LoadTemplate(ofd.FileName);
		}

		private void menuExit_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Are you sure you want to exit? All non exported changes will be lost.", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				Application.Exit();
		}

		private void menuExport_Click(object sender, EventArgs e) {
			if (Directory.Exists(templatePath))
				sfd.InitialDirectory = templatePath;

			if (sfd.ShowDialog() == DialogResult.OK)
				SaveTemplate(sfd.FileName);
		}
	}

	
}

namespace ExtensionMethods {
	public static class ColorExtensions {
		public static string ToHex(this Color c) {
			return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
		}
	}
}
