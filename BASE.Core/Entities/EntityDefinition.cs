using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using System.Xml;
using BASE.Xml;
using BASE.Modules;

namespace BASE.Entities
{
	/// <summary>
	/// Defines an entity in BASE. Entities are mainly tables in the database(s)used by BASE and its modules.
	/// Entities have many properties for future use which will make them very dynamic.
	/// </summary>
	public class EntityDefinition : XmlDefinitionBase
	{

		private Guid _guid = Guid.Empty;
		private Guid _moduleDefinitionGUID = Guid.Empty;
		private string _tabelName = "";
		private string[] _displayFields;
		private string _displayFormat = "";
		private Guid _defaultViewControlGUID = Guid.Empty;
		private Guid _defaultAttachControlGUID = Guid.Empty;
		private bool _isBuiltIn = false;
		private bool _canBeMaster = false;
		private bool _canBeChild = false;
		private bool _canHaveAttachments = false;
		private bool _canBeAttachment = false;
		private bool _canBeOwned = false;
		private bool _canBeExtended = false;
		private bool _isExtender = false;
		private string _entityToExtend = "";

		private List<Guid> _entityDependenciesGuidList;

		public EntityDefinition(XmlNode defNode, string fileName)
			: base(defNode, fileName)
		{
			//***** Initialize
			_entityDependenciesGuidList = new List<Guid>();

			try
			{

				//set attributes
				//TODO Add in more
				//Required Attributes
				_guid = XmlConvert.ToGuid(defNode.Attributes[EntityXmlAttributes.Guid].Value);
				_tabelName = defNode.Attributes[EntityXmlAttributes.TableName].Value;

				//Not Required Attributes. These attributes require a not null check prior to assignment. 
				//Tertiary provides a perfect solution. If null, assign a defualt value.
				_moduleDefinitionGUID = defNode.Attributes[EntityXmlAttributes.ModuleDefinitionGuid] == null ? Guid.Empty : XmlConvert.ToGuid(defNode.Attributes[EntityXmlAttributes.ModuleDefinitionGuid].Value);
				_displayFields = defNode.Attributes[EntityXmlAttributes.DisplayFields] == null ? new string[0] : defNode.Attributes[EntityXmlAttributes.DisplayFields].Value.Split(",".ToCharArray());
				_displayFormat = defNode.Attributes[EntityXmlAttributes.DisplayFormat] == null ? "" : defNode.Attributes[EntityXmlAttributes.DisplayFormat].Value;
				_defaultAttachControlGUID = defNode.Attributes[EntityXmlAttributes.DefaultAttachControlGuid] == null ? Guid.Empty : XmlConvert.ToGuid(defNode.Attributes[EntityXmlAttributes.DefaultAttachControlGuid].Value);
				_defaultViewControlGUID = defNode.Attributes[EntityXmlAttributes.DefaultViewControlGuid] == null ? Guid.Empty : XmlConvert.ToGuid(defNode.Attributes[EntityXmlAttributes.DefaultViewControlGuid].Value);
				_isBuiltIn = defNode.Attributes[EntityXmlAttributes.IsBultIn] == null ? false : XmlConvert.ToBoolean(defNode.Attributes[EntityXmlAttributes.IsBultIn].Value);
				_canBeMaster = defNode.Attributes[EntityXmlAttributes.CanBeMaster] == null ? false : XmlConvert.ToBoolean(defNode.Attributes[EntityXmlAttributes.CanBeMaster].Value);
				_canBeChild = defNode.Attributes[EntityXmlAttributes.CanBeChild] == null ? false : XmlConvert.ToBoolean(defNode.Attributes[EntityXmlAttributes.CanBeChild].Value);
				_canHaveAttachments = defNode.Attributes[EntityXmlAttributes.CanHaveAttachment] == null ? false : XmlConvert.ToBoolean(defNode.Attributes[EntityXmlAttributes.CanHaveAttachment].Value);
				_canBeAttachment = defNode.Attributes[EntityXmlAttributes.CanBeAttachment] == null ? false : XmlConvert.ToBoolean(defNode.Attributes[EntityXmlAttributes.CanBeAttachment].Value);
				_canBeOwned = defNode.Attributes[EntityXmlAttributes.CanBeOwned] == null ? false : XmlConvert.ToBoolean(defNode.Attributes[EntityXmlAttributes.CanBeOwned].Value);
				_canBeExtended = defNode.Attributes[EntityXmlAttributes.CanBeExtended] == null ? false : XmlConvert.ToBoolean(defNode.Attributes[EntityXmlAttributes.CanBeExtended].Value);
				_isExtender = defNode.Attributes[EntityXmlAttributes.IsExtender] == null ? false : XmlConvert.ToBoolean(defNode.Attributes[EntityXmlAttributes.IsExtender].Value);
				_entityToExtend = defNode.Attributes[EntityXmlAttributes.EntityToExtend] == null ? "" : defNode.Attributes[EntityXmlAttributes.EntityToExtend].Value;




			}
			catch (XmlDefinitionParsingException ex)
			{
#if DEBUG
				Logging.Logger.Log("************ BASEEntityDefinitionParsingException Caught ************");
				Logging.Logger.Log(ex.ToString());
				throw;
#endif
			}
			catch (Exception ex)
			{
#if DEBUG
				Logging.Logger.Log("************ Exception Caught ************");
				Logging.Logger.Log(ex.ToString());
				throw;
#endif
			}

#if DEBUG
			Debug.WriteLine("EntityDefinition Loaded: " + fileName);
#endif

		}

		/// <summary>
		/// Gets the globally unique ID for this entity definition
		/// </summary>
		public Guid Guid
		{
			get { return _guid; }
		}

		/// <summary>
		/// Gets the ModuleDefinition this entity is associated with
		/// </summary>
		public Guid ModuleDefinitionGuid
		{
			get { return _moduleDefinitionGUID; }
		}

		/// <summary>
		/// Gets the table name that this entity is based on
		/// </summary>
		public string TableName
		{
			get { return _tabelName; }
		}

		/// <summary>
		/// Gets a list of field names that are used for auto display of the records in this entity
		/// </summary>
		public string[] DisplayFields
		{
			get { return _displayFields; }
		}

		/// <summary>
		/// Gets a
		/// </summary>
		public string DisplayFormat
		{
			get { return _displayFormat; }
		}

		//public ModuleControlDefinition DefaultViewControlDefinition
		//{
		//    get { return null; }
		//}

		//public ModuleControlDefinition DefaultAttachControlDefinition
		//{
		//    get { return null; }
		//}

		/// <summary>
		/// Gets a value indicating if this is a core BASE entity
		/// </summary>
		public bool IsBultIn
		{
			get { return _isBuiltIn; }
		}

		public bool CanBeMaster
		{
			get { return _canBeMaster; }
		}

		public bool CanBeChild
		{
			get { return _canBeChild; }
		}

		public bool CanHaveAttachments
		{
			get { return _canHaveAttachments; }
		}

		public bool CanBeAttachment
		{
			get { return _canBeAttachment; }
		}

		public bool CanBeOwned
		{
			get { return _canBeOwned; }
		}

		public bool CanBeExtended
		{
			get { return _canBeExtended; }
		}

		public bool IsExtender
		{
			get { return _isExtender; }
		}

		public string EntityToExtend
		{
			get { return _entityToExtend; }
		}

		/// <summary>
		/// Gets the CustomSettings node as defined in the xml metadata
		/// </summary>
		public Dictionary<string, string> CustomSettings
		{
			get { return _customSettings; }
		}

		/// <summary>
		/// Gets the EntityDependanciesGuidList as defined in the xml metadata
		/// </summary>
		public List<Guid> EntityDependanciesGuidList
		{
			get { return _entityDependenciesGuidList; }
		}

		protected override void ParseChildNodes(XmlNode node, string fromFile)
		{
			if (node == null)
				return;

			switch (node.Name)
			{

				case "entityDependencies":
					ParseEntityDependancies(node);
					break;

				default:
					break;
			}

			base.ParseChildNodes(node, fromFile);
		}

		private void ParseEntityDependancies(XmlNode node)
		{
			foreach (XmlNode ent in node.ChildNodes)
			{
				_entityDependenciesGuidList.Add(XmlConvert.ToGuid(ent.Attributes[DependancyXmlAttributes.Guid].Value));
			}
		}

	}
}
