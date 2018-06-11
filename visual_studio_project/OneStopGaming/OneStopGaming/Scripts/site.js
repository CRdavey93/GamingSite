$(document).ready(function () {
    $("#zipsubmit").on("click", function() {
        var data = {
            zip: $("#zipcode").val()
        };
        $.ajax(
        {

            // The URL for the request
            url: "/Home/UpdateZip",
            // The data to send (will be converted to a query string)
            data: data,
            // Whether this is a POST or GET request
            type: "POST",

            // Code to run if the request succeeds;
            // the response is passed to the function
            success: function(json) {
                $("#zipcode").attr("placeholder", "Zip: " + $("#zipcode").val());
                $("#zipcode").val("");
            },
            // Code to run if the request fails; the raw request and
            // status codes are passed to the function
            error: function(xhr, status, errorThrown) {
                console.log("Sorry, there was a problem!");
                console.log("Error: " + errorThrown);
                console.log("Status: " + status);
                console.dir(xhr);
            },
            // Code to run regardless of success or failure
            complete: function(xhr, status) {
                console.log("The request is complete!");
            }
        });
    });

    $("#addToCart").on("click", function () {

        var data2 = {
            productIdS: $("#featuredProductId").text()
        };

        console.log(data2);
        $.ajax(
        {

            // The URL for the request
            url: "/Cart/AddToCart",
            // The data to send (will be converted to a query string)
            data: data2,
            // Whether this is a POST or GET request
            type: "POST",

            // Code to run if the request succeeds;
            // the response is passed to the function
            success: function (json) {
                window.location.href = "/Cart/"
            },
            // Code to run if the request fails; the raw request and
            // status codes are passed to the function
            error: function (xhr, status, errorThrown) {
                console.log("Sorry, there was a problem!");
                console.log("Error: " + errorThrown);
                console.log("Status: " + status);
                console.dir(xhr);
            },
            // Code to run regardless of success or failure
            complete: function (xhr, status) {
                console.log("The request is complete!");
                
            }
        });
    });

    $("#updateCart").on("click", function () {

        var data3 = {
            quantityS: $("#quantity").val(),
            productIdS: $("#cartProductId").text()
        };

        $.ajax(
        {

            // The URL for the request
            url: "/Cart/UpdateCart",
            // The data to send (will be converted to a query string)
            data: data3,
            // Whether this is a POST or GET request
            type: "POST",

            // Code to run if the request succeeds;
            // the response is passed to the function
            success: function (json) {
                window.location.href = "/Cart/"
            },
            // Code to run if the request fails; the raw request and
            // status codes are passed to the function
            error: function (xhr, status, errorThrown) {
                console.log("Sorry, there was a problem!");
                console.log("Error: " + errorThrown);
                console.log("Status: " + status);
                console.dir(xhr);
            },
            // Code to run regardless of success or failure
            complete: function (xhr, status) {
                console.log("The request is complete!");

            }
        });
    });

    $("#removeCart").on("click", function () {

        var data4 = {
            quantityS: "0",
            productIdS: $("#cartProductId").text()
        };

        $.ajax(
        {

            // The URL for the request
            url: "/Cart/UpdateCart",
            // The data to send (will be converted to a query string)
            data: data4,
            // Whether this is a POST or GET request
            type: "POST",

            // Code to run if the request succeeds;
            // the response is passed to the function
            success: function (json) {
                window.location.href = "/Cart/"
            },
            // Code to run if the request fails; the raw request and
            // status codes are passed to the function
            error: function (xhr, status, errorThrown) {
                console.log("Sorry, there was a problem!");
                console.log("Error: " + errorThrown);
                console.log("Status: " + status);
                console.dir(xhr);
            },
            // Code to run regardless of success or failure
            complete: function (xhr, status) {
                console.log("The request is complete!");

            }
        });
    });
});