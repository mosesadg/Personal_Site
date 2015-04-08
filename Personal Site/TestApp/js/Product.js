(function () {


    function prodFun(sumString) {
        
        var sumArray = sumString.split(" ").map(Number);
        totalprod = 1;
        for (var i = 0; i < sumArray.length; i++) {
            totalprod *= sumArray[i];
        }
        return totalprod;
        
    }



    $('#runprodFun').click(function (e) {
        $('#outputprod').val(prodFun($('#inputprod').val()))
    })
})();