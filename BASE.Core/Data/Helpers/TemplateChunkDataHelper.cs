/* Author: Steve Arbour
 * This source file is part of the BASE Web Framework System
 * Date: 3 August 2007
 * Copyright © 2007 BASE Web Systems Inc.
 * This software and its source code is protected by international copyright laws.
 * Any violation of this copyright will result in prosecution to the fullest
 * permissible extent of the law
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SD.LLBLGen.Pro.ORMSupportClasses;
using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.FactoryClasses;
using BASE.Data.LLDAL.HelperClasses;
//using BASE.Data.LLDAL.RelationClasses;
using BASE.Data.LLDAL.DatabaseSpecific;

using BASE.Web.HtmlParsing;

namespace BASE.Data.Helpers
{
    /// <summary>
    /// This class is used to offer bindable function and others tools functions to manage the TemplateChunksEntity
    /// </summary>
    [System.ComponentModel.DataObject]
    public static class TemplateChunkDataHelper
    {

		//public static int Count(Guid templateGuid)
		//{
		//    DataAccessAdapter ds = new DataAccessAdapter();
		//    PredicateExpression pred = new PredicateExpression();
		//    pred.Add(TemplateChunksFields.TemplateGUID == templateguid);
		//    RelationPredicateBucket bucket = new RelationPredicateBucket(pred);

		//    return ds.
		//    return ds.DeleteEntitiesDirectly("TemplateChunksEntity", bucket);
		//}


        /// <summary>
        /// This method is used to retreive a single TemplateChunksEntity by it Primary Key
        /// </summary>
        /// <param name="chunkID">Chunk ID</param>
        /// <param name="templateGUID">Template Global Unique ID</param>
        /// <param name="isPreParsed">Is Pre Parsed Flag</param>
        /// <returns>An entity if found, null if nothing found.</returns>
        public static TemplateChunksEntity SelectSingle(int chunkID, Guid templateGUID, bool isPreParsed)
        {
			TemplateChunksEntity tce = new TemplateChunksEntity(templateGUID, isPreParsed, chunkID);
            DataAccessAdapter ds = new DataAccessAdapter();
            if (ds.FetchEntity(tce) == true)
            {
                return tce;
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
        /// <returns>EntityCollection<TemplateChunksEntity></returns>
        public static EntityCollection<TemplateChunksEntity> Select()
        {
            EntityCollection<TemplateChunksEntity> templatechunks = new EntityCollection<TemplateChunksEntity>();
            DataAccessAdapter ds = new DataAccessAdapter();
            ds.FetchEntityCollection(templatechunks, null);
            return templatechunks;
        }

		/// <summary>
		/// This function is used to query the data source for records.
		/// </summary>
		/// <param name="guid">The TemplateGUID of the requested entity.</param>
		/// <returns>EntityCollection<TemplateChunksEntity></returns>
		public static EntityCollection<TemplateChunksEntity> SelectByTemplateGUID(Guid guid)
		{
			PredicateExpression filter = new PredicateExpression();
			filter.Add(TemplateChunksFields.TemplateGUID == guid);

			RelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(filter);

			EntityCollection<TemplateChunksEntity> templatechunks = new EntityCollection<TemplateChunksEntity>();
			DataAccessAdapter ds = new DataAccessAdapter();
			ds.FetchEntityCollection(templatechunks, bucket);
			return templatechunks;
		}


		/// <summary>
		/// This function is used to query the data source for records.
		/// </summary>
		/// <param name="guid">The TemplateGUID of the requested entity.</param>
		/// <returns>EntityCollection<TemplateChunksEntity></returns>
		public static EntityCollection<TemplateChunksEntity> Select(Guid templateGUID, bool preParsed)
		{
			RelationPredicateBucket filter = new RelationPredicateBucket();
			filter.PredicateExpression.Add(TemplateChunksFields.TemplateGUID == templateGUID);
			filter.PredicateExpression.AddWithAnd(TemplateChunksFields.IsPreParsed == preParsed);

			ISortExpression sorter = new SortExpression();
			sorter.Add(TemplateChunksFields.ChunkID | SortOperator.Ascending);

			EntityCollection<TemplateChunksEntity> templatechunks = new EntityCollection<TemplateChunksEntity>();
			DataAccessAdapter ds = new DataAccessAdapter();
			ds.FetchEntityCollection(templatechunks, filter, 0, sorter);
			return templatechunks;
		}



		public static int SelectCount(Guid templateGUID, bool preParsed)
		{

			RelationPredicateBucket filter = new RelationPredicateBucket();
			filter.PredicateExpression.Add(TemplateChunksFields.TemplateGUID == templateGUID);
			filter.PredicateExpression.AddWithAnd(TemplateChunksFields.IsPreParsed == preParsed);

			DataAccessAdapter adapter = new DataAccessAdapter();

			return (int)adapter.GetDbCount(new TemplateChunksEntityFactory().CreateFields(), filter, null, false);
		}

        #endregion

        #region INSERT GROUP
        /// <summary>
        /// This function is used to insert a TemplateChunksEntity in the storage area.
        /// </summary>
        /// <param name="chunkid">Chunk ID</param>
        /// <param name="templateguid">Template GUID</param>
        /// <param name="ispreparsed">Is Preparsed Flag</param>
        /// <param name="htmltext">HTML Text</param>
        /// <param name="chunktype">Chunk Type</param>
        /// <param name="prefix">Prefix</param>
        /// <param name="tagname">TagName</param>
        /// <param name="attributes">Attributes</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Insert(int chunkid, Guid templateguid, bool ispreparsed, string htmltext, byte chunktype, string prefix, string tagname, string attributes)
        {
            TemplateChunksEntity templates = new TemplateChunksEntity();
            templates.ChunkID = chunkid;
            templates.TemplateGUID = templateguid;
            templates.IsPreParsed = ispreparsed;
            templates.HTMLText = htmltext;
            templates.ChunkType = chunktype;
            templates.Prefix = prefix;
            templates.TagName = tagname;
            templates.Attributes = attributes;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(templates);
        }

		public static int SaveChunksFromSource(Guid templateGUID, string source)
		{

			//Chekc if guid exists with oarsed = true
			if (SelectCount(templateGUID, true) > 0)
			{
				Delete(templateGUID, true);
			}
			//Pass to parser.

			//get chunks

			//save chunks with incrementing chunk id;

			int currentChunk = 1;
			HtmlParser parser = new HtmlParser();
			EntityCollection<TemplateChunksEntity> chunkcoll = new EntityCollection<TemplateChunksEntity>();

			List<HtmlChunk> chunks = parser.ParseToChunks(source);

			foreach(HtmlChunk chunk in chunks)
			{
				TemplateChunksEntity chunkEntity = new TemplateChunksEntity(templateGUID, true, currentChunk);
				currentChunk++;
				chunkEntity.HTMLText = chunk.Value;
				chunkEntity.ChunkType = (byte)chunk.ChunkType;
				if (chunk.ChunkType == HtmlChunkType.Tag || chunk.ChunkType == HtmlChunkType.Region)
				{
					HtmlTag chunkTag = (HtmlTag)chunk;
					chunkEntity.Prefix = chunkTag.Prefix;
					chunkEntity.TagName = chunkTag.TagName;
					chunkEntity.Attributes = chunkTag.AttributesAsString;
				}
				chunkcoll.Add(chunkEntity);
			}

			DataAccessAdapter da = new DataAccessAdapter();
			return da.SaveEntityCollection(chunkcoll);

							

		}
		#endregion

		#region DELETE GROUP
		/// <summary>
		/// This function is used to delete an TemplateChunksEntity.
		/// </summary>
		/// <param name="chunkid">Chunk ID</param>
		/// <param name="templateguid">Template GUID</param>
		/// <param name="ispreparsed">Is Preparsed Flag</param>
		/// <returns>True on success, false on fail.</returns>
		public static bool Delete(int chunkid, Guid templateguid, bool ispreparsed)
        {
			TemplateChunksEntity templates = new TemplateChunksEntity(templateguid, ispreparsed, chunkid);
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.DeleteEntity(templates);
        }

		public static int Delete(Guid templateguid)
		{
			DataAccessAdapter ds = new DataAccessAdapter();
			PredicateExpression pred = new PredicateExpression();
			pred.Add(TemplateChunksFields.TemplateGUID == templateguid);
			RelationPredicateBucket bucket = new RelationPredicateBucket(pred);
			return ds.DeleteEntitiesDirectly("TemplateChunksEntity", bucket);
		}

		public static int Delete(Guid templateguid, bool isPreParsed)
		{
			DataAccessAdapter ds = new DataAccessAdapter();
			PredicateExpression pred = new PredicateExpression();
			pred.Add(TemplateChunksFields.TemplateGUID == templateguid);
			pred.Add(TemplateChunksFields.IsPreParsed == isPreParsed);
			RelationPredicateBucket bucket = new RelationPredicateBucket(pred);
			return ds.DeleteEntitiesDirectly("TemplateChunksEntity", bucket);
		}


        #endregion

        #region UPDATE GROUP
        /// <summary>
        /// This function is used to update an TemplateChunksEntity.
        /// </summary>
        /// <param name="chunkid">Chunk ID</param>
        /// <param name="templateguid">Template GUID</param>
        /// <param name="ispreparsed">Is Preparsed Flag</param>
        /// <param name="htmltext">HTML Text</param>
        /// <param name="chunktype">Chunk Type</param>
        /// <param name="prefix">Prefix</param>
        /// <param name="tagname">TagName</param>
        /// <param name="attributes">Attributes</param>
        /// <returns>True on success, False on fail</returns>
        public static bool Update(int chunkid, Guid templateguid, bool ispreparsed, string htmltext, byte chunktype, string prefix, string tagname, string attributes)
        {
			TemplateChunksEntity templates = new TemplateChunksEntity(templateguid, ispreparsed, chunkid);
            templates.IsNew = false;
            templates.ChunkID = chunkid;
            templates.TemplateGUID = templateguid;
            templates.IsPreParsed = ispreparsed;
            templates.HTMLText = htmltext;
            templates.ChunkType = chunktype;
            templates.Prefix = prefix;
            templates.TagName = tagname;
            templates.Attributes = attributes;
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(templates);
        }
        #endregion
    }
}
