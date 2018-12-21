using System;
using System.Web;

namespace Web.Models
{
    public class PagingSeo
    {
        public string PaginationSeo(int total, int page, int Take, int offset, string controller, string View, string Params, string seoName)
        {
            if (total > 0)
            {
                string c_url = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
                string URL = c_url.Substring(0, c_url.IndexOf(controller.ToLower(), StringComparison.Ordinal));
                //string URL = HttpContext.Current.Request.Url.Authority + "/";
                double rowPerPage = Take;
                if (Convert.ToDouble(total) < Take)
                {
                    rowPerPage = Convert.ToDouble(total);
                }

                int totalPage = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(total) / rowPerPage));
                int current = page;
                int record = offset;
                int pageStart = Convert.ToInt16(Convert.ToDouble(current) - Convert.ToDouble(offset));
                int pageEnd = Convert.ToInt16(Convert.ToDouble(current) + Convert.ToDouble(offset));
                string numPage = "";
                if (totalPage < 1) return "";
                numPage += "<ul class='pagination'>";
                seoName = "/" + seoName;
                if (current > 1) numPage += "<li class='previous page-item'><a class='page-link' href='" + URL + controller + Params + seoName + "?Page=" + (page - 1) + "' aria-label='Previous'>&laquo;</a></li>";
                else numPage += "<li class='disabled page-item'><a class='page-link'  href='#' aria-label='Previous'><span aria-hidden='true'>&laquo;</span></a></li>";
                if (current > (offset + 1)) numPage += "<li class='page-item'><a class='page-link'  href='" + URL + controller + Params + seoName + "?Page=1" + "' name='page1'>1</a></li><li class='disabled spacing-dot page-item'><a class='page-link'  href='#'>...</a></li>";
                for (int i = 1; i <= totalPage; i++)
                {
                    if (pageStart <= i && pageEnd >= i)
                    {
                        if (i == current) numPage += "<li class='active page-item'><a class='page-link'  href='#'>" + i + " <span class='sr-only'>(current)</span></a></li>";
                        else numPage += "<li class='page-item'><a class='page-link'  href='" + URL + controller + Params + seoName + "?Page=" + i + "'>" + i + "</a></li>";
                    }
                }
                if (totalPage > pageEnd)
                {
                    record = offset;
                    numPage += "<li class='disabled spacing-dot page-item'><a class='page-link'  href='#'>...</a></li><li><a class='page-link'  href='" + URL + controller + Params + seoName + "?Page=" + (totalPage) + "'>" + totalPage + "</a></li>";
                }
                if (current < totalPage) numPage += "<li class='next class='page-item''><a class='page-link ui-bar-d' href='" + URL + controller + Params + seoName + "?Page=" + (page + 1) + "'>&raquo;</a></li>";
                else numPage += "<li class='disabled class='page-item''><a class='page-link'  href='#' aria-label='Previous'><span aria-hidden='true'>&raquo;</span></a></li>";
                numPage += "</ul>";
                return numPage;
            }
            else
            {
                return "no records found";
            }
        }
    }
}