using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  Vector2 moveSpeed = new Vector2(700, 1940);
  float maxDistance = 10;
  float minDistance = 3;
  float wallHitForce = 300f;
  Vector2 mousePosition;
  Vector2 direction;
  Rigidbody2D rb;
  Animator ani;
  BoxCollider2D bc;
  bool canJump;

  RaycastHit2D wallRay;
  [SerializeField] private LayerMask groundLayerMask;
  float castDistance = 0.1f;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    ani = GetComponent<Animator>();
    canJump = true;
    bc = GetComponent<BoxCollider2D>();
  }

  void Update()
  {
    if (Input.GetMouseButtonUp(0) && canJump)
    {
      jump();
    }
    if (!canJump)
    {
      if (wallHit(1))
      {
        rb.AddForce(new Vector2(-wallHitForce, 0));
        ani.SetBool("hitRight", true);
        ani.SetBool("hitLeft", false);
      }
      if (wallHit(-1))
      {
        rb.AddForce(new Vector2(wallHitForce, 0));
        ani.SetBool("hitLeft", true);
        ani.SetBool("hitRight", false);
      }

    }
  }
  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.transform.tag == "HoppitGround")
    {
      canJump = true;
      ani.SetBool("jumpingFront", false);
      ani.SetBool("jumpingLeft", false);
      ani.SetBool("jumpingRight", false);
      if (ani.GetBool("hitLeft") ||
      ani.GetBool("hitRight"))
      {
        ani.SetBool("hitLeft", false);
        ani.SetBool("hitRight", false);
        ani.SetBool("stunned", true);
      }
    }
  }
  void jump()
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
    rb.AddForce(direction * 0.4f * moveSpeed);
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
    ani.SetBool("stunned", false);
  }
  bool wallHit(int direction)
  {
    wallRay = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.right, castDistance * direction, groundLayerMask);
    return wallRay.collider != null;
  }
}
