using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Blogs.Entities.Blogs
{
	/// <summary>
	/// 站点访问记录
	/// </summary>
	[SugarTable("site_visit_record")]
	public class SiteVisitRecord:BaseEntity
	{
		[SugarColumn(ColumnName ="ip_address")]
		public string IpAddress { get; set; } = null!;


		[SugarColumn(ColumnName = "request_path")]
		public string RequestPath { get; set; } = null!;

		[SugarColumn(ColumnName = "request_query_string")]
		public string RequestQueryString { get; set; } = null!;

		[SugarColumn(ColumnName = "user_agent")]
		public string UserAgent { get; set; } = null!;

		[SugarColumn(ColumnName = "request_method")]
		public string RequestMethod { get; set; } = null!;
	}
}
