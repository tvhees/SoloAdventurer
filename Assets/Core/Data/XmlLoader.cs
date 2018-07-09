using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using RSG.Promises;

namespace Core.Data
{
	public abstract class XmlLoader<T> : MonoBehaviour where T : XmlData
	{
		public string File;
		public T LoadedData;

		public void LoadData()
		{
			var xmlPath = System.IO.Path.Combine(Application.streamingAssetsPath, File + ".xml");
			try
			{
				LoadedData = XmlData.Load<T>(xmlPath);		
			}
			catch(DirectoryNotFoundException e)
			{
				if (xmlPath.Contains("StreamingAssets"))
				{
					Debug.LogErrorFormat("{0} Check that the Assets\\StreamingAssets folder exists and is correctly named.\n{1}",
						e.Message, e.StackTrace);
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

	[System.Serializable]
	public abstract class XmlData {
		public void Save<T>(string path) where T : class
		{
			var serializer = new XmlSerializer(typeof(T));
			using(var stream = new FileStream(path, FileMode.Create))
			{
				serializer.Serialize(stream, this);
			}
		}
	
		public static T Load<T>(string path) where T : class
		{
			var serializer = new XmlSerializer(typeof(T));
			using(var stream = new FileStream(path, FileMode.Open))
			{
				return serializer.Deserialize(stream) as T;
			}
		}
	}
}