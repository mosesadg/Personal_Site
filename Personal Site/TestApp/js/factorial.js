(function () {
    
    function factorial(n) {
        return Number(n) == Number.NaN || n < 1 ? "Invalid Input" : n > 2 ? n * factorial(n - 1) : n;
    }

    // (boolean expression) ? value if true : value if false


    $('#runFactorial').click(function (e) {
        $('#outputFactorial').val(factorial( $('#inputFactorial').val() ))
        })
})();