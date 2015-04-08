(function () {

    function readSingleFile(evt) {
        //Retrive the first (and only!) File from the FileList object
        var f = evt.target.files[0];

        var r = new FileReader();

        r.onload = function (e) {
            var fullText = r.result;
            //console.log(r.result);

            fullText = fullText.replace(/[^a-zA-Z0-9]/g, " ");

            var str = fullText.split(" ");

            console.log(str);
            //console.log(str.length);


            var longest = 0;

            var totalSum = 0;
            var checkWord = "Alice";

            console.log("Total words in the text file " + str.length);

            for (var i = 0; i < str.length; i++) {

                if (str[i] === checkWord) {
                    totalSum++;
                }


            }



            // console.log("Alice appeared " + totalSum + " times");
            
            document.getElementById('outputFindWord').value =totalSum;



        }



        r.readAsText(f);
    }
    document.getElementById('inputFindWord').addEventListener('change', readSingleFile, false);




    $('#runreadSingleFile').click(function (e) {
        $('#outputFindWord').val(readSingleFile($('#inputFindWord').val()))
    })
})();