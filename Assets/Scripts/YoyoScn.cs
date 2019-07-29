using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YoyoScn : MonoBehaviour
{

  public Text debugtext;

  private int systemSteps = 0;
  [SerializeField] private float speed;

  [SerializeField] private Image panel_;
  private float alfa;
  private float red, green, blue;
  [SerializeField] private GameObject lazer;
  [SerializeField] private GameObject judgement;

  [SerializeField] CanvasGroup system_;
  private float s_alfa;

  void Start()
  {
    red = panel_.color.r;
    green = panel_.color.g;
    blue = panel_.color.b;
    alfa = panel_.color.a;

    s_alfa = system_.alpha;
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
    // else if (systemSteps == 1)
    // {
    // ゲーム
    // }
    else if (systemSteps == 1)
    {
      if (s_alfa < 1.0f)
      {
        s_alfa += speed;
        system_.alpha = s_alfa;
      }
      else
      {
        system_.interactable = true;
        systemSteps = 2;
      }
    }
    else if (systemSteps == 2)
    {
      judgement.SetActive(false);
      lazer.SetActive(true);
    }
    else if (systemSteps == 3)
    {
      if (alfa < 1.0f)
      {
        alfa += speed;
        panel_.color = new Color(red, green, blue, alfa);
      }
      else
      {
        SceneManager.LoadScene("Start");
      }
    }
  }

  public void System()
  {
    systemSteps = 3;
  }

  public void Debug()
  {
    debugtext.text = "きた！".ToString();
  }

}