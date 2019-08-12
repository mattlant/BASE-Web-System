/* Author: Mattlant Consulting
 * This source file is part of the BASE Web Framework System
 * Creation Date: 24 July 2007 by Steve Arbour
 * Modified on: 08 August 2007 - Added SelectSingle();
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
    /// This class is used to offer bindable function and others tools functions to manage the ActionEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class ActionDataHelper
    {

        /// <summary>
        /// This method is used to retreive a single ActionEntity by it Primary Key
        /// </summary>
        /// <param name="code">The code</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static ActionEntity SelectSingle(string code)
        {
            ActionEntity action = new ActionEntity(code);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(action) == true)
            {
                return action;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <returns>EntityCollection<ActionEntity></returns>
        public static EntityCollection<ActionEntity> Select()
        {
            EntityCollection<ActionEntity> actions = new EntityCollection<ActionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(actions, null);
            return actions;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="code">The code of the requested action entity.</param>
        /// <returns>EntityCollection<ActionEntity></returns>
        public static EntityCollection<ActionEntity> SelectByCode(string code)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ActionFields.Code == code);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ActionEntity> actions = new EntityCollection<ActionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(actions, bucket);
            return actions;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="name">The name of the requested action entity.</param>
        /// <returns>EntityCollection<ActionEntity></returns>
        public static EntityCollection<ActionEntity> SelectByName(string name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(ActionFields.Name == name);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<ActionEntity> actions = new EntityCollection<ActionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(actions, bucket);
            return actions;
        }

        /// <summary>
        /// This function is used to insert a Action Entity in the storage area.
        /// </summary>
        /// <param name="code">Code of this action</param>
        /// <param name="name">Name of this action.</param>
        /// <returns>True if success, False on fail.</returns>
        public static bool Insert(string code, string name)
        {
            ActionEntity action = new ActionEntity();
            action.Code = code;
            action.Name = name;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(action);
        }

        /// <summary>
        /// This function is used to delete an Action Entity from it code.
        /// </summary>
        /// <param name="code">The code of the action entity</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(string code)
        {
            ActionEntity action = new ActionEntity(code);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(action);
        }

        /// <summary>
        /// This function is used to update an Action Entity.
        /// </summary>
        /// <param name="code">The code of the Action Entity.</param>
        /// <param name="name">The name of the Action Entity.</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Update(string code, string name)
        {
            ActionEntity action = new ActionEntity(code);
            action.IsNew = false;
            action.Name = name;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(action);
        }

        /// <summary>
        /// This function is used to change the Code of an Action Entity
        /// </summary>
        /// <param name="oldcode">The old code of the Action Entity.</param>
        /// <param name="newcode">The new code of the Action Entity.</param>
        /// <returns></returns>
        public static bool ChangeCode(string oldcode, string newcode)
        {
            ActionEntity action = new ActionEntity(oldcode);
            action.Code = newcode;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(action);
        }

    }
}
