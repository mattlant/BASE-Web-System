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
    /// This class is used to offer bindable function and others tools functions to manage the SiteTypeEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class SiteTypeDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single SiteTypeEntity by it Primary Key
        /// </summary>
        /// <param name="uID">Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static SiteTypeEntity SelectSingle(int uID)
        {
            SiteTypeEntity ste = new SiteTypeEntity(uID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(ste) == true)
            {
                return ste;
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
        /// <returns>EntityCollection<SiteTypeEntity></returns>
        public static EntityCollection<SiteTypeEntity> Select()
        {
            EntityCollection<SiteTypeEntity> sitestype = new EntityCollection<SiteTypeEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitestype, null);
            return sitestype;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="uid">The UID of the requested entity.</param>
        /// <returns>EntityCollection<SiteTypeEntity></returns>
        public static EntityCollection<SiteTypeEntity> SelectByUID(System.Int32 uid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteTypeFields.UID == uid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteTypeEntity> sitestype = new EntityCollection<SiteTypeEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitestype, bucket);
            return sitestype;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="name">The Name of the requested entity.</param>
        /// <returns>EntityCollection<SiteTypeEntity></returns>
        public static EntityCollection<SiteTypeEntity> SelectByName(System.String name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteTypeFields.Name == name);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteTypeEntity> sitestype = new EntityCollection<SiteTypeEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitestype, bucket);
            return sitestype;
        }

        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a SiteTypeEntity in the storage area.
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(System.String name)
        {
            SiteTypeEntity ste = new SiteTypeEntity();
            ste.Name = name;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(ste);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an SiteTypeEntity.
        /// </summary>
        /// <param name="uid">Unique ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Int32 uid)
        {
            SiteTypeEntity ste = new SiteTypeEntity(uid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(ste);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an SiteTypeEntity.
        /// </summary>
        /// <param name="uid">Unique ID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(System.Int32 uid, System.String name)
        {
            SiteTypeEntity ste = new SiteTypeEntity(uid);
            ste.IsNew = false;
            ste.Name = name;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(ste);
        }
        #endregion
    }
}
