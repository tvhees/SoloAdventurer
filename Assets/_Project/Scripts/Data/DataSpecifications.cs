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
  [XmlArray("Cards"), XmlArrayItem("Card")]
  public List<CardData> Cards = new List<CardData>();
}

[System.Serializable]
public class CardData
{
  [XmlAttribute("id")]
  public string Id;
}

/*
  Tiles
*/
[XmlRoot("TileCollection")]
[System.Serializable]
public class TileCollection : XmlData<TileCollection>
{
  [XmlArray("Tiles"), XmlArrayItem("Tile")]
  public List<TileData> Tiles = new List<TileData>();
}

[System.Serializable]
public class TileData
{
  [XmlAttribute("id")]
  public string Id;
}

/*
  Enemies
*/
[XmlRoot("EnemyCollection")]
[System.Serializable]
public class EnemyCollection : XmlData<EnemyCollection>
{
  [XmlArray("Enemies"), XmlArrayItem("Enemy")]
  public List<EnemyData> Enemies = new List<EnemyData>();
}

[System.Serializable]
public class EnemyData
{
  [XmlAttribute("id")]
  public string Id;
}