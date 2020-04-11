var DEBUG = false;
var socketConnected = 0;

var colors = {
    "btn_lanterna" : "#46ff40",
    "btn_luzbaixa" : "#46ff40",
    "btn_luzalta" : "#0d1dff",
    "btn_freiodemao" : "#f50504",
    "btn_piscaalerta" : "#f50504",
    "btn_limpadores" : "#aeaeae",
    "btn_cabine" : "#aeaeae",
    "btn_teto" : "#46ff40",
    "btn_emergencia" : "#efb602"
};

//Atualiza a tela do CDU conforme a string do servidor
function Update(inputStream) {

	var split = inputStream.split('|');

	//Cada valor a ser atualizado é divida por um pipe
	split.forEach(el => {
		var segments = el.split('@');

		if (segments.length == 2) {

			var id = segments[0];
            var value = segments[1];

            if (id.substr(0, 4) == "btn_") {
                if (document.getElementById(id)) {
                    if (value == "True")
                        document.getElementById(id).children[0].children[0].style.color = colors[id];
                    else
                    document.getElementById(id).children[0].children[0].style.color = "#111111";
                }   

            } else {
                if (document.getElementById(id))
                    document.getElementById(id).innerHTML = value;
            }
            
		}
	});
}

//Envia o pressionamento de um botao
function SendCommand(command) {
	if (!DEBUG) {
		if (socketConnected)
		socket.send(command);
	} 
}
    

$(document).ready(function() {
    $('.grid_botao').on("touchstart", function(e) {
        // alert("touch")
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