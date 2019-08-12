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
    /// This class is used to offer bindable function and others tools functions to manage the ModuleSetEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class ModuleSetDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single ModuleSetEntity by it Primary Key
        /// </summary>
        /// <param name="gUID">Global Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static ModuleSetEntity SelectSingle(Guid gUID)
        {
            ModuleSetEntity moduleset = new ModuleSetEntity(gUID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(moduleset) == true)
            {
                return moduleset;
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
        /// <returns>EntityCollection<ModuleSetEntity></returns>
        public static EntityCollection<ModuleSetEntity> Select()
        {
            EntityCollection<ModuleSetEntity> mse = new EntityCollection<ModuleSetEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(mse, null);
            return mse;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="guid">The GUID of the requested entity.</param>
        /// <returns>EntityCollection<ModuleSetEntity></returns>
        public static EntityCollection<ModuleSetEntity> SelectByGUID(System.Guid guid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleSetFields.GUID == guid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleSetEntity> mse = new EntityCollection<ModuleSetEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(mse, bucket);
            return mse;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="name">The Name of the requested entity.</param>
        /// <returns>EntityCollection<ModuleSetEntity></returns>
        public static EntityCollection<ModuleSetEntity> SelectByName(System.String name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleSetFields.Name == name);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleSetEntity> mse = new EntityCollection<ModuleSetEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(mse, bucket);
            return mse;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="description">The Description of the requested entity.</param>
        /// <returns>EntityCollection<ModuleSetEntity></returns>
        public static EntityCollection<ModuleSetEntity> SelectByDescription(System.String description)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleSetFields.Description == description);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleSetEntity> mse = new EntityCollection<ModuleSetEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(mse, bucket);
            return mse;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="isbuiltin">The IsBuiltin Flag of the requested entity.</param>
        /// <returns>EntityCollection<ModuleSetEntity></returns>
        public static EntityCollection<ModuleSetEntity> SelectByIsBuiltin(System.Boolean isbuiltin)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleSetFields.IsBuiltIn == isbuiltin);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleSetEntity> mse = new EntityCollection<ModuleSetEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(mse, bucket);
            return mse;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a ModuleSetEntity in the storage area.
        /// </summary>
        /// <param name="name">The Name</param>
        /// <param name="description">The Description</param>
        /// <param name="isbuiltin">The Is Built-In Flag</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(System.String name, System.String description, System.Boolean isbuiltin)
        {
            ModuleSetEntity mse = new ModuleSetEntity();
            mse.Description = description;
            mse.Name = name;
            mse.IsBuiltIn = isbuiltin;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(mse);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an ModuleSetEntity.
        /// </summary>
        /// <param name="guid">The GUID of the requested entity.</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Guid guid)
        {
            ModuleSetEntity mse = new ModuleSetEntity(guid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(mse);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an ModuleSetEntity.
        /// </summary>
        /// <param name="guid">GUID of the Entity</param>
        /// <param name="name">The Name</param>
        /// <param name="description">The Description</param>
        /// <param name="isbuiltin">The Is Built-In Flag</param>        
        /// <returns>True on success, False on fail</returns>
        public static bool Update(System.Guid guid, System.String name, System.String description, System.Boolean isbuiltin)
        {
            ModuleSetEntity mse = new ModuleSetEntity(guid);
            mse.IsNew = false;
            mse.Description = description;
            mse.Name = name;
            mse.IsBuiltIn = isbuiltin;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(mse);
        }
        #endregion
    }
}
