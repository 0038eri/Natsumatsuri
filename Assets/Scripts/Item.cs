using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

  private Rigidbody rigidbody_;

  private GameObject itemManager;
  private ItemManager item_manager;
  private Rigidbody im_rigidbody;

  private int steps = 0;

  private Text text;

  void Start()
  {
    rigidbody_ = GetComponent<Rigidbody>();

    itemManager = GameObject.Find("ItemManager");
    item_manager = itemManager.GetComponent<ItemManager>();
    im_rigidbody = itemManager.GetComponent<Rigidbody>();

    text = GameObject.Find("DebugText").GetComponent<Text>();
  }

  void Update()
  {
    text.text = im_rigidbody.velocity.ToString();

    if (steps == 2)
    {
      transform.position = itemManager.transform.position;
      transform.rotation = itemManager.transform.rotation;
    }
    else if (steps == 3)
    {
      rigidbody_.velocity = im_rigidbody.velocity;
      rigidbody_.angularVelocity = im_rigidbody.angularVelocity;
    }
    else if (steps == 4)
    {
      if (transform.position.y < -10)
      {
        Destroy(this.gameObject);
      }
    }
  }

  public void receiveSteps()
  {
    steps = item_manager.sendSteps();
  }

}