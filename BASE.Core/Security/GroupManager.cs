using System;
using System.Collections.Generic;
using System.Text;

using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.HelperClasses;
using BASE.Data.LLDAL.DatabaseSpecific;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace BASE.Security
{
	public static class GroupManager
	{
		public static List<int> GetGroupMembershipAsUIDList(int userUID)
		{
			List<int> groups = new List<int>();
			//Get List of all Groups for user
			EntityCollection<GroupMembershipListEntity> groupMemb = new EntityCollection<GroupMembershipListEntity>();
			UserEntity user = new UserEntity(userUID);
			DataAccessAdapter da = new DataAccessAdapter();
			da.FetchEntityCollection(groupMemb, user.GetRelationInfoGroupMembershipListCollection());
			foreach(GroupMembershipListEntity group in groupMemb)
				groups.Add(group.GroupUID);

			return groups;

		}
	}
}
