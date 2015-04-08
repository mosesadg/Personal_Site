(function () {


    function sumFun(sumString) {

        var sumArray = sumString.split(" ").map(Number);
        totalSum = 0;
        for (var i = 0; i < sumArray.length; i++) {
            totalSum += sumArray[i];
        }
        return totalSum;
        
    }


    
    $('#runsumFun').click(function (e) {
        $('#outputsumFun').val(sumFun($('#inputsumFun').val()))
    })
})();