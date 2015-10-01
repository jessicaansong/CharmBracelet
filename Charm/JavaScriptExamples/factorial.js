function factorial() {
    var f = document.getElementById('f').value;
    for (i = 1; i < f; i--) {
    factResult *= i;
    }
    var displayNow = document.getElementById('factResult');

   displayNow.innerHTML = "The factorial is " + factResult;
}