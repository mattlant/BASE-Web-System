/* Author: Mattlant Consulting
 * This source file is part of the BASE Web Framework System
 * 
 * Creation Date: 27 July 2007 by Steve Arbour
 * Modified on : 04 August 2007 by Mathew Lantteign
 * Modified on : 04 August 2007 by Steve Arbour
 * 
 * Copyright © 2007 BASE Web Systems Inc.
 * This software and its source code is protected by international copyright laws.
 * Any violation of this copyright will result in prosecution to the fullest
 * permissible extent of the law
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Assemblies;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SD.LLBLGen.Pro.ORMSupportClasses;
using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.HelperClasses;
//using BASE.Data.LLDAL.RelationClasses;
using BASE.Data.LLDAL.DatabaseSpecific;
using BASE.Logging;
using BASE.Logging.LogTypes;

namespace BASE.Data.Helpers
{
    /// <summary>
    /// This class is used to offer bindable function and others tools functions to manage the SectionEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class SectionDataHelper
    {

		#region STATIC METHODS

        /// <summary>
        /// This method is used to retreive a single SectionEntity by it Primary Key
        /// </summary>
        /// <param name="uID">Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static SectionEntity SelectSingle(int uID)
        {
            SectionEntity section = new SectionEntity(uID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(section) == true)
            {
                return section;
            }
            else
            {
                return null;
            }

        }

        public static int SelectUIDByNameSiteUID(string name, int siteUID)
		{
            // Create the SQL Connection Object with the WEB.CONFIG connection string. 
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["Main.ConnectionString"].ToString());
            try
            {
                // Create the SQL Command Object
                SqlCommand cmd = conn.CreateCommand();
                // Define as a StoredProcedure Call.
                cmd.CommandType = CommandType.StoredProcedure;
                // Define the Name of the Stored Procedure we will call.
                cmd.CommandText = "SelectSectionEntityUIDByNameSiteUID"; 
                // Adding parameters to the SQL Command object
                cmd.Parameters.Add(new SqlParameter("@Name", name));
				cmd.Parameters.Add(new SqlParameter("@SiteUID", siteUID)); 
                // Open the Database connection
                conn.Open();
                // Retreive the object with a Scalar call.
				object result = cmd.ExecuteScalar();
				if (result == null)
					return 0;
				return (int)result;
			}
            catch (SqlException sqlex)
            {
                // Log the error with the BASE Logger
                Logger.Log("An SqlException occured in SectionDataHelper:SelectUIDByNameSiteUID method call : " + sqlex.Message, LogPriority.Error, "DAL");
                // Throw the exception to the caller.
                throw sqlex;
            }
            catch (Exception ex)
            {
                // Log the error with the BASE Logger
                Logger.Log("An Exception occured in SectionDataHelper:SelectUIDByNameSiteUID method call : " + ex.Message, LogPriority.Error, "DAL");
                // Throw the exception to the caller.
                throw ex;
            }
            finally
            {
                // Finally close the Database Connection
                conn.Close();
            }
		}

        public static int SelectUIDByNameParentSectionUID(string name, int parentsectionuid)
		{
            // Create the SQL Connection Object with the WEB.CONFIG connection string. 
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["Main.ConnectionString"].ToString());
            try
            {
                // Create the SQL Command Object
                SqlCommand cmd = conn.CreateCommand();
                // Define as a StoredProcedure Call.
                cmd.CommandType = CommandType.StoredProcedure;
                // Define the Name of the Stored Procedure we will call.
                cmd.CommandText = "SelectSectionEntityUIDByNameParentSectionUID";
                // Adding parameters to the SQL Command object
                cmd.Parameters.Add(new SqlParameter("@Name", name));
                cmd.Parameters.Add(new SqlParameter("@ParentSectionUID", parentsectionuid));
                // Open the Database connection
                conn.Open();
                // Retreive the object with a Scalar call.
				object result = cmd.ExecuteScalar();
				if (result == null)
					return 0;
				return (int)result;
			}
            catch (SqlException sqlex)
            {
                // Log the error with the BASE Logger
                Logger.Log("An SqlException occured in SectionDataHelper:SelectUIDByNameParentSectionUID method call : " + sqlex.Message, LogPriority.Error, "DAL");
                // Throw the exception to the caller.
                throw sqlex;
            }
            catch (Exception ex)
            {
                // Log the error with the BASE Logger
                Logger.Log("An Exception occured in SectionDataHelper:SelectUIDByNameParentSectionUID method call : " + ex.Message, LogPriority.Error, "DAL");
                // Throw the exception to the caller.
                throw ex;
            }
            finally
            {
                // Finally close the Database Connection
                conn.Close();
            }
		}


		#endregion



        #region SELECT GROUP
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <returns>EntityCollection<SectionEntity></returns>
        public static EntityCollection<SectionEntity> Select()
        {
            EntityCollection<SectionEntity> sections = new EntityCollection<SectionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sections, null);
            return sections;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="uid">The UID of the requested entity.</param>
        /// <returns>EntityCollection<SectionEntity></returns>
        public static EntityCollection<SectionEntity> SelectByUID(System.Int32 uid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SectionFields.UID == uid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SectionEntity> sections = new EntityCollection<SectionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sections, bucket);
            return sections;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="siteuid">The Site UID of the requested entity.</param>
        /// <returns>EntityCollection<SectionEntity></returns>
        public static EntityCollection<SectionEntity> SelectBySiteUID(System.Int32 siteuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SectionFields.SiteUID == siteuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SectionEntity> sections = new EntityCollection<SectionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sections, bucket);
            return sections;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="name">The Name of the requested entity.</param>
        /// <returns>EntityCollection<SectionEntity></returns>
        public static EntityCollection<SectionEntity> SelectByName(System.Int32 name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SectionFields.Name == name);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SectionEntity> sections = new EntityCollection<SectionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sections, bucket);
            return sections;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="desc">The Description of the requested entity.</param>
        /// <returns>EntityCollection<SectionEntity></returns>
        public static EntityCollection<SectionEntity> SelectByDescription(System.Int32 desc)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SectionFields.Description == desc);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SectionEntity> sections = new EntityCollection<SectionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sections, bucket);
            return sections;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="templateguid">The Template GUID of the requested entity.</param>
        /// <returns>EntityCollection<SectionEntity></returns>
        public static EntityCollection<SectionEntity> SelectByTemplateGUID(System.Guid templateguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SectionFields.TemplateGUID == templateguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SectionEntity> sections = new EntityCollection<SectionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sections, bucket);
            return sections;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="dpuid">The Default Page UID of the requested entity.</param>
        /// <returns>EntityCollection<SectionEntity></returns>
        public static EntityCollection<SectionEntity> SelectByDefaultPageUID(System.Int32 dpuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SectionFields.DefaultPageUID == dpuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SectionEntity> sections = new EntityCollection<SectionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sections, bucket);
            return sections;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="owneruid">The Owner UID of the requested entity.</param>
        /// <returns>EntityCollection<SectionEntity></returns>
        public static EntityCollection<SectionEntity> SelectByOwnerUID(System.Int32 owneruid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SectionFields.OwnerUID == owneruid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SectionEntity> sections = new EntityCollection<SectionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sections, bucket);
            return sections;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="rowversion">The Row Version of the requested entity.</param>
        /// <returns>EntityCollection<SectionEntity></returns>
        public static EntityCollection<SectionEntity> SelectByRowVersion(System.Byte[] rowversion)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SectionFields.RowVersion == rowversion);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SectionEntity> pages = new EntityCollection<SectionEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(pages, bucket);
            return pages;
        }
        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a SectionEntity in the storage area.
        /// </summary>
        /// <param name="siteuid">Site UID</param>
        /// <param name="name">Name</param>
        /// <param name="description">Description</param>
        /// <param name="templateguid">Temaplte GUID</param>
        /// <param name="defaultpageuid">Default Page UID</param>
        /// <param name="owneruid">Owner UID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(
            System.Int32 siteuid,
            System.String name,
            System.String description,
            System.Guid templateguid,
            System.Int32 defaultpageuid,
            System.Int32 owneruid)
        {
            SectionEntity section = new SectionEntity();
            section.SiteUID = siteuid;
            section.Name = name;
            section.Description = description;
            section.TemplateGUID = templateguid;
            section.DefaultPageUID = defaultpageuid;
            section.OwnerUID = owneruid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(section);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an SectionEntity.
        /// </summary>
        /// <param name="uid">Unique ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Int32 uid)
        {
            SectionEntity section = new SectionEntity(uid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(section);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an SectionEntity.
        /// </summary>
        /// <param name="uid">Unique Section ID</param>
        /// <param name="siteuid">Site UID</param>
        /// <param name="name">Name</param>
        /// <param name="description">Description</param>
        /// <param name="templateguid">Temaplte GUID</param>
        /// <param name="defaultpageuid">Default Page UID</param>
        /// <param name="owneruid">Owner UID</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(
            System.Int32 uid,
            System.Int32 siteuid,
            System.String name,
            System.String description,
            System.Guid templateguid,
            System.Int32 defaultpageuid,
            System.Int32 owneruid)
        {
            SectionEntity section = new SectionEntity(uid);
            section.IsNew = false;
            section.SiteUID = siteuid;
            section.Name = name;
            section.Description = description;
            section.TemplateGUID = templateguid;
            section.DefaultPageUID = defaultpageuid;
            section.OwnerUID = owneruid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(section);
        }
        #endregion
    }
}
