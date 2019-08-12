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
    /// This class is used to offer bindable function and others tools functions to manage the TemplateTypeEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class TemplateTypeDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single TemplateTypeEntity by it Primary Key
        /// </summary>
        /// <param name="uID">Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static TemplateTypeEntity SelectSingle(int uID)
        {
            TemplateTypeEntity tte = new TemplateTypeEntity(uID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(tte) == true)
            {
                return tte;
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
        /// <returns>EntityCollection<TemplateTypeEntity></returns>
        public static EntityCollection<TemplateTypeEntity> Select()
        {
            EntityCollection<TemplateTypeEntity> templatetypes = new EntityCollection<TemplateTypeEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templatetypes, null);
            return templatetypes;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="uid">The Unique ID of the requested entity.</param>
        /// <returns>EntityCollection<TemplateTypeEntity></returns>
        public static EntityCollection<TemplateTypeEntity> SelectByUID(System.Int32 uid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateTypeFields.UID == uid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateTypeEntity> templatetypes = new EntityCollection<TemplateTypeEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templatetypes, bucket);
            return templatetypes;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="name">The Name of the requested entity.</param>
        /// <returns>EntityCollection<TemplateTypeEntity></returns>
        public static EntityCollection<TemplateTypeEntity> SelectByName(System.String name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(TemplateTypeFields.Name == name);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<TemplateTypeEntity> templatetypes = new EntityCollection<TemplateTypeEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templatetypes, bucket);
            return templatetypes;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a TemplateTypeEntity in the storage area.
        /// </summary>
        /// <param name="uid">Unique ID</param>
        /// <param name="name">Name</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(System.Int32 uid, System.String name)
        {
            TemplateTypeEntity templatetype = new TemplateTypeEntity();
            templatetype.UID = uid;
            templatetype.Name = name;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(templatetype);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an TemplateTypeEntity.
        /// </summary>
        /// <param name="uid">Unique ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Int32 uid)
        {
            TemplateTypeEntity templatetype = new TemplateTypeEntity(uid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(templatetype);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an TemplateTypeEntity.
        /// </summary>
        /// <param name="uid">Unique ID</param>
        /// <param name="name">Name</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(System.Int32 uid, System.String name)
        {
            TemplateTypeEntity templatetype = new TemplateTypeEntity(uid);
            templatetype.IsNew = false;
            templatetype.UID = uid;
            templatetype.Name = name; 
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(templatetype);
        }
        #endregion
    }
}