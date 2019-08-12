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
    /// This class is used to offer bindable function and others tools functions to manage the SiteModuleSetListEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class SiteModuleSetListDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single SiteModuleSetListEntity by it Primary Key
        /// </summary>
        /// <param name="siteUID">Site Unique ID</param>
        /// <param name="moduleSetGUID">Module Set Global Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static SiteModuleSetListEntity SelectSingle(int siteUID, Guid moduleSetGUID)
        {
            SiteModuleSetListEntity smsle = new SiteModuleSetListEntity(siteUID, moduleSetGUID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(smsle) == true)
            {
                return smsle;
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
        /// <returns>EntityCollection<SiteModuleSetListEntity></returns>
        public static EntityCollection<SiteModuleSetListEntity> Select()
        {
            EntityCollection<SiteModuleSetListEntity> sitemodulesetlists = new EntityCollection<SiteModuleSetListEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitemodulesetlists, null);
            return sitemodulesetlists;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="siteuid">The Site UID of the requested entity.</param>
        /// <param name="modulesetguid">The Module Set GUID of the requested entity.</param>
        /// <returns>EntityCollection<SiteModuleSetListEntity></returns>
        public static EntityCollection<SiteModuleSetListEntity> Select(System.Int32 siteuid, System.Guid modulesetguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteModuleSetListFields.SiteUID == siteuid);
            filter.Add(SiteModuleSetListFields.ModuleSetGUID == modulesetguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteModuleSetListEntity> sitemodulesetlists = new EntityCollection<SiteModuleSetListEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitemodulesetlists, bucket);
            return sitemodulesetlists;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="siteuid">The Site UID of the requested entity.</param>
        /// <returns>EntityCollection<SiteModuleSetListEntity></returns>
        public static EntityCollection<SiteModuleSetListEntity> SelectBySiteUID(System.Int32 siteuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteModuleSetListFields.SiteUID == siteuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteModuleSetListEntity> sitemodulesetlists = new EntityCollection<SiteModuleSetListEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitemodulesetlists, bucket);
            return sitemodulesetlists;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="modulesetguid">The Module Set GUID of the requested entity.</param>
        /// <returns>EntityCollection<SiteModuleSetListEntity></returns>
        public static EntityCollection<SiteModuleSetListEntity> SelectByModuleSetGUID(System.Guid modulesetguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteModuleSetListFields.ModuleSetGUID == modulesetguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteModuleSetListEntity> sitemodulesetlists = new EntityCollection<SiteModuleSetListEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitemodulesetlists, bucket);
            return sitemodulesetlists;
        }

        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a SiteModuleSetListEntity in the storage area.
        /// </summary>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="modulesetguid">Module Set GUID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(System.Int32 siteuid, System.Guid modulesetguid)
        {
            SiteModuleSetListEntity smsle = new SiteModuleSetListEntity();
            smsle.SiteUID = siteuid;
            smsle.ModuleSetGUID = modulesetguid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(smsle);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an SiteModuleSetListEntity.
        /// </summary>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="modulesetguid">Module Set GUID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Int32 siteuid, System.Guid modulesetguid)
        {
            SiteModuleSetListEntity smsle = new SiteModuleSetListEntity(siteuid, modulesetguid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(smsle);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an SiteModuleSetListEntity.
        /// </summary>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="modulesetguid">Module Set GUID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(System.Int32 siteuid, System.Guid modulesetguid)
        {
            SiteModuleSetListEntity smsle = new SiteModuleSetListEntity(siteuid, modulesetguid);
            smsle.IsNew = false;
            smsle.SiteUID = siteuid;
            smsle.ModuleSetGUID = modulesetguid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(smsle);
        }
        #endregion
    }
}
