function getNumber() {
    var f = document.getElementById('f').value; //The user's input
    var factResult = factorial(f); //Trigger the factorial function, passing the user's input as a parameter
    var toDisplay = document.getElementById('factResult');
    toDisplay.innerHTML = "The factorial is " + factResult;
}

function factorial(f) { //Pass the user's number in the function 
    var factResult = 1;
    for (var i = 1; i <= f; i++)
        factResult *= i;
    return factResult;
}

