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
    /// This class is used to offer bindable function and others tools functions to manage the EntityCustomPropertyEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class EntityCustomPropertyDataHelper
    {
        /// <summary>
        /// This method is used to retreive a single EntityCustomPropertyEntity by it Primary Key
        /// </summary>
        /// <param name="entityTypeUID">Entity Type Unique ID</param>
        /// <param name="name">Name</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static EntityCustomPropertyEntity SelectSingle(int entityTypeUID, string name)
        {
            EntityCustomPropertyEntity ecpe = new EntityCustomPropertyEntity(entityTypeUID, name);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(ecpe) == true)
            {
                return ecpe;
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
        /// <returns>EntityCollection<EntityCustomPropertyEntity></returns>
        public static EntityCollection<EntityCustomPropertyEntity> Select()
        {
            EntityCollection<EntityCustomPropertyEntity> ecp = new EntityCollection<EntityCustomPropertyEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ecp, null);
            return ecp;
        }
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="etuid">The Entity Type UID of the requested entity.</param>
        /// <param name="name">Name.</param>
        /// <returns>EntityCollection<EntityCustomPropertyEntity></returns>
        public static EntityCollection<EntityCustomPropertyEntity> Select(System.Int32 etuid, System.String name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(EntityCustomPropertyFields.EntityTypeUID == etuid);
            filter.Add(EntityCustomPropertyFields.Name == name);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<EntityCustomPropertyEntity> ecp = new EntityCollection<EntityCustomPropertyEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ecp, bucket);
            return ecp;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="etuid">The Entity Type UID of the requested entity.</param>
        /// <returns>EntityCollection<EntityCustomPropertyEntity></returns>
        public static EntityCollection<EntityCustomPropertyEntity> SelectByEntityTypeUID(System.Int32 etuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(EntityCustomPropertyFields.EntityTypeUID == etuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<EntityCustomPropertyEntity> ecp = new EntityCollection<EntityCustomPropertyEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ecp, bucket);
            return ecp;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <returns>EntityCollection<EntityCustomPropertyEntity></returns>
        public static EntityCollection<EntityCustomPropertyEntity> SelectByName(System.String name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(EntityCustomPropertyFields.Name == name);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<EntityCustomPropertyEntity> ecp = new EntityCollection<EntityCustomPropertyEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ecp, bucket);
            return ecp;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="val">Value.</param>
        /// <returns>EntityCollection<EntityCustomPropertyEntity></returns>
        public static EntityCollection<EntityCustomPropertyEntity> SelectByValue(System.String val)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(EntityCustomPropertyFields.Value == val);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<EntityCustomPropertyEntity> ecp = new EntityCollection<EntityCustomPropertyEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(ecp, bucket);
            return ecp;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a EntityCustomPropertyEntity in the storage area.
        /// </summary>
        /// <param name="etuid">The Entity Type UID of the requested entity.</param>
        /// <param name="name">Name.</param>
        /// <param name="val">Value.</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(System.Int32 etuid, System.String name, System.String val)
        {
            EntityCustomPropertyEntity ecp = new EntityCustomPropertyEntity();
            ecp.EntityTypeUID = etuid;
            ecp.Name = name;
            ecp.Value = val;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(ecp);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an EntityCustomPropertyEntity.
        /// </summary>
        /// <param name="etuid">The Entity Type UID of the requested entity.</param>
        /// <param name="name">Name.</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Int32 etuid, System.String name)
        {
            EntityCustomPropertyEntity el = new EntityCustomPropertyEntity(etuid, name);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(el);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an EntityCustomPropertyEntity.
        /// </summary>
        /// <param name="etuid">The Entity Type UID of the requested entity.</param>
        /// <param name="name">Name.</param>
        /// <param name="val">Value.</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(System.Int32 etuid, System.String name, System.String val)
        {
            EntityCustomPropertyEntity ecp = new EntityCustomPropertyEntity(etuid, name);
            ecp.IsNew = false;
            ecp.Name = name;
            ecp.Value = val;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(ecp);
        }
        #endregion
    }
}
