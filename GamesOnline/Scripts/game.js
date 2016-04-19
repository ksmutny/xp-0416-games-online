﻿function S4() {
    return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
}

function InitNim() {

    $('.newGame').click(function () {
        GetNewGame();
    });

    $('.move').click(function () {
        // call jirka function to get params
        MakeMove();
    });

    GetNewGame();
}

function MakeMove() {
    var input = GetInput();

    $.post('Move', {
        id: window.modelId,
        pile: input[0],
        count: input[1],
        playerName: window.ModelFromServer.PlayerOnTheMove
    },
    function (res) {
        // call jirka js new game
        GenerateGameHtml(res);
    })

}

function GetNewGame() {

    //$.getJSON(
    //    'NewGame',

    //    function (res) {
    //        // call jirka js new game
    //        GenerateGameHtml(res);
    //    })

    var id = S4();

    $.post('NewGame', {
        NewGame: id,
        player1: 'a',
        player2: 'b',
    },
    function (res) {
        // call jirka js new game
        GenerateGameHtml(res);
    })

}

function ShowMakeMove(how) {


}

function ShowMessage(text) {

    $("#messageText").html(text);

}

function MakeClick(i, j) {


    var turnOn = !window.ModelTable[i][j];

    window.ModelTable[i][j] = !window.ModelTable[i][j];


    $("#div" + i + "_" + j).toggleClass("ischeck");


    for (var a = 0; a < window.ModelTable.length ; a++) {

        for (var b = 0; b < window.ModelTable[a].length ; b++) {

            if (ModelTable[a][b] && a != i) {

                $("#div" + a + "_" + b).removeClass("ischeck");
                ModelTable[a][b] = false;

            }

        }

    }


}

function GetItem(i, j) {
    return '<div  id="div' + i + '_' + j + '"  class="gamefield " onclick="MakeClick(' + i + ',' + j + ')"  />';
}

function GenerateGameHtml(model) {


    if (model.ErrorMessage) {
        ShowMessage(model.ErrorMessage);
        return;
    }
    else
        if (model.PlayerWins) {
            ShowMessage("Vyhrál hráč " + model.PlayerWins);
        }
        else { ShowMessage("Hraje hráč " + model.PlayerOnTheMove); }




    window.ModelFromServer = model;

    window.modelId = model.GameId;

    window.ModelTable = [];

    var html = "<table>";

    for (var i = 0; i < model.Piles.length ; i++) {

        var arr = [];

        window.ModelTable.push(arr);

        html += "<tr>";

        for (var j = 0; j < model.Piles[i]; j++) {

            arr.push(false);

            html += "<td>";
            html += GetItem(i, j);
            html += "</td>";
        }

        html += "</tr>";
    }

    html += "</table>";

    $("#gameContainer").html(html);




}


function GetInput() {


    var counts = [];

    var index = -1;

    for (var i = 0; i < window.ModelTable.length ; i++) {

        var arr = [0];
        counts.push(arr)
        for (var j = 0; j < window.ModelTable[i].length ; j++) {

            if (ModelTable[i][j]) {
                arr[0]++;
                index = i;
            }
        }
    }

    if (index >= 0) {
        return [index, counts[index][0]];
    }
    else {
        return [-1, [0]];
    }


}



