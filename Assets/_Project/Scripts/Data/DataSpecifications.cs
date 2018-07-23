using Core.Data;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SA._Data {
  /*
  Decks
  */
  [XmlRoot("PlayerData")]
  [System.Serializable]
  public class PlayerData : XmlData<PlayerData>
  {
    [XmlArray("Deck"), XmlArrayItem("Id")]
    public List<string> Deck = new List<string>();

    [XmlArray("Hand"), XmlArrayItem("Id")]
    public List<string> Hand = new List<string>();

    [XmlArray("Discard"), XmlArrayItem("Id")]
    public List<string> Discard = new List<string>();

    public List<string> InPlay = new List<string>();
  }

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

    [XmlAttribute("name")]
    public string Name;

    [XmlElement("Effect")]
    public string effect;
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
}