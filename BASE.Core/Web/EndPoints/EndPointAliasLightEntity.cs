using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Web.EndPoints
{
	/// <summary>
	/// Lightweight class to hold End Point Aliases
	/// </summary>
	public class EndPointAliasLightEntity
	{
		int? _pageUID = null;
		string _endPointUrl;
		string _queryString;
		EndPointAliasType _epaType;

		/// <summary>
		/// initilaizes a new instance of an EndPointAlias
		/// </summary>
		/// <param name="pageUID">The page UID that the alias points to. This can be null. If null, it is not associated with a page. If null, the endPointUrl must be specified.</param>
		/// <param name="endPointUrl">The endpoint url this alias points to. This can be empty or null. If so, it is only associated with a PageEntity. If null or empty, PageUID must not be null</param>
		/// <remarks>If both parameters are null or empty, and exception will be thrown. At least one must be specified. If both are specified, the endPointUrl may only contain extra query string info.</remarks>
		/// <exception cref="ArgumentException">Will be thrown if any parameters are invalid.</exception>
		public EndPointAliasLightEntity(int? pageUID, string endPointUrl, string queryString, EndPointAliasType endPointAliasType)
		{
			if (pageUID == null && string.IsNullOrEmpty(endPointUrl))
				throw new ArgumentException("Either pageUID or endPointUrl (or both) must be specified");
			if (pageUID.HasValue && pageUID.Value < 1)
				throw new ArgumentException("Invalid pageUID. Must be greater than 0.");

			_pageUID = pageUID;
			_endPointUrl = endPointUrl;

			_queryString = queryString;
			_epaType = endPointAliasType;

		}

		public EndPointAliasType EndPointtype
		{
			get { return _epaType; }
		}
		/// <summary>
		/// Gets the page UID that the alias points to. This can be null. If null, it is not associated with a page. If null, the endPointUrl must be specified.
		/// </summary>
		public int? PageUID
		{ get { return _pageUID; } }

		/// <summary>
		/// Gets the endpoint url this alias points to. This can be empty or null. If so, it is only associated with a PageEntity. If null or empty, PageUID must not be null
		/// </summary>
		public string EndPointUrl
		{ get { return _endPointUrl; } }
	}

	public enum EndPointAliasType
	{
		Virtual = 1,
		RelativeURL,
		AbsoluteURL
	}
}
