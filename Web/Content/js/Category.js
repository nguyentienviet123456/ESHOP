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

                var seoname = toSeoUrl(xoa_dau(model[i].CategoryName));

                var contentUrl = currentLocation + "/danh-muc-san-pham/" + model[i].Id + "/" +seoname;

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

function xoa_dau(str) {
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ/g, "A");
    str = str.replace(/È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ/g, "E");
    str = str.replace(/Ì|Í|Ị|Ỉ|Ĩ/g, "I");
    str = str.replace(/Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ/g, "O");
    str = str.replace(/Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ/g, "U");
    str = str.replace(/Ỳ|Ý|Ỵ|Ỷ|Ỹ/g, "Y");
    str = str.replace(/Đ/g, "D");
    return str;
}

function toSeoUrl(url) {
    return url.toString()
        .normalize('NFD')
        .replace(/[\u0300-\u036f]/g, '')
        .replace(/\s+/g, '-')
        .toLowerCase()
        .replace(/&/g, '-and-')
        .replace(/[^a-z0-9\-]/g, '')
        .replace(/-+/g, '-')
        .replace(/^-*/, '')
        .replace(/-*$/, '');
}
