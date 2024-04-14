using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class Keyboard : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    string[] keys = {
      "~1234567890-=\b",
      "\tQWERTYUIOP[]\\",
      "\0ASDFGHJKL;'\n",
      "\0ZXCVBNM,./\0",
      "\0\0\0\0\0\0\0\0"
    };
    int[][] widths = {
      new int[] { 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 22 },
      new int[] { 17, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 17 },
      new int[] { 22, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 25 },
      new int[] { 27, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 33 },
      new int[] { 14, 14, 14, 86, 14, 14, 14, 14 },
    };
    int height = 12;
    for (int i = 0; i < widths.Length; i++)
    {
      int currentX = 0;
      for (int j = 0; j < widths[i].Length; j++)
      {
        Debug.Log(keys[i][j]);
        GameObject c = Instantiate(Resources.Load<GameObject>("Prefabs/Key"), transform);
        c.GetComponent<Key>().SetChar(keys[i][j]);
        c.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"Images/key_{widths[i][j]}");
        // TODO: 左上を基準点にする
        c.transform.localPosition = new Vector3(currentX, -i * (height + 1) * Const.UNIT_PER_DOT, 0);
        currentX += (widths[i][j] + 1) * Const.UNIT_PER_DOT;
      }
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
