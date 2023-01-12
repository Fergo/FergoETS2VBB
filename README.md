
# Fergo Virtual Button Box for Euro Truck Simulator 2

<p align="center">
  <img width="460" src="https://i.imgur.com/GP3LQxy.jpg">
</p>

Welcome to the Fergo ETS2 Virtual Button Box page. 

This project aims to create a virtual button box for Euro Truck Simulator 2 that you can use on any handheld device (smartphones, tablets). It has two main components:

* **Server:** C# application that retrieves data from Euro Truck Simulator 2, creates a web server and sends and receives data to/from clients. This must run in the same computer as your Euro Truck Simulator 2;
* **Client:** A local website that connects to the server and provides the user interface of the button box. You can access this from any browser on any device on your local network.

Fergo ETS2 VBB uses pieces of code already written by other fellow ETS fans:

https://github.com/Funbit/ets2-telemetry-server

https://github.com/logisticsmod/Ets2-Telemetry-Library

*Some of the code from the above repositores had to be updated in order to properly work with the current version of the telemetry library.*

**Official SCS forum post:**

https://forum.scssoft.com/viewtopic.php?f=34&t=283591

# Requirements

Fergo ETS2 VBB makes use of the `ets2-telemetry-server.dll` plugin created by [Funbit](https://github.com/Funbit). If desired, the pre-compiled files are available in the `ETS2 Telemetry Plugins` folder of this repository. Just copy the contents of that folder into your ETS2 `bin` directory (e.g. `C:\Program Files\Steam\steamapps\common\Euro Truck Simulator 2\bin`)

You will also need `.NET Framework 4.6.1`

# Download 

Check the `Releases` page:

https://github.com/Fergo/FergoETS2Dash/releases

# Usage

Download and extract the release package to a directory of choice. Run `FergoETS2Dash.exe` (the first time, it's recommended to run it with elevated priviledges, as it needs to configure firewall rules and reserve the HTTP address.

With the program running, click `Start server` to start the HTTP and WebSocket listeners. You can then go to your device's web browser (Safari, Firefox, Chrome, etc.) and type in the local address of the server, as shown in the log window (e.g. http://192.168.1.100:8080). The virtual buttons will be shown on the page. 

To configure the action of each button, click `Map commands` on the server window and then push the desired button on the client. A new entry will be added to the command list, for which you can then assign a virtual keypress. When finished, just click `End mapping`. If both the server and the ETS2 connection are estabilished (shown in green in the server window), you should be good to.

PS.: The release already comes with a preset configuration compatible with the default ETS2 keybindings.

# Template Tool

Since version 0.2a, the package now includes a templating tool that allows you to customize the client buttons to your own liking, including custom icons, text and colors. It also enables support for multiple pages, so you can now have more than 16 buttons to control your simulator.

# Screenshots

<p align="center">
  <img width="460" src="https://i.imgur.com/mQVDdgf.png">
</p>

<p align="center">
  <img width="460" src="https://i.imgur.com/e70hdUh.png">
</p>



