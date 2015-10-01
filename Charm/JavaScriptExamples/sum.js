function sumOfFive() {
    var num1 = document.getElementById('num1').value;
    var num2 = document.getElementById('num2').value;
    var num3 = document.getElementById('num3').value;
    var num4 = document.getElementById('num4').value;
    var num5 = document.getElementById('num5').value;
    
    var sumResult = Number(num1) + Number(num2) + Number(num3) + Number(num4) + Number(num5);
  
    var onScreen = document.getElementById('sumResult');

    onScreen.innerHTML = "The sum is " + sumResult;
}