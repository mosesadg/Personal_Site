
(function () {

    function palFun(myText) {
	
        var z = myText.length-1;
        
        for(var i= 0; i <= myText.length ; i++){

            if(myText[i] !== myText[z-i]){
             return ("Not a Palindrmome!");

            }
        }

        return ("A Palindrome"); 
	
    }


    $('#runPalindrome').click(function (e) {
        $('#outputPalindrome').val(palFun($('#inputPalindrome').val()))
    })
})();