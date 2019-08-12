using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Entities
{
	public static class EntityXmlAttributes
	{

		public static readonly string DoNotLoad = "doNotLoad";
		public static readonly string Name = "name";
		public static readonly string Guid = "guid";
		public static readonly string Description = "description";
		public static readonly string CanHaveAttachment = "canHaveAttachment";
		public static readonly string CanBeAttachment = "canBeAttachment";
		public static readonly string CanBeChild = "canBeChild";
		public static readonly string CanBeExtended = "canBeExtended";
		public static readonly string CanBeMaster = "canBeMaster";
		public static readonly string CanBeOwned = "canBeOwned";
		public static readonly string DefaultAttachControlGuid = "defaultAttachControlGuid";
		public static readonly string DefaultViewControlGuid = "defaultViewControlGuid";
		public static readonly string DisplayFields = "displayFields";
		public static readonly string DisplayFormat = "displayFormat";
		public static readonly string IsBultIn = "isBultIn";
		public static readonly string IsExtender = "isExtender";
		public static readonly string EntityToExtend = "entityToExtend";
		public static readonly string ModuleDefinitionGuid = "moduleDefinitionGuid";
		public static readonly string TableName = "tableName";

		/// <summary>
		/// Gets a string[] array of the required attributes
		/// </summary>
		public static string[] RequiredAttributes
		{
			get
			{
				//ALWAYS REMEMBER TO ADJUST LENGTH!!!

				string[] reqAttributes = new string[3];

				//Add to the list required attributes
				reqAttributes[0] = Name;
				reqAttributes[1] = Guid;
				reqAttributes[2] = TableName;

				return reqAttributes;
			}
		}

	}
}
