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
    /// This class is used to offer bindable function and others tools functions to manage the LinkEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class LinkDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single LinkEntity by it Primary Key
        /// </summary>
        /// <param name="uID">Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static LinkEntity SelectSingle(int uID)
        {
            LinkEntity link = new LinkEntity(uID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(link) == true)
            {
                return link;
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
        /// <returns>EntityCollection<LinkEntity></returns>
        public static EntityCollection<LinkEntity> Select()
        {
            EntityCollection<LinkEntity> links = new EntityCollection<LinkEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(links, null);
            return links;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="uid">The UID of the requested entity.</param>
        /// <returns>EntityCollection<LinkEntity></returns>
        public static EntityCollection<LinkEntity> SelectByUID(System.Int32 uid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(LinkFields.UID == uid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<LinkEntity> links = new EntityCollection<LinkEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(links, bucket);
            return links;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="dname">The Display Name of the requested entity.</param>
        /// <returns>EntityCollection<LinkEntity></returns>
        public static EntityCollection<LinkEntity> SelectByDisplayName(System.String dname)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(LinkFields.DisplayName == dname);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<LinkEntity> links = new EntityCollection<LinkEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(links, bucket);
            return links;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="name">The Name of the requested entity.</param>
        /// <returns>EntityCollection<LinkEntity></returns>
        public static EntityCollection<LinkEntity> SelectByName(System.String name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(LinkFields.Name == name);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<LinkEntity> links = new EntityCollection<LinkEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(links, bucket);
            return links;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="navigateurl">The Navigate URL of the requested entity.</param>
        /// <returns>EntityCollection<LinkEntity></returns>
        public static EntityCollection<LinkEntity> SelectByNavigateURL(System.String navigateurl)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(LinkFields.NavigateURL == navigateurl);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<LinkEntity> links = new EntityCollection<LinkEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(links, bucket);
            return links;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="isdisabled">The Is Disabled Flag of the requested entity.</param>
        /// <returns>EntityCollection<LinkEntity></returns>
        public static EntityCollection<LinkEntity> SelectByIsDisabled(System.Boolean isdisabled)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(LinkFields.IsDisabled == isdisabled);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<LinkEntity> links = new EntityCollection<LinkEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(links, bucket);
            return links;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="isvisibleloggedinonly">The Is Visible Logged In Only Flag of the requested entity.</param>
        /// <returns>EntityCollection<LinkEntity></returns>
        public static EntityCollection<LinkEntity> SelectByIsVisibleLoggedInOnly(System.Boolean isvisibleloggedinonly)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(LinkFields.IsVisibleLoggedInOnly == isvisibleloggedinonly);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<LinkEntity> links = new EntityCollection<LinkEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(links, bucket);
            return links;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="tuid">The Entity Type UID of the requested entity.</param>
        /// <returns>EntityCollection<LinkEntity></returns>
        public static EntityCollection<LinkEntity> SelectByEntityTypeUID(System.Int32 tuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(LinkFields.EntityTypeUID == tuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<LinkEntity> links = new EntityCollection<LinkEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(links, bucket);
            return links;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="eruid">The Entity Record UID of the requested entity.</param>
        /// <returns>EntityCollection<LinkEntity></returns>
        public static EntityCollection<LinkEntity> SelectByEntityRecordUID(System.Int32 eruid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(LinkFields.EntityRecordUID == eruid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<LinkEntity> links = new EntityCollection<LinkEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(links, bucket);
            return links;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="dorder">The Display Order of the requested entity.</param>
        /// <returns>EntityCollection<LinkEntity></returns>
        public static EntityCollection<LinkEntity> SelectByDisplayOrder(System.Int32 dorder)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(LinkFields.DisplayOrder == dorder);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<LinkEntity> links = new EntityCollection<LinkEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(links, bucket);
            return links;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="lbuid">The Link Bar UID Order of the requested entity.</param>
        /// <returns>EntityCollection<LinkEntity></returns>
        public static EntityCollection<LinkEntity> SelectByLinkBarUID(System.Int32 lbuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(LinkFields.LinkBarUID == lbuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<LinkEntity> links = new EntityCollection<LinkEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(links, bucket);
            return links;
        }

        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a LinkEntity in the storage area.
        /// </summary>
        /// <param name="linkbaruid">LinkBar UID</param>
        /// <param name="name">Name</param>
        /// <param name="displayname">Display Name</param>
        /// <param name="navurl">Navigate URL</param>
        /// <param name="isdisabled">Is Disabled Flag</param>
        /// <param name="isvisibleloggedinonly">Is Visible Logged In Only flag</param>
        /// <param name="etuid">Entity Type UID</param>
        /// <param name="eruid">Entity Record UID</param>
        /// <param name="displayorder">Display Order</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(
            System.Int32 linkbaruid,
            System.String name,
            System.String displayname,
            System.String navurl,
            System.Boolean isdisabled,
            System.Boolean isvisibleloggedinonly,
            System.Int32 etuid,
            System.Int32 eruid,
            System.Int32 displayorder)
        {
            LinkEntity le = new LinkEntity();
            le.LinkBarUID = linkbaruid;
            le.DisplayName = displayname;
            le.Name = name;
            le.NavigateURL = navurl;
            le.IsDisabled = isdisabled;
            le.IsVisibleLoggedInOnly = isvisibleloggedinonly;
            le.EntityTypeUID = etuid;
            le.EntityRecordUID = eruid;
            le.DisplayOrder = displayorder;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(le);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an LinkEntity.
        /// </summary>
        /// <param name="uid">Unique ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Int32 uid)
        {
            LinkEntity le = new LinkEntity(uid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(le);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an LinkEntity.
        /// </summary>
        /// <param name="uid">Unique ID</param>
        /// <param name="linkbaruid">LinkBar UID</param>
        /// <param name="name">Name</param>
        /// <param name="displayname">Display Name</param>
        /// <param name="navurl">Navigate URL</param>
        /// <param name="isdisabled">Is Disabled Flag</param>
        /// <param name="isvisibleloggedinonly">Is Visible Logged In Only flag</param>
        /// <param name="etuid">Entity Type UID</param>
        /// <param name="eruid">Entity Record UID</param>
        /// <param name="displayorder">Display Order</param>        
        /// <returns>True on success, False on fail</returns>
        public static bool Update(
            System.Int32 uid,
            System.Int32 linkbaruid,
            System.String name,
            System.String displayname,
            System.String navurl,
            System.Boolean isdisabled,
            System.Boolean isvisibleloggedinonly,
            System.Int32 etuid,
            System.Int32 eruid,
            System.Int32 displayorder            
            )
        {
            LinkEntity le = new LinkEntity(uid);
            le.IsNew = false;
            le.LinkBarUID = linkbaruid;
            le.DisplayName = displayname;
            le.Name = name;
            le.NavigateURL = navurl;
            le.IsDisabled = isdisabled;
            le.IsVisibleLoggedInOnly = isvisibleloggedinonly;
            le.EntityTypeUID = etuid;
            le.EntityRecordUID = eruid;
            le.DisplayOrder = displayorder;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(le);
        }
        #endregion
    }
}
