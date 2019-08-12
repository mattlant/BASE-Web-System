/* Author: Steve Arbour
 * This source file is part of the BASE Web Framework System
 * Date: 27 July 2007
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
    /// This class is used to offer bindable function and others tools functions to manage the UserEntityPermissionEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class UserEntityPermissionDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single UserEntityPermissionEntity by it Primary Key
        /// </summary>
        /// <param name="userUID">User Unique ID</param>
        /// <param name="entityTypeGUID">Entity Type GUID</param>
        /// <param name="actionCode">Action Code</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static UserEntityPermissionEntity SelectSingle(int userUID, Guid entityTypeGUID, string actionCode)
        {
            UserEntityPermissionEntity userpermission = new UserEntityPermissionEntity(userUID, entityTypeGUID, actionCode);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(userpermission) == true)
            {
                return userpermission;
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
        /// <returns>EntityCollection<UserEntityPermissionEntity></returns>
        public static EntityCollection<UserEntityPermissionEntity> Select()
        {
            EntityCollection<UserEntityPermissionEntity> templatetypes = new EntityCollection<UserEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templatetypes, null);
            return templatetypes;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="useruid">The User GUID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity type GUID of the requested entity.</param>
        /// <returns>EntityCollection<UserEntityPermissionEntity></returns>
        public static EntityCollection<UserEntityPermissionEntity> Select(int useruid, System.Guid entitytypeguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserEntityPermissionFields.UserUID == useruid);
            filter.Add(UserEntityPermissionFields.EntityTypeGUID == entitytypeguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntityPermissionEntity> userspermissions = new EntityCollection<UserEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(userspermissions, bucket);
            return userspermissions;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="useruid">The User GUID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity type GUID of the requested entity.</param>
        /// <param name="actioncode">The Action Code of the requested entity.</param>
        /// <returns>EntityCollection<UserEntityPermissionEntity></returns>
        public static EntityCollection<UserEntityPermissionEntity> Select(int useruid, System.Guid entitytypeguid, System.String actioncode)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserEntityPermissionFields.UserUID == useruid);
            filter.Add(UserEntityPermissionFields.EntityTypeGUID == entitytypeguid);
            filter.Add(UserEntityPermissionFields.ActionCode == actioncode);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntityPermissionEntity> userspermissions = new EntityCollection<UserEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(userspermissions, bucket);
            return userspermissions;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="useruid">The User GUID of the requested entity.</param>
        /// <returns>EntityCollection<UserEntityPermissionEntity></returns>
        public static EntityCollection<UserEntityPermissionEntity> SelectByUserGUID(int useruid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserEntityPermissionFields.UserUID == useruid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntityPermissionEntity> userspermissions = new EntityCollection<UserEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(userspermissions, bucket);
            return userspermissions;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="entitytypeguid">The Entity type GUID of the requested entity.</param>
        /// <returns>EntityCollection<UserEntityPermissionEntity></returns>
        public static EntityCollection<UserEntityPermissionEntity> SelectByEntityTypeGUID(int useruid, System.Guid entitytypeguid, System.String actioncode)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserEntityPermissionFields.EntityTypeGUID == entitytypeguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntityPermissionEntity> userspermissions = new EntityCollection<UserEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(userspermissions, bucket);
            return userspermissions;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="actioncode">The Action Code of the requested entity.</param>
        /// <returns>EntityCollection<UserEntityPermissionEntity></returns>
        public static EntityCollection<UserEntityPermissionEntity> SelectByActionCode(System.String actioncode)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserEntityPermissionFields.ActionCode == actioncode);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntityPermissionEntity> userspermissions = new EntityCollection<UserEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(userspermissions, bucket);
            return userspermissions;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="allow">The Allow Flag of the requested entity.</param>
        /// <returns>EntityCollection<UserEntityPermissionEntity></returns>
        public static EntityCollection<UserEntityPermissionEntity> SelectByAllow(System.Boolean allow)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserEntityPermissionFields.Allow == allow);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntityPermissionEntity> userspermissions = new EntityCollection<UserEntityPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(userspermissions, bucket);
            return userspermissions;
        }


        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a UserEntityPermissionEntity in the storage area.
        /// </summary>
        /// <param name="useruid">The User GUID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity type GUID of the requested entity.</param>
        /// <param name="actioncode">The Action Code of the requested entity.</param>
        /// <param name="allow">The Allow Flag of the requested entity.</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(int useruid, System.Guid entitytypeguid, System.String actioncode, System.Boolean allow)
        {
            UserEntityPermissionEntity upermission = new UserEntityPermissionEntity();
            upermission.UserUID = useruid;
            upermission.EntityTypeGUID = entitytypeguid;
            upermission.ActionCode = actioncode;
            upermission.Allow = allow;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(upermission);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an UserEntityPermissionEntity.
        /// </summary>
        /// <param name="uid">Unique ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(int useruid, System.Guid entitytypeguid, System.String actioncode)
        {
            UserEntityPermissionEntity upermission = new UserEntityPermissionEntity(useruid, entitytypeguid, actioncode);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(upermission);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an UserEntityPermissionEntity.
        /// </summary>
        /// <param name="useruid">The User GUID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity type GUID of the requested entity.</param>
        /// <param name="actioncode">The Action Code of the requested entity.</param>
        /// <param name="allow">The Allow Flag of the requested entity.</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(int useruid, System.Guid entitytypeguid, System.String actioncode, System.Boolean allow)
        {
            UserEntityPermissionEntity upermission = new UserEntityPermissionEntity(useruid, entitytypeguid, actioncode);
            upermission.IsNew = false;
            upermission.UserUID = useruid;
            upermission.EntityTypeGUID = entitytypeguid;
            upermission.ActionCode = actioncode;
            upermission.Allow = allow;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(upermission);
        }
        #endregion
    }
}