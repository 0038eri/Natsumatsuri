using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScn : MonoBehaviour
{

  [SerializeField] private Text debugText1;

  private int selectSteps = 0;
  [SerializeField] private float speed;
  private string sceneName = "none";

  [SerializeField] private Image panel_;
  private float alfa;
  private float red, green, blue;

  [SerializeField] private CanvasGroup title_;
  private float title_alfa;
  [SerializeField] private CanvasGroup select_;
  private float select_alfa;

  void Start()
  {
    title_alfa = title_.alpha;
    select_alfa = select_.alpha;

    red = panel_.color.r;
    green = panel_.color.g;
    blue = panel_.color.b;
    alfa = panel_.color.a;
  }

  void Update()
  {
    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
    {
      if (selectSteps == 1)
      {
        selectSteps = 2;
      }
    }

    if (selectSteps == 0)
    {
      if (alfa > 0.0f)
      {
        alfa -= speed;
        panel_.color = new Color(red, green, blue, alfa);
      }
      else
      {
        selectSteps = 1;
      }
    }
    else if (selectSteps == 2)
    {
      if (title_alfa > 0.0f)
      {
        title_alfa -= speed;
        title_.alpha = title_alfa;
      }
      else
      {
        selectSteps = 3;
      }
    }
    else if (selectSteps == 3)
    {
      if (select_alfa < 1.0f)
      {
        select_alfa += speed;
        select_.alpha = select_alfa;
      }
      else
      {
        select_.interactable = true;
        selectSteps = 4;
      }
    }
    else if (selectSteps == 5)
    {
      if (alfa < 1.0f)
      {
        alfa += speed;
        panel_.color = new Color(red, green, blue, alfa);
      }
      else
      {
        switch (sceneName)
        {
          case "yoyo":
            yoyoMethod();
            break;

          case "syateki":
            syatekiMethod();
            break;

          case "wanage":
            syatekiMethod();
            break;

          default:
            break;
        }
      }
    }

    debugText1.text = alfa.ToString();
  }

  public void Yoyo()
  {
    selectSteps = 5;
    sceneName = "yoyo";
  }

  void yoyoMethod()
  {
    SceneManager.LoadScene("Yoyo");
  }

  public void Syateki()
  {
    selectSteps = 5;
    sceneName = "syateki";
  }

  void syatekiMethod()
  {
    SceneManager.LoadScene("Syateki");
  }

  public void Wanage()
  {
    selectSteps = 5;
    sceneName = "wanage";
  }

  void wanageMethod()
  {
    SceneManager.LoadScene("Wanage");
  }

}