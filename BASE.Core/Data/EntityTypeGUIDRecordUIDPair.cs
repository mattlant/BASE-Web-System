using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Data
{
	public class EntityTypeGUIDRecordUIDPair
	{
		Guid _entityTypeGUID = Guid.Empty;
		int _recordUID = 0;


		public EntityTypeGUIDRecordUIDPair(Guid entityTypeGUID, int recordUID)
		{
			_entityTypeGUID = entityTypeGUID;
			_recordUID = recordUID;

		}

		public override int GetHashCode()
		{
			return _entityTypeGUID.ToString().GetHashCode();
		}

		public Guid EntityTypeGUID
		{
			get { return _entityTypeGUID; }
		}
		public int RecordUID
		{
			get { return _recordUID; }
		}
	}
}
