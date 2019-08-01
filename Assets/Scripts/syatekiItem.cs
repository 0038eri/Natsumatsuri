using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class syatekiItem : MonoBehaviour
{

  [SerializeField] private VRInteractiveItem m_InteractiveItem;
  public bool isGazeOver;

  private void OnEnable()
  {
    m_InteractiveItem.OnClick += HandleClick;
  }

  private void OnDisable()
  {
    m_InteractiveItem.OnClick -= HandleClick;
  }

  private void HandleClick()
  {
    if (isGazeOver)
    {
      gameObject.GetComponent<Renderer>().material.color = Color.green;
      if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
      {
        Destroy(gameObject);
      }
    }
  }

}