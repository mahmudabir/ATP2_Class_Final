$(document).ready(function () {

    var loadLogout = function () {
        $.ajax({
            url: "http://localhost:9205/api/categories/logout",
            method: "GET",
            headers: {
                'Authorization': 'Basic ' + btoa(localStorage.user),
            },
            success: function (data, status, jqXhr) {

            },
            error: function (jqXhr, textStatus, errorMessage) {

            },
            complete: function (xmlhttp, status) {
                if (xmlhttp.status == 200) {
                    console.log("Logout Success");
                    localStorage.clear();
                    console.log(localStorage.user);
                } else {
                    $("#msg").html(xmlhttp.status + ":" + xmlhttp.statusText)
                }
            }
        })
    }


    var loadLogin = function () {
        var username = $("#username").val();
        var password = $("#password").val();
        var userDetails = username + ":" + password;
        localStorage.user = userDetails;
        console.log(localStorage.user);

        $.ajax({
            url: "http://localhost:9205/api/categories/login",
            method: "GET",
            headers: {
                'Authorization': 'Basic ' + btoa(localStorage.user),
            },
            success: function (data, status, jqXhr) {

            },
            error: function (jqXhr, textStatus, errorMessage) {

            },
            complete: function (xmlhttp, status) {
                if (xmlhttp.status == 200) {
                    var data = xmlhttp.responseJSON;
                    console.log("Login Success");
                    window.location.href = "Index.html";
                } else {
                    $("#msg").html(xmlhttp.status + ":" + xmlhttp.statusText)
                }
            }
        })
    }

    var searchProduct = function () {
        $.ajax({
            url: "http://localhost:9205/api/categories/" + $("#pID").val(),
            method: "GET",
            success: function (data, status, jqXhr) {

            },
            error: function (jqXhr, textStatus, errorMessage) {

            },
            complete: function (xmlhttp, status) {
                if (xmlhttp.status == 200) {
                    var data = xmlhttp.responseJSON;
                    console.log(data[0]);

                    var str = '';
                    str += "<tr><td>" + data.categoryId + "</td><td>" + data.categoryName + "</td>< /tr>";

                    $("#productList tbody").html(str);
                } else {
                    $("#msg").html(xmlhttp.status + ":" + xmlhttp.statusText)
                }
            }
        })
    }

    $("#btnSearch").click(function () {
        searchProduct();
    });

    $("#btnlogin").click(function () {
        loadLogin();
    });

    $("#btnlogout").click(function () {
        loadLogout();
    });

});