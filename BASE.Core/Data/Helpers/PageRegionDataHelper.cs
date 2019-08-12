/* Author: Mattlant Consulting
 * Creator: Steve Arbour
 * This source file is part of the BASE Web Framework System
 * Date: 27 August 2007
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
    /// This class is used to offer bindable function and others tools functions to manage the PageRegionEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class PageRegionDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single PageRegionEntity by it Primary Key
        /// </summary>
        /// <param name="pageUID">Page Unique ID</param>
        /// <param name="regionId">Region ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static PageRegionEntity SelectSingle(int pageUID, string regionId)
        {
            PageRegionEntity pr = new PageRegionEntity(pageUID, regionId);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(pr) == true)
            {
                return pr;
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
        /// <returns>EntityCollection<PageRegionEntity></returns>
        public static EntityCollection<PageRegionEntity> Select()
        {
            EntityCollection<PageRegionEntity> prs = new EntityCollection<PageRegionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(prs, null);
            return prs;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a PageRegionEntity in the storage area.
        /// </summary>
        /// <param name="pageUID">Page Unique ID</param>
        /// <param name="regionId">Region ID</param>
        /// <param name="regionContent">Region Content</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(
            int pageUID,
            string regionId,
            string regionContent)
        {
            PageRegionEntity pr = new PageRegionEntity();
            pr.PageUID = pageUID;
            pr.RegionContent = regionContent;
            pr.RegionId = regionId;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(pr);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an PageRegionEntity.
        /// </summary>
        /// <param name="pageUID">Page Unique ID</param>
        /// <param name="regionId">Region ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(int pageUID, string regionId)
        {
            PageRegionEntity pr = new PageRegionEntity(pageUID, regionId);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(pr);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an PageRegionEntity.
        /// </summary>
        /// <param name="pageUID">Page Unique ID</param>
        /// <param name="regionId">Region ID</param>
        /// <param name="regionContent">Region Content</param>        
        /// <returns>True on success, False on fail</returns>
        public static bool Update(int pageUID, string regionId, string regionContent)
        {
            PageRegionEntity pr = new PageRegionEntity(pageUID, regionId);
            pr.IsNew = false;
            pr.PageUID = pageUID;
            pr.RegionContent = regionContent;
            pr.RegionId = regionId;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(pr);
        }
        #endregion
    }
}
