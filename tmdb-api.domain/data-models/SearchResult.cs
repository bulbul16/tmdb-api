using System;
using System.Collections.Generic;
using System.Text;

namespace tmdb_api.domain.data_models
{
	public class SearchResult
	{
		public int Id { get; set; }
		public int SearchId { get; set; }
		public string SearchResultJson { get; set; }

	}
}
