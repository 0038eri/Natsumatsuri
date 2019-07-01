using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
  public GameObject item_prefab;

  private GameObject item;
  private Item _item;

  private int steps = 0;
  private bool itemFlag = false;
  private bool triggerFlag = false;

  private GameObject debugObj2;
  private Text debugText2;

  void Start()
  {
    debugObj2 = GameObject.Find("DebugText2");
    debugText2 = debugObj2.GetComponent<Text>();
  }

  void Update()
  {
    debugText2.text = steps.ToString();

    if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
    {
      if (triggerFlag == false)
      {
        steps++;
      }
      triggerFlag = true;
    }

    if (steps == 1)
    {
      if (itemFlag == false)
      {
        item = Instantiate(item_prefab, transform.position, transform.rotation);
        _item = item.GetComponent<Item>();
        itemFlag = true;
      }
    }
    else if (steps == 2)
    {
      if (triggerFlag == true)
      {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
          steps++;
          _item.receiveSteps();
        }
      }
    }
    else if (steps == 3)
    {
      // 投げる
    }
    else if (steps == 4)
    {
      // 待機
    }
    else if (steps == 5)
    {
      steps = 0;
      itemFlag = false;
      triggerFlag = false;
    }
  }

  void FixedUpdate()
  {
    if (steps == 1)
    {
      steps = 2;
      _item.receiveSteps();
    }
    else if (steps == 3)
    {
      steps = 4;
      _item.receiveSteps();
    }
    else if (steps == 4)
    {
      if (item == null)
      {
        steps = 5;
      }
    }
  }

  public int sendSteps()
  {
    return steps;
  }

}