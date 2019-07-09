using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YoyoScn : MonoBehaviour
{

  private int systemSteps = 0;
  [SerializeField] private float speed;

  [SerializeField] private Image panel_;
  private float alfa;
  private float red, green, blue;

  void Start()
  {
    red = panel_.color.r;
    green = panel_.color.g;
    blue = panel_.color.b;
    alfa = panel_.color.a;
  }

  void Update()
  {
    if (systemSteps == 0)
    {
      if (alfa > 0.0f)
      {
        alfa -= speed;
        panel_.color = new Color(red, green, blue, alfa);
      }
      else
      {
        systemSteps = 1;
      }
    }

  }

}