/* Author: Steve Arbour
 * This source file is part of the BASE Web Framework System
 * Date: 24 July 2007
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
    /// This class is used to offer bindable function and others tools functions to manage the AttachmentList Entity.
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class AttachmentListDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single AttachmentListEntity by it Primary Key
        /// </summary>
        /// <param name="parentUID">Parent Unique ID</param>
        /// <param name="parentEntityTypeGUID">Parent Entity Type Global Unique ID</param>
        /// <param name="childUID">Child Unique ID</param>
        /// <param name="childEntityTypeGUID">Child Entity Type Global Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static AttachmentListEntity SelectSingle(int parentUID, Guid parentEntityTypeGUID, int childUID, Guid childEntityTypeGUID)
        {
            AttachmentListEntity attachmentlist = new AttachmentListEntity(parentUID, parentEntityTypeGUID, childUID, childEntityTypeGUID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(attachmentlist) == true)
            {
                return attachmentlist;
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
        /// <returns>EntityCollection<AttachmentListEntity></returns>
        public static EntityCollection<AttachmentListEntity> Select()
        {
            EntityCollection<AttachmentListEntity> attachments = new EntityCollection<AttachmentListEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(attachments, null);
            return attachments;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="parentuid">The Parent Unique ID of the requested AttachmentList Entity.</param>
        /// <returns>EntityCollection<AttachmentListEntity></returns>
        public static EntityCollection<AttachmentListEntity> SelectByParentUID(System.Int32 parentuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(AttachmentListFields.ParentUID == parentuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<AttachmentListEntity> attachments = new EntityCollection<AttachmentListEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(attachments, bucket);
            return attachments;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="childuid">The Child Unique ID of the requested AttachmentList Entity.</param>
        /// <returns>EntityCollection<AttachmentListEntity></returns>
        public static EntityCollection<AttachmentListEntity> SelectByChildUID(System.Int32 childuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(AttachmentListFields.ChildUID == childuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<AttachmentListEntity> attachments = new EntityCollection<AttachmentListEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(attachments, bucket);
            return attachments;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="parentguid">The Parent GUID of the requested AttachmentList Entity.</param>
        /// <returns>EntityCollection<AttachmentListEntity></returns>
        public static EntityCollection<AttachmentListEntity> SelectByParentGUID(System.Guid parentguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(AttachmentListFields.ParentEntityTypeGUID == parentguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<AttachmentListEntity> attachments = new EntityCollection<AttachmentListEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(attachments, bucket);
            return attachments;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="childguid">The Child GUID of the requested AttachmentList Entity.</param>
        /// <returns>EntityCollection<AttachmentListEntity></returns>
        public static EntityCollection<AttachmentListEntity> SelectByChildGUID(System.Guid childguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(AttachmentListFields.ChildEntityTypeGUID == childguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<AttachmentListEntity> attachments = new EntityCollection<AttachmentListEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(attachments, bucket);
            return attachments;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a AttachmentList Entity in the storage area.
        /// </summary>
        /// <param name="parentuid">The Parent Unique ID of the AttachmentList Entity.</param>
        /// <param name="childuid">The Child Unique ID of the AttachmentList Entity.</param>
        /// <param name="parentguid">The Parent GUID of the AttachmentList Entity.</param>
        /// <param name="childguid">The Child GUID of the AttachmentList Entity.</param>
        /// <returns>True on success, False on fail.</returns>
        public static bool Insert(System.Int32 parentuid, System.Int32 childuid, System.Guid parentguid, System.Guid childguid)
        {
            AttachmentListEntity attachment = new AttachmentListEntity();
            attachment.ChildUID = childuid;
            attachment.ParentUID = parentuid;
            attachment.ChildEntityTypeGUID = childguid;
            attachment.ParentEntityTypeGUID = parentguid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(attachment);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an AttachmentList Entity.
        /// </summary>
        /// <param name="parentuid">The Parent Unique ID of the AttachmentList Entity.</param>
        /// <param name="childuid">The Child Unique ID of the AttachmentList Entity.</param>
        /// <param name="parentguid">The Parent GUID of the AttachmentList Entity.</param>
        /// <param name="childguid">The Child GUID of the AttachmentList Entity.</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Int32 parentuid, System.Int32 childuid, System.Guid parentguid, System.Guid childguid)
        {
            AttachmentListEntity attachment = new AttachmentListEntity(parentuid, parentguid, childuid, childguid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(attachment);
        }
        #endregion

    }
}
