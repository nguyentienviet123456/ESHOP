//var url = "@Html.Raw(Url.Action("GetAllCategory", "Category"))";
var url = "/News/GetLastestNews";
var content = "";
$.ajax({
    url: url,
    type: 'GET',
    success: function (response) {
        if (response.lastest) {
            var model = response.lastest;
            content = '<img class=\"card-img-top\" src=\"' + model.ImageUrl + '\" alt=\"Card image cap\">' + '<div class=\"card-body text-center\" style= \"padding: 0px\"> <h5 class=\"card-title\" style=\"margin-bottom: 0px\">' + model.Title + '</h5></div >';
            $('#card-custom').html(content);
        }
    },
    error: function (xhr, textStatus, errorThrown) {
        console.log('Error in Operation');
    }
});
