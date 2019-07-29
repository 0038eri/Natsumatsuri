using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wa : MonoBehaviour
{

  private int steps = 0;

  private GameObject waManager;
  private WaManager wa_manager;

  private int colTimer = 0;
  [SerializeField] private int colLimit;

  void Start()
  {
    waManager = GameObject.Find("GameObject");
    wa_manager = waManager.GetComponent<WaManager>();
  }

  void Update()
  {
    if (steps == 2)
    {
      transform.position = waManager.transform.position;
      transform.rotation = waManager.transform.rotation;
    }

  }

  void OnCollisionStay(Collision col)
  {
    if (col.gameObject.tag == "field")
    {
      if (colTimer < colLimit)
      {
        colTimer++;
      }
      else
      {
        Destroy(this.gameObject);
      }
    }
  }

  public void receiveSteps()
  {
    steps = wa_manager.sendSteps();
  }

}