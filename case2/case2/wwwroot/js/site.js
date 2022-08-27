// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$(document).ready(function () {
    var wordsArray = [];
    setInterval(function () {
        $.get("http://localhost:57501/words").then(function (result) {
            $(jQuery("#values")[0]).empty();
            console.log(result, "result")
            wordsArray = result;
            result.forEach(x => {
                $(jQuery("#values")[0]).append("<tr><td>" + x.id +"</td><td>" + x.text + "</td></tr>")
            })
            
        })
    

    }, 3000)
    $("#searchButton").click(function () {
         $(jQuery("#values")[0]).empty();
        var r=wordsArray.filter(x => x.text.indexOf($("#filter").val())!=-1);
            r.forEach(x => {
                $(jQuery("#values")[0]).append("<tr><td>" + x.id +"</td><td>" + x.text + "</td></tr>")
            })
    });

    $("#SortByNameAsc").click(function () {
        $(jQuery("#values")[0]).empty();
        var r = wordsArray.sort(function (a, b) {
            if (a.text > b.text)
                return 1;

            else if (a.text < b.text)
                return -1;
            else return 0
        });
        r.forEach(x => {
            $(jQuery("#values")[0]).append("<tr><td>" + x.id +"</td><td>" + x.text + "</td></tr>")
        })
    });

    $("#SortByNameDesc").click(function () {
        $(jQuery("#values")[0]).empty();
        var r = wordsArray.sort(function (a, b) {
            if (a.text < b.text)
                return 1;

            else if (a.text > b.text)
                return -1;
            else return 0
        });
        r.forEach(x => {
            $(jQuery("#values")[0]).append("<tr><td>"+x.id+"</td>  <td>" + x.text + "</td></tr>")
        })
    });

    $("#SortByIdAsc").click(function () {
        $(jQuery("#values")[0]).empty();
        var r = wordsArray.sort(function (a, b) {
            if (a.id > b.id)
                return 1;

            else if (a.id < b.id)
                return -1;
            else return 0
        });
        r.forEach(x => {
            $(jQuery("#values")[0]).append("<tr><td>" + x.id +"</td>><td>" + x.text + "</td></tr>")
        })
    });


    $("#SortByIdDesc").click(function () {
        $(jQuery("#values")[0]).empty();
        var r = wordsArray.sort(function (a, b) {
            if (a.id < b.id)
                return 1;

            else if (a.id > b.id)
                return -1;
            else return 0
        });
        r.forEach(x => {
            $(jQuery("#values")[0]).append("<tr><td>" + x.id +"</td><td>" + x.text + "</td></tr>")
        })
    });

})
