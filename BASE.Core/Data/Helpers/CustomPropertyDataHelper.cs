/* Author: Steve Arbour
 * This source file is part of the BASE Web Framework System
 * Date: 25 July 2007
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
    /// This class is used to offer bindable function and others tools functions to manage the CustomPropertyEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class CustomPropertyDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single CustomPropertyEntity by it Primary Key
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static CustomPropertyEntity SelectSingle(string name)
        {
            CustomPropertyEntity cpe = new CustomPropertyEntity(name);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(cpe) == true)
            {
                return cpe;
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
        /// <returns>EntityCollection<CustomPropertyEntity></returns>
        public static EntityCollection<CustomPropertyEntity> Select()
        {
            EntityCollection<CustomPropertyEntity> propertys = new EntityCollection<CustomPropertyEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(propertys, null);
            return propertys;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>EntityCollection<CustomPropertyEntity></returns>
        public static EntityCollection<CustomPropertyEntity> SelectByName(System.String name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomPropertyFields.Name == name);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomPropertyEntity> propertys = new EntityCollection<CustomPropertyEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(propertys, bucket);
            return propertys;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="guid">The Guid</param>
        /// <returns>EntityCollection<CustomPropertyEntity></returns>
        public static EntityCollection<CustomPropertyEntity> SelectByValue(System.String val)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(CustomPropertyFields.Value == val);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<CustomPropertyEntity> propertys = new EntityCollection<CustomPropertyEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(propertys, bucket);
            return propertys;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert an CustomPropertyEntity in the storage area.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="value">Value</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(System.String name, System.String value)
        {
            CustomPropertyEntity cpe = new CustomPropertyEntity(name);
            cpe.Value = value;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(cpe);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an CustomPropertyEntity.
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.String name)
        {
            CustomPropertyEntity cpe = new CustomPropertyEntity(name);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(cpe);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an CustomPropertyEntity.
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <param name="name">Name</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(System.String name, System.String val)
        {
            CustomPropertyEntity cpe = new CustomPropertyEntity(name);
            cpe.IsNew = false;
            cpe.Value = val;
            cpe.Name = name;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(cpe);
        }
        #endregion
    }
}
