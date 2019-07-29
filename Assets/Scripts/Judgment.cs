using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yoyoManager : MonoBehaviour
{

  private int point = 0;
  [SerializeField] private int add;
  [SerializeField] private GameObject hook;
  public Text text;

  private GameObject oya;

  void Update()
  {
    if (Input.GetKey(KeyCode.UpArrow))
    {
      hook.transform.position += new Vector3(0.0f, 0.0f, 0.5f);
    }
    else if (Input.GetKey(KeyCode.RightArrow))
    {
      hook.transform.position += new Vector3(0.5f, 0.0f, 0.0f);
    }
    else if (Input.GetKey(KeyCode.LeftArrow))
    {
      hook.transform.position += new Vector3(-0.5f, 0.0f, 0.0f);
    }
    else if (Input.GetKey(KeyCode.DownArrow))
    {
      hook.transform.position += new Vector3(0.0f, 0.0f, -0.5f);
    }

    text.text = "point: " + point.ToString();
  }

  void OnTriggerStay(Collider col)
  {
    if (col.gameObject.tag == "yoyo")
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        oya = col.gameObject.transform.parent.gameObject;
        point += add;
        Destroy(oya.gameObject);
      }
    }
  }

}