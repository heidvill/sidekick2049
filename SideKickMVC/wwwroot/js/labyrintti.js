var kartta = [
    [1, 1, 1, 1, 1],
    [1, 'O', 1, 'H', 1],
    [1, 0, 0, 0, 1],
    [1, 1, 1, 1, 1]
];
var LEVEYS = 700;
var KORKEUS = 600;
var sisalto;
var nappain;
var pelaaja;
pelaaja = {
    y: 1,
    x: 1,
    paivita: function () {
        if (nappain[ylos]) {
            this.y -= 1;
        } else if (nappain[alas]) {
            this.y += 1;
        } else if (nappain[vasen]) {
            this.x -= 1;
        } else if (nappain[oikea]) {
            this.x += 1;
        }

    }
};

var korkeus = kartta.length;
var leveys = kartta[0].length;

console.log(korkeus);
console.log(leveys);

for (let i = 0; i < korkeus; i++) {
    var rivi = "";
    for (let j = 0; j < leveys; j++) {
        rivi += kartta[i][j];
    }
    console.log(rivi);
}
var pelialue = document.createElement("canvas");
pelialue.width = LEVEYS;
pelialue.korkeus = KORKEUS;
sisalto = pelialue.getContext("2d");
document.body.appendChild(pelialue);
function main() {
    document.addEventListener("keydown", function (evt) { nappain[evt.keyCode] = true; });
    document.addEventListener("keyup", function (evt) { delete nappain[evt.keyCode]; });
}

function draw() {
    sisalto.clearRect(0, 0, pelialue.width, pelialue.length);
    for (let i = 0; i < korkeus; i++) {
        var rivi = "";
        for (let j = 0; j < leveys; j++) {
            rivi += kartta[i][j];
            sisalto.beginPath();
            sisalto.rect(i*10, i*10+j, 10, 10);
            sisalto.closePath();
        }
        console.log(rivi);
    }
}


