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
    /// This class is used to offer bindable function and others tools functions to manage the TemplateEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class TemplateDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single TemplateEntity by it Primary Key
        /// </summary>
        /// <param name="gUID">Global Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static TemplateEntity SelectSingle(Guid gUID)
        {
            TemplateEntity template = new TemplateEntity(gUID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(template) == true)
            {
                return template;
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
        /// <returns>EntityCollection<TemplateEntity></returns>
        public static EntityCollection<TemplateEntity> Select()
        {
            EntityCollection<TemplateEntity> templates = new EntityCollection<TemplateEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templates, null);
            return templates;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="guid">The GUID of the requested entity.</param>
        /// <returns>EntityCollection<TemplateEntity></returns>
        public static EntityCollection<TemplateEntity> SelectByGUID(System.Guid guid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateFields.GUID == guid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateEntity> templates = new EntityCollection<TemplateEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templates, bucket);
            return templates;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="siteuid">The Site UID of the requested entity.</param>
        /// <returns>EntityCollection<TemplateEntity></returns>
        public static EntityCollection<TemplateEntity> SelectBySiteUID(System.Int32 siteuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateFields.SiteUID == siteuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateEntity> templates = new EntityCollection<TemplateEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templates, bucket);
            return templates;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="siteuid">The Site UID of the requested entity.</param>
        /// <param name="templatetypeuid">The Template Type UID of the requested entity.</param>
        /// <returns>EntityCollection<TemplateEntity></returns>
        public static EntityCollection<TemplateEntity> SelectBySiteUIDTemplateTypeUID(System.Int32 siteuid, int templatetypeuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateFields.SiteUID == siteuid);
            filter.Add(TemplateFields.TemplateTypeUID == templatetypeuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateEntity> templates = new EntityCollection<TemplateEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templates, bucket);
            return templates;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="ttuid">The Template Type UID of the requested entity.</param>
        /// <returns>EntityCollection<TemplateEntity></returns>
        public static EntityCollection<TemplateEntity> SelectByTemplateTypeUID(System.Int32 ttuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateFields.TemplateTypeUID == ttuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateEntity> templates = new EntityCollection<TemplateEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templates, bucket);
            return templates;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="flag">The Is Locked Flag of the requested entity.</param>
        /// <returns>EntityCollection<TemplateEntity></returns>
        public static EntityCollection<TemplateEntity> SelectByIsLocked(System.Boolean flag)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateFields.IsLocked == flag);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateEntity> templates = new EntityCollection<TemplateEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templates, bucket);
            return templates;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="flag">The Is Builtin Flag of the requested entity.</param>
        /// <returns>EntityCollection<TemplateEntity></returns>
        public static EntityCollection<TemplateEntity> SelectByIsBuiltin(System.Boolean flag)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateFields.IsBuiltin == flag);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateEntity> templates = new EntityCollection<TemplateEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templates, bucket);
            return templates;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="name">The Name of the requested entity.</param>
        /// <returns>EntityCollection<TemplateEntity></returns>
        public static EntityCollection<TemplateEntity> SelectByName(System.String name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateFields.Name == name);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateEntity> templates = new EntityCollection<TemplateEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templates, bucket);
            return templates;
        }


        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="displayname">The DisplayName of the requested entity.</param>
        /// <returns>EntityCollection<TemplateEntity></returns>
        public static EntityCollection<TemplateEntity> SelectByDisplayName(System.String displayname)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateFields.DisplayName == displayname);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateEntity> templates = new EntityCollection<TemplateEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templates, bucket);
            return templates;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="ceatetime">The Create Time of the requested entity.</param>
        /// <returns>EntityCollection<TemplateEntity></returns>
        public static EntityCollection<TemplateEntity> SelectByCreateTime(System.DateTime ceatetime)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateFields.CreateTime == ceatetime);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateEntity> templates = new EntityCollection<TemplateEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templates, bucket);
            return templates;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="edittime">The Edit Time of the requested entity.</param>
        /// <returns>EntityCollection<TemplateEntity></returns>
        public static EntityCollection<TemplateEntity> SelectByEditTime(System.DateTime edittime)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateFields.EditTime == edittime);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateEntity> templates = new EntityCollection<TemplateEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templates, bucket);
            return templates;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="createuseruid">The Create User UID of the requested entity.</param>
        /// <returns>EntityCollection<TemplateEntity></returns>
        public static EntityCollection<TemplateEntity> SelectByCreateUserUID(System.Int32 createuseruid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateFields.CreateUserUID == createuseruid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateEntity> templates = new EntityCollection<TemplateEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templates, bucket);
            return templates;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="edituseruid">The Edit User UID of the requested entity.</param>
        /// <returns>EntityCollection<TemplateEntity></returns>
        public static EntityCollection<TemplateEntity> SelectByEditUserUID(System.Int32 edituseruid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateFields.EditUserUID == edituseruid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateEntity> templates = new EntityCollection<TemplateEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templates, bucket);
            return templates;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="ouid">The Owner UID of the requested entity.</param>
        /// <returns>EntityCollection<TemplateEntity></returns>
        public static EntityCollection<TemplateEntity> SelectByOwnerUID(System.Int32 ouid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateFields.OwnerUID == ouid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateEntity> templates = new EntityCollection<TemplateEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templates, bucket);
            return templates;
        }

        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a TemplateEntity in the storage area.
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="templatetypeuid">Template Type Unique ID</param>
        /// <param name="name">Name</param>
        /// <param name="displayname">Display Name</param>
        /// <param name="description">Description</param>
        /// <param name="islocked">Is Locked Flag</param>
        /// <param name="isbuiltin">Is Builtin Flag</param>
        /// <param name="htmltext">HTML Text</param>
        /// <param name="createtime">Create Time</param>
        /// <param name="createuseruid">Create User UID</param>
        /// <param name="edittime">Edit Time</param>
        /// <param name="edituseruid">Edit User UID</param>
        /// <param name="owneruid">Owner Unique ID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(
            System.Guid guid,
            System.Int32 siteuid,
            System.Int32 templatetypeuid,
            System.String name,
            System.String displayname,
            System.String description, 
            System.Boolean islocked,
            System.Boolean isbuiltin,
            System.DateTime createtime, 
            System.Int32 createuseruid, 
            System.DateTime edittime, 
            System.Int32 edituseruid,
            System.Int32 owneruid)
        {
            TemplateEntity template = new TemplateEntity();
            template.GUID = guid;
            template.SiteUID = siteuid;
            template.TemplateTypeUID = templatetypeuid;
            template.Name = name;
            template.DisplayName = displayname;
            template.Description = description;
            template.IsLocked = islocked;
            template.IsBuiltin = isbuiltin;
            template.CreateTime = createtime;
            template.CreateUserUID = createuseruid;
            template.EditTime = edittime;
            template.EditUserUID = edituseruid;
            template.OwnerUID = owneruid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(template);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an TemplateEntity.
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Guid guid)
        {
            TemplateEntity template = new TemplateEntity(guid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(template);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an TemplateEntity.
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="templatetypeuid">Template Type Unique ID</param>
        /// <param name="name">Name</param>
        /// <param name="displayname">Display Name</param>
        /// <param name="description">Description</param>
        /// <param name="islocked">Is Locked Flag</param>
        /// <param name="isbuiltin">Is Builtin Flag</param>
        /// <param name="htmltext">HTML Text</param>
        /// <param name="createtime">Create Time</param>
        /// <param name="createuseruid">Create User UID</param>
        /// <param name="edittime">Edit Time</param>
        /// <param name="edituseruid">Edit User UID</param>
        /// <param name="owneruid">Owner Unique ID</param>       
        /// <returns>True on success, False on fail</returns>
        public static bool Update(
            System.Guid guid,
            System.Int32 siteuid,
            System.Int32 templatetypeuid,
            System.String name,
            System.String displayname,
            System.String description,
            System.Boolean islocked,
            System.Boolean isbuiltin,
            System.DateTime createtime,
            System.Int32 createuseruid,
            System.DateTime edittime,
            System.Int32 edituseruid,
            System.Int32 owneruid            
            )
        {
            TemplateEntity template = new TemplateEntity(guid);
            template.IsNew = false;
            template.GUID = guid;
            template.SiteUID = siteuid;
            template.TemplateTypeUID = templatetypeuid;
            template.Name = name;
            template.DisplayName = displayname;
            template.Description = description;
            template.IsLocked = islocked;
            template.IsBuiltin = isbuiltin;
            template.CreateTime = createtime;
            template.CreateUserUID = createuseruid;
            template.EditTime = edittime;
            template.EditUserUID = edituseruid;
            template.OwnerUID = owneruid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(template);
        }
        #endregion
    }
}