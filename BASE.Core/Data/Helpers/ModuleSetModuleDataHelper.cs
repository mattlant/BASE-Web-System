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
    /// This class is used to offer bindable function and others tools functions to manage the ModuleSetModuleEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class ModuleSetModuleDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single ModuleSetModuleEntity by it Primary Key
        /// </summary>
        /// <param name="moduleSetGUID">Module Set Global Unique ID</param>
        /// <param name="moduleDefinitionGUID">Module Definition Global Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static ModuleSetModuleEntity SelectSingle(Guid moduleSetGUID, Guid moduleDefinitionGUID)
        {
            ModuleSetModuleEntity modulesetmodule = new ModuleSetModuleEntity(moduleSetGUID, moduleDefinitionGUID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(modulesetmodule) == true)
            {
                return modulesetmodule;
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
        /// <returns>EntityCollection<ModuleSetModuleEntity></returns>
        public static EntityCollection<ModuleSetModuleEntity> Select()
        {
            EntityCollection<ModuleSetModuleEntity> mse = new EntityCollection<ModuleSetModuleEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(mse, null);
            return mse;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="msguid">The Module Set GUID of the requested entity.</param>
        /// <param name="defguid">The Module Definition GUID of the requested entity.</param>
        /// <returns>EntityCollection<ModuleSetModuleEntity></returns>
        public static EntityCollection<ModuleSetModuleEntity> Select(System.Guid msguid, System.Guid defguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleSetModuleFields.ModuleSetGUID == msguid);
            filter.Add(ModuleSetModuleFields.ModuleDefinitionGUID == defguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleSetModuleEntity> mse = new EntityCollection<ModuleSetModuleEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(mse, bucket);
            return mse;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="msguid">The Module Set GUID of the requested entity.</param>
        /// <param name="defguid">The Module Definition GUID of the requested entity.</param>
        /// <param name="instancesallowed">The Instances Allowed of the requested entity.</param> 
        /// <returns>EntityCollection<ModuleSetModuleEntity></returns>
        public static EntityCollection<ModuleSetModuleEntity> Select(System.Guid msguid, System.Guid defguid, System.Int32 instancesallowed)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleSetModuleFields.ModuleSetGUID == msguid);
            filter.Add(ModuleSetModuleFields.ModuleDefinitionGUID == defguid);
            filter.Add(ModuleSetModuleFields.InstancesAllowed == instancesallowed);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleSetModuleEntity> mse = new EntityCollection<ModuleSetModuleEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(mse, bucket);
            return mse;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="msguid">The Module Set GUID of the requested entity.</param>
        /// <returns>EntityCollection<ModuleSetModuleEntity></returns>
        public static EntityCollection<ModuleSetModuleEntity> SelectByModuleSetGUID(System.Guid msguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleSetModuleFields.ModuleSetGUID == msguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleSetModuleEntity> mse = new EntityCollection<ModuleSetModuleEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(mse, bucket);
            return mse;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="defguid">The Module Definition GUID of the requested entity.</param>
        /// <returns>EntityCollection<ModuleSetModuleEntity></returns>
        public static EntityCollection<ModuleSetModuleEntity> SelectByModuleDefinitionGUID(System.Guid defguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleSetModuleFields.ModuleDefinitionGUID == defguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleSetModuleEntity> mse = new EntityCollection<ModuleSetModuleEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(mse, bucket);
            return mse;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="instancesallowed">The Instances Allowed of the requested entity.</param>
        /// <returns>EntityCollection<ModuleSetModuleEntity></returns>
        public static EntityCollection<ModuleSetModuleEntity> SelectByInstancesAllowed(System.Int32 instancesallowed)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ModuleSetModuleFields.InstancesAllowed == instancesallowed);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ModuleSetModuleEntity> mse = new EntityCollection<ModuleSetModuleEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(mse, bucket);
            return mse;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a ModuleSetModuleEntity in the storage area.
        /// </summary>
        /// <param name="modulesetguid">The Module Set GUID of the requested entity.</param>
        /// <param name="moduledefinitionguid">The Module Definition GUID of the requested entity.</param>
        /// <param name="instancesallowed">The Instances Allowed of the requested entity.</param> 
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(System.Guid modulesetguid, System.Guid moduledefinitionguid, System.Int32 instancesallowed)
        {
            ModuleSetModuleEntity mse = new ModuleSetModuleEntity();
            mse.ModuleSetGUID = modulesetguid;
            mse.ModuleDefinitionGUID = moduledefinitionguid;
            mse.InstancesAllowed = instancesallowed;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(mse);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an ModuleSetModuleEntity.
        /// </summary>
        /// <param name="modulesetguid">The Module Set GUID of the requested entity.</param>
        /// <param name="moduledefinitionguid">The Module Definition GUID of the requested entity.</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Guid modulesetguid, System.Guid moduledefinitionguid)
        {
            ModuleSetModuleEntity mse = new ModuleSetModuleEntity(modulesetguid, moduledefinitionguid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(mse);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an ModuleSetModuleEntity.
        /// </summary>
        /// <param name="modulesetguid">The Module Set GUID of the requested entity.</param>
        /// <param name="moduledefinitionguid">The Module Definition GUID of the requested entity.</param>
        /// <param name="instancesallowed">The Instances Allowed of the requested entity.</param> 
        /// <returns>True on success, False on fail</returns>
        public static bool Update(System.Guid modulesetguid, System.Guid moduledefinitionguid, System.Int32 instancesallowed)
        {
            ModuleSetModuleEntity mse = new ModuleSetModuleEntity(modulesetguid, moduledefinitionguid);
            mse.IsNew = false;
            mse.ModuleSetGUID = modulesetguid;
            mse.ModuleDefinitionGUID = moduledefinitionguid;
            mse.InstancesAllowed = instancesallowed;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(mse);
        }
        #endregion
    }
}
