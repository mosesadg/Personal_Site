(function () {

    function readSingleFile(evt) {
        //Retrive the first (and only!) File from the FileList object
        var f = evt.target.files[0];

        var r = new FileReader();

        r.onload = function (e) {
            var fullText = r.result;
            //console.log(r.result);

            fullText = fullText.replace(/[^a-zA-Z0-9]/g, " ");
            fullText = fullText.toLowerCase();
            var str = fullText.split(" ");
            //console.log(str[0]);
            //console.log(str.length);
            var limit = prompt("Please enter word filer size");
            var longest = [];
            var word = null;

            for (var i = 0; i < str.length; i++) {

                if (str[i].length > limit) {

                    longest.push(str[i]);

                }

            }
            longest.sort();

            for (var j = 0; j < longest.length; j++) {
                if (longest[j] === longest[j + 1]) {
                    longest.splice(j + 1, 1);
                }
                //console.log(longest[j]);
                document.getElementById('outputfilterword').value = longest;
            }






        }



        r.readAsText(f);
    }

    document.getElementById('inputfilterword').addEventListener('change', readSingleFile, false);






    $('#runfilterword').click(function (e) {
        $('#outputfilterword').val(readSingleFile($('#inputfilterword').val()))
    })
})();