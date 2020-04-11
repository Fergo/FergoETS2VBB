
# Fergo ETS2 Virtual Button Box

Welcome to Fergo ETS2 Virtual Button Box page. 

This project aims to create a virtual button box for Euro Truck Simulator 2 that you can use on any handheld device (smartphones, tablets). The project contains two components:

* **Server:** the C# application that retrieves the data from Euro Truck Simulator 2, creates a web server, sends and receives  data from the clients
* **Client:** an HTML/JS page that connects to the server and provides the user interface of the button box.

This projects uses pieces of code already written by other fellow ETS fans:

https://github.com/Funbit/ets2-telemetry-server

https://github.com/logisticsmod/Ets2-Telemetry-Library

# Requirements

Fergo ETS2 VBB makes use of the telemetry plugin 'ets2-telemetry-server.dll' created by Funbit. If desired, the files are available in the `ETS2 Telemetry Plugins` folder of this repository. Just copy the contents of that folder into your ETS2 `bin` directory (e.g. `C:\Program Files\Steam\steamapps\common\Euro Truck Simulator 2\bin`)

You will also need `.NET Framework 4.6.1`

# Usage

Download and extract the release to a directory of your choice. Run `FergoETS2Dash.exe` (the first time, it's recommended to run it with elevated priviledges, as it needs to configure the firewall rule and HTTP reservation.

With the program running, click `Start server` to start the HTTP and WebSocket listeners. You can then go to your device (or  use the browser on your own computer) and access the local address of the server, as shown in the log window (i.e. http://192.168.1.100:8080). The virtual buttons will be shown on the page. 

Now, to configure what each button does, click the `Map commands` button on the server and then push the desired button the client. A new entry will be added to the command list, where you can then assign a keypress to that command. When finished, just click `End mapping`. If both the server and the ETS2 connection are estabilished (shown in green in the server window), you should be good to.

PS.: The release already comes with a preset configuration compatible with the default keybindings.

# Screenshots

<p align="center">
  <img width="460" src="https://i.imgur.com/GP3LQxy.jpg">
</p>

<p align="center">
  <img width="460" height="300" src="https://i.imgur.com/mQVDdgf.png">
</p>

