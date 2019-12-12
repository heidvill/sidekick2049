var kartta = [
    [1, 1, 1, 1, 1],
    [1, 'O', 1, 'H', 1],
    [1, 0, 0, 0, 1],
    [1, 1, 1, 1, 1]
];
var korkeus = kartta.length;
var leveys = kartta[0].length;
var KOKO = 50;
var LEVEYS = leveys * KOKO;
var KORKEUS = korkeus * KOKO;
var sisalto;
var nappain;
var pelaaja;
var oikeaN = false;
var vasenN = false;
var ylosN = false;
var alasN = false;

var pelialue = document.createElement("canvas");
pelialue.width = LEVEYS;
pelialue.height = KORKEUS;
sisalto = pelialue.getContext("2d");
document.getElementById("peli").appendChild(pelialue);

pelaaja = {
    y: 1,
    x: 1
};

document.addEventListener("keydown", alaspainallus, false);
document.addEventListener("keyup", ylosnosto, false);

function alaspainallus(e) {
    if (e.key == "Right" || e.key == "ArrowRight" || e.key == "D" || e.key == "d") {
        oikeaN = true;
        console.log("oikea alas true")
        pelaaja.x += 1;
        draw();
    } else if (e.key == "Left" || e.key == "ArrowLeft" || e.key == "A" || e.key == "a") {
        vasenN = true;
        pelaaja.x -= 1;
        draw();
    } else if (e.key == "Up" || e.key == "ArrowUp" || e.key == "W" || e.key == "w") {
        ylosN = true;
        pelaaja.y -= 1;
        draw();
    } else if (e.key == "Down" || e.key == "ArrowDown" || e.key == "S" || e.key == "s") {
        alasN = true;
        pelaaja.y += 1;
        draw();
    }
}

function ylosnosto(e) {
    if (e.key == "Right" || e.key == "ArrowRight" || e.key == "D" || e.key == "d") {
        oikeaN = false;
    } else if (e.key == "Left" || e.key == "ArrowLeft" || e.key == "A" || e.key == "a") {
        vasenN = false;
    } else if (e.key == "Up" || e.key == "ArrowUp" || e.key == "W" || e.key == "w") {
        ylosN = false;
    } else if (e.key == "Down" || e.key == "ArrowDown" || e.key == "S" || e.key == "s") {
        alasN = false;
    }
}

function draw() {
    sisalto.clearRect(0, 0, pelialue.width, pelialue.height);
    for (let i = 0; i < korkeus; i++) {
        var rivi = "";
        for (let j = 0; j < leveys; j++) {
            rivi += kartta[i][j];
            if (kartta[i][j] == 1) {
                sisalto.beginPath();
                sisalto.rect(j * KOKO, i * KOKO, KOKO, KOKO);
                sisalto.fillStyle = "#0095DD";
                sisalto.fill();
                sisalto.closePath();
            } else if (i == pelaaja.y && j == pelaaja.x) {
                sisalto.beginPath();
                sisalto.rect(j * KOKO, i * KOKO, KOKO, KOKO);
                sisalto.fillStyle = "#eb8334";
                sisalto.fill();
                sisalto.closePath();
            } else if (kartta[i][j] == "H") {
                sisalto.beginPath();
                sisalto.rect(j * KOKO, i * KOKO, KOKO, KOKO);
                sisalto.fillStyle = "#286ab0";
                sisalto.fill();
            }
        }
    }
}
draw();
//setInterval(draw, 10);


