using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

  private int steps = 0;
  private Rigidbody _rigidbody;
  private Vector3 _transform;
  private Vector3 _velocity;

  private GameObject debugObj0;
  private GameObject debugObj1;
  private GameObject debugObj3;
  private Text debugText0;
  private Text debugText1;
  private Text debugText3;

  private GameObject itemManager;
  private ItemManager item_manager;

  void Start()
  {
    _rigidbody = GetComponent<Rigidbody>();

    debugObj0 = GameObject.Find("DebugText0");
    debugObj1 = GameObject.Find("DebugText1");
    debugObj3 = GameObject.Find("DebugText3");
    debugText0 = debugObj0.GetComponent<Text>();
    debugText1 = debugObj1.GetComponent<Text>();
    debugText3 = debugObj3.GetComponent<Text>();

    itemManager = GameObject.Find("ItemManager");
    item_manager = itemManager.GetComponent<ItemManager>();
  }

  void Update()
  {
    debugText0.text = _rigidbody.velocity.ToString();
    debugText1.text = _transform.ToString();

    if (steps == 2)
    {
      transform.position = itemManager.transform.position;
    }
    else if (steps == 3)
    {
      _velocity = transform.position - _transform;
      _rigidbody.velocity = _velocity;
      debugText3.text = _velocity.ToString();
    }
    else if (steps == 4)
    {
      if (transform.position.y < -10)
      {
        Destroy(this.gameObject);
      }
    }

    _transform = transform.position;
  }

  public void receiveSteps()
  {
    steps = item_manager.sendSteps();
  }

}