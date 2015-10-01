function multiplyFive() {
    var m1 = document.getElementById('m1').value;
    var m2 = document.getElementById('m2').value;
    var m3 = document.getElementById('m3').value;
    var m4 = document.getElementById('m4').value;
    var m5 = document.getElementById('m5').value;

    var mResult = Number(m1) * Number(m2) * Number(m3) * Number(m4) * Number(m5);

    var onDisplay = document.getElementById('mResult');

    onDisplay.innerHTML = "The product is " + mResult;
}