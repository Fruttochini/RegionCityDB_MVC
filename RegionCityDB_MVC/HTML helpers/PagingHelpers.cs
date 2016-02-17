using RegionCityDB_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RegionCityDB_MVC.HTML_helpers
{
	public static class PagingHelpers
	{
		public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
		{
			Boolean prPrev = true, prNext = true;
			StringBuilder result = new StringBuilder();
			result.Append("<ul class=\"pagination\">");
			for (int i = 1; i <= pagingInfo.TotalPages; i++)
			{
				if (i == 1 || i == 2 || i == pagingInfo.TotalPages - 1 || i == pagingInfo.TotalPages
					|| i == pagingInfo.CurrentPage - 1 || i == pagingInfo.CurrentPage || i == pagingInfo.CurrentPage + 1)
				{

					if (i == pagingInfo.CurrentPage) result.Append("<li class=\"active\">");
					else result.Append("<li>");
					TagBuilder tag = new TagBuilder("a"); // Создание дескриптора <a>
					tag.MergeAttribute("href", pageUrl(i));
					tag.AddCssClass("paging");
					tag.InnerHtml = i.ToString();
					result.Append(tag.ToString());
					result.Append("</li>");
				}
				else
				{
					if ((i < pagingInfo.CurrentPage - 1) && prPrev)
					{
						CreateDescr(result);
						prPrev = false;
					}
					if ((i > pagingInfo.CurrentPage + 1) && prNext)
					{
						CreateDescr(result);
						prNext = false;
					}
				}
			}
			result.Append("</ul>");
			return MvcHtmlString.Create(result.ToString());


		}

		private static void CreateDescr(StringBuilder result)
		{
			result.Append("<li>");
			TagBuilder tag = new TagBuilder("a"); // Создание дескриптора <a>
			tag.MergeAttribute("href", "#");
			tag.AddCssClass("paging");
			tag.InnerHtml = "...";
			result.Append(tag.ToString());
			result.Append("</li>");
		}

	}

}