using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shatekiManager : MonoBehaviour
{

  [SerializeField] private Camera camera_;
  [SerializeField] private float distance;
  Vector3 center;
  Ray ray;
  RaycastHit hitInfo;

  private int point = 0;
  [SerializeField] private int[] level;
  [SerializeField] private Text text;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Shot();
    }

    center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    ray = camera_.ScreenPointToRay(center);
    if (Physics.Raycast(ray, out hitInfo, distance))
    {
      Debug.DrawLine(ray.origin, hitInfo.point, Color.magenta);
    }

    text.text = "point: " + point.ToString();
  }

  void Shot()
  {
    if (hitInfo.collider.tag == "level0")
    {
      point += level[0];
      Debug.Log("Level0");
    }
    else if (hitInfo.collider.tag == "level1")
    {
      point += level[1];
      Debug.Log("Level1");
    }
    else if (hitInfo.collider.tag == "level2")
    {
      point += level[2];
      Debug.Log("Level2");
    }

    Destroy(hitInfo.collider.gameObject);
  }
}