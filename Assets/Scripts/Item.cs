using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

  private Text text;

  private GameObject itemManager;
  private ItemManager item_manager;
  private Rigidbody im_rigidbody;

  private GameObject RightHandAnchor;

  private int steps = 0;

  void Start()
  {
    itemManager = GameObject.Find("ItemManager");
    item_manager = itemManager.GetComponent<ItemManager>();
    RightHandAnchor = GameObject.Find("RightHandAnchor");
    im_rigidbody = RightHandAnchor.GetComponent<Rigidbody>();
    text = GameObject.Find("DebugText").GetComponent<Text>();
  }

  void Update()
  {
    text.text = steps.ToString();
    if (steps == 2)
    {
      transform.position = itemManager.transform.position;
    }
    else if (steps == 3)
    {
      this.GetComponent<Rigidbody>().velocity = im_rigidbody.velocity;
      this.GetComponent<Rigidbody>().angularVelocity = im_rigidbody.angularVelocity;
    }
  }

  public void receiveSteps()
  {
    steps = item_manager.sendSteps();
  }

}