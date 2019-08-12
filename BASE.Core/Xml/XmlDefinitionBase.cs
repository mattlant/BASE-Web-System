using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using BASE.Xml;

namespace BASE.Xml
{
	abstract public class XmlDefinitionBase
	{
		/// <summary>
		/// The Name for the item being defined
		/// </summary>
		protected string _name = "";
		/// <summary>
		/// The Description for the item being defined
		/// </summary>
		protected string _description = "";
		/// <summary>
		/// If true the item being defined will not load (will not ne defined)
		/// </summary>
		protected bool _doNotLoad = false;
		/// <summary>
		/// The original file the definition was loaded from
		/// </summary>
		protected string _fromFile = "";
		/// <summary>
		/// hold custom settings for the item being defined.
		/// </summary>
		protected Dictionary<string, string> _customSettings;

		/// <summary>
		/// This is the base class of all Defintion files in BASE Web System
		/// </summary>
		/// <param name="defNode">The node of the current definition in the deifnition file</param>
		/// <param name="fromDefFile">The file from which the definition was loaded. Used only for error output.</param>
		public XmlDefinitionBase(XmlNode defNode, string fromDefFile)
		{
			//Initial error checking
			if (defNode == null)
				throw new ArgumentNullException("defNode", "A non-null Definition node is required");

			//Add back in support for this
			_customSettings = new Dictionary<string, string>();

			//If DoNotLoad exists and is true, set flag and return right away;

            // Modified by Steve because of the null exception that was causing.
            if (defNode != null)
            {
                if (defNode.Attributes != null)
                {
                    if (defNode.Attributes[DefinitionBaseXmlAttributes.DoNotLoad] != null)
                    {

                        if (XmlConvert.ToBoolean(defNode.Attributes[DefinitionBaseXmlAttributes.DoNotLoad].Value) == true)
                        {
                            _doNotLoad = true;
                            return;
                        }
                    }
                }
            }

			//Set the file loaded from
			_fromFile = fromDefFile;

			List<string> temp = new List<string>();
			//Check for required attributes
			AssertWithExceptionIsMissingAttributes(defNode, temp);
			//Retreive the name and description from the definition
			_name = defNode.Attributes[DefinitionBaseXmlAttributes.Name] == null ? "" : defNode.Attributes[DefinitionBaseXmlAttributes.Name].Value;
			_description = defNode.Attributes[DefinitionBaseXmlAttributes.Description] == null ? "" : defNode.Attributes[DefinitionBaseXmlAttributes.Description].Value;


			//*********** PARSE CHILD NODES *********** 
			//ParseChildNodes is expected to be overidden in definition classes to parse relatedhildren
			foreach (XmlNode childNode in defNode.ChildNodes)
				ParseChildNodes(childNode, fromDefFile);

		}

		/// <summary>
		/// Gets a custom setting from the CustomSettings section of the definition.
		/// </summary>
		/// <param name="key">The key of the CustomSetting Value to retreive.</param>
		/// <returns>The Value of the Custom Setting.</returns>
		public virtual string GetCustomSetting(string key)
		{
			return _customSettings[key];
		}

		/// <summary>
		/// Gets the Name of the definition
		/// </summary>
		public virtual string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Gets a flag indicating if this Definition is to not be loaded
		/// </summary>
		public virtual bool DoNotLoad
		{
			get { return _doNotLoad; }
		}

		/// <summary>
		/// Gets the Description of the definition
		/// </summary>
		public virtual string Description
		{
			get { return _description; }
		}

		/// <summary>
		/// Will throw an exception if the node is missing attributes
		/// </summary>
		/// <param name="node"></param>
		protected void AssertWithExceptionIsMissingAttributes(XmlNode node, List<string> attrToCkeck)
		{
			string missingAttr = "";
			if (IsMissingAttributes(node, attrToCkeck, ref missingAttr))
			{
				//TODO: Log this action
				Logging.Logger.Log("Required attribute(s) missing: " + missingAttr + " from file: " + _fromFile, BASE.Logging.LogPriority.CriticalError);
				throw new XmlDefinitionParsingException("Required attribute(s) missing: " + missingAttr, _fromFile);
			}
		}

		/// <summary>
		/// This method must be overriden in the inherited class to add required attributes. Then call base.IsMissingAttributes.
		/// </summary>
		/// <param name="node">The node being parsed</param>
		/// <param name="missingAttr">The list of attributes to be checked</param>
		/// <returns>Returns true if the node is missing a required attribute, false otherwise.</returns>
		protected virtual bool IsMissingAttributes(XmlNode node, List<string> attrToCheck, ref string missingAttr)
		{
			//Add in the basic required attributes
			attrToCheck.AddRange(DefinitionBaseXmlAttributes.RequiredAttributes);

			//Check attributes using the XmlHelper
			missingAttr += Xml.XmlHelper.CheckRequiredAttributes(node, attrToCheck);
			return missingAttr == null ? true : false;

		}
		
		/// <summary>
		/// When overriden in an inherited class, it will pass a refereence to child nodes. Use this method if you need to parse child nodes for this definition.
		/// </summary>
		/// <param name="node">The child XmlNode to be parsed</param>
		/// <param name="fromFile">The original name of the def file</param>
		/// <remarks><b>MAKSE SURE</b> to call the base class LAST!!! otherwise you will generate unnecassary log entries incorrectly stating that there are undefined sections in the definition file. </remarks>
		protected virtual void ParseChildNodes(XmlNode node, string fromFile)
		{
			if (node == null)
				return;

			//TODO: Add in support for custom sections. A module can define a section and this routine can hadnle it.
			//Unrecognized if we got here! This should be the last method called in the inheritance chain.

			/*
			switch (node.Name)
			{
				case "AddSomething":
					//Do Something
					break;

				default:
					//***Unrecognized***
					break;
			}
			*/
			Logging.Logger.Log("Unrecognized section: " + node.Name + " in file: " + fromFile, BASE.Logging.LogPriority.Warning);

		}

		//OBSOLETE, I DONT EVEN KNOW WHY ITS HERE!
		[Obsolete]
		public static XmlDefinitionBase CreateFromFile(string fileName)
		{

			//Make sure we have a valid def file
			if (!fileName.EndsWith(".def"))
				throw new XmlDefinitionParsingException("Invalid definition file type for file '" + fileName + "'", fileName);

			//make sure it exists
			if (!System.IO.File.Exists(fileName))
				throw new System.IO.FileNotFoundException("Definition file not found", fileName);

			return null;
		}

	}
}
