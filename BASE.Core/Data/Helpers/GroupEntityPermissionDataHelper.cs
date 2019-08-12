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
    /// This class is used to offer bindable function and others tools functions to manage the GroupEntityPermissionEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class GroupEntityPermissionDataHelper
    {
        /// <summary>
        /// This method is used to retreive a single GroupEntityPermissionEntity by it Primary Key
        /// </summary>
        /// <param name="groupUID">Group Unique ID</param>
        /// <param name="entityTypeGUID">Entity Type Global Unique ID</param>
        /// <param name="actionCode">Action Code</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static GroupEntityPermissionEntity SelectSingle(int groupUID, Guid entityTypeGUID, string actionCode)
        {
            GroupEntityPermissionEntity grpp = new GroupEntityPermissionEntity(groupUID, entityTypeGUID, actionCode);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(grpp) == true)
            {
                return grpp;
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
        /// <returns>EntityCollection<GroupEntityPermissionEntity></returns>
        public static EntityCollection<GroupEntityPermissionEntity> Select()
        {
            EntityCollection<GroupEntityPermissionEntity> permissions = new EntityCollection<GroupEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, null);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="guid">The Group GUID</param>
        /// <param name="etguid">Entity Type GUID</param>
        /// <returns>EntityCollection<GroupEntityPermissionEntity></returns>
        public static EntityCollection<GroupEntityPermissionEntity> Select(int gUid, System.Guid etguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupEntityPermissionFields.GroupUID == gUid);
            filter.Add(GroupEntityPermissionFields.EntityTypeGUID == etguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntityPermissionEntity> permissions = new EntityCollection<GroupEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="guid">The Group GUID</param>
        /// <param name="etguid">Entity Type GUID</param>
        /// <param name="actioncode">Action code</param>
        /// <returns>EntityCollection<GroupEntityPermissionEntity></returns>
        public static EntityCollection<GroupEntityPermissionEntity> Select(int gUid, System.Guid etguid, System.String actioncode)
        {
            PredicateExpression filter = new PredicateExpression();
			filter.Add(GroupEntityPermissionFields.GroupUID == gUid);
            filter.Add(GroupEntityPermissionFields.EntityTypeGUID == etguid);
            filter.Add(GroupEntityPermissionFields.ActionCode == actioncode);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntityPermissionEntity> permissions = new EntityCollection<GroupEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="guid">The Group GUID</param>
        /// <param name="etguid">Entity Type GUID</param>
        /// <param name="actioncode">Action code</param>
        /// <param name="allow">Allow</param>
        /// <returns>EntityCollection<GroupEntityPermissionEntity></returns>
        public static EntityCollection<GroupEntityPermissionEntity> Select(int gUid, System.Guid etguid, System.String actioncode, System.Boolean allow)
        {
            PredicateExpression filter = new PredicateExpression();
			filter.Add(GroupEntityPermissionFields.GroupUID == gUid);
            filter.Add(GroupEntityPermissionFields.EntityTypeGUID == etguid);
            filter.Add(GroupEntityPermissionFields.ActionCode == actioncode);
            filter.Add(GroupEntityPermissionFields.Allow == allow);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntityPermissionEntity> permissions = new EntityCollection<GroupEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="guid">The Group GUID of the requested entity.</param>
        /// <returns>EntityCollection<GroupEntityPermissionEntity></returns>
        public static EntityCollection<GroupEntityPermissionEntity> SelectByGroupGUID(int gUid)
        {
            PredicateExpression filter = new PredicateExpression();
			filter.Add(GroupEntityPermissionFields.GroupUID == gUid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntityPermissionEntity> permissions = new EntityCollection<GroupEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="etguid">The Entity Type GUID of the requested entity.</param>
        /// <returns>EntityCollection<GroupEntityPermissionEntity></returns>
        public static EntityCollection<GroupEntityPermissionEntity> SelectByEntityTypeGUID(System.Guid etguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupEntityPermissionFields.EntityTypeGUID == etguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntityPermissionEntity> permissions = new EntityCollection<GroupEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="actioncode">The Action Code the requested entity.</param>
        /// <returns>EntityCollection<GroupEntityPermissionEntity></returns>
        public static EntityCollection<GroupEntityPermissionEntity> SelectByActionCode(System.String actioncode)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupEntityPermissionFields.ActionCode == actioncode);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntityPermissionEntity> permissions = new EntityCollection<GroupEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="allow">The Allow flag of the requested entity.</param>
        /// <returns>EntityCollection<GroupEntityPermissionEntity></returns>
        public static EntityCollection<GroupEntityPermissionEntity> SelectByAllow(System.Boolean allow)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupEntityPermissionFields.Allow == allow);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntityPermissionEntity> permissions = new EntityCollection<GroupEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert an GroupEntityPermissionEntity in the storage area.
        /// </summary>
        /// <param name="guid">Group GUID</param>
        /// <param name="etguid">Entity Type GUID</param>
        /// <param name="actioncode">Action Code</param>
        /// <param name="allow">Allow flag</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(int gUid, System.Guid etguid, System.String actioncode, System.Boolean allow)
        {
            GroupEntityPermissionEntity gepe = new GroupEntityPermissionEntity();
			gepe.GroupUID = gUid;
            gepe.EntityTypeGUID = etguid;
            gepe.ActionCode = actioncode;
            gepe.Allow = allow;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(gepe);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an GroupEntityPermissionEntity.
        /// </summary>
        /// <param name="guid">Group GUID</param>
        /// <param name="etguid">Entity Type GUID</param>
        /// <param name="actioncode">Action Code</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(int gUid, System.Guid etguid, System.String actioncode)
        {
			GroupEntityPermissionEntity gepe = new GroupEntityPermissionEntity(gUid, etguid, actioncode);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(gepe);
        }
        #endregion
    }
}
