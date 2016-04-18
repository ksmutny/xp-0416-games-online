
function MakeClick(i, j) {

    window.ModelTable[i][j] = !window.ModelTable[i][j];

    $("#div" + i + "_" + j).toggleClass("notcheck");

}

function GetItem(i, j) {
    return '<div  id="div' + i + '_' + j + '"  class="gamefield notcheck" onclick="MakeClick(' + i + ',' + j + ')"  />';
}

function GenerateGameHtml(model) {

    window.modelId = model.GameId;

    window.ModelTable = [];

    var html = "<table>";

    for (var i = 0; i < model.Piles.length ; i++) {

        var arr = [];

        window.ModelTable.push(arr);

        html += "<tr>";

        for (var j = 0; j < model.Piles[i] ; j++) {

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



function MakeMove() {


}

function Reset() {
}

