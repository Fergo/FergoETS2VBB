using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using Fleck;
using Ets.Telemetry.Server.Data;
using Ets.Telemetry.Server.Data.Reader;
using System.IO;
using InputManager;

namespace FergoETS2Dash {
	public partial class frmMain : Form {
		WebSocketServer serverWS = null;
		SimpleHTTPServer serverHTTP = null;

		List<IWebSocketConnection> socketsWS = new List<IWebSocketConnection>();
		Ets2TelemetryDataReader etsData = Ets2TelemetryDataReader.Instance;
		bool isMapping = false;
		bool isConnected = false;

		List<EventMapping> keyMaps = new List<EventMapping>();

		Dictionary<string, string> variaveis = new Dictionary<string, string> {
			{ "data_speed", "" },
			{ "data_gear", "" },
			{ "data_cruise","" },
			{ "data_fuel", "" },
			{ "data_fuelc", "" },
			{ "data_oilp", "" },
			{ "data_oilt", "" },
			{ "data_watert", ""},
			{ "data_airpr", "" },
			{ "data_limit", "" }
		};

		Dictionary<string, bool> oldStates = new Dictionary<string, bool> {
			{ "btn_freiodemao", false },
			{ "btn_limpadores", false },
			{ "btn_lanterna", false },
			{ "btn_luzbaixa", false },
			{ "btn_luzalta", false },
			{ "btn_piscaalerta", false },
			{ "btn_teto", false},
			{ "btn_emergencia", false}
		};

		Dictionary<string, bool> states = new Dictionary<string, bool> {
			{ "btn_freiodemao", false },
			{ "btn_limpadores", false },
			{ "btn_lanterna", false },
			{ "btn_luzbaixa", false },
			{ "btn_luzalta", false },
			{ "btn_piscaalerta", false },
			{ "btn_teto", false},
			{ "btn_emergencia", false}
		};

		public frmMain() {
			InitializeComponent();

			
		}

		private void cmbStartServer_Click(object sender, EventArgs e) {

			if (!isConnected) {
				if (int.TryParse(txtPort.Text, out int port)) {
					Log("Validating network configuration...");

					//Check if the firewall and http rules are ok
					bool isConfigured = Setup.Check(port, "Fergo ETS2 Virtual Button Box");

					//If not, exit
					if (!isConfigured) {
						Application.Exit();
						return;
					}

					//Start HTTP server and WebSocket
					StartHTTP(@"web\", "*", port);
					StartSocket(string.Format("ws://0.0.0.0:{0}", port + 1));

					//If both are connected, validate everything
					CheckAllConected();
				} else {
					MessageBox.Show("Invalid port number");
				}
			} else {
				//Stop all sockets
				StopHTTP();
				StopSocket();

				//Validade connections
				CheckAllConected();
			}
			
		}

		//Start the websocket and manages all client connections
		private void StartSocket(string Address) {
			serverWS = new WebSocketServer(Address);
			serverWS.Start(socket => {
				socket.OnOpen = () => {
					Log("<- New connection from: " + socket.ConnectionInfo.ClientIpAddress);
					socketsWS.Add(socket);
				};
				socket.OnClose = () => {
					Log("<- Connection closed from: " + socket.ConnectionInfo.ClientIpAddress);
					socketsWS.Remove(socket);
				};
				socket.OnMessage = message => {
					ProcessMessage(message);
				};
			});

			Log("WebSocket server started");
		}

		//Disconect all websocket clients and terminates the connection
		private void StopSocket() {
			socketsWS.ForEach(s => s.Close());
			socketsWS.Clear();

			if (serverWS != null) {
				serverWS.Dispose();
				serverWS = null;

				Log("WebSocket server stopped");
			}

		}

		//Start HTTP listener that servers the webapp
		private void StartHTTP(string Path, string IP, int Port) {
			serverHTTP = new SimpleHTTPServer(Path, IP, Port);

			Log("HTTP server started");
		}

		//Stop HTTP server
		private void StopHTTP() {
			if (serverHTTP != null) {
				serverHTTP.Stop();
				serverHTTP = null;

				Log("HTTP server stopped");
			}
		}

		//Get the active ethernet interface IP address
		private string GetInternalIP() {
			foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces()) {
				if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet) {
					foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses) {
						if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
							return ip.Address.ToString();
						}
					}
				}
			}

			return null;
		}

		//Check if all the conections are active and configures buttons, logs, etc...
		private void CheckAllConected() {
			if (serverHTTP != null && serverWS != null) {
				string IP = GetInternalIP();

				if (IP != null)
					Log("Servers are running! Go to 'http://" + IP + ":" + serverHTTP.Port + "' to access Fergo ETS2 VBB");
				else
					Log("Servers are running, but I was unable to resolve your internal IP address");

				cmbStartServer.Enabled = true;
				cmbStartServer.Text = "Stop server";

				cmbMapear.Enabled = true;

				tmrUpdate.Enabled = true;

				lblServidor.Text = "Server connected";
				lblServidor.ForeColor = Color.DarkGreen;

				isConnected = true;
			} else if (serverHTTP == null && serverWS == null) {
				Log("All servers stopped");

				cmbStartServer.Enabled = true;
				cmbStartServer.Text = "Start server";

				cmbMapear.Enabled = false;
				
				tmrUpdate.Enabled = false;

				lblServidor.Text = "Server disconnected";
				lblServidor.ForeColor = Color.DarkRed;

				isConnected = false;
			}
		}

		//Logs messages to the listbox
		private void Log(string Message) {
			lstLog.Invoke((MethodInvoker)delegate {
				lstLog.Items.Add(string.Format("[{0:HH:mm:ss}] {1}", DateTime.Now, Message));
				lstLog.TopIndex = lstLog.Items.Count - 1;
			});
		}

		//Send message to all websocket clients
		private void SendMessage(string Message) {
			if (Message != "") {
				socketsWS.ForEach(s => {
					s.Send(Message);
				});
			}
		}

		//Process the incoming messages from the websocket clients
		private void ProcessMessage(string Message) {
			if (Message != "") {
				string[] split = Message.Split('@');

				//If the message is properly formatted (variable@value)
				if (split.Length == 2) {
					Log("Received command: " + split[0] + " - " + split[1]);

					//If the user is not mapping a new command, tries to find a match and send the adequate keypress event
					if (!isMapping) {
						if (keyMaps.Exists(d => d.Nome == split[0])) {
							EventMapping currentMap = keyMaps.Find(d => d.Nome == split[0]);
							if (currentMap.KeyCode != 0) {
								if (split[1] == "down") {
									Keyboard.KeyDown(currentMap.KeyCode);
								} else if (split[1] == "up") {
									Keyboard.KeyUp(currentMap.KeyCode);
								}
							}
						}
					//If the user is mapping a new command, add to the mappings list
					} else {
						if (split[1] == "down") {
							if (!keyMaps.Exists(d => d.Nome == split[0])) {
								keyMaps.Add(new EventMapping { Nome = split[0], FriendlyKey = "", KeyCode = 0 });
								AtualizaLista();
							}
						}
						
					}
				}
			}
		}

		//Refreshes the DataGridView with the current key mappings
		private void AtualizaLista() {
			dgvComandos.Invoke((MethodInvoker)delegate {
				dgvComandos.Rows.Clear();
				foreach (var mapeamento in keyMaps) {
					dgvComandos.Rows.Add(new object[] { mapeamento.Nome, mapeamento.FriendlyKey });
				}
			});
		}

		//When exiting the application...
		private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
			//Closes all the connections
			StopHTTP();
			StopSocket();

			//Saves the current settings to disk
			using (StreamWriter sw = new StreamWriter("config.cfg")) {
				sw.WriteLine("port|" + txtPort.Text);
				foreach (EventMapping mapeamento in keyMaps) {
					sw.WriteLine($"{mapeamento.Nome}|{mapeamento.FriendlyKey}|{(int)mapeamento.KeyCode}");
				}
				sw.Close();
			}
		}

		//Telemetry update
		private void tmrUpdate_Tick(object sender, EventArgs e) {
			if (etsData.IsConnected) {

				if (lblETS.ForeColor != Color.DarkGreen) {
					lblETS.Text = "ETS2 detected";
					lblETS.ForeColor = Color.DarkGreen;
				}

				//Reads all the telemetry data from the game and parses everything. Currently inneficient.
				IEts2TelemetryData data = etsData.Read();

				variaveis["data_speed"] = data.Truck.Speed.ToString("N0");

				if (data.Truck.DisplayedGear > 0)
					variaveis["data_gear"] = data.Truck.DisplayedGear.ToString("N0");
				else if (data.Truck.DisplayedGear == 0)
					variaveis["data_gear"] = "N";
				else
					variaveis["data_gear"] = "R" + Math.Abs(data.Truck.DisplayedGear).ToString();

				variaveis["data_gear"] = data.Truck.DisplayedGear >= 0 ? data.Truck.DisplayedGear.ToString("N0") : "R" + Math.Abs(data.Truck.DisplayedGear).ToString();
				variaveis["data_cruise"] = data.Truck.CruiseControlSpeed.ToString("N0");
				variaveis["data_fuel"] = data.Truck.Fuel.ToString("N0") + " / " + data.Truck.FuelCapacity.ToString() + " liters";
				variaveis["data_oilp"] = data.Truck.OilPressure.ToString("N0") + " psi";
				variaveis["data_oilt"] = data.Truck.OilTemperature.ToString("N0") + " ºC";
				variaveis["data_watert"] = data.Truck.WaterTemperature.ToString("N0") + " ºC";
				variaveis["data_airpr"] = data.Truck.AirPressure.ToString("N0") + " psi";
				variaveis["data_limit"] = data.Navigation.SpeedLimit.ToString("N0");

				states["btn_freiodemao"] = data.Truck.ParkBrakeOn;
				states["btn_limpadores"] = data.Truck.WipersOn;
				states["btn_lanterna"] = data.Truck.LightsParkingOn;
				states["btn_luzbaixa"] = data.Truck.LightsBeamLowOn;
				states["btn_luzalta"] = data.Truck.LightsBeamHighOn;
				states["btn_teto"] = data.Truck.LightsAuxRoofOn;
				states["btn_piscaalerta"] = data.Truck.BlinkerLeftOn && data.Truck.BlinkerRightOn;
				states["btn_emergencia"] = data.Truck.LightsBeaconOn;


				if (!data.Truck.LightsBeamLowOn)
					states["btn_luzalta"] = false;

				//Prepares the string to be sent with websockets (pattern: variable1@value1|variable2@value2 ... )
				string dataSend = "";

				//Telemetry info (speed, gear, ...)
				foreach(var variavel in variaveis)
					dataSend += variavel.Key + "@" + variavel.Value + "|";
				
				//Button light info (wipers, lights, ...)
				foreach (var state in states)
					dataSend += state.Key + "@" + state.Value + "|";

				SendMessage(dataSend);
			} else {
				if (lblETS.ForeColor != Color.DarkRed) {
					lblETS.Text = "ETS2 not detected";
					lblETS.ForeColor = Color.DarkRed;
				}
			}
			
		}

		//When user clicks on the map button, 
		private void cmbMapear_Click(object sender, EventArgs e) {
			if (!isMapping) {
				MessageBox.Show("Press a virtual button on your device in order to add it do the list. You can then assign a virtual keypress to it.",
								"Command mapping", MessageBoxButtons.OK, MessageBoxIcon.Information);

				isMapping = true;
				cmbMapear.Text = "End mapping";
				dgvComandos.Columns[1].DefaultCellStyle.BackColor = Color.LightGreen;
			} else {
				isMapping = false;
				cmbMapear.Text = "Map commands";
				dgvComandos.Columns[1].DefaultCellStyle.BackColor = Color.White;
			}

		}

		private void frmMain_Load(object sender, EventArgs e) {
			lblETS.ForeColor = Color.DarkRed;
			lblServidor.ForeColor = Color.DarkRed;

			//Loads the settings file
			if (File.Exists("config.cfg")) {
				StreamReader sr = new StreamReader("config.cfg");

				while (!sr.EndOfStream) {
					string linha = sr.ReadLine();
					string[] split = linha.Split('|');

					//If there are three values, assume a keyboard mapping, otherwise it's another setting
					if (split.Length == 3) {
						Keys vk = (Keys)Convert.ToInt32(split[2]);
						keyMaps.Add(new EventMapping { Nome = split[0], FriendlyKey = split[1], KeyCode = vk });
					} else if (split.Length == 2)  {
						if (split[0] == "port")
							if (int.TryParse(split[1], out int port))
								txtPort.Text = port.ToString();
							else
								txtPort.Text = "8080";
					}

				}
				sr.Close();
			}

			AtualizaLista();

			this.Activate();
		}

		private void dgvComandos_KeyDown(object sender, KeyEventArgs e) {
			//If the user is in mapping mode and clicks the 'Key' column, assign the key to the command
			if (isMapping) {
				if (dgvComandos.CurrentCell.ColumnIndex == 1) {
					string mapName = dgvComandos.CurrentRow.Cells[0].Value.ToString();
					if (keyMaps.Exists(d => d.Nome == mapName)) {
						EventMapping existing = keyMaps.Find(d => d.Nome == mapName);
						
						existing.KeyCode = e.KeyCode;
						existing.FriendlyKey = existing.KeyCode.ToString();

						dgvComandos.CurrentRow.Cells[1].Value = existing.FriendlyKey;
					}

				}
			//If the user is not in edit mode, manages the removal of command mappings
			} else {
				if (dgvComandos.CurrentRow != null) {
					if (e.KeyCode == Keys.Delete) {
						string mapName = dgvComandos.CurrentRow.Cells[0].Value.ToString();
						if (MessageBox.Show($"Do you really want to delete '{mapName}'?", "Remove mapping", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
							keyMaps.RemoveAll(d => d.Nome == dgvComandos.CurrentRow.Cells[0].Value.ToString());

							AtualizaLista();
						}
						
					}
				}
			}
		}

	}

	
}
