using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Judgment : MonoBehaviour
{

  public Text text;

  void OnTriggerEnter(Collider col)
  {
    if (col.gameObject.tag == "objects")
    {
      Destroy(col.gameObject);
    }
  }

}