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
    /// This class is used to offer bindable function and others tools functions to manage the SiteVirtualInfoEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class SiteVirtualInfoDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single SiteVirtualInfoEntity by it Primary Key
        /// </summary>
        /// <param name="siteUID">Site Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static SiteVirtualInfoEntity SelectSingle(int siteUID)
        {
            SiteVirtualInfoEntity svie = new SiteVirtualInfoEntity(siteUID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(svie) == true)
            {
                return svie;
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
        /// <returns>EntityCollection<SiteVirtualInfoEntity></returns>
        public static EntityCollection<SiteVirtualInfoEntity> Select()
        {
            EntityCollection<SiteVirtualInfoEntity> siteinfos = new EntityCollection<SiteVirtualInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(siteinfos, null);
            return siteinfos;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="siteuid">The SiteUID of the requested entity.</param>
        /// <returns>EntityCollection<SiteVirtualInfoEntity></returns>
        public static EntityCollection<SiteVirtualInfoEntity> SelectBySiteUID(int siteuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteVirtualInfoFields.SiteUID == siteuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteVirtualInfoEntity> siteinfos = new EntityCollection<SiteVirtualInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(siteinfos, bucket);
            return siteinfos;
        }



        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="etuid">The EnforcedTemplateUID of the requested entity.</param>
        /// <returns>EntityCollection<SiteVirtualInfoEntity></returns>
        public static EntityCollection<SiteVirtualInfoEntity> SelectByIsEnforcedTemplate(bool isEnforced)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteVirtualInfoFields.IsEnforcedTemplate == isEnforced);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteVirtualInfoEntity> siteinfos = new EntityCollection<SiteVirtualInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(siteinfos, bucket);
            return siteinfos;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="isphysicalsite">The IsPhysicalSite Flag of the requested entity.</param>
        /// <returns>EntityCollection<SiteVirtualInfoEntity></returns>
        public static EntityCollection<SiteVirtualInfoEntity> SelectByIsPhysicalSite(bool isphysicalsite)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteVirtualInfoFields.IsPhysicalSite == isphysicalsite);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteVirtualInfoEntity> siteinfos = new EntityCollection<SiteVirtualInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(siteinfos, bucket);
            return siteinfos;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="tguid">The TemplateGUID of the requested entity.</param>
        /// <returns>EntityCollection<SiteVirtualInfoEntity></returns>
        public static EntityCollection<SiteVirtualInfoEntity> SelectByTemplateGUID(Guid tguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteVirtualInfoFields.TemplateGUID == tguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteVirtualInfoEntity> siteinfos = new EntityCollection<SiteVirtualInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(siteinfos, bucket);
            return siteinfos;
        }

        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a SiteVirtualInfoEntity in the storage area.
        /// </summary>
        /// <param name="siteuid">Site Unique ID</param>
		/// <param name="domainname">Domain Name</param>
		/// <param name="subsitename">SubSite Name</param>
		/// <param name="virtualroot">Virtual Root</param>
        /// <param name="isphysicalsite">Is Physical Flag</param>
        /// <param name="defaultsection">Default Section</param>
        /// <param name="defaultpage">Default Page</param>
        /// <param name="loginpage">Login Page</param>
        /// <param name="templateguid">Template GUID</param>
        /// <param name="enforcedtemplateuid">Enforced Template UID</param>
        /// <param name="pagetitleprefix">Page Title Prefix</param>
        /// <param name="pagetitlesuffix">Page Title Suffix</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(
            int siteuid,
			string domainname,
			string subsitename,
			string virtualroot,
			bool isphysicalsite,
            int defaultsection,
            int defaultpage,
            int loginpage,
            Guid templateguid,
            bool isEnforcedTemplate,
            string pagetitleprefix,
            string pagetitlesuffix
            )
        {
            SiteVirtualInfoEntity siteinfos = new SiteVirtualInfoEntity();
            siteinfos.SiteUID = siteuid;
			siteinfos.DomainName = domainname;
			siteinfos.SubSiteName = subsitename;
			siteinfos.VirtualRoot = virtualroot;
			siteinfos.IsPhysicalSite = isphysicalsite;
            siteinfos.DefaultSection = defaultsection;
            siteinfos.DefaultPage = defaultpage;
            siteinfos.LoginPage = loginpage;
            siteinfos.TemplateGUID = templateguid;
            siteinfos.IsEnforcedTemplate = isEnforcedTemplate;
            siteinfos.PageTitlePrefix = pagetitleprefix;
            siteinfos.PageTitleSuffix = pagetitlesuffix;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(siteinfos);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an SiteVirtualInfoEntity.
        /// </summary>
        /// <param name="siteuid">Site Unique ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(int siteuid)
        {
            SiteVirtualInfoEntity siteinfo = new SiteVirtualInfoEntity(siteuid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(siteinfo);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an SiteVirtualInfoEntity.
        /// </summary>
        /// <param name="siteuid">Site Unique ID</param>
		/// <param name="domainname">Domain Name</param>
		/// <param name="subsitename">SubSite Name</param>
		/// <param name="virtualroot">Virtual Root</param>
		/// <param name="isphysicalsite">Is Physical Flag</param>
        /// <param name="defaultsection">Default Section</param>
        /// <param name="defaultpage">Default Page</param>
        /// <param name="loginpage">Login Page</param>
        /// <param name="templateguid">Template GUID</param>
        /// <param name="enforcedtemplateuid">Enforced Template UID</param>
        /// <param name="pagetitleprefix">Page Title Prefix</param>
        /// <param name="pagetitlesuffix">Page Title Suffix</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(
            int siteuid,
			string domainname,
			string subsitename,
			string virtualroot,
            bool isphysicalsite,
            int defaultsection,
            int defaultpage,
            int loginpage,
            Guid templateguid,
            bool isEnforcedTemplate,
            string pagetitleprefix,
            string pagetitlesuffix
            )
        {
            SiteVirtualInfoEntity siteinfos = new SiteVirtualInfoEntity(siteuid);
            siteinfos.IsNew = false;
            siteinfos.SiteUID = siteuid;
			siteinfos.DomainName = domainname;
			siteinfos.SubSiteName = subsitename;
			siteinfos.VirtualRoot = virtualroot;
            siteinfos.IsPhysicalSite = isphysicalsite;
            siteinfos.DefaultSection = defaultsection;
            siteinfos.DefaultPage = defaultpage;
            siteinfos.LoginPage = loginpage;
            siteinfos.TemplateGUID = templateguid;
            siteinfos.IsEnforcedTemplate = isEnforcedTemplate;
            siteinfos.PageTitlePrefix = pagetitleprefix;
            siteinfos.PageTitleSuffix = pagetitlesuffix;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(siteinfos);
        }
        #endregion
    }
}