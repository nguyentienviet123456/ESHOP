//var url = "@Html.Raw(Url.Action("GetAllCategory", "Category"))";
var url = "/Category/GetAllCategory";
var contentNavbar = "";
var contentSidebar = "";
var currentLocation = window.location.origin;
$.ajax({
    url: url,
    type: 'GET',
    success: function (response) {
        if (response.categories) {
            var model = response.categories;
            for (i = 0; i < model.length; i++) {

                var contentUrl = currentLocation+ "/danh-muc-san-pham?id=" + model[i].Id;

                contentNavbar += '<a class=\"dropdown-item\" href=\"' + contentUrl + '\">' + model[i].CategoryName + '</a>';

                contentSidebar += '<li class=\"list-group-item\" style=\"border-left-width: 0px; border-right-width: 0px\"><a class=\"text-info font-weight-bold\"  href= \"' + contentUrl + '\" >'+ model[i].CategoryName +'</a></li >';
            }
            $('#dropdown-menu').html(contentNavbar);
            $('#sidebar-dropdown-category').html(contentSidebar);
            $('#sidebar-dropdown-category-web').html(contentSidebar);
        }
    },
    error: function (xhr, textStatus, errorThrown) {
    console.log('Error in Operation');
}
});
