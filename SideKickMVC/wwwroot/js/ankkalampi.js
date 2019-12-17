var BORDER_LEFT_RIGHT = 378;
var BORDER_TOP_DOWN = 80;
var ankat = new Array();
var nextId = 0;
var heightMax;
var widthMax;
var n; //initial direction, see createFish()

init();
/* rubberduck*/

var i;
for (i = 0; i < 150; i++) {
    luoAnkka("../media/kumiankka2.png", "../media/kumiankka2.png");
}
luoAnkka("../media/kumiankka2reverse.png", "../media/kumiankka2reverse.png");

var i;
for (i = 0; i < 50; i++) {
    luoAnkka("../media/kumiankka2.png", "../media/kumiankka2.png");
}


naytaAnkat();

function init() {

    heightMax = document.getElementById("acquario").clientHeight + BORDER_TOP_DOWN;
    widthMax = document.getElementById("acquario").clientWidth + BORDER_LEFT_RIGHT;
    n = 1;
}

function luoAnkka(src1, src2) {
    imgAnkkaSX = new Image();
    imgAnkkaDX = new Image();
    imgAnkkaSX.src = src1;
    imgAnkkaDX.src = src2;
    n *= -1;
    var ankka = {
        id: nextId,
        /* default x position: random number between 1 and widthMax */
        x: Math.floor((Math.random() * (widthMax - BORDER_LEFT_RIGHT - imgAnkkaSX.width)) + BORDER_LEFT_RIGHT),
        /* default y position: random number between 1 and heightMax */
        y: Math.floor((Math.random() * (heightMax - BORDER_TOP_DOWN - imgAnkkaSX.height)) + BORDER_TOP_DOWN),
        xIncrease: n * getIncrease(),
        yIncrease: n * getIncrease(),
        imageSX: imgAnkkaSX,
        imageDX: imgAnkkaDX
    };
    addFishToArray((ankka));
    nextId++;
}

function addFishToArray(ankka) {
    ankat.push(ankka);
}

function naytaAnkat() {

    var node = document.getElementById("acquario");
    var stringToInner = "";
    var src;

    /* first, we make the string with all the img filled in */
    for (var i = 0; i < ankat.length; i++) {
        /* we have to check if the default increase direction was <-- or --> */
        ankat[i].xIncrease > 0 ? src = ankat[i].imageSX.src : src = ankat[i].imageDX.src;
        /* z-index --> overlap priority */
        if (i === 150) {
            ankat[0].xIncrease > 0 ? src = ankat[0].imageSX.src : src = ankat[0].imageDX.src;
            stringToInner += " <a href=\"javascript:ankkaPost()\">" +
                "<img src =\"" + src +
                "\" id=\"" + ankat[i].id + "\" style= \"left: " +
                ankat[i].x + "px;top: " + ankat[i].y + "px;z-index: " +
                ankat[i].id + ";position: absolute;\">" +
                "</a>";
        }
        else {
            stringToInner += "<img src =\"" + src +
                "\" id=\"" + ankat[i].id + "\" style= \"left: " +
                ankat[i].x + "px;top: " + ankat[i].y + "px;z-index: " +
                ankat[i].id + ";position: absolute;\">";
        }
        stringToInner += "<br>";
    }
    /* then, we insert it */
    node.innerHTML = stringToInner;
    /* let's raise hell! */
    liikutaAnkkoja();
}

function getIncrease() {
    return Math.floor((Math.random() * 5) + 1);
}

function liikutaAnkkoja() {

    /* scroll the array: we need to check each fish one by one */
    for (var i = 0; i < ankat.length; i++) {
        liikutaAnkkaa(ankat[i]);
    }
    /* infinite loop */
    setTimeout(function () {
        liikutaAnkkoja()
    }, 50);
}

function liikutaAnkkaa(ankka) {
    /* with this node, I'll apply changes to my html document */
    node = document.getElementById(ankka.id);
    /* we are inside, just move */
    if (ankka.x > BORDER_LEFT_RIGHT && ankka.x < widthMax - node.width && ankka.y > BORDER_TOP_DOWN && ankka.y < heightMax - node.height) {
        node.style.left = ankka.x + "px";
        node.style.top = ankka.y + "px";
        ankka.x += ankka.xIncrease;
        ankka.y += ankka.yIncrease;
        /* too --> , we need to get <-- */
    } else if (ankka.x >= widthMax - node.width) {
        node.src = ankka.imageDX.src;
        ankka.xIncrease = -getIncrease();
        ankka.x += ankka.xIncrease;
        /* too <-- , we need to get --> */
    } else if (ankka.x <= BORDER_LEFT_RIGHT) {
        node.src = ankka.imageSX.src;
        ankka.xIncrease = 5;
        ankka.x += getIncrease();
        /* too up, we need to get down */
    } else if (ankka.y >= heightMax - node.height) {
        ankka.yIncrease = -getIncrease();
        ankka.y += ankka.yIncrease;
        /* too down, we need to get up */
    } else if (ankka.y <= BORDER_TOP_DOWN) {
        ankka.yIncrease = getIncrease();
        ankka.y += ankka.yIncrease;
    }
}

function ankkaPost() {
    let form = document.createElement('form');
    form.action = 'ankkalampi';
    form.method = 'POST';
    // the form must be in the document to submit it
    document.body.append(form);

    form.submit();
}