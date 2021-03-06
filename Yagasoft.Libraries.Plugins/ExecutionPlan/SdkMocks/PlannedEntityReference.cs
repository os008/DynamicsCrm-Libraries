﻿#region Imports

using System;
using System.Runtime.Serialization;
using Yagasoft.Libraries.EnhancedOrgService.ExecutionPlan.Base;
using Yagasoft.Libraries.EnhancedOrgService.ExecutionPlan.Planning;

#endregion

namespace Yagasoft.Libraries.EnhancedOrgService.ExecutionPlan.SdkMocks
{
	[DataContract]
	public class PlannedEntityReference : PlannedMapBase
	{
		[DataMember]
		public PlannedValue LogicalName { get; set; }

		[DataMember]
		public PlannedValue EntityRefId { get; set; }

		[DataMember]
		public PlannedValue EntityRefName { get; set; }

		public PlannedEntityReference(Guid? parentId, string alias) : base(parentId, alias)
		{
			InnerDictionary["LogicalName"] = LogicalName = new PlannedValue(Id, "LogicalName");
			InnerDictionary["Id"] = EntityRefId = new PlannedValue(Id, "Id");
			InnerDictionary["Name"] = EntityRefName = new PlannedValue(Id, "Name");
		}
	}
}
