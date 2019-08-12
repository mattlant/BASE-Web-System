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
    /// This class is used to offer bindable function and others tools functions to manage the GroupEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class GroupDataHelper
    {
        /// <summary>
        /// This method is used to retreive a single GroupEntity by it Primary Key
        /// </summary>
        /// <param name="uID">Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static GroupEntity SelectSingle(int uID)
        {
            GroupEntity grp = new GroupEntity(uID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(grp) == true)
            {
                return grp;
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
        /// <returns>EntityCollection<GroupEntity></returns>
        public static EntityCollection<GroupEntity> Select()
        {
            EntityCollection<GroupEntity> ge = new EntityCollection<GroupEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ge, null);
            return ge;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="guid">The GUID of the requested entity.</param>
        /// <returns>EntityCollection<GroupEntity></returns>
        public static EntityCollection<GroupEntity> Select(System.Guid guid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupFields.GUID == guid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntity> ge = new EntityCollection<GroupEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ge, bucket);
            return ge;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="siteuid">The Site UID of the requested entity.</param>
        /// <returns>EntityCollection<GroupEntity></returns>
        public static EntityCollection<GroupEntity> SelectBySiteUID(System.Int32 siteuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupFields.SiteUID == siteuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntity> ge = new EntityCollection<GroupEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ge, bucket);
            return ge;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="name">The Name of the requested entity.</param>
        /// <returns>EntityCollection<GroupEntity></returns>
        public static EntityCollection<GroupEntity> SelectByName(System.String name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupFields.Name == name);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntity> ge = new EntityCollection<GroupEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ge, bucket);
            return ge;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="isbuiltin">The IsBuiltin Flag of the requested entity.</param>
        /// <returns>EntityCollection<GroupEntity></returns>
        public static EntityCollection<GroupEntity> SelectByIsBuiltin(System.Boolean isbuiltin)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupFields.IsBuiltin == isbuiltin);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntity> ge = new EntityCollection<GroupEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ge, bucket);
            return ge;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="ishidden">The IsHidden Flag of the requested entity.</param>
        /// <returns>EntityCollection<GroupEntity></returns>
        public static EntityCollection<GroupEntity> SelectByIsHidden(System.Boolean ishidden)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupFields.IsHidden == ishidden);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntity> ge = new EntityCollection<GroupEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ge, bucket);
            return ge;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="isdisabled">The IsDisabled Flag of the requested entity.</param>
        /// <returns>EntityCollection<GroupEntity></returns>
        public static EntityCollection<GroupEntity> SelectByIsDisabled(System.Boolean isdisabled)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupFields.IsDisabled == isdisabled);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntity> ge = new EntityCollection<GroupEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ge, bucket);
            return ge;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="emailaddress">The email address Flag of the requested entity.</param>
        /// <returns>EntityCollection<GroupEntity></returns>
        public static EntityCollection<GroupEntity> SelectByEmailAddress(System.String emailaddress)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupFields.EmailAddress == emailaddress);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntity> ge = new EntityCollection<GroupEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ge, bucket);
            return ge;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="owneruid">The Owner UID of the requested entity.</param>
        /// <returns>EntityCollection<GroupEntity></returns>
        public static EntityCollection<GroupEntity> SelectByOwnerID(System.Int32 owneruid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupFields.OwnerUID == owneruid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntity> ge = new EntityCollection<GroupEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ge, bucket);
            return ge;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="bytes">The Row Version of the requested entity.</param>
        /// <returns>EntityCollection<GroupEntity></returns>
        public static EntityCollection<GroupEntity> SelectByRowVersion(System.Byte[] bytes)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupFields.RowVersion == bytes);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupEntity> ge = new EntityCollection<GroupEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ge, bucket);
            return ge;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a GroupEntity in the storage area.
        /// </summary>
        /// <param name="siteuid">The site UID</param>
        /// <param name="name">The Name</param>
        /// <param name="isbuiltin">The Is Built-In Flag</param>
        /// <param name="ishidden">The Is Hidden Flag</param>
        /// <param name="isdisabled">The Is Disabled</param>
        /// <param name="emailaddress">The Email Address</param>
        /// <param name="owneruid">The Owner UID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(System.Int32 siteuid, System.String name, System.Boolean isbuiltin, System.Boolean ishidden, System.Boolean isdisabled, System.String emailaddress, System.Int32 owneruid)
        {
            GroupEntity ge = new GroupEntity();
            ge.SiteUID = siteuid;
            ge.Name = name;
            ge.IsBuiltin = isbuiltin;
            ge.IsHidden = ishidden;
            ge.IsDisabled = isdisabled;
            ge.EmailAddress = emailaddress;
            ge.OwnerUID = owneruid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(ge);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an GroupEntity.
        /// </summary>
        /// <param name="guid">The GUID of the requested entity.</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(int gUid)
        {
            GroupEntity ge = new GroupEntity(gUid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(ge);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an GroupEntity.
        /// </summary>
        /// <param name="guid">GUID of the Entity</param>
        /// <param name="siteuid">The site UID</param>
        /// <param name="name">The Name</param>
        /// <param name="isbuiltin">The Is Built-In Flag</param>
        /// <param name="ishidden">The Is Hidden Flag</param>
        /// <param name="isdisabled">The Is Disabled</param>
        /// <param name="emailaddress">The Email Address</param>
        /// <param name="owneruid">The Owner UID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(int guid, System.Int32 siteuid, System.String name, System.Boolean isbuiltin, System.Boolean ishidden, System.Boolean isdisabled, System.String emailaddress, System.Int32 owneruid)
        {
            GroupEntity ge = new GroupEntity(guid);
            ge.IsNew = false;
            ge.SiteUID = siteuid;
            ge.Name = name;
            ge.IsBuiltin = isbuiltin;
            ge.IsHidden = ishidden;
            ge.IsDisabled = isdisabled;
            ge.EmailAddress = emailaddress;
            ge.OwnerUID = owneruid;

            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(ge);
        }
        #endregion
    }
}
