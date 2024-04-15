using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
using Unity.VisualScripting;

public class Key : MonoBehaviour
{

  Color KeyColor = Color.white;
  Color PressedKeyColor = new Color(109 / 255f, 174 / 255f, 202 / 255f);

  KeyCode keyCode = 0;
  KeyCode CharToKeyCode(char c)
  {
    if (c == '\n')
    {
      return KeyCode.Return;
    }
    if ('A' <= c && c <= 'Z')
    {
      return c - 'A' + KeyCode.A;
    }
    return (KeyCode)(c);
  }

  public void SetChar(char c)
  {
    transform.Find("Char").GetComponent<Char>().UpdateChar(c);
    keyCode = CharToKeyCode(c);
  }

  public void SetCharOffset(int y, int x)
  {
    transform.Find("Char").SetLocalPositionAndRotation(new Vector3(x * Const.UNIT_PER_DOT, y * Const.UNIT_PER_DOT, 0), Quaternion.identity);
  }

  public bool KeyDown()
  {
    return Input.GetKeyDown(keyCode);
  }

  public bool KeyUp()
  {
    return Input.GetKeyUp(keyCode);
  }

  public bool KeyPressed()
  {
    return Input.GetKey(keyCode);
  }

  // Start is called before the first frame update
  void Start()
  {
    if (KeyPressed())
    {
      transform.SetLocalPositionAndRotation(new Vector3(transform.localPosition.x, transform.localPosition.y - 1 * Const.UNIT_PER_DOT, 0), Quaternion.identity);
      transform.Find("Char").GetComponent<SpriteRenderer>().color = PressedKeyColor;
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(keyCode))
    {
      transform.SetLocalPositionAndRotation(new Vector3(transform.localPosition.x, transform.localPosition.y - 1 * Const.UNIT_PER_DOT, 0), Quaternion.identity);
      transform.Find("Char").GetComponent<SpriteRenderer>().color = PressedKeyColor;
    }
    if (Input.GetKeyUp(keyCode))
    {
      transform.SetLocalPositionAndRotation(new Vector3(transform.localPosition.x, transform.localPosition.y + 1 * Const.UNIT_PER_DOT, 0), Quaternion.identity);
      transform.Find("Char").GetComponent<SpriteRenderer>().color = KeyColor;
    }
  }
}
