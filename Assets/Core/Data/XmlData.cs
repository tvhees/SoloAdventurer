using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using RSG.Promises;

namespace Core.Data
{
	[System.Serializable]
	public abstract class XmlData<T> where T : class {
		public void Save(string path)
		{
			var serializer = new XmlSerializer(typeof(T));
			using(var stream = new FileStream(path, FileMode.Create))
			{
				serializer.Serialize(stream, this);
			}
		}
	
		public static T Load(string path)
		{
			var serializer = new XmlSerializer(typeof(T));
			using(var stream = new FileStream(path, FileMode.Open))
			{
				return serializer.Deserialize(stream) as T;
			}
		}

		public static T LoadStreamingAssets (string file)
		{
			var path = System.IO.Path.Combine(Application.streamingAssetsPath, file + ".xml");
			try
			{
				return Load(path);		
			}
			catch(DirectoryNotFoundException e)
			{
				if (path.Contains("StreamingAssets"))
				{
					Debug.LogErrorFormat("{0} Check that the Assets\\StreamingAssets folder exists and is correctly named.\n{1}",
						e.Message, e.StackTrace);
					
					return default(T);
				}
				else
				{
					throw;
				}
			}
			catch (System.Exception)
			{
				throw;
			}
		}
	}
}