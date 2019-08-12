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
    /// This class is used to offer bindable function and others tools functions to manage the PageEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class PageDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single PageEntity by it Primary Key
        /// </summary>
        /// <param name="uID">Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static PageEntity SelectSingle(int uID)
        {
            PageEntity page = new PageEntity(uID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(page) == true)
            {
                return page;
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
        /// <returns>EntityCollection<PageEntity></returns>
        public static EntityCollection<PageEntity> Select()
        {
            EntityCollection<PageEntity> pages = new EntityCollection<PageEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(pages, null);
            return pages;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="uid">The UID of the requested entity.</param>
        /// <returns>EntityCollection<PageEntity></returns>
        public static EntityCollection<PageEntity> SelectByUID(System.Int32 uid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PageFields.UID == uid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<PageEntity> pages = new EntityCollection<PageEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(pages, bucket);
            return pages;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="systemvisibility">The System Visibility of the requested entity.</param>
        /// <returns>EntityCollection<PageEntity></returns>
        public static EntityCollection<PageEntity> SelectBySystemVisibility(System.Byte systemvisibility)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PageFields.SystemVisibility == systemvisibility);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<PageEntity> pages = new EntityCollection<PageEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(pages, bucket);
            return pages;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="sectionuid">The Section UID of the requested entity.</param>
        /// <returns>EntityCollection<PageEntity></returns>
        public static EntityCollection<PageEntity> SelectBySectionUID(System.Int32 sectionuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PageFields.SectionUID == sectionuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<PageEntity> pages = new EntityCollection<PageEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(pages, bucket);
            return pages;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="templateguid">The Template GUID of the requested entity.</param>
        /// <returns>EntityCollection<PageEntity></returns>
        public static EntityCollection<PageEntity> SelectByTemplateGUID(System.Guid templateguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PageFields.TemplateGUID == templateguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<PageEntity> pages = new EntityCollection<PageEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(pages, bucket);
            return pages;
        }



        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="isdisabled">The Is Disabled Flag of the requested entity.</param>
        /// <returns>EntityCollection<PageEntity></returns>
        public static EntityCollection<PageEntity> SelectByIsDisabled(System.Boolean isdisabled)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PageFields.IsDisabled == isdisabled);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<PageEntity> pages = new EntityCollection<PageEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(pages, bucket);
            return pages;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="islocked">The Is Locked Flag of the requested entity.</param>
        /// <returns>EntityCollection<PageEntity></returns>
        public static EntityCollection<PageEntity> SelectByIsLocked(System.Boolean islocked)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PageFields.IsLocked == islocked);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<PageEntity> pages = new EntityCollection<PageEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(pages, bucket);
            return pages;
        }



        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="friendlyurl">The Friendly URL of the requested entity.</param>
        /// <returns>EntityCollection<PageEntity></returns>
        public static EntityCollection<PageEntity> SelectByFriendlyURL(System.String friendlyurl)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PageFields.FriendlyURL == friendlyurl);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<PageEntity> pages = new EntityCollection<PageEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(pages, bucket);
            return pages;
        }


        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="disableredirecturl">The Disable Redirect URL of the requested entity.</param>
        /// <returns>EntityCollection<PageEntity></returns>
        public static EntityCollection<PageEntity> SelectByDisableRedirectURL(System.String disableredirecturl)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PageFields.DisableRedirectURL == disableredirecturl);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<PageEntity> pages = new EntityCollection<PageEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(pages, bucket);
            return pages;
        }


        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="owneruid">The OwnerUID of the requested entity.</param>
        /// <returns>EntityCollection<PageEntity></returns>
        public static EntityCollection<PageEntity> SelectByOwnerUID(System.Int32 owneruid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PageFields.OwnerUID == owneruid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<PageEntity> pages = new EntityCollection<PageEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(pages, bucket);
            return pages;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="rowversion">The Row Version of the requested entity.</param>
        /// <returns>EntityCollection<PageEntity></returns>
        public static EntityCollection<PageEntity> SelectByRowVersion(System.Byte[] rowversion)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(PageFields.RowVersion == rowversion);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<PageEntity> pages = new EntityCollection<PageEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(pages, bucket);
            return pages;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a PageEntity in the storage area.
        /// </summary>
        /// <param name="systemvisibility">System Visibility</param>
        /// <param name="sectionuid">Section UID</param>
        /// <param name="templateguid">Template GUID</param>
        /// <param name="htmlcontent">HTML Content</param>
        /// <param name="isdisabled">Is Disabled</param>
        /// <param name="islocked">Is Locked</param>
        /// <param name="publishdate">Publish Date</param>
        /// <param name="expiredate">Expire Date</param>
        /// <param name="friendlyurl">Friendly URL</param>
        /// <param name="expireredirecturl">Expire Redirect URL</param>
        /// <param name="disableredirecturl">Disable Redirect URL</param>
        /// <param name="createtime">Create Time</param>
        /// <param name="createuseruid">Create User UID</param>
        /// <param name="edittime">Edit Time</param>
        /// <param name="edituseruid">Edit User UID</param>
        /// <param name="owneruid">Owner UID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(
            System.Byte systemvisibility,
            System.Int32 sectionuid,
            System.Guid templateguid,
            System.Boolean isdisabled,
            System.Boolean islocked,
            System.DateTime publishdate,
            System.DateTime expiredate,
            System.String friendlyurl,
            System.String expireredirecturl,
            System.String disableredirecturl,
            System.Int32 owneruid)
        {
            PageEntity page = new PageEntity();
            page.SystemVisibility = systemvisibility;
            page.SectionUID = sectionuid;
            page.TemplateGUID = templateguid;
            page.IsDisabled = isdisabled;
            page.IsLocked = islocked;
            page.PublishDate = publishdate;
            page.ExpireDate = expiredate;
            page.FriendlyURL = friendlyurl;
            page.ExpireRedirectURL = expireredirecturl;
            page.DisableRedirectURL = disableredirecturl;
            page.OwnerUID = owneruid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(page);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an PageEntity.
        /// </summary>
        /// <param name="uid">Unique ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Int32 uid)
        {
            PageEntity page = new PageEntity(uid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(page);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an PageEntity.
        /// </summary>
        /// <param name="uid">Unique Page ID</param>
        /// <param name="systemvisibility">System Visibility</param>
        /// <param name="sectionuid">Section UID</param>
        /// <param name="templateguid">Template GUID</param>
        /// <param name="htmlcontent">HTML Content</param>
        /// <param name="isdisabled">Is Disabled</param>
        /// <param name="islocked">Is Locked</param>
        /// <param name="publishdate">Publish Date</param>
        /// <param name="expiredate">Expire Date</param>
        /// <param name="friendlyurl">Friendly URL</param>
        /// <param name="expireredirecturl">Expire Redirect URL</param>
        /// <param name="disableredirecturl">Disable Redirect URL</param>
        /// <param name="createtime">Create Time</param>
        /// <param name="createuseruid">Create User UID</param>
        /// <param name="edittime">Edit Time</param>
        /// <param name="edituseruid">Edit User UID</param>
        /// <param name="owneruid">Owner UID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(
            System.Int32 uid,
            System.Byte systemvisibility,
            System.Int32 sectionuid,
            System.Guid templateguid,
            System.String htmlcontent,
            System.Boolean isdisabled,
            System.Boolean islocked,
            System.DateTime publishdate,
            System.DateTime expiredate,
            System.String friendlyurl,
            System.String expireredirecturl,
            System.String disableredirecturl,
            System.Int32 owneruid)
        {
            PageEntity page = new PageEntity(uid);
            page.IsNew = false;
            page.SystemVisibility = systemvisibility;
            page.SectionUID = sectionuid;
            page.TemplateGUID = templateguid;
            page.IsDisabled = isdisabled;
            page.IsLocked = islocked;
            page.PublishDate = publishdate;
            page.ExpireDate = expiredate;
            page.FriendlyURL = friendlyurl;
            page.ExpireRedirectURL = expireredirecturl;
            page.DisableRedirectURL = disableredirecturl;
            page.OwnerUID = owneruid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(page);
        }
        #endregion
    }
}
