(function () {

        function readWord(evt) {
        //Retrive the first (and only!) File from the FileList object
        var f = evt.target.files[0];

        var r = new FileReader();

        r.onload = function (e) {
            var fullText = r.result;
            //console.log(r.result);
            fullText = fullText.replace(/[^a-zA-Z0-9]/g, " ");

            var str = fullText.split(" ");
            //console.log(str[0]);
            //console.log(str.length);

            var longest = 0;
            var word = null;

            for (var i = 0; i < str.length; i++) {

                if (longest < str[i].length) {
                    longest = str[i].length;
                    word = str[i];
                }


            }
            //document.getElement return (word);
            document.getElementById('outputLongest').value =word;

        }



        r.readAsText(f);
    }

        document.getElementById('inputLongest').addEventListener('change', readWord, false);
        



    $('#runLongest').click(function (e) {
        $('#outputLongest').val(readWord($().val()))
    })
})();