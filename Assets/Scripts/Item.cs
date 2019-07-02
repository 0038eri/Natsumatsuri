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
  [SerializeField] private float velocityValue;

  private GameObject debugObj0;
  private GameObject debugObj1;
  private GameObject debugObj2;
  private GameObject debugObj3;
  private Text debugText0;
  private Text debugText1;
  private Text debugText2;
  private Text debugText3;

  private GameObject itemManager;
  private ItemManager item_manager;

  public OVRInput.Controller controller;

  void Start()
  {
    _rigidbody = GetComponent<Rigidbody>();

    debugObj0 = GameObject.Find("DebugText0");
    debugObj1 = GameObject.Find("DebugText1");
    debugObj1 = GameObject.Find("DebugText2");
    debugObj3 = GameObject.Find("DebugText3");
    debugText0 = debugObj0.GetComponent<Text>();
    debugText1 = debugObj1.GetComponent<Text>();
    debugText2 = debugObj1.GetComponent<Text>();
    debugText3 = debugObj3.GetComponent<Text>();

    itemManager = GameObject.Find("ItemManager");
    item_manager = itemManager.GetComponent<ItemManager>();
  }

  void Update()
  {
    Vector3 angVel = OVRInput.GetLocalControllerAngularVelocity(controller);

    debugText0.text = angVel.ToString();
    debugText1.text = _transform.ToString();
    debugText2.text = controller.ToString();

    if (steps == 2)
    {
      transform.position = itemManager.transform.position;
      transform.rotation = itemManager.transform.rotation;
      _rigidbody.velocity = Vector3.zero;
      _transform = transform.localPosition;
    }
    else if (steps == 3)
    {
      // _velocity = transform.localPosition - _transform;
      _velocity = transform.localPosition;
      _rigidbody.velocity = _velocity * velocityValue;

      // transform.localRotation = OVRInput.GetLocalControllerRotation(controller);
      debugText3.text = _velocity.ToString();
    }
    else if (steps == 4)
    {
      _rigidbody.velocity += new Vector3(0.0f, 5.0f, 0.0f) * Time.deltaTime;
      if (transform.position.y < -10)
      {
        Destroy(this.gameObject);
      }
    }
  }

  void LateUpdate()
  {

  }

  public void receiveSteps()
  {
    steps = item_manager.sendSteps();
  }

}