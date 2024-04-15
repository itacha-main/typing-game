using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class Keyboard : MonoBehaviour
{
  public static bool JISLayout = true;

  int[][] widths_us = {
    new int[] { 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 22 },
    new int[] { 17, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 17 },
    new int[] { 22, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 25 },
    new int[] { 27, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 33 },
    new int[] { 14, 14, 14, 86, 14, 14, 14, 14 },
  };
  int[][] widths_jis = {
    new int[] { 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12 },
    new int[] { 17, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, -1 },
    new int[] { 22, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12 },
    new int[] { 27, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 23 },
    new int[] { 14, 12, 14, 12, 67, 12, 14, 14, 12, 14 },
  };

  string[] keys_us = {
    "~1234567890-=\b",
    "\tQWERTYUIOP[]\\",
    "\0ASDFGHJKL;'\n",
    "\0ZXCVBNM,./\0",
    "\0\0\0\0\0\0\0\0"
  };
  string[] keys_jis = {
    "\01234567890-^\\\b",
    "\tQWERTYUIOP@[\n",
    "\0ASDFGHJKL;:]",
    "\0ZXCVBNM,./\\\0",
    "\0\0\0\0\0\0\0\0\0\0"
  };
  // Start is called before the first frame update
  void Start()
  {
    int[][] widths = JISLayout ? widths_jis : widths_us;
    string[] keys = JISLayout ? keys_jis : keys_us;
    for (int i = 0; i < widths.Length; i++)
    {
      int currentX = 0;
      for (int j = 0; j < widths[i].Length; j++)
      {
        Debug.Log(keys[i][j]);
        GameObject c = Instantiate(Resources.Load<GameObject>("Prefabs/Key"), transform);
        c.GetComponent<Key>().SetChar(keys[i][j]);
        c.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"Images/key_{widths[i][j]}");
        int height = widths[i][j] == -1 ? 25 : 12;
        int width = widths[i][j] == -1 ? 20 : widths[i][j];
        int dy = height * Const.UNIT_PER_DOT / 2, dx = width * Const.UNIT_PER_DOT / 2;
        c.transform.localPosition = new Vector3(currentX + dx, -i * (height + 1) * Const.UNIT_PER_DOT + dy, 0);
        currentX += (width + 1) * Const.UNIT_PER_DOT;
      }
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
