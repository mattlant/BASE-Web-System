/* Author: Steve Arbour
 * This source file is part of the BASE Web Framework System
 * Date: 26 July 2007
 * Copyright © 2007 BASE Web Systems Inc.
 * This software and its source code is protected by international copyright laws.
 * Any violation of this copyright will result in prosecution to the fullest
 * permissible extent of the law
 */

using System;
using System.Collections.Generic;
using System.Text;
using SD.LLBLGen.Pro.ORMSupportClasses;
using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.HelperClasses;
//using BASE.Data.LLDAL.RelationClasses;
using BASE.Data.LLDAL.DatabaseSpecific;

namespace BASE.Data.Helpers
{
    /// <summary>
    /// This class is used to offer bindable function and others tools functions to manage the GroupRecordPermissionEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class GroupRecordPermissionDataHelper
    {
        /// <summary>
        /// This method is used to retreive a single GroupRecordPermissionEntity by it Primary Key
        /// </summary>
        /// <param name="groupUID">Group Unique ID</param>
        /// <param name="entityTypeGUID">Entity Type Global Unique ID</param>
        /// <param name="recordUID">Record Unique ID</param>
        /// <param name="actionCode">Action Code</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static GroupRecordPermissionEntity SelectSingle(int groupUID, Guid entityTypeGUID, int recordUID, string actionCode)
        {
            GroupRecordPermissionEntity grpe = new GroupRecordPermissionEntity(groupUID, entityTypeGUID, recordUID, actionCode);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(grpe) == true)
            {
                return grpe;
            }
            else
            {
                return null;
            }

        }

        #region SELECT GROUP
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <returns>EntityCollection<GroupRecordPermissionEntity></returns>
        public static EntityCollection<GroupRecordPermissionEntity> Select()
        {
            EntityCollection<GroupRecordPermissionEntity> permissions = new EntityCollection<GroupRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, null);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="gguid">The Group GUID</param>
        /// <param name="etguid">Entity Type GUID</param>
        /// <returns>EntityCollection<GroupRecordPermissionEntity></returns>
        public static EntityCollection<GroupRecordPermissionEntity> Select(int gUid, System.Guid etguid)
        {
            PredicateExpression filter = new PredicateExpression();
			filter.Add(GroupRecordPermissionFields.GroupUID == gUid);
            filter.Add(GroupRecordPermissionFields.EntityTypeGUID == etguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupRecordPermissionEntity> permissions = new EntityCollection<GroupRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="gguid">The Group GUID</param>
        /// <param name="etguid">Entity Type GUID</param>
        /// <param name="actioncode">Action code</param>
        /// <returns>EntityCollection<GroupRecordPermissionEntity></returns>
        public static EntityCollection<GroupRecordPermissionEntity> Select(int gUid, System.Guid etguid, System.String actioncode)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupRecordPermissionFields.GroupUID == gUid);
            filter.Add(GroupRecordPermissionFields.EntityTypeGUID == etguid);
            filter.Add(GroupRecordPermissionFields.ActionCode == actioncode);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupRecordPermissionEntity> permissions = new EntityCollection<GroupRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="gguid">The Group GUID</param>
        /// <param name="etguid">Entity Type GUID</param>
        /// <param name="actioncode">Action code</param>
        /// <param name="allow">Allow</param>
        /// <returns>EntityCollection<GroupRecordPermissionEntity></returns>
        public static EntityCollection<GroupRecordPermissionEntity> Select(int gUid, System.Guid etguid, System.String actioncode, System.Boolean allow)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupRecordPermissionFields.GroupUID == gUid);
            filter.Add(GroupRecordPermissionFields.EntityTypeGUID == etguid);
            filter.Add(GroupRecordPermissionFields.ActionCode == actioncode);
            filter.Add(GroupRecordPermissionFields.Allow == allow);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupRecordPermissionEntity> permissions = new EntityCollection<GroupRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="gguid">The Group GUID</param>
        /// <param name="etguid">Entity Type GUID</param>
        /// <param name="actioncode">Action code</param>
        /// <param name="allow">Allow</param>
        /// <param name="recorduid">Record UID</param>
        /// <returns>EntityCollection<GroupRecordPermissionEntity></returns>
        public static EntityCollection<GroupRecordPermissionEntity> Select(int gUid, System.Guid etguid, System.String actioncode, System.Boolean allow, System.Int32 recorduid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupRecordPermissionFields.GroupUID == gUid);
            filter.Add(GroupRecordPermissionFields.EntityTypeGUID == etguid);
            filter.Add(GroupRecordPermissionFields.ActionCode == actioncode);
            filter.Add(GroupRecordPermissionFields.Allow == allow);
            filter.Add(GroupRecordPermissionFields.RecordUID == recorduid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupRecordPermissionEntity> permissions = new EntityCollection<GroupRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="gguid">The Group GUID of the requested entity.</param>
        /// <returns>EntityCollection<GroupRecordPermissionEntity></returns>
        public static EntityCollection<GroupRecordPermissionEntity> SelectByGroupGUID(int gUid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupRecordPermissionFields.GroupUID == gUid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupRecordPermissionEntity> permissions = new EntityCollection<GroupRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="etguid">The Entity Type GUID of the requested entity.</param>
        /// <returns>EntityCollection<GroupRecordPermissionEntity></returns>
        public static EntityCollection<GroupRecordPermissionEntity> SelectByEntityTypeGUID(System.Guid etguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupRecordPermissionFields.EntityTypeGUID == etguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupRecordPermissionEntity> permissions = new EntityCollection<GroupRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="actioncode">The Action Code the requested entity.</param>
        /// <returns>EntityCollection<GroupRecordPermissionEntity></returns>
        public static EntityCollection<GroupRecordPermissionEntity> SelectByActionCode(System.String actioncode)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupRecordPermissionFields.ActionCode == actioncode);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupRecordPermissionEntity> permissions = new EntityCollection<GroupRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="allow">The Allow flag of the requested entity.</param>
        /// <returns>EntityCollection<GroupRecordPermissionEntity></returns>
        public static EntityCollection<GroupRecordPermissionEntity> SelectByAllow(System.Boolean allow)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupRecordPermissionFields.Allow == allow);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupRecordPermissionEntity> permissions = new EntityCollection<GroupRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="recorduid">The Record UID of the requested entity.</param>
        /// <returns>EntityCollection<GroupRecordPermissionEntity></returns>
        public static EntityCollection<GroupRecordPermissionEntity> SelectByRecordUID(System.Int32 recorduid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupRecordPermissionFields.RecordUID == recorduid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupRecordPermissionEntity> permissions = new EntityCollection<GroupRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert an GroupRecordPermissionEntity in the storage area.
        /// </summary>
        /// <param name="gguid">Group GUID</param>
        /// <param name="etguid">Entity Type GUID</param>
        /// <param name="actioncode">Action Code</param>
        /// <param name="allow">Allow flag</param>
        /// <param name="recorduid">Record UID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(int gUid, System.Guid etguid, System.String actioncode, System.Boolean allow, System.Int32 recorduid)
        {
            GroupRecordPermissionEntity grpe = new GroupRecordPermissionEntity();
            grpe.GroupUID = gUid;
            grpe.EntityTypeGUID = etguid;
            grpe.ActionCode = actioncode;
            grpe.Allow = allow;
            grpe.RecordUID = recorduid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(grpe);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an GroupRecordPermissionEntity.
        /// </summary>
        /// <param name="gguid">Group GUID</param>
        /// <param name="etguid">Entity Type GUID</param>
        /// <param name="recorduid">Record UID</param>
        /// <param name="actioncode">Action Code</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(int gUid, System.Guid etguid, System.Int32 recorduid, System.String actioncode)
        {
            GroupRecordPermissionEntity grpe = new GroupRecordPermissionEntity(gUid, etguid, recorduid, actioncode);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(grpe);
        }
        #endregion
    }
}
