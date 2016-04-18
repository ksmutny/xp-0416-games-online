



function MakeClick(i, j) {




}


function GetItem(i, j) {
    return '<div class= "gamefield notcheck" onlick="MakeClick(' + i + ',' + j + ')"  />';
}

function GenerateGameHtml(model) {

    window.table = [];

    var html = "<table>";


    for (var i = 0; i < model.Piles.length ; i++) {

        var arr = [];

        window.table.push(arr);

        html += "<row>";

        for (var j = 0; j < model.Piles[i].length ; j++) {


            arr.push(false);


            html += "<td>";

            html += GetItem(i, j);

            html += "</td>";

        }

        html += "</row>";
    }

    html += "</table>";






}