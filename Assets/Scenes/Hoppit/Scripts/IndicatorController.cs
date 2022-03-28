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
      // Make indicator follow the finger
      mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      gameObject.transform.position = mousePosition;

    }
    if (Input.GetMouseButtonDown(0))
    {
      // show indicator
      gameObject.GetComponent<Renderer>().enabled = true;
    }
    if (Input.GetMouseButtonUp(0))
    {
      // hide indicator when not pressing
      gameObject.GetComponent<Renderer>().enabled = false;
      gameObject.transform.position = new Vector2(-10, -10);
    }
  }
}
