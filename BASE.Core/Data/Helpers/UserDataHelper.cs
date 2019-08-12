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
    /// This class is used to offer bindable function and others tools functions to manage the UserEntity
    /// </summary>
    /// 
    [System.ComponentModel.DataObject]
    public static class UserDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single UserEntity by it Primary Key
        /// </summary>
        /// <param name="uID">Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static UserEntity SelectSingle(int uID)
        {
            UserEntity user = new UserEntity(uID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(user) == true)
            {
                return user;
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
        /// <returns>EntityCollection<UserEntity></returns>
        public static EntityCollection<UserEntity> Select()
        {
            EntityCollection<UserEntity> users = new EntityCollection<UserEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(users, null);
            return users;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="guid">The GUID of the requested entity.</param>
        /// <returns>EntityCollection<UserEntity></returns>
        public static EntityCollection<UserEntity> SelectByGUID(int uid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserFields.UID == uid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntity> users = new EntityCollection<UserEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(users, bucket);
            return users;
        }


        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="siteuid">The Site UID of the requested entity.</param>
        /// <returns>EntityCollection<UserEntity></returns>
        public static EntityCollection<UserEntity> SelectBySiteUID(System.Int32 siteuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserFields.SiteUID == siteuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntity> users = new EntityCollection<UserEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(users, bucket);
            return users;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="username">The UserName of the requested entity.</param>
        /// <returns>EntityCollection<UserEntity></returns>
        public static EntityCollection<UserEntity> SelectByUsername(System.String username)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserFields.UserName == username);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntity> users = new EntityCollection<UserEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(users, bucket);
            return users;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="username">The UserName Lower of the requested entity.</param>
        /// <returns>EntityCollection<UserEntity></returns>
        public static EntityCollection<UserEntity> SelectByUsernameLower(System.String username)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserFields.UserNameLower == username);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntity> users = new EntityCollection<UserEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(users, bucket);
            return users;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="password">The Password of the requested entity.</param>
        /// <returns>EntityCollection<UserEntity></returns>
        public static EntityCollection<UserEntity> SelectByPassword(System.String password)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserFields.Password == password);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntity> users = new EntityCollection<UserEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(users, bucket);
            return users;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="flag">The Can Expire Flag of the requested entity.</param>
        /// <returns>EntityCollection<UserEntity></returns>
        public static EntityCollection<UserEntity> SelectByCanExpire(System.Boolean flag)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserFields.CanExpire == flag);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntity> users = new EntityCollection<UserEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(users, bucket);
            return users;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="dt">The Expiry Date of the requested entity.</param>
        /// <returns>EntityCollection<UserEntity></returns>
        public static EntityCollection<UserEntity> SelectByExpiryDate(System.DateTime dt)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserFields.ExpiryDate == dt);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntity> users = new EntityCollection<UserEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(users, bucket);
            return users;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="flag">The Is Disabled Flag of the requested entity.</param>
        /// <returns>EntityCollection<UserEntity></returns>
        public static EntityCollection<UserEntity> SelectByIsDisabled(System.Boolean flag)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserFields.IsDisabled == flag);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntity> users = new EntityCollection<UserEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(users, bucket);
            return users;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="flag">The Is System Admin Flag of the requested entity.</param>
        /// <returns>EntityCollection<UserEntity></returns>
        public static EntityCollection<UserEntity> SelectByIsSystemAdmin(System.Boolean flag)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserFields.IsSystemAdmin == flag);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntity> users = new EntityCollection<UserEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(users, bucket);
            return users;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="emailaddress">The Email Address of the requested entity.</param>
        /// <returns>EntityCollection<UserEntity></returns>
        public static EntityCollection<UserEntity> SelectByEmailAddress(System.String emailaddress)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserFields.EmailAddress == emailaddress);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntity> users = new EntityCollection<UserEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(users, bucket);
            return users;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="dt">The Last Login of the requested entity.</param>
        /// <returns>EntityCollection<UserEntity></returns>
        public static EntityCollection<UserEntity> SelectByLastLogin(System.DateTime dt)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserFields.LastLogin == dt);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntity> users = new EntityCollection<UserEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(users, bucket);
            return users;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="ouid">The Owner UID of the requested entity.</param>
        /// <returns>EntityCollection<UserEntity></returns>
        public static EntityCollection<UserEntity> SelectByOwnerUID(System.Int32 ouid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(UserFields.OwnerUID == ouid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<UserEntity> users = new EntityCollection<UserEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(users, bucket);
            return users;
        }

        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a UserEntity in the storage area.
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="username">Username</param>
        /// <param name="usernamelower">Username Lower</param>
        /// <param name="password">Password</param>
        /// <param name="canexpire">Can Expire Flag</param>
        /// <param name="expirydate">Expiry Date</param>
        /// <param name="isdisabled">Is Disabled Flag</param>
        /// <param name="issystemadmin">Is System Admin Flag</param>
        /// <param name="emailaddress">Email Address</param>
        /// <param name="lastlogin">Last login</param>
        /// <param name="owneruid">Owner Unique ID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(
            int uid,
            System.Int32 siteuid,
            System.String username,
            System.String usernamelower,
            System.String password,
            System.Boolean canexpire,
            System.DateTime expirydate,
            System.Boolean isdisabled,
            System.Boolean issystemadmin,
            System.String emailaddress,
            System.DateTime lastlogin, 
            System.Int32 owneruid)
        {
            UserEntity user = new UserEntity();
            user.UID = uid;
            user.SiteUID = siteuid;
            user.UserName = username;
            user.UserNameLower = usernamelower;
            user.Password = password;
            user.CanExpire = canexpire;
            user.ExpiryDate = expirydate;
            user.IsDisabled = isdisabled;
            user.IsSystemAdmin = issystemadmin;
            user.EmailAddress = emailaddress;
            user.LastLogin = lastlogin;
            user.OwnerUID = owneruid;

            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(user);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an UserEntity.
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(int uid)
        {
            UserEntity user = new UserEntity(uid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(user);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an UserEntity.
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="username">Username</param>
        /// <param name="usernamelower">Username Lower</param>
        /// <param name="password">Password</param>
        /// <param name="canexpire">Can Expire Flag</param>
        /// <param name="expirydate">Expiry Date</param>
        /// <param name="isdisabled">Is Disabled Flag</param>
        /// <param name="issystemadmin">Is System Admin Flag</param>
        /// <param name="emailaddress">Email Address</param>
        /// <param name="lastlogin">Last login</param>
        /// <param name="owneruid">Owner Unique ID</param>       
        /// <returns>True on success, False on fail</returns>
        public static bool Update(
            System.Int16 uid,
            System.Int32 siteuid,
            System.String username,
            System.String usernamelower,
            System.String password,
            System.Boolean canexpire,
            System.DateTime expirydate,
            System.Boolean isdisabled,
            System.Boolean issystemadmin,
            System.String emailaddress,
            System.DateTime lastlogin,
            System.Int32 owneruid)
        {
            UserEntity user = new UserEntity(uid);
            user.IsNew = false;
            user.UID = uid;
            user.SiteUID = siteuid;
            user.UserName = username;
            user.UserNameLower = usernamelower;
            user.Password = password;
            user.CanExpire = canexpire;
            user.ExpiryDate = expirydate;
            user.IsDisabled = isdisabled;
            user.IsSystemAdmin = issystemadmin;
            user.EmailAddress = emailaddress;
            user.LastLogin = lastlogin;
            user.OwnerUID = owneruid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(user);
        }
        #endregion

    }
}