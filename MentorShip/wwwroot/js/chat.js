"use strict";


$(document).ready(() => {
    var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();
 
   
    var email = $("#client").val();
  
    connection.start().then(() => connection.invoke('setUserEmail ', email));

    $("#msg-send").click(() => {
        let message = $("#txtMessage").val();
        $("#txtMessage").val(" ");
        var user = $("#sender").val();
        connection.invoke("ClientSendMessage", $("#client").val(),user, message)
            .catch(error => console.log("Error." + error));       
        var div = document.createElement("div");
        div.textContent = message;
        div.style.fontSize = "20px";
        div.style.fontFamily = "Josefin Sans, sans-serif";
        div.style.paddingLeft = "5px";
        div.style.paddingRight = "5px";
        div.style.paddingBottom = "3px";
        div.style.paddingTop = "3px";
        
        
        div.style.marginBottom = "2px";
        div.style.width = "fit-content";
        
        div.style.marginRight = "3px";
        div.style.float = "right";
        div.style.content = "";
        div.style.clear = "both";
        
        
        div.style.height = "fit-content";
        div.style.backgroundColor = "#056162";
        div.style.color = "white";
        
        div.style.borderRadius = "10px";
        div.style.border = "1px solid black";
        document.getElementById("chat-cont").appendChild(div);
       
        
    });

    connection.on("ReceiveMessage", function (user, message) {
        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var encodedMsg = msg;
        $("#senderuser").html(user);
        var div = document.createElement("div");
        div.textContent = encodedMsg;
        div.style.fontSize = "20px";
        div.style.fontFamily = "Josefin Sans, sans-serif";
        div.style.paddingLeft = "5px";
        div.style.paddingRight = "5px";
        div.style.paddingBottom = "3px";
        div.style.paddingTop = "3px";
        div.style.marginLeft = "0px";
        div.style.float = "left";
        div.style.content = "";
        div.style.clear = "both";
        div.style.marginBottom = "2px";
        div.style.width = "fit-content";
        div.style.height = "fit-content";
        div.style.backgroundColor = "#262D31";
        div.style.color = "white";
        div.style.borderRadius = "10px";
        div.style.border = "1px solid black";
        document.getElementById("chat-cont").appendChild(div);
        
    });

});