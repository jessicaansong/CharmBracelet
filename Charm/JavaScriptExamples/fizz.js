function fizzBuzz() {
    var fb1 = document.getElementById('fb1').value;
    var fb2 = document.getElementById('fb2').value;
    var statement;
    var result = document.getElementById('result');

    if (fb1 < 1 || fb1 >= 101 || fb2 < 1 || fb2 >= 101)
         statement = "Please enter values between 1 and 100.";

    else {
        for (n = 1; n <= 100; n++)
            if (n % fb1 * fb2)
                var onMonitor = FizzBuzz;
            else
            {
                result = " ";
            }


    }

    var onMonitor = document.getElementById('statement');


    onMonitor.innerHTML = statement;
 
}