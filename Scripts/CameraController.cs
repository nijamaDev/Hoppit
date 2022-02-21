using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
  public float Xmax; // Maximum value for X
  public Transform Target;   // camera will follow this object
  public Transform camTransform;  //camera transform
  public float SmoothTime;    // change this value to get desired smoothness
  public float vOffset = 2.5f; // Vertical offset between camera and target
  Vector3 velocity = Vector3.zero; // This value will change at the runtime depending on target movement. Initialize with zero vector.
  Vector3 targetPosition;
  float posX = 0, posY = 0, posZ = -10;
  private void LateUpdate()
  {
    limitX();
    limitY();
    targetPosition = new Vector3(posX, posY, posZ);
    camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
  }
  // resolve camera X position
  private void limitX()
  {
    if (Target.position.x < -Xmax)
    {
      posX = -Xmax;
    }
    else if (Target.position.x > Xmax)
    {
      posX = Xmax;
    }
    else
    {
      posX = Target.position.x;
    }
  }
  // resolve camera Y position
  private void limitY()
  {
    if (Target.position.y < -vOffset)
    {
      posY = 0;
    }
    else
    {
      posY = Target.position.y + vOffset;
    }
  }
}