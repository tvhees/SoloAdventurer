using System.IO;
using UnityEngine;

namespace Core.Data
{
	/// <summary>
	/// Json implementation of file saver
	/// </summary>
	public class JsonSaver<TDataStore> : FileSaver<TDataStore> where TDataStore : IDataStore
	{
		public JsonSaver(string filename)
			: base(filename)
		{
		}

		/// <summary>
		/// Save the specified data store
		/// </summary>
		public override void Save(TDataStore data)
		{
			string json = JsonUtility.ToJson(data, true);

			using (StreamWriter writer = GetWriteStream())
			{
				writer.Write(json);
			}
		}

		/// <summary>
		/// Load the specified data store
		/// </summary>
		public override bool Load(out TDataStore data)
		{
			if (!File.Exists(m_Filename))
			{
				data = default(TDataStore);
				return false;
			}

			using (StreamReader reader = GetReadStream())
			{
				data = JsonUtility.FromJson<TDataStore>(reader.ReadToEnd());
			}

			return true;
		}
	}
}