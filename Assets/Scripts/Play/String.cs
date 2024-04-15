using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class String : MonoBehaviour
{
  string text;
  int width = 0;

  public void UpdateString(string _text)
  {
    Debug.Log("UpdateString");
    text = _text;
    // delete current all children
    foreach (Transform child in transform)
    {
      Destroy(child.gameObject);
    }
    int currentX = 0;
    // add new chars
    for (int i = 0; i < text.Length; i++)
    {
      GameObject c = Instantiate(Resources.Load<GameObject>("Prefabs/Char"), transform);
      c.GetComponent<Char>().UpdateChar(text[i]);
      c.transform.localPosition = new Vector3(currentX, 0, 0);
      currentX += (c.GetComponent<Char>().GetWidth() + 1) * Const.UNIT_PER_DOT;
    }
    width = currentX;
  }

  void Start()
  {

  }
}
