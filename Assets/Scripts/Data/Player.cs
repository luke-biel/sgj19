using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace Data {
    [Serializable]
    public class Player
    {
      public float points;
      public Color32 color;
      public string name;
      public Sprite image;
    }
}
