using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
  int code = 0;
  // small
  public bool small = false;

  public void UpdateChar(char c)
  {
    code = c;
    Debug.Log("UpdateChar " + c + " " + code);
    GetComponent<SpriteRenderer>().sprite = small ? FontSmall.GetSprite(c) : Font.GetSprite(c);
  }

  public int GetWidth()
  {
    return (int)(GetComponent<SpriteRenderer>().sprite.rect.width);
  }
}
