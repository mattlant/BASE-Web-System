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
    /// This class is used to offer bindable function and others tools functions to manage the RecordCustomPropertyEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class RecordCustomPropertyDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single RecordCustomPropertyEntity by it Primary Key
        /// </summary>
        /// <param name="recordUID">Record Unique ID</param>
        /// <param name="entityTypeGUID">Entity Type Global Unique ID</param>
        /// <param name="name">Name</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static RecordCustomPropertyEntity SelectSingle(int recordUID, Guid entityTypeGUID, string name)
        {
            RecordCustomPropertyEntity rcpe = new RecordCustomPropertyEntity(recordUID, entityTypeGUID, name);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(rcpe) == true)
            {
                return rcpe;
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
        /// <returns>EntityCollection<RecordCustomPropertyEntity></returns>
        public static EntityCollection<RecordCustomPropertyEntity> Select()
        {
            EntityCollection<RecordCustomPropertyEntity> rcpe = new EntityCollection<RecordCustomPropertyEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(rcpe, null);
            return rcpe;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="recorduid">The Record UID of the requested entity.</param>
        /// <returns>EntityCollection<RecordCustomPropertyEntity></returns>
        public static EntityCollection<RecordCustomPropertyEntity> Select(System.Int32 recorduid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(RecordCustomPropertyFields.RecordUID == recorduid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<RecordCustomPropertyEntity> rcpe = new EntityCollection<RecordCustomPropertyEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(rcpe, bucket);
            return rcpe;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="recorduid">The Record UID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity Type GUID of the requested entity.</param>
        /// <returns>EntityCollection<RecordCustomPropertyEntity></returns>
        public static EntityCollection<RecordCustomPropertyEntity> Select(System.Int32 recorduid, System.Guid entitytypeguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(RecordCustomPropertyFields.RecordUID == recorduid);
            filter.Add(RecordCustomPropertyFields.EntityTypeGUID == entitytypeguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<RecordCustomPropertyEntity> rcpe = new EntityCollection<RecordCustomPropertyEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(rcpe, bucket);
            return rcpe;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="recorduid">The Record UID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity Type GUID of the requested entity.</param>
        /// <param name="name">The Name of the requested entity.</param>
        /// <returns>EntityCollection<RecordCustomPropertyEntity></returns>
        public static EntityCollection<RecordCustomPropertyEntity> Select(System.Int32 recorduid, System.Guid entitytypeguid, System.String name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(RecordCustomPropertyFields.RecordUID == recorduid);
            filter.Add(RecordCustomPropertyFields.EntityTypeGUID == entitytypeguid);
            filter.Add(RecordCustomPropertyFields.Name == name);


            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<RecordCustomPropertyEntity> rcpe = new EntityCollection<RecordCustomPropertyEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(rcpe, bucket);
            return rcpe;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a RecordCustomPropertyEntity in the storage area.
        /// </summary>
        /// <param name="recorduid">The Record UID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity Type GUID of the requested entity.</param>
        /// <param name="name">The Name of the requested entity.</param>
        /// <param name="val">The Value of the requested entity.</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(System.Int32 recorduid, System.Guid entitytypeguid, System.String name, System.String val)
        {
            RecordCustomPropertyEntity rcpe = new RecordCustomPropertyEntity();
            rcpe.RecordUID = recorduid;
            rcpe.EntityTypeGUID = entitytypeguid;
            rcpe.Name = name;
            rcpe.Value = val;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(rcpe);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an RecordCustomPropertyEntity.
        /// </summary>
        /// <param name="recorduid">The Record UID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity Type GUID of the requested entity.</param>
        /// <param name="name">The Name of the requested entity.</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Int32 recorduid, System.Guid entitytypeguid, System.String name)
        {
            RecordCustomPropertyEntity rcpe = new RecordCustomPropertyEntity(recorduid, entitytypeguid, name);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(rcpe);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an RecordCustomPropertyEntity.
        /// </summary>
        /// <param name="recorduid">The Record UID of the requested entity.</param>
        /// <param name="entitytypeguid">The Entity Type GUID of the requested entity.</param>
        /// <param name="name">The Name of the requested entity.</param>
        /// <param name="val">The Value of the requested entity.</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(System.Int32 recorduid, System.Guid entitytypeguid, System.String name, System.String val)
        {
            RecordCustomPropertyEntity rcpe = new RecordCustomPropertyEntity(recorduid, entitytypeguid, name);
            rcpe.IsNew = false;
            rcpe.RecordUID = recorduid;
            rcpe.EntityTypeGUID = entitytypeguid;
            rcpe.Name = name;
            rcpe.Value = val;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(rcpe);
        }
        #endregion
    }
}
