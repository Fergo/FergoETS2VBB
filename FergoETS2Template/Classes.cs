using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Globalization;

namespace FergoETS2Template {

	public static class HTMLTemplates {
	}

	public class Page {
		[JsonProperty("id")]
		public int ID;
		[JsonProperty("button")]
		public VirtualButton[] Buttons = new VirtualButton[16];
	}

	public class VirtualButton {
		[JsonIgnore]
		private string _tempIcon = "";

		public string id;
		public string name;
		public string icon = "";
		[JsonIgnore]
		public VirtualButtonType Action = VirtualButtonType.Command;
		[JsonIgnore]
		public bool Tie = false;
		public int telemetry = -1;
		public string colorOn = "#46ff40";
		public string colorOff = "#333333";

		[OnSerializing]
		private void OnSerializing(StreamingContext context) {
			if (icon != "") {
				_tempIcon = icon;
				icon = "&#x" + ((int)Convert.ToChar(icon)).ToString("X").ToLower() + ";";
			}
				
		}

		[OnSerialized]
		private void OnSerialized(StreamingContext context) {
			icon = _tempIcon;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context) {

			if (telemetry != -1)
				Tie = true;

			if (id == "prev_page")
				Action = VirtualButtonType.PreviousPage;

			if (id == "next_page")
				Action = VirtualButtonType.NextPage;

			icon = System.Net.WebUtility.HtmlDecode(icon);
		}
	}	

	public enum VirtualButtonType {
		Command,
		NextPage,
		PreviousPage
	}
}
