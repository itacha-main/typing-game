using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Font : MonoBehaviour
{
  static Sprite[] font;

  public static Sprite GetSprite(char c)
  {
    return Instantiate(font[c]);
  }

  void Start()
  {
    font = Resources.LoadAll<Sprite>($"Images/font");
    Debug.Log(font.Length);
  }
}
