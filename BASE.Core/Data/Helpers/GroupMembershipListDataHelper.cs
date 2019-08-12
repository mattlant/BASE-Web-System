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
    /// This class is used to offer bindable function and others tools functions to manage the GroupMembershipListEntity
    /// </summary>
    public static class GroupMembershipListDataHelper
    {
        /// <summary>
        /// This method is used to retreive a single GroupMembershipListEntity by it Primary Key
        /// </summary>
        /// <param name="userUID">User Unique ID</param>
        /// <param name="groupUID">Group Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static GroupMembershipListEntity SelectSingle(int userUID, int groupUID)
        {
            GroupMembershipListEntity bmle = new GroupMembershipListEntity(userUID, groupUID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(bmle) == true)
            {
                return bmle;
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
        /// <returns>EntityCollection<GroupMembershipListEntity></returns>
        public static EntityCollection<GroupMembershipListEntity> Select()
        {
            EntityCollection<GroupMembershipListEntity> bmle = new EntityCollection<GroupMembershipListEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(bmle, null);
            return bmle;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="userUID">The User Unique ID of the requested entity.</param>
        /// <returns>EntityCollection<GroupMembershipListEntity></returns>
        public static EntityCollection<GroupMembershipListEntity> SelectByUserUID(int userUID)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupMembershipListFields.UserUID == userUID);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupMembershipListEntity> bmle = new EntityCollection<GroupMembershipListEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(bmle, bucket);
            return bmle;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="groupUID">The Group Unique ID of the requested entity.</param>
        /// <returns>EntityCollection<GroupMembershipListEntity></returns>
        public static EntityCollection<GroupMembershipListEntity> SelectByGroupUID(int groupUID)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(GroupMembershipListFields.GroupUID == groupUID);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<GroupMembershipListEntity> bmle = new EntityCollection<GroupMembershipListEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(bmle, bucket);
            return bmle;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a GroupMembershipListEntity in the storage area.
        /// </summary>
        /// <param name="userUID">User Unique ID</param>
        /// <param name="groupUID">Group Unique ID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(int userUID, int groupUID)
        {
            GroupMembershipListEntity gmle = new GroupMembershipListEntity();
            gmle.UserUID = userUID;
            gmle.GroupUID = groupUID;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(gmle);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an GroupMembershipListEntity.
        /// </summary>
        /// <param name="userUID">User Unique ID</param>
        /// <param name="groupUID">Group Unique ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(int userUID, int groupUID)
        {
            GroupMembershipListEntity gmle = new GroupMembershipListEntity(userUID, groupUID);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(gmle);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an GroupMembershipListEntity.
        /// </summary>
        /// <param name="userUID">User Unique ID</param>
        /// <param name="groupUID">Group Unique ID</param>      
        /// <returns>True on success, False on fail</returns>
        public static bool Update(int userUID, int groupUID)
        {
            GroupMembershipListEntity gmle = new GroupMembershipListEntity(userUID, groupUID);
            gmle.IsNew = false;
            gmle.UserUID = userUID;
            gmle.GroupUID = groupUID;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(gmle);
        }
        #endregion
    }
}
