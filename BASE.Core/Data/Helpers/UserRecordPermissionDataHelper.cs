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
    /// This class is used to offer bindable function and others tools functions to manage the UserRecordPermissionEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class UserRecordPermissionDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single UserRecordPermissionEntity by it Primary Key
        /// </summary>
        /// <param name="userUID">User Unique ID</param>
        /// <param name="entityTypeGUID">Entity Type GUID</param>
        /// <param name="recordUID">Record Unique ID</param>
        /// <param name="actionCode">Action Code</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static UserRecordPermissionEntity SelectSingle(int userUID, Guid entityTypeGUID, int recordUID, string actionCode)
        {
            UserRecordPermissionEntity userrecordpermission = new UserRecordPermissionEntity(userUID, entityTypeGUID, recordUID, actionCode);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(userrecordpermission) == true)
            {
                return userrecordpermission;
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
        /// <returns>EntityCollection<UserRecordPermissionEntity></returns>
        public static EntityCollection<UserRecordPermissionEntity> Select()
        {
            EntityCollection<UserRecordPermissionEntity> urpermission = new EntityCollection<UserRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(urpermission, null);
            return urpermission;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="userguid">The User GUID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity type GUID of the requested entity.</param>
        /// <returns>EntityCollection<UserRecordPermissionEntity></returns>
        public static EntityCollection<UserRecordPermissionEntity> Select(int useruid, System.Guid entitytypeguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserRecordPermissionFields.UserUID == useruid);
            filter.Add(UserRecordPermissionFields.EntityTypeGUID == entitytypeguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserRecordPermissionEntity> urpermission = new EntityCollection<UserRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(urpermission, bucket);
            return urpermission;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="userguid">The User GUID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity type GUID of the requested entity.</param>
        /// <param name="actioncode">The Action Code of the requested entity.</param>
        /// <returns>EntityCollection<UserRecordPermissionEntity></returns>
        public static EntityCollection<UserRecordPermissionEntity> Select(int useruid, System.Guid entitytypeguid, System.String actioncode)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserRecordPermissionFields.UserUID == useruid);
            filter.Add(UserRecordPermissionFields.EntityTypeGUID == entitytypeguid);
            filter.Add(UserRecordPermissionFields.ActionCode == actioncode);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserRecordPermissionEntity> userspermissions = new EntityCollection<UserRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(userspermissions, bucket);
            return userspermissions;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="userguid">The User GUID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity type GUID of the requested entity.</param>
        /// <param name="actioncode">The Action Code of the requested entity.</param>
        /// <param name="recorduid">The Record Unique ID Code of the requested entity.</param>
        /// <returns>EntityCollection<UserRecordPermissionEntity></returns>
		public static EntityCollection<UserRecordPermissionEntity> Select(int useruid, System.Guid entitytypeguid, System.String actioncode, System.Int32 recorduid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserRecordPermissionFields.UserUID == useruid);
            filter.Add(UserRecordPermissionFields.EntityTypeGUID == entitytypeguid);
            filter.Add(UserRecordPermissionFields.ActionCode == actioncode);
            filter.Add(UserRecordPermissionFields.RecordUID == recorduid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserRecordPermissionEntity> userspermissions = new EntityCollection<UserRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(userspermissions, bucket);
            return userspermissions;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="userguid">The User GUID of the requested entity.</param>
        /// <returns>EntityCollection<UserRecordPermissionEntity></returns>
		public static EntityCollection<UserRecordPermissionEntity> SelectByUserGUID(int useruid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserRecordPermissionFields.UserUID == useruid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserRecordPermissionEntity> userspermissions = new EntityCollection<UserRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(userspermissions, bucket);
            return userspermissions;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="entitytypeguid">The Entity type GUID of the requested entity.</param>
        /// <returns>EntityCollection<UserRecordPermissionEntity></returns>
        public static EntityCollection<UserRecordPermissionEntity> SelectByEntityTypeGUID(System.Guid entitytypeguid, System.String actioncode)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserRecordPermissionFields.EntityTypeGUID == entitytypeguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserRecordPermissionEntity> userspermissions = new EntityCollection<UserRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(userspermissions, bucket);
            return userspermissions;
        }


        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="ruid">The Record UID of the requested entity.</param>
        /// <returns>EntityCollection<UserRecordPermissionEntity></returns>
        public static EntityCollection<UserRecordPermissionEntity> SelectByRecordUID(System.Int32 ruid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserRecordPermissionFields.RecordUID == ruid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserRecordPermissionEntity> userspermissions = new EntityCollection<UserRecordPermissionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(userspermissions, bucket);
            return userspermissions;
        }


        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a UserRecordPermissionEntity in the storage area.
        /// </summary>
        /// <param name="userguid">The User GUID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity type GUID of the requested entity.</param>
        /// <param name="actioncode">The Action Code of the requested entity.</param>
        /// <param name="allow">The Allow Flag of the requested entity.</param>
        /// <param name="ruid">The Record UID of the requested entity.</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(int useruid, System.Guid entitytypeguid, System.String actioncode, System.Boolean allow, System.Int32 ruid)
        {
            UserRecordPermissionEntity upermission = new UserRecordPermissionEntity();
            upermission.UserUID = useruid;
            upermission.EntityTypeGUID = entitytypeguid;
            upermission.ActionCode = actioncode;
            upermission.Allow = allow;
            upermission.RecordUID = ruid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(upermission);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an UserRecordPermissionEntity.
        /// </summary>
        /// <param name="userguid">The User GUID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity type GUID of the requested entity.</param>
        /// <param name="actioncode">The Action Code of the requested entity.</param>
        /// <param name="ruid">The Record UID of the requested entity.</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(int useruid, System.Guid entitytypeguid, System.String actioncode, System.Int32 ruid)
        {
            UserRecordPermissionEntity upermission = new UserRecordPermissionEntity(useruid, entitytypeguid, ruid, actioncode);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(upermission);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an UserRecordPermissionEntity.
        /// </summary>
        /// <param name="userguid">The User GUID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity type GUID of the requested entity.</param>
        /// <param name="actioncode">The Action Code of the requested entity.</param>
        /// <param name="allow">The Allow Flag of the requested entity.</param>
        /// <param name="ruid">The Record UID of the requested entity.</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(int useruid, System.Guid entitytypeguid, System.String actioncode, System.Boolean allow, System.Int32 ruid)
        {
            UserRecordPermissionEntity upermission = new UserRecordPermissionEntity(useruid, entitytypeguid, ruid, actioncode);
            upermission.IsNew = false;
            upermission.UserUID = useruid;
            upermission.EntityTypeGUID = entitytypeguid;
            upermission.ActionCode = actioncode;
            upermission.Allow = allow;
            upermission.RecordUID = ruid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(upermission);
        }
        #endregion
    }
}