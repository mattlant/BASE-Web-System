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
    /// This class is used to offer bindable function and others tools functions to manage the CustomPermissionTypeEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class CustomPermissionTypeDataHelper
    {
        /// <summary>
        /// This method is used to retreive a single CustomPermissionTypeEntity by it Primary Key
        /// </summary>
        /// <param name="gUID">Global Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static CustomPermissionTypeEntity SelectSingle(Guid gUID)
        {
            CustomPermissionTypeEntity cpte = new CustomPermissionTypeEntity(gUID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(cpte) == true)
            {
                return cpte;
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
        /// <returns>EntityCollection<CustomPermissionTypeEntity></returns>
        public static EntityCollection<CustomPermissionTypeEntity> Select()
        {
            EntityCollection<CustomPermissionTypeEntity> permissionstypes = new EntityCollection<CustomPermissionTypeEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissionstypes, null);
            return permissionstypes;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>EntityCollection<CustomPermissionTypeEntity></returns>
        public static EntityCollection<CustomPermissionTypeEntity> SelectByName(System.String name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomPermissionTypeFields.Name == name);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomPermissionTypeEntity> permissionstypes = new EntityCollection<CustomPermissionTypeEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissionstypes, bucket);
            return permissionstypes;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="guid">The Guid</param>
        /// <returns>EntityCollection<CustomPermissionTypeEntity></returns>
        public static EntityCollection<CustomPermissionTypeEntity> SelectByGUID(System.Guid guid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomPermissionTypeFields.GUID == guid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomPermissionTypeEntity> permissionstypes = new EntityCollection<CustomPermissionTypeEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(permissionstypes, bucket);
            return permissionstypes;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert an CustomPermissionTypeEntity in the storage area.
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <param name="name">Name</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(System.Guid guid, System.String name)
        {
            CustomPermissionTypeEntity cpte = new CustomPermissionTypeEntity();
            cpte.GUID = guid;
            cpte.Name = name;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(cpte);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an CustomPermissionTypeEntity.
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Guid guid)
        {
            CustomPermissionTypeEntity cpte = new CustomPermissionTypeEntity(guid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(cpte);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an CustomPermissionTypeEntity.
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <param name="name">Name</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(System.Guid guid, System.String name)
        {
            CustomPermissionTypeEntity cpte = new CustomPermissionTypeEntity(guid);
            cpte.IsNew = false;
            cpte.GUID = guid;
            cpte.Name = name;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(cpte);
        }
        #endregion
    }
}
