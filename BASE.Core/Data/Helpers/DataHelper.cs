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

using System.Data.SqlClient;

namespace BASE.Data.Helpers
{
    public static class DataHelper
    {
        public static bool UpdateEntity(IEntity2 entity)
        {
            DataAccessAdapter ds = new DataAccessAdapter();
            return ds.SaveEntity(entity);
        }

		public static SqlConnection CreateNewSqlConnection()
		{
			return new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["Main.ConnectionString"].ToString());
		}

    }
}
