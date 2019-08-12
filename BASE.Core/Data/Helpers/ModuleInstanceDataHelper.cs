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
    /// This class is used to offer bindable function and others tools functions to manage the ModuleInstanceEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class ModuleInstanceDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single ModuleInstanceEntity by it Primary Key
        /// </summary>
        /// <param name="uID">Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static ModuleInstanceEntity SelectSingle(int uID)
        {
            ModuleInstanceEntity moduleinstance = new ModuleInstanceEntity(uID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(moduleinstance) == true)
            {
                return moduleinstance;
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
        /// <returns>EntityCollection<ModuleInstanceEntity></returns>
        public static EntityCollection<ModuleInstanceEntity> Select()
        {
            EntityCollection<ModuleInstanceEntity> modulesinstances = new EntityCollection<ModuleInstanceEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(modulesinstances, null);
            return modulesinstances;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="uid">The UID of the requested entity.</param>
        /// <returns>EntityCollection<ModuleInstanceEntity></returns>
        public static EntityCollection<ModuleInstanceEntity> SelectByUID(System.Int32 uid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleInstanceFields.UID == uid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleInstanceEntity> modulesinstances = new EntityCollection<ModuleInstanceEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(modulesinstances, bucket);
            return modulesinstances;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="suid">The Site UID of the requested entity.</param>
        /// <returns>EntityCollection<ModuleInstanceEntity></returns>
        public static EntityCollection<ModuleInstanceEntity> SelectBySiteUID(System.Int32 suid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleInstanceFields.SiteUID == suid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleInstanceEntity> modulesinstances = new EntityCollection<ModuleInstanceEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(modulesinstances, bucket);
            return modulesinstances;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="mdguid">The Module Definition GUID of the requested entity.</param>
        /// <returns>EntityCollection<ModuleInstanceEntity></returns>
        public static EntityCollection<ModuleInstanceEntity> SelectByModuleDefinitionGUID(System.Guid mdguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleInstanceFields.ModuleDefinitionGUID == mdguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleInstanceEntity> modulesinstances = new EntityCollection<ModuleInstanceEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(modulesinstances, bucket);
            return modulesinstances;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="islocked">The Is Locked Flag of the requested entity.</param>
        /// <returns>EntityCollection<ModuleInstanceEntity></returns>
        public static EntityCollection<ModuleInstanceEntity> SelectByIsLocked(System.Boolean islocked)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleInstanceFields.IsLocked == islocked);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleInstanceEntity> modulesinstances = new EntityCollection<ModuleInstanceEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(modulesinstances, bucket);
            return modulesinstances;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="isreadonly">The Is Read Only Flag of the requested entity.</param>
        /// <returns>EntityCollection<ModuleInstanceEntity></returns>
        public static EntityCollection<ModuleInstanceEntity> SelectByIsReadOnly(System.Boolean isreadonly)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleInstanceFields.IsReadOnly == isreadonly);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleInstanceEntity> modulesinstances = new EntityCollection<ModuleInstanceEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(modulesinstances, bucket);
            return modulesinstances;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="sv">The System Visibility of the requested entity.</param>
        /// <returns>EntityCollection<ModuleInstanceEntity></returns>
        public static EntityCollection<ModuleInstanceEntity> SelectBySystemVisibility(System.Byte sv)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleInstanceFields.SystemVisibility == sv);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleInstanceEntity> modulesinstances = new EntityCollection<ModuleInstanceEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(modulesinstances, bucket);
            return modulesinstances;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="nametag">The Name Tag of the requested entity.</param>
        /// <returns>EntityCollection<ModuleInstanceEntity></returns>
        public static EntityCollection<ModuleInstanceEntity> SelectByNameTag(System.String nametag)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleInstanceFields.NameTag == nametag);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleInstanceEntity> modulesinstances = new EntityCollection<ModuleInstanceEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(modulesinstances, bucket);
            return modulesinstances;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="dt">The Create Time of the requested entity.</param>
        /// <returns>EntityCollection<ModuleInstanceEntity></returns>
        public static EntityCollection<ModuleInstanceEntity> SelectByCreateTime(System.DateTime dt)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleInstanceFields.CreateTime == dt);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleInstanceEntity> modulesinstances = new EntityCollection<ModuleInstanceEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(modulesinstances, bucket);
            return modulesinstances;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="usuid">The Create User UID of the requested entity.</param>
        /// <returns>EntityCollection<ModuleInstanceEntity></returns>
        public static EntityCollection<ModuleInstanceEntity> SelectByCreateUserUID(System.Int32 usuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleInstanceFields.CreateUserUID == usuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleInstanceEntity> modulesinstances = new EntityCollection<ModuleInstanceEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(modulesinstances, bucket);
            return modulesinstances;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="dt">The Edit Time of the requested entity.</param>
        /// <returns>EntityCollection<ModuleInstanceEntity></returns>
        public static EntityCollection<ModuleInstanceEntity> SelectByEditTime(System.DateTime dt)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleInstanceFields.EditTime == dt);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleInstanceEntity> modulesinstances = new EntityCollection<ModuleInstanceEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(modulesinstances, bucket);
            return modulesinstances;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="usuid">The Edit User UID of the requested entity.</param>
        /// <returns>EntityCollection<ModuleInstanceEntity></returns>
        public static EntityCollection<ModuleInstanceEntity> SelectByEditUserUID(System.Int32 usuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleInstanceFields.EditUserUID == usuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleInstanceEntity> modulesinstances = new EntityCollection<ModuleInstanceEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(modulesinstances, bucket);
            return modulesinstances;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a ModuleInstanceEntity in the storage area.
        /// </summary>
        /// <param name="siteuid">Site UID</param>
        /// <param name="moduledefinitionguid">Module Definition GUID</param>
        /// <param name="islocked">Is Locked Flag</param>
        /// <param name="isreadonly">Is Read Only Flag</param>
        /// <param name="systemvisibility">System Visibility</param>
        /// <param name="nametag">Name Tag</param>
        /// <param name="createtime">Create Time</param>
        /// <param name="createuseruid">Create User UID</param>
        /// <param name="edittime">Edit Time</param>
        /// <param name="edituseruid">Edit User UID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(
            System.Int32 siteuid,
            System.Guid moduledefinitionguid,
            System.Boolean islocked,
            System.Boolean isreadonly,
            System.Byte systemvisibility,
            System.String nametag,
            System.DateTime createtime,
            System.Int32 createuseruid,
            System.DateTime edittime,
            System.Int32 edituseruid)
        {
            ModuleInstanceEntity md = new ModuleInstanceEntity();
            md.SiteUID = siteuid;
            md.ModuleDefinitionGUID = moduledefinitionguid;
            md.IsLocked = islocked;
            md.IsReadOnly = isreadonly;
            md.SystemVisibility = systemvisibility;
            md.NameTag = nametag;
            md.CreateTime = createtime;
            md.CreateUserUID = createuseruid;
            md.EditTime = edittime;
            md.EditUserUID = edituseruid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(md);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an ModuleInstanceEntity.
        /// </summary>
        /// <param name="uid">Unique ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Int32 uid)
        {
            ModuleInstanceEntity md = new ModuleInstanceEntity(uid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(md);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an ModuleInstanceEntity.
        /// </summary>
        /// <param name="uid">Unique ID</param>
        /// <param name="siteuid">Site UID</param>
        /// <param name="moduledefinitionguid">Module Definition GUID</param>
        /// <param name="islocked">Is Locked Flag</param>
        /// <param name="isreadonly">Is Read Only Flag</param>
        /// <param name="systemvisibility">System Visibility</param>
        /// <param name="nametag">Name Tag</param>
        /// <param name="createtime">Create Time</param>
        /// <param name="createuseruid">Create User UID</param>
        /// <param name="edittime">Edit Time</param>
        /// <param name="edituseruid">Edit User UID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(
            System.Int32 uid,
            System.Int32 siteuid,
            System.Guid moduledefinitionguid,
            System.Boolean islocked,
            System.Boolean isreadonly,
            System.Byte systemvisibility,
            System.String nametag,
            System.DateTime createtime,
            System.Int32 createuseruid,
            System.DateTime edittime,
            System.Int32 edituseruid)
        {
            ModuleInstanceEntity md = new ModuleInstanceEntity(uid);
            md.IsNew = false;
            md.SiteUID = siteuid;
            md.ModuleDefinitionGUID = moduledefinitionguid;
            md.IsLocked = islocked;
            md.IsReadOnly = isreadonly;
            md.SystemVisibility = systemvisibility;
            md.NameTag = nametag;
            md.CreateTime = createtime;
            md.CreateUserUID = createuseruid;
            md.EditTime = edittime;
            md.EditUserUID = edituseruid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(md);
        }
        #endregion
    }
}
