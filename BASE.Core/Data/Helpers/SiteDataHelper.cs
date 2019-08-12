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
using System.Data;
using System.Data.SqlClient;
using SD.LLBLGen.Pro.ORMSupportClasses;
using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.HelperClasses;
//using BASE.Data.LLDAL.RelationClasses;
using BASE.Data.LLDAL.DatabaseSpecific;
using BASE.Logging;

namespace BASE.Data.Helpers
{
    /// <summary>
    /// This class is used to offer bindable function and others tools functions to manage the SiteEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class SiteDataHelper
	{

		#region PREDICATE AND RELATIONS FILTER GENERATION

		/// <summary>
		/// Class to generate common filters for use with generated entity classes.
		/// </summary>
		public static class Filters
		{
			/// <summary>
			/// Generates a filter that checks for the ParentSiteUID == null (WHERE ISNULL(ParentSiteUID))
			/// </summary>
			/// <returns>A RelationPredicateBucket with the required predicate.</returns>
			public static RelationPredicateBucket GetRootSitesPredicate()
			{
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(SiteFields.ParentSiteUID == DBNull.Value);
				return new RelationPredicateBucket(filter);
				//filter.Add(SiteFields.pa);
			}

			//static PredicateExpression GetSite(Guid guid)
			//{
			//    //Construct a filter to get all sites
			//}

			//static PredicateExpression GetSite(List<Guid> guidList)
			//{

			//}
		}

		#endregion

		#region STATIC METHODS

        /// <summary>
        /// This method is used to retreive a single SiteEntity by it Primary Key
        /// </summary>
        /// <param name="uID">Unique ID</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static SiteEntity SelectSingle(int uID)
        {
            SiteEntity site = new SiteEntity(uID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(site) == true)
            {
                return site;
            }
            else
            {
                return null;
            }

        }

		public static int SelectSiteUIDByDomainName(string domainName)
		{
			// Create the SQL Connection Object with the WEB.CONFIG connection string. 
			using (SqlConnection conn = DataHelper.CreateNewSqlConnection())
			{
				// Create the SQL Command Object
				SqlCommand cmd = conn.CreateCommand();
				// Define as a StoredProcedure Call.
				cmd.CommandType = CommandType.StoredProcedure;
				// Define the Name of the Stored Procedure we will call.
				cmd.CommandText = "SelectSiteEntityUIDByDomainName";
				// Adding parameters to the SQL Command object
				cmd.Parameters.Add(new SqlParameter("@DomainName", domainName));
				// Open the Database connection
				try
				{
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
					Logger.Log("An SqlException occured in SiteDataHelper:GetSiteUIDByDomain method call : " + sqlex.Message, LogPriority.Error, "DAL");
					// Throw the exception to the caller.
					throw;
				}
				catch (Exception ex)
				{
					// Log the error with the BASE Logger
					Logger.Log("An Exception occured in SiteDataHelper:GetSiteUIDByDomain method call : " + ex.Message, LogPriority.Error, "DAL");
					// Throw the exception to the caller.
					throw;
				}
			}
		}

		public static int SelectSiteUIDBySubSiteNameANDParentUID(string subSiteName, int parentUID)
		{
			// Create the SQL Connection Object with the WEB.CONFIG connection string. 
			using(SqlConnection conn = DataHelper.CreateNewSqlConnection())
			{
				// Create the SQL Command Object
				SqlCommand cmd = conn.CreateCommand();
				// Define as a StoredProcedure Call.
				cmd.CommandType = CommandType.StoredProcedure;
				// Define the Name of the Stored Procedure we will call.
				cmd.CommandText = "SelectSiteEntityUIDBySubSiteNameParentSiteUID";
				// Adding parameters to the SQL Command object
				cmd.Parameters.Add(new SqlParameter("@SubSiteName", subSiteName));
				cmd.Parameters.Add(new SqlParameter("@ParentSiteUID", parentUID));
				// Open the Database connection
				try
				{
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
					Logger.Log("An SqlException occured in SiteDataHelper:GetSiteUIDBySubSiteNameANDParentUID method call : " + sqlex.Message, LogPriority.Error, "DAL");
					// Throw the exception to the caller.
					throw;
				}
				catch (Exception ex)
				{
					// Log the error with the BASE Logger
					Logger.Log("An Exception occured in SiteDataHelper:GetSiteUIDBySubSiteNameANDParentUID method call : " + ex.Message, LogPriority.Error, "DAL");
					// Throw the exception to the caller.
					throw;
				}
			}
		}

		public static bool InsertNewSite(SiteEntity site, SiteVirtualInfoEntity siteVirtual, SiteNetInfoEntity siteNet, SiteSubSiteInfoEntity siteSubSite)
		{
			site.SiteVirtualInfo = siteVirtual;
			site.SiteNetInfo = siteNet;
			site.SiteSubSiteInfo = siteSubSite == null ? null : siteSubSite;

			DataAccessAdapter da = new DataAccessAdapter();
			return da.SaveEntity(site, true, true);
		}




		#endregion



		#region BINDING METHODS

		#region SELECT GROUP
		/// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <returns>EntityCollection<SiteEntity></returns>
        public static EntityCollection<SiteEntity> Select()
        {
            EntityCollection<SiteEntity> sites = new EntityCollection<SiteEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sites, null);
            return sites;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="uid">The UID of the requested entity.</param>
        /// <returns>EntityCollection<SiteEntity></returns>
        public static EntityCollection<SiteEntity> SelectByUID(System.Int32 uid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteFields.UID == uid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteEntity> sites = new EntityCollection<SiteEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sites, bucket);
            return sites;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="name">The Name of the requested entity.</param>
        /// <returns>EntityCollection<SiteEntity></returns>
        public static EntityCollection<SiteEntity> SelectByName(System.String name)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteFields.Name == name);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteEntity> sites = new EntityCollection<SiteEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sites, bucket);
            return sites;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="siteguid">The Site GUID of the requested entity.</param>
        /// <returns>EntityCollection<SiteEntity></returns>
        public static EntityCollection<SiteEntity> SelectBySiteGUID(System.Guid siteguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteFields.SiteGUID == siteguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteEntity> sites = new EntityCollection<SiteEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sites, bucket);
            return sites;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="ownerguid">The Owner GUID of the requested entity.</param>
        /// <returns>EntityCollection<SiteEntity></returns>
        public static EntityCollection<SiteEntity> SelectByOwnerGUID(System.Guid ownerguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteFields.OwnerGUID == ownerguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteEntity> sites = new EntityCollection<SiteEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sites, bucket);
            return sites;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="referrerguid">The Referrer GUID of the requested entity.</param>
        /// <returns>EntityCollection<SiteEntity></returns>
        public static EntityCollection<SiteEntity> SelectByReferrerGUID(System.Guid referrerguid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteFields.ReferrerGUID == referrerguid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteEntity> sites = new EntityCollection<SiteEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sites, bucket);
            return sites;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="sitetypeuid">The Site Type UID of the requested entity.</param>
        /// <returns>EntityCollection<SiteEntity></returns>
        public static EntityCollection<SiteEntity> SelectBySiteTypeUID(System.Int32 sitetypeuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteFields.SiteTypeUID == sitetypeuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteEntity> sites = new EntityCollection<SiteEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sites, bucket);
            return sites;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="parentsiteuid">The Parent Site UID of the requested entity.</param>
        /// <returns>EntityCollection<SiteEntity></returns>
        public static EntityCollection<SiteEntity> SelectByParentSiteUID(System.Int32 parentsiteuid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteFields.ParentSiteUID == parentsiteuid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteEntity> sites = new EntityCollection<SiteEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sites, bucket);
            return sites;
        }


        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="issitelocked">The Is Site Locked Flag of the requested entity.</param>
        /// <returns>EntityCollection<SiteEntity></returns>
        public static EntityCollection<SiteEntity> SelectByIsSiteLocked(System.Boolean issitelocked)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteFields.IsSiteLocked == issitelocked);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteEntity> sites = new EntityCollection<SiteEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sites, bucket);
            return sites;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="isenlabedflag">The Is Enabled Flag of the requested entity.</param>
        /// <returns>EntityCollection<SiteEntity></returns>
        public static EntityCollection<SiteEntity> SelectByIsEnabled(System.Boolean isenlabedflag)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteFields.IsEnabled == isenlabedflag);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteEntity> sites = new EntityCollection<SiteEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sites, bucket);
            return sites;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="createuseruid">The Create User UID of the requested entity.</param>
        /// <returns>EntityCollection<SiteEntity></returns>
        public static EntityCollection<SiteEntity> SelectByCreateUserUID(System.Int32 createuseruid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteFields.CreateUserUID == createuseruid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteEntity> sites = new EntityCollection<SiteEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sites, bucket);
            return sites;
        }

        /// <summary>
        /// This function is used to query the data source for records.
        /// </summary>
        /// <param name="owneruid">The Owner UID of the requested entity.</param>
        /// <returns>EntityCollection<SiteEntity></returns>
        public static EntityCollection<SiteEntity> SelectByOwnerGUID(System.Int32 owneruid)
        {
            PredicateExpression filter = new PredicateExpression();
            filter.Add(SiteFields.OwnerGUID == owneruid);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(filter);

            EntityCollection<SiteEntity> sites = new EntityCollection<SiteEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(sites, bucket);
            return sites;
        }


        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a SiteEntity in the storage area.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="siteguid">Site GUID</param>
        /// <param name="ownerguid">Owner GUID</param>
        /// <param name="referrerguid">Referrer GUID</param>
        /// <param name="description">Description</param>
        /// <param name="sitetypeuid">Site Type UID</param>
        /// <param name="parentsiteuid">Parent Site UID</param>
        /// <param name="inheritusers">Inherit Users</param>
        /// <param name="inheritsecurity">Inherit Security</param>
        /// <param name="issitelocked">Is Site Locked Flag</param>
        /// <param name="isenabled">Is Enabled Flag</param>
        /// <param name="createtime">Create Time</param>
        /// <param name="createuseruid">Create User UID</param>
        /// <param name="edittime">Edit Time</param>
        /// <param name="edituseruid">Edit User UID</param>
        /// <param name="owneruid">Owner UID</param>
        /// <returns>True on success, False on fail</returns>
        /// <remarks>
        /// The Domain Name field is deprecated and will be changed in the future.
        /// </remarks>
        public static bool Insert(
            string name, 
            Guid siteguid, 
            Guid ownerguid, 
            Guid referrerguid,
            string description, 
            int sitetypeuid, 
            int parentsiteuid, 
            bool inheritusers, 
            bool inheritsecurity,             
            bool issitelocked,
            bool isenabled, 
			DateTime createtime,
			int createuseruid, 
			DateTime edittime,
			int edituseruid, 
			int owneruid)
        {
            //DEPRECATED: Domain Name field will be changed in a near future.
            SiteEntity site = new SiteEntity();
            site.Name = name;
            site.SiteGUID = siteguid;
            site.OwnerGUID = ownerguid;
            site.ReferrerGUID = referrerguid;
            site.Description = description;
            site.SiteTypeUID = sitetypeuid;
            site.ParentSiteUID = parentsiteuid;
            site.InheritUsers = inheritusers;
            site.InheritSecurity = inheritsecurity;
            site.IsSiteLocked = issitelocked;
            site.IsEnabled = isenabled;
            site.CreateTime = createtime == DateTime.MaxValue ? DateTime.Now : createtime;
            site.CreateUserUID = createuseruid < 1 ? 0 : createuseruid;
			site.EditTime = edittime == DateTime.MaxValue ? DateTime.Now : edittime;
			site.EditUserUID = edituseruid < 1 ? 0 : edituseruid;
            site.OwnerUID = owneruid < 1 ? 0 : owneruid; 
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(site);
        }
        #endregion

        #region DELETE GROUP
        /// <summary>
        /// This function is used to delete an SiteEntity.
        /// </summary>
        /// <param name="uid">Unique ID</param>
        /// <returns>True on success, false on fail.</returns>
        public static bool Delete(System.Int32 uid)
        {
            SiteEntity site = new SiteEntity(uid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(site);
        }
        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an SiteEntity.
        /// </summary>
        /// <param name="uid">Unique Site ID</param>
        /// <param name="name">Name</param>
        /// <param name="siteguid">Site GUID</param>
        /// <param name="ownerguid">Owner GUID</param>
        /// <param name="referrerguid">Referrer GUID</param>
        /// <param name="description">Description</param>
        /// <param name="sitetypeuid">Site Type UID</param>
        /// <param name="parentsiteuid">Parent Site UID</param>
        /// <param name="inheritusers">Inherit Users</param>
        /// <param name="inheritsecurity">Inherit Security</param>
        /// <param name="issitelocked">Is Site Locked Flag</param>
        /// <param name="isenabled">Is Enabled Flag</param>
        /// <param name="createtime">Create Time</param>
        /// <param name="createuseruid">Create User UID</param>
        /// <param name="edittime">Edit Time</param>
        /// <param name="edituseruid">Edit User UID</param>
        /// <param name="owneruid">Owner UID</param>
        /// <returns>True on success, False on fail</returns>
        /// <remarks>
        /// The Domain Name field is deprecated and will be changed in the future.
        /// </remarks>
        public static bool Update(
            int uid, 
            string name,
            Guid siteguid,
            Guid ownerguid,
            Guid referrerguid,
            string description,
            int sitetypeuid,
            int parentsiteuid,
            bool inheritusers,
            bool inheritsecurity,
            string feedbackemail,
            bool issitelocked,
            bool isenabled,
            DateTime createtime,
            int createuseruid,
            DateTime edittime,
            int edituseruid,
            int owneruid)
        {
            //DEPRECATED: Domain Name field will be changed in a near future.
            SiteEntity site = new SiteEntity(uid);
            site.IsNew = false;
            site.Name = name;
            site.SiteGUID = siteguid;
            site.OwnerGUID = ownerguid;
            site.ReferrerGUID = referrerguid;
            site.Description = description;
            site.SiteTypeUID = sitetypeuid;
            site.ParentSiteUID = parentsiteuid;
            site.InheritUsers = inheritusers;
            site.InheritSecurity = inheritsecurity;
            site.IsSiteLocked = issitelocked;
            site.IsEnabled = isenabled;
            site.CreateTime = createtime;
            site.CreateUserUID = createuseruid;
            site.EditTime = edittime;
            site.EditUserUID = edituseruid;
            site.OwnerUID = owneruid;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(site);
        }
        #endregion

		#endregion
	}
}
