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
    /// This class is used to offer bindable function and others tools functions to manage the TemplateSetEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class TemplateSetDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single TemplateSetEntity by it Primary Key
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="siteUID">Site Unique ID</param>
        /// <param name="templateGUID">Template GUID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static TemplateSetEntity SelectSingle(string name, int siteUID, Guid templateGUID)
        {
            TemplateSetEntity tse = new TemplateSetEntity(name, siteUID, templateGUID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(tse) == true)
            {
                return tse;
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
        /// <returns>EntityCollection<TemplateSetEntity></returns>
        public static EntityCollection<TemplateSetEntity> Select()
        {
            EntityCollection<TemplateSetEntity> templatessets = new EntityCollection<TemplateSetEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templatessets, null);
            return templatessets;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="name">The Name of the requested entity.</param>
        /// <param name="siteuid">The Site Unique ID of the requested entity.</param>
        /// <param name="templateuid">The Template Unique ID of the requested entity.</param>
        /// <returns>EntityCollection<TemplateSetEntity></returns>
        public static EntityCollection<TemplateSetEntity> Select(System.String name, System.Int32 siteuid, System.Guid templateGuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateSetFields.Name == name);
            filter.Add(TemplateSetFields.SiteUID == siteuid);
            filter.Add(TemplateSetFields.TemplateGUID == templateGuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateSetEntity> templatessets = new EntityCollection<TemplateSetEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templatessets, bucket);
            return templatessets;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="name">The Name of the requested entity.</param>
        /// <returns>EntityCollection<TemplateSetEntity></returns>
        public static EntityCollection<TemplateSetEntity> SelectByName(System.String name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateSetFields.Name == name);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateSetEntity> templatessets = new EntityCollection<TemplateSetEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templatessets, bucket);
            return templatessets;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="siteuid">The Site Unique ID of the requested entity.</param>
        /// <returns>EntityCollection<TemplateSetEntity></returns>
        public static EntityCollection<TemplateSetEntity> SelectBySiteUID(System.Int32 siteuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateSetFields.SiteUID == siteuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateSetEntity> templatessets = new EntityCollection<TemplateSetEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templatessets, bucket);
            return templatessets;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="templateuid">The Template Unique ID of the requested entity.</param>
        /// <returns>EntityCollection<TemplateSetEntity></returns>
        public static EntityCollection<TemplateSetEntity> SelectByTemplateUID(System.Guid templateguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateSetFields.TemplateGUID == templateguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateSetEntity> templatessets = new EntityCollection<TemplateSetEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templatessets, bucket);
            return templatessets;
        }

        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a TemplateSetEntity in the storage area.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="templateuid">Template Unique ID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(System.String name, System.Int32 siteuid, System.Guid templateguid)
        {
            TemplateSetEntity templateset = new TemplateSetEntity();
            templateset.Name = name;
            templateset.SiteUID = siteuid;
            templateset.TemplateGUID = templateguid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(templateset);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an TemplateSetEntity.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="templateuid">Template Unique ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.String name, System.Int32 siteuid, System.Guid templateGuid)
        {
            TemplateSetEntity templateset = new TemplateSetEntity(name, siteuid, templateGuid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(templateset);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an TemplateSetEntity.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="templateuid">Template Unique ID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(System.String name, System.Int32 siteuid, System.Guid templateguid)
        {
            TemplateSetEntity templateset = new TemplateSetEntity(name, siteuid, templateguid);
            templateset.IsNew = false;
            templateset.Name = name;
            templateset.SiteUID = siteuid;
            templateset.TemplateGUID = templateguid; 
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(templateset);
        }
        #endregion
    }
}