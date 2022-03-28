using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Vector2 moveSpeed = new Vector2(600, 2000);
  private float maxDistance = 8;
  private float minDistance = 1;
  Vector2 mousePosition;
  Vector2 direction;
  Rigidbody2D rb;
  Animator ani;
  bool canJump;
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    ani = GetComponent<Animator>();
    canJump = true;
  }

  void Update()
  {
    if (Input.GetMouseButtonUp(0) && canJump)
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
      rb.AddForce(direction * 0.5f * moveSpeed);
      if (direction.x < -1)
      {
        ani.SetBool("jumpingLeft", true);
      }
      else if (direction.x > 1)
      {
        ani.SetBool("jumpingRight", true);
      }
      else
      {
        ani.SetBool("jumpingFront", true);
      }
      canJump = false;
    }
  }
  void OnCollisionEnter2D(Collision2D col)
  {
    if (col.transform.tag == "HoppitGround")
    {
      canJump = true;
      ani.SetBool("jumpingFront", false);
      ani.SetBool("jumpingLeft", false);
      ani.SetBool("jumpingRight", false);
    }
  }
}
