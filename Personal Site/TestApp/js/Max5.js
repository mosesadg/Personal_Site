(function () {

    function maxOfFive(n1,n2,n3,n4,n5) {
        return Math.max(n1, n2, n3, n4, n5);
    }

    


    $('#runMax5').click(function (e) {
        $('#outputMax5').val(maxOfFive($('#inputMaxval1').val(), $('#inputMaxval2').val(), $('#inputMaxval3').val(), $('#inputMaxval4').val(), $('#inputMaxval5').val()))
        })
})();