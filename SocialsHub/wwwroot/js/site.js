function getUrlVars() {
    var vars = {};
    var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
        vars[key] = value;
    });
    return vars;
}

var bcolor = getUrlVars()["favcolor"].replace("%23", "#");

if (bcolor){

    const nodeList = document.querySelectorAll(".tableRow");
    for (let i = 0; i < nodeList.length; i++) {
        nodeList[i].style.backgroundColor = bcolor;
    }
}
