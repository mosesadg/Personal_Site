
(function () {

    function armstrong() {
        
        

        displayarm = [];

        for (i = 100; i < 1000; i++) {

            
            var valuetest = i;
            var units = valuetest % 10;
            var value2 = parseInt(valuetest / 10);
            var tens = value2 % 10;
            var hundreds = parseInt(value2 / 10);

             if (valuetest === Math.pow(units, 3) + Math.pow(tens, 3) + Math.pow(hundreds, 3)) {

                displayarm.push(valuetest);
                               
            }

            
        }

        

        return (displayarm);
        //document.getElementById("outputarmstrong").value = displayarm;
        
        
    }


    


    $('#runarmstrong').click(function (e) {
        $('#outputarmstrong').val(armstrong($().val()))
    })
})();