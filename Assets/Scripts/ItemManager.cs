using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{

  // public Text debugText;

  public GameObject item_prefab;

  private GameObject item;
  private Item item_;

  public int steps = 0;
  private bool itemFlag = false;
  private bool triggerFlag = false;


  void Update()
  {

    if (steps == 0)
    {
      if (triggerFlag == false)
      {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
          steps++;
          triggerFlag = true;
        }
      }
    }
    else if (steps == 2)
    {
      if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
      {
        steps++;
      }
    }

    if (steps == 1)
    {
      item = Instantiate(item_prefab, transform.position, transform.rotation);
      item_ = item.GetComponent<Item>();
      itemFlag = true;
      steps = 2;
    }
    else if (steps == 3)
    {
      // 投げる
      item_.receiveSteps();
      steps = 4;
    }
    else if (steps == 4)
    {
      itemFlag = false;
      steps = 0;
      triggerFlag = false;
    }

    if (itemFlag == true)
    {
      item_.receiveSteps();
    }

    // debugText.text = steps.ToString();
  }

  public int sendSteps()
  {
    return steps;
  }

}