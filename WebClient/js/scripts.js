var DEBUG = false;
var socketConnected = 0;
var telemetryVars = new Array(25);
var currentPage = 0;
var pages = "";

buttons = document.getElementsByClassName("grid_botao");

$.ajax({
  url: "template.json",
  async: false,
  dataType: 'json',
  success: function (response) {
    pages = response;
  }
});

function ShowPage(page) {
    if (pages[page] != null) {
        for (var i = 0; i < buttons.length; i ++ ) {
            buttons[i].children[0].children[0].innerHTML = pages[page].button[i].icon;
            buttons[i].children[0].children[1].innerHTML = pages[page].button[i].name;
            buttons[i].children[0].children[0].style.color = pages[page].button[i].colorOff;
            buttons[i].id = pages[page].button[i].id;
        }
        currentPage = page;
    }
}

//Atualiza a tela do CDU conforme a string do servidor
function Update(inputStream) {

	var split = inputStream.split('|');

	//Cada valor a ser atualizado é divida por um pipe
	split.forEach(el => {
		var segments = el.split('@');

		if (segments.length == 2) {

			var id = segments[0];
            var value = segments[1];

            if (id.substr(0, 5) == "data_") {
                if (document.getElementById(id))
                    document.getElementById(id).innerHTML = value;
            } else {
                telemetryVars[parseInt(id)] = value;
            }
            
		}
    });

    for (var i = 0; i < buttons.length; i ++ ) {
        var buttonTelemetry = parseInt(pages[currentPage].button[i].telemetry);

        if (buttonTelemetry >= 0) {
            if (telemetryVars[buttonTelemetry] == 1)
                buttons[i].children[0].children[0].style.color = pages[currentPage].button[i].colorOn;
            else
                buttons[i].children[0].children[0].style.color = pages[currentPage].button[i].colorOff;
        }
        
    }
    
}

//Envia o pressionamento de um botao
function SendCommand(command) {
    if (command.substr(0, 9) == "next_page") {
        ShowPage(currentPage + 1);
    } else if (command.substr(0, 9) == "prev_page") {
        ShowPage(currentPage - 1);
    } else {
        if (!DEBUG) {
            if (socketConnected)
            socket.send(command);
        } 
    }
}
    

$(document).ready(function() {
    $('.grid_botao').on("touchstart", function(e) {
        SendCommand(this.id + "@down");
        e.preventDefault();
    });

    $('.grid_botao').on("mousedown", function(e) {
        SendCommand(this.id + "@down");
    });

    $('.grid_botao').on("touchend", function(e) {
        SendCommand(this.id + "@up");
        e.preventDefault();
    });

    $('.grid_botao').on("mouseup", function(e) {
        SendCommand(this.id + "@up");
    });
});

//Apenas configura o socket se nao estivermos no modo debug
if (!DEBUG) {
    socket = new WebSocket("ws://" + location.hostname + ":" + (parseInt(location.port) + 1) + "/");	
                
    socket.onopen = function(e){
        socketConnected = 1;
    }

    //Quando receber mensagem do servidor, atualizar o CDU
    socket.onmessage = function (evt) {
        Update(evt.data);
    };
}

ShowPage(0);