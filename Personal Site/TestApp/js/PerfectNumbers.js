(function () {


    function perfCal (n) {

       
        var myTotal = 0;

        for (i = 0; i < n; i++) {
            if (n % i == 0) {
                myTotal += i;

            }

        }

        if (myTotal == n) {
            return ("Perfect Number!");
        }
        else {
            return ("NOT a Perfect Number!");
        }



    };


    $('#runPerfectNumbers').click(function (e) {
        $('#outputPerfectNumbers').val(perfCal($('#inputPerfectNumbers').val()))
    })
})();