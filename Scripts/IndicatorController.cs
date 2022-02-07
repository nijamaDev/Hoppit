using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour
{
  Vector2 mousePosition;
  void Start()
  {

  }

  void Update()
  {
    if (Input.GetMouseButton(0))
    {
      // Get world position for the mouse
      mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      gameObject.transform.position = mousePosition;

    }
    else
    {
      // hide indicator TODO
      gameObject.transform.position = new Vector2(-10, -10);
    }
  }
}
