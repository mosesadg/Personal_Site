(function () {

    function fizzbuzz() {

                  
        var display_fizz = [];

        for(i = 0; i < 100; i++) {
            if (i % 3===0 && i % 5===0){	
	
                display_fizz.push("fizzbuzz");

                //document.write("fizzbuzz");
                
            }
	
            else if (i % 3 === 0) {
                display_fizz.push("FIZZ");
               //document.write("FIZZ");
            }
            else if (i % 5 === 0) {
                display_fizz.push("BUZZ");
              //document.write("BUZZ");
            }
            else {
                display_fizz.push(i);
              //document.write(i);
            }
        }

        document.getElementById('outputfizzbuzz').value = display_fizz;
               }

    

    $('#runfizzbuzz').click(function (e) {
        $('#disFizz').val(fizzbuzz($().val()))
    })
})();