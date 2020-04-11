using System.Diagnostics;
using System.Windows.Forms;

namespace FergoETS2Dash {
	public class Setup {

		public static bool Check(int Port, string FirewallRuleName) {
			bool firewallOk = CheckFirewall(FirewallRuleName);
			bool httpOk = CheckHTTP(Port);


			if (firewallOk == false || httpOk == false) {

				//If either the firewall or the HTTP reservation are not ok, add them

				//Adding those rules requires elevated privileges, so if the program is not currently elevated,
				//terminates the current instance and start another one requesting elevated priviledges.

				MessageBox.Show("Fergo ETS2 VBB will try to add firewall and reserved HTTP rules.\r\n\r\n" +
								"This requires elevated privileges, so the program might restart requesting priviledge elevation (only required once).",
								"Setup", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				
				if (!firewallOk) {
					if (Uac.IsProcessElevated()) {
						firewallOk = SetupFirewall(Port, FirewallRuleName);
					} else {
						Uac.RestartElevated();
						return false;
					}
				}

				if (!httpOk) {
					if (Uac.IsProcessElevated()) {
						httpOk = SetupHTTP(Port);
					} else {
						Uac.RestartElevated();
						return false;
					}
				}

				//Check if the rules were successfully added
				if (firewallOk && httpOk) {
					MessageBox.Show("Networking rules successfully configured", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return true;
				} else {
					if (!firewallOk)
						MessageBox.Show("Failed to add firewall rule", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

					if (!firewallOk)
						MessageBox.Show("Failed to add HTTP reservation rule", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

					return false;
				}
			} else {
				return true;
			}
		}

		//Checks if the HTTP reservation is already present
		private static bool CheckHTTP(int Port) {
			string checkURL = $"http show urlacl url=http://*:{Port}/";

			//Executes the command and checks if it was successfull (poorly implemented verification, but seems reliable)
			string stdOut = RunNetSh(checkURL);
			if (stdOut.Contains($"http://*:{Port}/"))
				return true;
			else
				return false;
		}

		//Checks if the firewall rule is already present
		private static bool CheckFirewall(string RuleName) {
			string checkRule = $"advfirewall firewall show rule name=\"{RuleName}\"";

			string stdOut = RunNetSh(checkRule);
			if (stdOut.Contains(RuleName))
				return true;
			else
				return false;
		}

		//Adds the firewall rule
		private static bool SetupFirewall(int Port, string RuleName) {
			string addRule = $"advfirewall firewall add rule name=\"{RuleName}\" dir=in action=allow protocol=TCP localport={Port},{Port + 1} remoteip=localsubnet";

			string stdOut = RunNetSh(addRule);
			if (stdOut.Contains("Ok."))
				return true;
			else
				return false;
		}

		//Adds the HTTP reservation
		private static bool SetupHTTP(int Port) {
			string allUsers = new System.Security.Principal.SecurityIdentifier("S-1-1-0").Translate(typeof(System.Security.Principal.NTAccount)).ToString();
			string httpRule = string.Format("http add urlacl url=http://+:{0}/ user=\"\\{1}\"", Port, allUsers);

			string stdOut = RunNetSh(httpRule);
			if (!stdOut.ToLower().Contains("err"))
				return true;
			else
				return false;
		}

		//Runs a hidden "netsh.exe" instance with the provided arguments
		private static string RunNetSh(string Arguments) {
			ProcessStartInfo info = new ProcessStartInfo("netsh", Arguments) {
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true
			};

			Process process = Process.Start(info);
			string output = process.StandardOutput.ReadToEnd();
			process.WaitForExit();

			return output;
		}
	}
}
