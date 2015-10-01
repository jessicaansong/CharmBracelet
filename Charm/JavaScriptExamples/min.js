function min() {
    var min1 = document.getElementById('min1').value;
    var min2 = document.getElementById('min2').value;
    var min3 = document.getElementById('min3').value;
    var min4 = document.getElementById('min4').value;
    var min5 = document.getElementById('min5').value;

    var minResult = Math.min(min1, min2, min3, min4, min5);

    var showNow = document.getElementById('minResult')

    showNow.innerHTML = "The mean is " + minResult;
}