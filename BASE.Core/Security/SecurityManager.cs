using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using SD.LLBLGen.Pro.ORMSupportClasses;

using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.DatabaseSpecific;
using BASE.Data.LLDAL.HelperClasses;
using BASE.Data.LLDAL;
using BASE.Data;
using BASE.Modules;
using BASE.Entities;

namespace BASE.Security
{
	public static class SecurityManager
	{

		#region Entity Record Permissions
		public static EntityCollection<UserRecordPermissionEntity> GetUserEntityTypePermissions(int userUID, int entityTypeGUID, int uID)
		{

			//User Entity Type 2
			EntityCollection<UserRecordPermissionEntity> l_coll = new EntityCollection<UserRecordPermissionEntity>();

			//Create filter for GUID's
			IPredicateExpression l_filter = new PredicateExpression();
			l_filter.Add(UserRecordPermissionFields.RecordUID == uID);
			l_filter.AddWithAnd(UserRecordPermissionFields.EntityTypeGUID == entityTypeGUID);
			l_filter.AddWithAnd(UserRecordPermissionFields.UserUID == userUID);
			//Add to a bucket
			RelationPredicateBucket l_bucket = new RelationPredicateBucket(l_filter);
			//Retreive data
			DataAccessAdapter l_daa = new DataAccessAdapter();
			l_daa.FetchEntityCollection(l_coll, l_bucket);


			return l_coll;
		}

		public static EntityCollection<GroupRecordPermissionEntity> GetGroupPermissions(int groupUID, int entityTypeGUID, int uID)
		{
			//User Entity Type 2
			EntityCollection<GroupRecordPermissionEntity> l_coll = new EntityCollection<GroupRecordPermissionEntity>();

			//Create filter for GUID's
			IPredicateExpression l_filter = new PredicateExpression();
			l_filter.Add(GroupRecordPermissionFields.RecordUID == uID);
			l_filter.AddWithAnd(GroupRecordPermissionFields.EntityTypeGUID == entityTypeGUID);
			l_filter.AddWithAnd(GroupRecordPermissionFields.GroupUID == groupUID);
			//Add to a bucket
			RelationPredicateBucket l_bucket = new RelationPredicateBucket(l_filter);
			//Retreive data
			DataAccessAdapter l_daa = new DataAccessAdapter();
			l_daa.FetchEntityCollection(l_coll, l_bucket);


			return l_coll;
		}
		#endregion

		public static DataTable GetUserEntityTypePermissions(int userUID)
		{
			DataTable perms = RetrievalProcedures.SelectUserEntityTypePermissions(userUID);
			return perms;
		}

		public static DataTable GetUserEntityTypePermissions(int userUID, Guid entityTypeGUID)
		{
			DataTable perms = RetrievalProcedures.SelectUserEntityTypePermissions(userUID);
			return perms;
		}

		public static bool GetUserEntityTypePermission(int userUID, Guid entityTypeGUID, string actionCode)
		{
			return false;
		}

		public static DataTable GetGroupEntityTypePermissions(int groupUID)
		{
			DataTable perms = RetrievalProcedures.SelectGroupEntityTypePermissions(groupUID);
			return perms;
		}

		public static DataTable GetGroupEntityTypePermissions(int groupUID, Guid entityTypeGUID)
		{
			DataTable perms = RetrievalProcedures.SelectGroupEntityTypePermissions(groupUID);
			return perms;	
		}

		public static bool GetGroupEntityTypePermission(int groupUID, Guid entityTypeGUID, string actionCode)
		{
			return false;
		}



		/// <summary>
		/// All encompassing function that returns true if the user has Allow bit set for the given record for the given action
		/// </summary>
		/// <param name="userID"></param>
		/// <param name="entityTypeUID"></param>
		/// <param name="entityUID"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public static bool AllowAction(int userUID, Guid entityTypeGUID, int recordUID, string action)
		{
			//get groups user is int.
			//TODO: Change to use light weight group table retreival functions.
			EntityCollection<GroupEntity> groups = GetGroups(userUID);

			//check record permission tables for deny/allow

			//if deny in anything, return false
			//if allow keep that in a local var

			//check entity records for deny allow


			//if deny in anything, return false
			//if allow keep that in a local var

			//if now allow set, return false;
			// if any allow found, return true
#if DEBUG
			//TODO: CHange from DEBUG to something like ALLOWALL (Allow Any And All Access)!
			return true;
#else
			//TODO: CHange to proper logic for non debug
			return false;
#endif
		}



		public static EntityCollection<GroupEntity> GetGroups(UserEntity user)
		{
			//TODO: Create light weight group retreival queries for getting JUST the groupUID and name
			EntityCollection<GroupEntity> l_coll = new EntityCollection<GroupEntity>();
			DataAccessAdapter da = new DataAccessAdapter();
			da.FetchEntityCollection(l_coll, user.GetRelationInfoGroupCollection());
			return l_coll;
		}

		public static EntityCollection<GroupEntity> GetGroups(int userUID)
		{
			UserEntity user = new UserEntity(userUID);
			return GetGroups(user);

		}

		public static Dictionary<Guid, Dictionary<string, bool>> GetEffectiveEntityTypePermissions(int userUID, List<int> groupUIDList)
		{
			//Create initial dictionary
			Dictionary<Guid, Dictionary<string, bool>> effPerms = new Dictionary<Guid, Dictionary<string, bool>>();

			//Get List of all entityTypes.
			List<EntityDefinition> entityTypes = new List<EntityDefinition>();

			//Get Datatable of entitytype permissions for user
			DataTable userPerms = RetrievalProcedures.SelectUserEntityTypePermissions(userUID);

			//Iterate through list of entity Types
			foreach (EntityDefinition eType in entityTypes)
			{
				DataView eTypeRows = new DataView(userPerms);
				eTypeRows.RowFilter = "EntityTypeGUID = '" + eType.Guid + "'";

				//If no prmissions for the EntityType, ignore and continue
				//if(eTypeRows.Count == 0)
				//    continue;
				//CReate sub-keyvalue pair
				Dictionary<string, bool> ePerms = new Dictionary<string, bool>();

				assignAllowFromDataView(ePerms, eTypeRows);

				foreach (int uID in groupUIDList)
				{
					//Get Datatable of entitytype permissions for group gm
					DataTable groupPerms = RetrievalProcedures.SelectGroupEntityTypePermissions(uID);

					DataView eTypeGRows = new DataView(groupPerms);
					eTypeGRows.RowFilter = "EntityTypeGUID = '" + eType.Guid + "'";

					//If no prmissions for the EntityType, ignore and continue
					if (eTypeGRows.Count == 0)
						continue;

					assignAllowFromDataView(ePerms, eTypeGRows);
				}

				if(ePerms.Count > 0)
					effPerms.Add(eType.Guid, ePerms);

			}

			return effPerms;


		}

		public static Dictionary<Guid, Dictionary<string, bool>> GetEffectiveCustomPermissions(int userUID, List<int> groupUIDList)
		{
			//Create initial dictionary
			Dictionary<Guid, Dictionary<string, bool>> effPerms = new Dictionary<Guid, Dictionary<string, bool>>();

			//Get List of all entityTypes.
			EntityCollection<CustomPermissionTypeEntity> customPermissionTypes = new EntityCollection<CustomPermissionTypeEntity>();
			DataAccessAdapter da = new DataAccessAdapter(true);
			da.FetchEntityCollection(customPermissionTypes, null);

			da.CloseConnection();

			//Get Datatable of entitytype permissions for user
			DataTable userPerms = RetrievalProcedures.SelectUserCustomPermissions(userUID);

			//Iterate through list of entity Types
			foreach (CustomPermissionTypeEntity cpType in customPermissionTypes)
			{
				DataView cpTypeRows = new DataView(userPerms);
				cpTypeRows.RowFilter = "CPUID = '" + cpType.GUID + "'";

				//If no prmissions for the EntityType, ignore and continue
				//if(eTypeRows.Count == 0)
				//    continue;
				//CReate sub-keyvalue pair
				Dictionary<string, bool> cpPerms = new Dictionary<string, bool>();

				assignAllowFromDataView(cpPerms, cpTypeRows);

				foreach (int gUID in groupUIDList)
				{
					//Get Datatable of entitytype permissions for group gm
					DataTable groupPerms = RetrievalProcedures.SelectGroupEntityTypePermissions(gUID);

					DataView cpTypeGRows = new DataView(groupPerms);
					cpTypeGRows.RowFilter = "CPUID = '" + cpType.GUID + "'";

					//If no prmissions for the EntityType, ignore and continue
					if (cpTypeGRows.Count == 0)
						continue;

					assignAllowFromDataView(cpPerms, cpTypeGRows);
				}

				//No point adding perm if no perms anyways.
				if (cpPerms.Count > 0)
					effPerms.Add(cpType.GUID, cpPerms);

			}

			return effPerms;


		}

		public static Dictionary<string, bool> GetEffectiveEntityRecordPermissions(int userUID, EntityTypeGUIDRecordUIDPair eTypeUIDPair, List<int> groupUIDList)
		{
			//Create initial dictionary
			Dictionary<string, bool> effPerms = new Dictionary<string, bool>();

			DataAccessAdapter da = new DataAccessAdapter(true);

			da.CloseConnection();

			//Get Datatable of entitytype permissions for user
			DataTable userPerms = RetrievalProcedures.SelectUserRecordPermissions(eTypeUIDPair.EntityTypeGUID, eTypeUIDPair.RecordUID, userUID);

			assignAllowFromDataView(effPerms, userPerms.DefaultView);

			foreach (int gGUID in groupUIDList)
			{
				//Get Datatable of entitytype permissions for group gm
				DataTable groupPerms = RetrievalProcedures.SelectGroupRecordPermissions(eTypeUIDPair.EntityTypeGUID, eTypeUIDPair.RecordUID, gGUID);

				//If no prmissions for the EntityType, ignore and continue
				if (groupPerms.DefaultView.Count == 0)
					continue;

				assignAllowFromDataView(effPerms, groupPerms.DefaultView);
			}

			return effPerms;

		}

		internal static void assignAllowFromDataView(Dictionary<string, bool> permsDict, DataView permsView)
		{
			foreach(DataRowView row in permsView)
			{
				//Get the action code and allow bit 
				string actionCode = row["ActionCode"].ToString();
				bool allowBit = Convert.ToBoolean(row["Allow"]);

				//If the current actioncode is denied, we will not ever allow
				if (permsDict.ContainsKey(actionCode) && !(permsDict[actionCode]))
					continue;
				else //Set the allow bit
					permsDict[actionCode] = allowBit;

			}
		}

	}
}
