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
            var string = fullText.split(" ");
            ////******************

            var freq = {};
            for (var i = 0; i < string.length; i++) {
                var character = string[i];
                if (freq[character]) {
                    freq[character]++;
                } else {
                    freq[character] = 1;
                }
            }

            keysSorted = Object.keys(freq).sort(function(a,b){return freq[a]-freq[b]});
           // alert(keysSorted[3]);
            //console.log(freq);
            var sorted=[];
            console.log(keysSorted.length);
            for (i = keysSorted.length - 1; i > 0; i--) {

                sorted.push(keysSorted[i]);
                //console.log(keysSorted[i]);
            }
            document.getElementById('outputwordfreq').value = sorted;


            //alert(freq.toSource());




            ///****************

        }



        r.readAsText(f);
    }

    document.getElementById('inputwordfreq').addEventListener('change', readSingleFile, false);




    $('#runreadSingleFile').click(function (e) {
        $('#outputwordfreq').val(readSingleFile($().val()))
    })
})();