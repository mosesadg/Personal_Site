(function () {

    
    function happy_cal(n) {
        var past = [];
        while (n = [].reduce.call(n.toString(), function (a, n) { return a + n * n }, 0)) {
            if (n === 1)
                return 1;
            else if (past.indexOf(n) >= 0)
                return 0;
            else past.push(n);
        }

    }
    function happy() {
        var maxRange = document.getElementById("inputhappy").value;
        var n = parseInt(maxRange);
        var display_i = [];
        for (var i = 0; i <= n; ++i) {
            if (happy_cal(i)) {
                var istring = i.toString();
                display_i.push(istring + " ");
            }
            else continue;
        }
        return (display_i);
        //document.getElementByID('outputhappy').value = "test";
    }
    

       
    $('#runhappy').click(function (e) {
        $('#outputhappy').val(happy($('#inputhappy').val()))
    })
})();