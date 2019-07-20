using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace Data { 
    [Serializable]
    public struct Player
    { 
      public string name;
      public float points;
      public Color32 color;
  }
}
