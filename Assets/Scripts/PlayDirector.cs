using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// const

public class PlayDirector : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    GameObject s = GameObject.Find("String");
    s.GetComponent<String>().UpdateString("Hello, World!");
  }

  // Update is called once per frame
  void Update()
  {

  }
}
