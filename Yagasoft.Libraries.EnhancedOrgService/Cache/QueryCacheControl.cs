﻿#region Imports

using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Query;
using Yagasoft.Libraries.Common;

#endregion

namespace Yagasoft.Libraries.EnhancedOrgService.Cache
{
	internal class QueryCacheControl
	{
		private readonly Dictionary<string, string> queryCache = new Dictionary<string, string>();

		public void AddCachedQuery(QueryBase query, QueryExpression queryExpression)
		{
			var serialisedQuery = SerialiserHelpers.SerialiseStrictXml(query);
			queryCache[serialisedQuery] = SerialiserHelpers.SerialiseStrictXml(queryExpression);
		}

		public QueryExpression GetCachedQuery(QueryBase query)
		{
			var serialisedQuery = SerialiserHelpers.SerialiseStrictXml(query);
			queryCache.TryGetValue(serialisedQuery, out var queryExpression);
			return queryExpression == null ? null : SerialiserHelpers.DeserialiseStrictXml<QueryExpression>(queryExpression);
		}

		public void ClearCache()
		{
			queryCache.Clear();
		}
	}
}
