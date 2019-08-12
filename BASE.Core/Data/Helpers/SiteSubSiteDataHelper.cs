/* Author: Steve Arbour
 * This source file is part of the BASE Web Framework System
 * Date: 31 July 2007
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
    /// This class is used to offer bindable function and others tools functions to manage the SiteSubSiteInfoEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class SiteSubSiteDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single SiteSubSiteInfoEntity by it Primary Key
        /// </summary>
        /// <param name="siteUID">Site Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static SiteSubSiteInfoEntity SelectSingle(int siteUID)
        {
            SiteSubSiteInfoEntity sssie = new SiteSubSiteInfoEntity(siteUID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(sssie) == true)
            {
                return sssie;
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
        /// <returns>EntityCollection<SiteSubSiteInfoEntity></returns>
        public static EntityCollection<SiteSubSiteInfoEntity> Select()
        {
            EntityCollection<SiteSubSiteInfoEntity> sitenetinfo = new EntityCollection<SiteSubSiteInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitenetinfo, null);
            return sitenetinfo;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="currentsubsitecount">The CurrentSubSiteCount of the requested entity.</param>
        /// <returns>EntityCollection<SiteSubSiteInfoEntity></returns>
        public static EntityCollection<SiteSubSiteInfoEntity> SelectByCurrentSubSiteCount(int currentsubsitecount)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteSubSiteInfoFields.CurrentSubSiteCount == currentsubsitecount);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteSubSiteInfoEntity> sitenetinfo = new EntityCollection<SiteSubSiteInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitenetinfo, bucket);
            return sitenetinfo;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="siteuid">The SiteUID of the requested entity.</param>
        /// <returns>EntityCollection<SiteSubSiteInfoEntity></returns>
        public static EntityCollection<SiteSubSiteInfoEntity> SelectBySiteUID(int siteuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteSubSiteInfoFields.SiteUID == siteuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteSubSiteInfoEntity> sitenetinfo = new EntityCollection<SiteSubSiteInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitenetinfo, bucket);
            return sitenetinfo;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="maxsubsites">The MaxSubSites of the requested entity.</param>
        /// <returns>EntityCollection<SiteSubSiteInfoEntity></returns>
        public static EntityCollection<SiteSubSiteInfoEntity> SelectByMaxSubSites(int maxsubsites)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteSubSiteInfoFields.MaxSubSites == maxsubsites);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteSubSiteInfoEntity> sitenetinfo = new EntityCollection<SiteSubSiteInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitenetinfo, bucket);
            return sitenetinfo;
        }

        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a SiteSubSiteInfoEntity in the storage area.
        /// </summary>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="currentsubsitecount">The CurrentSubSiteCount of the requested entity.</param>
        /// <param name="maxsubsites">The MaxSubSites of the requested entity.</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(
            int siteuid,
            int currentsubsitecount,
            int maxsubsites
            )
        {
            SiteSubSiteInfoEntity siteinfos = new SiteSubSiteInfoEntity();
            siteinfos.SiteUID = siteuid;
            siteinfos.CurrentSubSiteCount = currentsubsitecount;
            siteinfos.MaxSubSites = maxsubsites;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(siteinfos);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an SiteSubSiteInfoEntity.
        /// </summary>
        /// <param name="siteuid">Site Unique ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(int siteuid)
        {
            SiteSubSiteInfoEntity siteinfo = new SiteSubSiteInfoEntity(siteuid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(siteinfo);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an SiteSubSiteInfoEntity.
        /// </summary>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="currentsubsitecount">The CurrentSubSiteCount of the requested entity.</param>
        /// <param name="maxsubsites">The MaxSubSites of the requested entity.</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(
            int siteuid,
            int currentsubsitecount,
            int maxsubsites
            )
        {
            SiteSubSiteInfoEntity siteinfos = new SiteSubSiteInfoEntity(siteuid);
            siteinfos.IsNew = false;
            siteinfos.SiteUID = siteuid;
            siteinfos.CurrentSubSiteCount = currentsubsitecount;
            siteinfos.MaxSubSites = maxsubsites;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(siteinfos);
        }
        #endregion
    }
}