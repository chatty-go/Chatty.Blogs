using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Chatty.Blogs.Web.Models
{
    public class OutlineModel
    {
		[JsonPropertyName("id")]
        public string Id { get; set; } = null!;

		[JsonPropertyName("text")]
		public string Text { get; set; } = null!;

		[JsonPropertyName("level")]
		public int Level { get; set; }
    }
}
