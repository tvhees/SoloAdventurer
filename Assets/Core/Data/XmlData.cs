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
	
		public static T Load(string fileName)
		{
			var serializer = new XmlSerializer(typeof(T));
			using(var stream = new UnityAssetStream(new []{"Xml", fileName + ".xml"}))
			{
				return serializer.Deserialize(stream) as T;
			}
		}

		public static T LoadStreamingAssets (string fileName)
		{
			//var path = System.IO.Path.Combine(Application.streamingAssetsPath, "Xml", file + ".xml");
			try
			{
				return Load(fileName);		
			}
			catch(DirectoryNotFoundException e)
			{
				Debug.LogErrorFormat("{0} Check that the Assets\\StreamingAssets folder exists and is correctly named.\n{1}",
					e.Message, e.StackTrace);
				
				return default(T);
			}
			catch (System.Exception)
			{
				throw;
			}
		}
	}
}