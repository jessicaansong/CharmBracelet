function mean() {
    var e1 = document.getElementById('e1').value;
    var e2 = document.getElementById('e2').value;
    var e3 = document.getElementById('e3').value;
    var e4 = document.getElementById('e4').value;
    var e5 = document.getElementById('e5').value;

    var eResult = Number(e1) + Number(e2) + Number(e3) + Number(e4) + Number(e5);

    var eResult2 = eResult / 5;

    var forShow = document.getElementById('eResult2');

    forShow.innerHTML = "The mean is " + eResult2;
}