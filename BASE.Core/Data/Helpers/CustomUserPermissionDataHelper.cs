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
    /// This class is used to offer bindable function and others tools functions to manage the CustomUserPermissionEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class CustomUserPermissionDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single CustomUserPermissionEntity by it Primary Key
        /// </summary>
        /// <param name="userUID">User Unique ID</param>
        /// <param name="customPermissionTypeGUID">Custom Permission Type Global Unique ID</param>
        /// <param name="actionCode">Action Code</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static CustomUserPermissionEntity SelectSingle(int userUID, Guid customPermissionTypeGUID, string actionCode)
        {
            CustomUserPermissionEntity cupe = new CustomUserPermissionEntity(userUID, customPermissionTypeGUID, actionCode);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(cupe) == true)
            {
                return cupe;
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
        /// <returns>EntityCollection<CustomUserPermissionEntity></returns>
        public static EntityCollection<CustomUserPermissionEntity> Select()
        {
            EntityCollection<CustomUserPermissionEntity> permissions = new EntityCollection<CustomUserPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, null);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="uUid">The User GUID</param>
        /// <param name="cptguid">Custom Permission Type GUID</param>
        /// <returns>EntityCollection<CustomUserPermissionEntity></returns>
        public static EntityCollection<CustomUserPermissionEntity> Select(int uUid, System.Guid cptguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomUserPermissionFields.UserUID == uUid);
            filter.Add(CustomUserPermissionFields.CustomPermissionTypeGUID == cptguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomUserPermissionEntity> permissions = new EntityCollection<CustomUserPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="uUid">The User GUID</param>
        /// <param name="cptguid">Custom Permission Type GUID</param>
        /// <param name="actioncode">Action code</param>
        /// <returns>EntityCollection<CustomUserPermissionEntity></returns>
        public static EntityCollection<CustomUserPermissionEntity> Select(int uUid, System.Guid cptguid, System.String actioncode)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomUserPermissionFields.UserUID == uUid);
            filter.Add(CustomUserPermissionFields.CustomPermissionTypeGUID == cptguid);
            filter.Add(CustomUserPermissionFields.ActionCode == actioncode);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomUserPermissionEntity> permissions = new EntityCollection<CustomUserPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="uUid">The User GUID</param>
        /// <param name="cptguid">Custom Permission Type GUID</param>
        /// <param name="actioncode">Action code</param>
        /// <param name="allow">Allow</param>
        /// <returns>EntityCollection<CustomUserPermissionEntity></returns>
        public static EntityCollection<CustomUserPermissionEntity> Select(int uUid, System.Guid cptguid, System.String actioncode, System.Boolean allow)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomUserPermissionFields.UserUID == uUid);
            filter.Add(CustomUserPermissionFields.CustomPermissionTypeGUID == cptguid);
            filter.Add(CustomUserPermissionFields.ActionCode == actioncode);
            filter.Add(CustomUserPermissionFields.Allow == allow);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomUserPermissionEntity> permissions = new EntityCollection<CustomUserPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="groupguid">The Group Unique ID of the requested entity.</param>
        /// <returns>EntityCollection<CustomUserPermissionEntity></returns>
        public static EntityCollection<CustomUserPermissionEntity> SelectByUserGUID(int uUid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomUserPermissionFields.UserUID == uUid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomUserPermissionEntity> permissions = new EntityCollection<CustomUserPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="cptguid">The Custom Permission Type GUID of the requested entity.</param>
        /// <returns>EntityCollection<CustomUserPermissionEntity></returns>
        public static EntityCollection<CustomUserPermissionEntity> SelectByCustomPermissionTypeGUID(System.Guid cptguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomUserPermissionFields.CustomPermissionTypeGUID == cptguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomUserPermissionEntity> permissions = new EntityCollection<CustomUserPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="actioncode">The Action Code the requested entity.</param>
        /// <returns>EntityCollection<CustomUserPermissionEntity></returns>
        public static EntityCollection<CustomUserPermissionEntity> SelectByActionCode(System.String actioncode)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomUserPermissionFields.ActionCode == actioncode);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomUserPermissionEntity> permissions = new EntityCollection<CustomUserPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="allow">The Allow flag of the requested entity.</param>
        /// <returns>EntityCollection<CustomUserPermissionEntity></returns>
        public static EntityCollection<CustomUserPermissionEntity> SelectByAllow(System.Boolean allow)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomUserPermissionFields.Allow == allow);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomUserPermissionEntity> permissions = new EntityCollection<CustomUserPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissions, bucket);
            return permissions;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert an CustomUserPermissionEntity in the storage area.
        /// </summary>
        /// <param name="uUid">User GUID</param>
        /// <param name="cptguid">Custom Permission Type GUID</param>
        /// <param name="actioncode">Action Code</param>
        /// <param name="allow">Allow flag</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(int uUid, System.Guid cptguid, System.String actioncode, System.Boolean allow)
        {
            CustomUserPermissionEntity cupe = new CustomUserPermissionEntity();
            cupe.UserUID = uUid;
            cupe.CustomPermissionTypeGUID = cptguid;
            cupe.ActionCode = actioncode;
            cupe.Allow = allow;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(cupe);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an CustomUserPermissionEntity.
        /// </summary>
        /// <param name="uUid">Group GUID</param>
        /// <param name="cptguid">Custom Permission Type GUID</param>
        /// <param name="actioncode">Action Code</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(int uUid, System.Guid cptguid, System.String actioncode)
        {
            CustomUserPermissionEntity cgpe = new CustomUserPermissionEntity(uUid, cptguid, actioncode);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(cgpe);
        }
        #endregion
    }
}
