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
    /// This class is used to offer bindable function and others tools functions to manage the SiteNetInfoEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class SiteNetInfoDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single SiteNetInfoEntity by it Primary Key
        /// </summary>
        /// <param name="siteUID">Site Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static SiteNetInfoEntity SelectSingle(int siteUID)
        {
            SiteNetInfoEntity snie = new SiteNetInfoEntity(siteUID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(snie) == true)
            {
                return snie;
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
        /// <returns>EntityCollection<SiteNetInfoEntity></returns>
        public static EntityCollection<SiteNetInfoEntity> Select()
        {
            EntityCollection<SiteNetInfoEntity> sitenetinfo = new EntityCollection<SiteNetInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitenetinfo, null);
            return sitenetinfo;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="siteuid">The SiteUID of the requested entity.</param>
        /// <returns>EntityCollection<SiteNetInfoEntity></returns>
        public static EntityCollection<SiteNetInfoEntity> SelectBySiteUID(int siteuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteNetInfoFields.SiteUID == siteuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteNetInfoEntity> sitenetinfo = new EntityCollection<SiteNetInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitenetinfo, bucket);
            return sitenetinfo;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="smtps">The SMTPServer of the requested entity.</param>
        /// <returns>EntityCollection<SiteNetInfoEntity></returns>
        public static EntityCollection<SiteNetInfoEntity> SelectBySMTPServer(System.String smtps)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteNetInfoFields.SMTPServer == smtps);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteNetInfoEntity> sitenetinfo = new EntityCollection<SiteNetInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitenetinfo, bucket);
            return sitenetinfo;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="ns">The NameServer of the requested entity.</param>
        /// <returns>EntityCollection<SiteNetInfoEntity></returns>
        public static EntityCollection<SiteNetInfoEntity> SelectByNameServer(System.String ns)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteNetInfoFields.NameServer == ns);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteNetInfoEntity> sitenetinfo = new EntityCollection<SiteNetInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitenetinfo, bucket);
            return sitenetinfo;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="iprange">The Internal IP Range of the requested entity.</param>
        /// <returns>EntityCollection<SiteNetInfoEntity></returns>
        public static EntityCollection<SiteNetInfoEntity> SelectByInternalIPRange(System.String iprange)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteNetInfoFields.InternalIPRange == iprange);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteNetInfoEntity> sitenetinfo = new EntityCollection<SiteNetInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitenetinfo, bucket);
            return sitenetinfo;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="feedbackemail">The Feedback Email of the requested entity.</param>
        /// <returns>EntityCollection<SiteNetInfoEntity></returns>
        public static EntityCollection<SiteNetInfoEntity> SelectByFeedbackEmail(System.String feedbackemail)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteNetInfoFields.FeedbackEmail == feedbackemail);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteNetInfoEntity> sitenetinfo = new EntityCollection<SiteNetInfoEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sitenetinfo, bucket);
            return sitenetinfo;
        } 
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a SiteNetInfoEntity in the storage area.
        /// </summary>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="allowinternalaccess">Allow Internal Access Flag</param>
        /// <param name="allowexternalaccess">Allow External Access Flag</param>
        /// <param name="smtpserver">SMTP Server</param>
        /// <param name="nameserver">Name Server</param>
        /// <param name="internaliprange">Internal IP Range</param>
        /// <param name="feedbackemail">FeedBack Email</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(
            int siteuid,
            bool allowinternalaccess,
            bool allowexternalaccess,
            string smtpserver,
            string nameserver,
            string internaliprange,
            string feedbackemail
            )
        {
            SiteNetInfoEntity siteinfos = new SiteNetInfoEntity();
            siteinfos.SiteUID = siteuid;
            siteinfos.AllowInternalAccess = allowinternalaccess;
            siteinfos.AllowExternalAccess = allowexternalaccess;
            siteinfos.SMTPServer = smtpserver;
            siteinfos.NameServer = nameserver;
            siteinfos.InternalIPRange = internaliprange;
            siteinfos.FeedbackEmail = feedbackemail;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(siteinfos);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an SiteNetInfoEntity.
        /// </summary>
        /// <param name="siteuid">Site Unique ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(int siteuid)
        {
            SiteNetInfoEntity siteinfo = new SiteNetInfoEntity(siteuid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(siteinfo);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an SiteNetInfoEntity.
        /// </summary>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="allowinternalaccess">Allow Internal Access Flag</param>
        /// <param name="allowexternalaccess">Allow External Access Flag</param>
        /// <param name="smtpserver">SMTP Server</param>
        /// <param name="nameserver">Name Server</param>
        /// <param name="internaliprange">Internal IP Range</param>
        /// <param name="feedbackemail">FeedBack Email</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(
            int siteuid,
            bool allowinternalaccess,
            bool allowexternalaccess,
            string smtpserver,
            string nameserver,
            string internaliprange,
            string feedbackemail
            )
        {
            SiteNetInfoEntity siteinfos = new SiteNetInfoEntity(siteuid);
            siteinfos.IsNew = false;
            siteinfos.SiteUID = siteuid;
            siteinfos.AllowInternalAccess = allowinternalaccess;
            siteinfos.AllowExternalAccess = allowexternalaccess;
            siteinfos.SMTPServer = smtpserver;
            siteinfos.NameServer = nameserver;
            siteinfos.InternalIPRange = internaliprange;
            siteinfos.FeedbackEmail = feedbackemail;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(siteinfos);
        }
        #endregion
    }
}