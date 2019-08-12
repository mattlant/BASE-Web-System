/* Author: Steve Arbour
 * This source file is part of the BASE Web Framework System
 * Date: 25 July 2007
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
    /// This class is used to offer bindable function and others tools functions to manage the CustomGroupPermissionEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class CustomGroupPermissionDataHelper
    {
        /// <summary>
        /// This method is used to retreive a single CustomGroupPermissionEntity by it Primary Key
        /// </summary>
        /// <param name="groupUID">Group Unique ID</param>
        /// <param name="customPermissionTypeGUID">Custom Permission Type Global Unique ID</param>
        /// <param name="actionCode">Action Code</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static CustomGroupPermissionEntity SelectSingle(int groupUID, Guid customPermissionTypeGUID, string actionCode)
        {
            CustomGroupPermissionEntity cgpe = new CustomGroupPermissionEntity(groupUID, customPermissionTypeGUID, actionCode);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(cgpe) == true)
            {
                return cgpe;
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
        /// <returns>EntityCollection<CustomGroupPermissionEntity></returns>
        public static EntityCollection<CustomGroupPermissionEntity> Select()
        {
            EntityCollection<CustomGroupPermissionEntity> permissions = new EntityCollection<CustomGroupPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, null);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="groupguid">The group GUID</param>
        /// <param name="cptguid">Custom Permission Type GUID</param>
        /// <returns>EntityCollection<CustomGroupPermissionEntity></returns>
        public static EntityCollection<CustomGroupPermissionEntity> Select(int groupuid, System.Guid cptguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomGroupPermissionFields.GroupUID == groupuid);
            filter.Add(CustomGroupPermissionFields.CustomPermissionTypeGUID == cptguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomGroupPermissionEntity> permissions = new EntityCollection<CustomGroupPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="groupguid">The group GUID</param>
        /// <param name="cptguid">Custom Permission Type GUID</param>
        /// <param name="atype">Action code</param>
        /// <returns>EntityCollection<CustomGroupPermissionEntity></returns>
        public static EntityCollection<CustomGroupPermissionEntity> Select(int groupuid, System.Guid cptguid, System.String atype)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomGroupPermissionFields.GroupUID == groupuid);
            filter.Add(CustomGroupPermissionFields.CustomPermissionTypeGUID == cptguid);
            filter.Add(CustomGroupPermissionFields.ActionCode == atype);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomGroupPermissionEntity> permissions = new EntityCollection<CustomGroupPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="groupguid">The group GUID</param>
        /// <param name="cptguid">Custom Permission Type GUID</param>
        /// <param name="atype">Action code</param>
        /// <param name="allow">Allow</param>
        /// <returns>EntityCollection<CustomGroupPermissionEntity></returns>
        public static EntityCollection<CustomGroupPermissionEntity> Select(int groupuid, System.Guid cptguid, System.String atype, System.Boolean allow)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomGroupPermissionFields.GroupUID == groupuid);
            filter.Add(CustomGroupPermissionFields.CustomPermissionTypeGUID == cptguid);
            filter.Add(CustomGroupPermissionFields.ActionCode == atype);
            filter.Add(CustomGroupPermissionFields.Allow == allow);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomGroupPermissionEntity> permissions = new EntityCollection<CustomGroupPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="groupguid">The Group Unique ID of the requested entity.</param>
        /// <returns>EntityCollection<CustomGroupPermissionEntity></returns>
        public static EntityCollection<CustomGroupPermissionEntity> SelectByGroupGUID(int groupuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomGroupPermissionFields.GroupUID == groupuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomGroupPermissionEntity> permissions = new EntityCollection<CustomGroupPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="cptguid">The Custom Permission Type GUID of the requested entity.</param>
        /// <returns>EntityCollection<CustomGroupPermissionEntity></returns>
        public static EntityCollection<CustomGroupPermissionEntity> SelectByCustomPermissionTypeGUID(System.Guid cptguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomGroupPermissionFields.CustomPermissionTypeGUID == cptguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomGroupPermissionEntity> permissions = new EntityCollection<CustomGroupPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="atype">The Action Code the requested entity.</param>
        /// <returns>EntityCollection<CustomGroupPermissionEntity></returns>
        public static EntityCollection<CustomGroupPermissionEntity> SelectByActionCode(System.String atype)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomGroupPermissionFields.ActionCode == atype);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomGroupPermissionEntity> permissions = new EntityCollection<CustomGroupPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="allow">The Allow flag of the requested entity.</param>
        /// <returns>EntityCollection<CustomGroupPermissionEntity></returns>
        public static EntityCollection<CustomGroupPermissionEntity> SelectByAllow(System.Boolean allow)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomGroupPermissionFields.Allow == allow);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomGroupPermissionEntity> permissions = new EntityCollection<CustomGroupPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert an CustomGroupPermissionEntity in the storage area.
        /// </summary>
        /// <param name="gguid">Group GUID</param>
        /// <param name="cptguid">Custom Permission Type GUID</param>
        /// <param name="actioncode">Action Code</param>
        /// <param name="allow">Allow flag</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(int gUid, System.Guid cptguid, System.String actioncode, System.Boolean allow)
        {
            CustomGroupPermissionEntity cgpe = new CustomGroupPermissionEntity();
            cgpe.GroupUID = gUid;
            cgpe.CustomPermissionTypeGUID = cptguid;
            cgpe.ActionCode = actioncode;
            cgpe.Allow = allow;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(cgpe);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an CustomGroupPermissionEntity.
        /// </summary>
        /// <param name="gguid">Group GUID</param>
        /// <param name="cptguid">Custom Permission Type GUID</param>
        /// <param name="actioncode">Action Code</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(int gUid, System.Guid cptguid, System.String actioncode)
        {
            CustomGroupPermissionEntity cgpe = new CustomGroupPermissionEntity(gUid, cptguid, actioncode);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(cgpe);
        }
        #endregion
    }
}
