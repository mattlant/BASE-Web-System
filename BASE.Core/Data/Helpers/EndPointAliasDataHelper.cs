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
using System.Data;
using System.Data.SqlClient;
using SD.LLBLGen.Pro.ORMSupportClasses;
using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.HelperClasses;
//using BASE.Data.LLDAL.RelationClasses;
using BASE.Data.LLDAL.DatabaseSpecific;
using BASE.Web.EndPoints;
using BASE.Logging;

namespace BASE.Data.Helpers
{
    /// <summary>
    /// This class is used to offer bindable function and others tools functions to manage the EndPointAliasEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class EndPointAliasDataHalper
    {

		#region STATIC METHODS

		public static class Buckets
		{
			public static RelationPredicateBucket GetForPK(int section, string alias)
			{

				RelationPredicateBucket bucket = new RelationPredicateBucket();
				bucket.PredicateExpression.Add(EndPointAliasFields.Alias == alias);
				bucket.PredicateExpression.Add(EndPointAliasFields.SectionUID == section);

				return bucket;
			}
		}

        /// <summary>
        /// This method is used to retreive a single EndPointAliasEntity by it Primary Key
        /// </summary>
        /// <param name="alias">Alias</param>
        /// <param name="sectionUID">Section Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static EndPointAliasEntity SelectSingle(string alias, int sectionUID)
        {
            EndPointAliasEntity epae = new EndPointAliasEntity(sectionUID, alias);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(epae) == true)
            {
                return epae;
            }
            else
            {
                return null;
            }

        }

        public static EndPointAliasLightEntity SelectByAliasSectionUID(string alias, int sectionuid)
		{
			System.Data.SqlClient.SqlDataReader rdr = null;
            // Create the SQL Connection Object with the WEB.CONFIG connection string setting.
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["Main.ConnectionString"].ToString());
            try
            {
                // Create the SQL Command Object
                SqlCommand sqlcmd = conn.CreateCommand();
                // Define as a StoredProcedure Call.
                sqlcmd.CommandType = CommandType.StoredProcedure;
                // Define the Name of the Stored Procedure we will call.
                sqlcmd.CommandText = "SelectEndPointAliasByAliasSectionUID"; 
                // Adding parameters to the SQL Command object
                sqlcmd.Parameters.Add(new SqlParameter("@Alias", alias));
                sqlcmd.Parameters.Add(new SqlParameter("@SectionUID", sectionuid));
                // Open the Database connection
                conn.Open();
                // Retreive the DataReader
                rdr = sqlcmd.ExecuteReader();
                // Verify we have a result
                if (rdr.HasRows == true)
                {
                    // Advance the cursor to next record.
                    rdr.Read();
                    // Attempt to create a new EndPointAlias.
                    EndPointAliasLightEntity newobj = new EndPointAliasLightEntity(rdr.GetInt32(0), rdr.GetString(1), "", EndPointAliasType.Virtual);
                    // Return the object.
                    return newobj;
                }
                else
                {
                    // Close the DataReader.
                    rdr.Close();
                    // There is no row, we should return null.
                    return null;
                }

            }
            catch (SqlException sqlex)
            {
                // Log the error with the BASE Logger
                Logger.Log("An SqlException occured in EndPointAliasDataHelper:SelectByAliasSectionUID method call : " + sqlex.Message, LogPriority.Error, "DAL");
                // Throw the exception to the caller.
                throw sqlex;
            }
            catch (Exception ex)
            {
                // Log the error with the BASE Logger
                Logger.Log("An Exception occured in EndPointAliasDataHelper:SelectByAliasSectionUID method call : " + ex.Message, LogPriority.Error, "DAL");
                // Throw the exception to the caller.
                throw ex;
            }
            finally
            {
				//Close the reader if not null and not closed.
				if (rdr != null && !rdr.IsClosed)
					rdr.Close();
                // Close the SQL Connection Object.
				if (conn != null && conn.State != ConnectionState.Closed)
					conn.Close();
            }
		}

		#endregion



        #region SELECT GROUP
        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <returns>EntityCollection<EndPointAliasEntity></returns>
        public static EntityCollection<EndPointAliasEntity> Select()
        {
            EntityCollection<EndPointAliasEntity> endpoints = new EntityCollection<EndPointAliasEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(endpoints, null);
            return endpoints;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="alias">The Alias of the requested entity.</param>
        /// <returns>EntityCollection<EndPointAliasEntity></returns>
        public static EntityCollection<EndPointAliasEntity> Select(int section, System.String alias)
        {

            EntityCollection<EndPointAliasEntity> endpoints = new EntityCollection<EndPointAliasEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(endpoints, Buckets.GetForPK(section, alias));
            return endpoints;
        }

		/// <summary>
		/// This function is used to query the data source for records.
		/// </summary>
		/// <param name="endpoint">The EndPoint of the requested entity.</param>
		/// <returns>EntityCollection<EndPointAliasEntity></returns>
		public static EntityCollection<EndPointAliasEntity> SelectByEndPoint(System.String endpoint)
		{
			PredicateExpression filter = new PredicateExpression();
			filter.Add(EndPointAliasFields.EndPoint == endpoint);

			RelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(filter);

			EntityCollection<EndPointAliasEntity> endpoints = new EntityCollection<EndPointAliasEntity>();
			DataAccessAdapter ds = new DataAccessAdapter();
			ds.FetchEntityCollection(endpoints, bucket);
			return endpoints;
		}


        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="sectionuid">The SectionUID of the requested entity.</param>
        /// <returns>EntityCollection<EndPointAliasEntity></returns>
        public static EntityCollection<EndPointAliasEntity> SelectBySectionUID(int sectionuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(EndPointAliasFields.SectionUID == sectionuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<EndPointAliasEntity> endpoints = new EntityCollection<EndPointAliasEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(endpoints, bucket);
            return endpoints;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="pageuid">The PageUID of the requested entity.</param>
        /// <returns>EntityCollection<EndPointAliasEntity></returns>
        public static EntityCollection<EndPointAliasEntity> SelectByPageUID(int pageuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(EndPointAliasFields.PageUID == pageuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<EndPointAliasEntity> endpoints = new EntityCollection<EndPointAliasEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(endpoints, bucket);
            return endpoints;
        }

        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a EndPointAliasEntity in the storage area.
        /// </summary>
        /// <param name="alias">Alias</param>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="sectionuid">Section Unique ID</param>
        /// <param name="pageuid">Page Unique ID</param>
        /// <param name="endpoint">End Point</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(string alias, int sectionuid, int pageuid, string endpoint)
        {
            EndPointAliasEntity epae = new EndPointAliasEntity();
            epae.Alias = alias;
            epae.SectionUID = sectionuid;
            epae.PageUID = pageuid;
            epae.EndPoint = endpoint;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(epae);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an EndPointAliasEntity.
        /// </summary>
        /// <param name="alias">Alias</param>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="sectionuid">Section Unique ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(string alias, int sectionuid)
        {
			EndPointAliasEntity epea = new EndPointAliasEntity(sectionuid, alias);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(epea);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an EndPointAliasEntity.
        /// </summary>
        /// <param name="alias">Alias</param>
        /// <param name="siteuid">Site Unique ID</param>
        /// <param name="sectionuid">Section Unique ID</param>
        /// <param name="pageuid">Page Unique ID</param>
        /// <param name="endpoint">End Point</param>
        /// <returns>True on success, False on fail</returns>
		public static bool Update(string alias, int sectionuid, int pageuid, string endpoint)
        {
			EndPointAliasEntity epae = new EndPointAliasEntity(sectionuid, alias);
            epae.IsNew = false;
            epae.Alias = alias;
            epae.SectionUID = sectionuid;
            epae.PageUID = pageuid;
            epae.EndPoint = endpoint;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(epae);
        }
        #endregion
    }
}
