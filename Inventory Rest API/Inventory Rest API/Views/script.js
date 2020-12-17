$(document).ready(function() {
    var catId;
    var loadCategories = function() {
        console.log(localStorage.user);
        var userDetails = localStorage.user;

        $.ajax({
            url: "http://localhost:9205/api/categories/",
            method: "GET",
            headers: {
                'Authorization': 'Basic ' + btoa(userDetails),
            },
            complete: function(xmlhttp, status) {
                // $("#par1").html(xmlhttp);
                // console.log(status);
                if (xmlhttp.status == 200) {
                    var data = xmlhttp.responseJSON;
                    // $("#msg").html(datvar], categoryName);
                    console.log(data[0]);

                    var str = '';
                    var strForSelect = "<option selected>--Select--</option>";
                    for (var i = 0; i < data.length; i++) {
                        str += "<tr><td>" + data[i].categoryId + "</td><td>" + data[i].categoryName + "</td></tr>";
                        strForSelect += "<option value=" + data[i].categoryId + ">" + data[i].categoryName + "</option>";
                    }

                    $("#categoryList tbody").html(str);
                    $("#updateCatList").html(strForSelect);
                } else {
                    $("#msg").html(xmlhttp.status + ":" + xmlhttp.statusText)
                }
            }
        })
    }

    loadCategories();

    var loadProducts = function() {
        $.ajax({
            url: "http://localhost:9205/api/products/",
            method: "GET",
            headers: {
                'Authorization': 'Basic ' + btoa("admin:123"),
            },
            complete: function(xmlhttp, status) {
                // $("#par1").html(xmlhttp);
                // console.log(status);
                if (xmlhttp.status == 200) {
                    var data = xmlhttp.responseJSON;
                    // $("#msg").html(datvar], categoryName);
                    console.log(data[0]);

                    var str = '';
                    for (var i = 0; i < data.length; i++) {
                        str += "<tr><td>" + data[i].productId + "</td><td>" + data[i].productName + "</td><td>" + data[i].price + "</td><td>" + data[i].category.categoryName + "</td></tr>";
                    }

                    $("#productList tbody").html(str);
                } else {
                    $("#msg").html(xmlhttp.status + ":" + xmlhttp.statusText)
                }
            }
        })
    }

    loadProducts();

    var addCategory = function() {
        $.ajax({
            url: "http://localhost:9205/api/categories/",
            method: "POST",
            headers: "Content-Type:application/json",
            data: {
                categoryName: $("#addCategoryName").val(),
            },
            complete: function(xmlhttp, status) {
                if (xmlhttp.status == 201) {
                    $("#msg").html("category Created");
                    loadCategories();
                    loadProducts();
                } else {
                    $("#msg").html(xmlhttp.state + ":" + xmlhttp.statusText);
                }
            }
        })
    }

    var updateCategory = function() {
        $.ajax({
            url: "http://localhost:9205/api/categories/" + catId,
            method: "PUT",
            headers: "Content-Type:application/json",
            data: {
                categoryName: $("#updateCategoryName").val(),
            },
            complete: function(xmlhttp, status) {
                if (xmlhttp.status == 200) {
                    $("#msg").html("category updated");
                    loadCategories();
                    loadProducts();
                } else {
                    $("#msg").html(xmlhttp.state + ":" + xmlhttp.statusText);
                }
            }
        })
    }

    $("#updatebtn").click(function() {
        updateCategory();
    });

    $("#addbtn").click(function() {
        addCategory();
    });

    $("#updateCatList").change(function() {
        $("#updateCategoryName").val($("#updateCatList option:selected").text());
        catId = $("#updateCatList option:selected").val();
    });

});