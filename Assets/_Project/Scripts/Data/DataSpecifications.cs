using Core.Data;
using System.Collections.Generic;
using System.Xml.Serialization;

/*
  Cards
*/
[XmlRoot("CardCollection")]
[System.Serializable]
public class CardCollection : XmlData<CardCollection>
{
  public List<CardData> Cards = new List<CardData>();
}

[System.Serializable]
public class CardData
{
  [XmlAttribute("Id")]
  public string Id;
}

/*
  Tiles
*/
[XmlRoot("TileCollection")]
[System.Serializable]
public class TileCollection : XmlData<TileCollection>
{
  public List<TileData> Tiles = new List<TileData>();
}

[System.Serializable]
public class TileData
{
  [XmlAttribute("Id")]
  public string Id;
}

/*
  Enemies
*/
[XmlRoot("EnemyCollection")]
[System.Serializable]
public class EnemyCollection : XmlData<EnemyCollection>
{
  public List<EnemyData> Enemys = new List<EnemyData>();
}

[System.Serializable]
public class EnemyData
{
  [XmlAttribute("Id")]
  public string Id;
}