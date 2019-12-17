//var kartta = [
//    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
//    [1, 'O', 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'M'],
//    [1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1],
//    [1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1],
//    [1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 'H', 0, 1, 1, 1, 0, 0, 0, 1, 1,],
//    [1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1],
//    [1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1],
//    [1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1 ,0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
//    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,]
//];


/* KARTAN GENEROINTI */
// https://stackoverflow.com/questions/23530756/maze-recursive-division-algorithm-design
var kartta;
function luoKartta(koko, numDoors) {
    kartta = new Array();
    for (var i = 0; i < koko; i++) {
        kartta[i] = new Array();

        for (var j = 0; j < koko; j++) {
            kartta[i][j] = "";
        }
    }

    lisaaUlkoseinat();
    lisaaSisaseinat(true, 1, kartta.length - 2, 1, kartta.length - 2);
    lisaaMaali();
}

function lisaaUlkoseinat() {
    for (var i = 0; i < kartta.length; i++) {
        if (i == 0 || i == (kartta.length - 1)) {
            for (var j = 0; j < kartta.length; j++) {
                kartta[i][j] = 1;
            }
        } else {
            kartta[i][0] = 1;
            kartta[i][kartta.length - 1] = 1;
        }
    }
}

function lisaaMaali() {
    var x = satunnaisluku(1, kartta.length - 1);
    while (kartta[kartta.length - 2][x] == 1) {
        x = satunnaisluku(1, kartta.length - 1);
    }
    kartta[kartta.length - 1][x] = 'M';
    return x;
}

function lisaaSisaseinat(h, minX, maxX, minY, maxY) {
    if (h) {

        if (maxX - minX < 2) {
            return;
        }

        var y = Math.floor(satunnaisluku(minY, maxY) / 2) * 2;
        lisaaVaakaseina(minX, maxX, y);

        lisaaSisaseinat(!h, minX, maxX, minY, y - 1);
        lisaaSisaseinat(!h, minX, maxX, y + 1, maxY);
    } else {
        if (maxY - minY < 2) {
            return;
        }

        var x = Math.floor(satunnaisluku(minX, maxX) / 2) * 2;
        lisaaPystyseina(minY, maxY, x);

        lisaaSisaseinat(!h, minX, x - 1, minY, maxY);
        lisaaSisaseinat(!h, x + 1, maxX, minY, maxY);
    }
}

function lisaaVaakaseina(minX, maxX, y) {
    var reika = Math.floor(satunnaisluku(minX, maxX) / 2) * 2 + 1;

    for (var i = minX; i <= maxX; i++) {
        if (i == reika) kartta[y][i] = "";
        else kartta[y][i] = 1;
    }
}

function lisaaPystyseina(minY, maxY, x) {
    var reika = Math.floor(satunnaisluku(minY, maxY) / 2) * 2 + 1;

    for (var i = minY; i <= maxY; i++) {
        if (i == reika) kartta[i][x] = "";
        else kartta[i][x] = 1;
    }
}

function satunnaisluku(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min);
}

luoKartta(27, 1, 1); // eka parametri pariton!

// lisää aukkoja seiniin
var kierros = 0;
while (kierros < Math.floor(kartta.length / 2)) {
    var rX = Math.floor(Math.random() * (kartta.length - 2)) + 1;
    var rY = Math.floor(Math.random() * (kartta.length - 2)) + 1;
    if (kartta[rY][rX] == 1) {
        kartta[rY][rX] = "";
        kierros++;
    }
}

// arvo pelaajan paikka
var rPelaajaX = Math.floor(Math.random() * (kartta.length - 2)) + 1;
var rPelaajaY = Math.floor(Math.random() * (kartta.length / 2)) + 1;
while (kartta[rPelaajaY][rPelaajaX] != "") {
    rPelaajaX = Math.floor(Math.random() * (kartta.length - 2)) + 1;
    rPelaajaY = Math.floor(Math.random() * (kartta.length / 2)) + 1;
}
kartta[rPelaajaY][rPelaajaX] = 'O';

// arvo vastustajan paikka
var rVastustajaX = Math.floor(Math.random() * kartta.length - 1) + 1;
var rVastustajaY = Math.floor(Math.random() * kartta.length - 1) + 1;
while (kartta[rVastustajaY][rVastustajaX] != "") {
    rVastustajaX = Math.floor(Math.random() * kartta.length - 1) + 1;
    rVastustajaY = Math.floor(Math.random() * kartta.length - 1) + 1;
}
kartta[rVastustajaY][rVastustajaX] = 'H';

/* ALUSTA MUUTTUJAT PIIRTÄMISTÄ VARTEN */
var korkeus = kartta.length;
var leveys = kartta[0].length;
var KOKO = 25;
var LEVEYS = leveys * KOKO;
var KORKEUS = korkeus * KOKO;
var sisalto;
var pelaaja;
var gameOn = true;

var pelialue = document.createElement("canvas");
pelialue.width = LEVEYS;
pelialue.height = KORKEUS;
sisalto = pelialue.getContext("2d");
document.getElementById("peli").appendChild(pelialue);

pelaaja = {
    y: 0,
    x: 0
};

vastustaja = {
    y: 0,
    x: 0
};

document.addEventListener("keydown", alaspainallus, false);

function alaspainallus(e) {
    if (gameOn) {
        if (e.key == "Right" || e.key == "ArrowRight" || e.key == "D" || e.key == "d") {
            yritaLiikkuaVasemmalle();
            gameOver();
            liikutaVastustajaa();
            piirra();
        } else if (e.key == "Left" || e.key == "ArrowLeft" || e.key == "A" || e.key == "a") {
            yritaLiikkuaOikealle();
            gameOver();
            liikutaVastustajaa();
            piirra();
        } else if (e.key == "Up" || e.key == "ArrowUp" || e.key == "W" || e.key == "w") {
            yritaLiikkuaAlas();
            gameOver();
            liikutaVastustajaa();
            piirra();
        } else if (e.key == "Down" || e.key == "ArrowDown" || e.key == "S" || e.key == "s") {
            yritaLiikkuaYlos();
            gameOver();
            liikutaVastustajaa();
            piirra();
        }
        gameOver();
        gameWon();
    }
}

function gameOver() {
    if (pelaaja.x == vastustaja.x && pelaaja.y == vastustaja.y) {
        window.location.reload(false);
    }
}

function gameWon() {
    if (kartta[pelaaja.y][pelaaja.x] == 'M') {
        gameOn = false;
        var submit = document.createElement("form");
        var input = document.createElement("input");
        submit.action = "labyrintti";
        submit.method = "POST";
        input.type = "submit";
        input.value = "Siirry seuraavaan";
        document.getElementById("otsikko").textContent = "Voitit";
        submit.appendChild(input);
        document.getElementById("maali").appendChild(submit);
    }
}

function yritaLiikkuaYlos() {
    if (pelaaja.y <= 0) return;
    if (kartta[pelaaja.y - 1][pelaaja.x] == 1) return;
    pelaaja.y -= 1;
}

function yritaLiikkuaAlas() {
    if (pelaaja.y >= korkeus - 1) return;
    if (kartta[pelaaja.y + 1][pelaaja.x] == 1) return;
    pelaaja.y += 1;
}

function yritaLiikkuaVasemmalle() {
    if (pelaaja.x <= 0) return;
    if (kartta[pelaaja.y][pelaaja.x - 1] == 1) return;
    pelaaja.x -= 1;
}

function yritaLiikkuaOikealle() {
    if (pelaaja.x >= leveys - 1) return;
    if (kartta[pelaaja.y][pelaaja.x + 1] == 1) return;
    pelaaja.x += 1;
}

function main() {
    etsiPelaajaJaVastustaja();
    piirra();
}

function etsiPelaajaJaVastustaja() {
    for (var i = 0; i < korkeus; i++) {
        for (var j = 0; j < leveys; j++) {
            if (kartta[i][j] == 'O') {
                pelaaja.y = i;
                pelaaja.x = j;
            } else if (kartta[i][j] == 'H') {
                vastustaja.y = i;
                vastustaja.x = j;
            }
        }
    }
}
/* ASTAR */
function teeLista() {
    var lista = [];
    for (var i = 0; i < korkeus; i++) {
        for (var j = 0; j < leveys; j++) {
            var solmu;
            if (kartta[i][j] == 1) {
                continue;
            } else if (i == pelaaja.y && j == pelaaja.x) { // loppu, maali
                solmu = {
                    rivi: i,
                    sarake: j,
                    alkuun: 9999,
                    loppuun: 0,
                    edellinen: null
                };
            } else if (i == vastustaja.y && j == vastustaja.x) { // alku, lähtö
                solmu = {
                    rivi: i,
                    sarake: j,
                    alkuun: 0,
                    loppuun: 0,
                    edellinen: null
                };
                solmu.loppuun = matkaLoppuun(solmu);
            } else { // tyhjä
                solmu = {
                    rivi: i,
                    sarake: j,
                    alkuun: 9999,
                    loppuun: 0,
                    edellinen: null
                };
                solmu.loppuun = matkaLoppuun(solmu);
            }
            lista.push(solmu);
        }
    }
    lista.sort((a, b) => (a.alkuun + a.loppuun > b.alkuun + b.loppuun) ? 1 : -1);
    return lista;
}

function etsiReitti(lista) {
    var u;
    while (true) {
        lista.sort((a, b) => (a.alkuun + a.loppuun > b.alkuun + b.loppuun) ? 1 : -1);
        u = lista[0];
        lista.shift();

        var naapurit = etsiNaapuri(lista, u);
        for (var i = 0; i < naapurit.length; i++) {
            var naapuri = naapurit[i];
            if (naapuri.alkuun > u.alkuun + 1) {
                naapuri.alkuun = u.alkuun + 1;
                naapuri.edellinen = u;
            }
        }
        if (u.rivi == pelaaja.y && u.sarake == pelaaja.x) {
            break;
        }
    }
    return u;
}

function etsiNaapuri(lista, solmu) {
    var naapurit = [];
    for (var i = 0; i < lista.length; i++) {
        ehdokas = lista[i];
        if (ehdokas.rivi == solmu.rivi && ehdokas.sarake == solmu.sarake) {
            continue;
        }
        if (ehdokas.rivi == solmu.rivi - 1 && ehdokas.sarake == solmu.sarake) { // yläpuolella
            naapurit.push(ehdokas);
        } else if (ehdokas.rivi == solmu.rivi + 1 && ehdokas.sarake == solmu.sarake) { // alapuolella
            naapurit.push(ehdokas);
        } else if (ehdokas.rivi == solmu.rivi && ehdokas.sarake == solmu.sarake - 1) { // vasemmalla
            naapurit.push(ehdokas);
        } else if (ehdokas.rivi == solmu.rivi && ehdokas.sarake == solmu.sarake + 1) {
            naapurit.push(ehdokas);
        }
    }
    return naapurit;
}

function matkaLoppuun(solmu) {
    return Math.abs(solmu.rivi - pelaaja.y) + Math.abs(solmu.sarake - pelaaja.x);
}

// mihin vastustaja liikkuu
function seuraavaSiirto(solmu) {
    while (true) {
        edellinen = solmu.edellinen;
        if (edellinen.rivi == vastustaja.y && edellinen.sarake == vastustaja.x) {
            return solmu;
        }
        solmu = edellinen;
    }
}

function liikutaVastustajaa() {
    var lista = teeLista();
    var maali = etsiReitti(lista);
    var seuraavaRuutu = seuraavaSiirto(maali);
    vastustaja.x = seuraavaRuutu.sarake;
    vastustaja.y = seuraavaRuutu.rivi;
}

function piirra() {
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
            } else if (i == vastustaja.y && j == vastustaja.x) {
                sisalto.beginPath();
                sisalto.rect(j * KOKO, i * KOKO, KOKO, KOKO);
                sisalto.fillStyle = "#45f5e6";
                sisalto.fill();
            }
            else if (kartta[i][j] == "M") {
                sisalto.beginPath();
                sisalto.rect(j * KOKO, i * KOKO, KOKO, KOKO);
                sisalto.fillStyle = "#45f588";
                sisalto.fill();
            }
        }
    }
}
main();
//setInterval(draw, 10);


