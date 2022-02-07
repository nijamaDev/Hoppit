using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Vector2 moveSpeed = new Vector2(300, 700);
  private float maxDistance = 4;
  private float minDistance = 1;
  Vector2 mousePosition;
  Vector2 direction;
  Rigidbody2D rb;
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {


    if (Input.GetMouseButtonUp(0))
    {
      // Get world position for the mouse
      mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      // Get the direction of the mouse relative to the player
      direction = mousePosition - (Vector2)transform.position;
      // Debug.Log(direction);
      if (direction.x < -maxDistance) direction.x = -maxDistance;
      if (direction.x > maxDistance) direction.x = maxDistance;
      if (direction.y > maxDistance) direction.y = maxDistance;
      if (direction.y < minDistance) direction.y = minDistance;
      rb.AddForce(direction * moveSpeed);
    }
  }
}
