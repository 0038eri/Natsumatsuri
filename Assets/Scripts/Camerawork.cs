using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerawork : MonoBehaviour
{

  [SerializeField] private Transform parentTransform_;
  [SerializeField] private Transform transform_;

  void Update()
  {
    if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
    {
      float X_Rotation = Input.GetAxis("Mouse X");
      float Y_Rotation = Input.GetAxis("Mouse Y");
      parentTransform_.transform.Rotate(0, -X_Rotation, 0);
      transform_.transform.Rotate(Y_Rotation, 0, 0);
    }
  }

}