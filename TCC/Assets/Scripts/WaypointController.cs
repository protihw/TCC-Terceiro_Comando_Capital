using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform[] waypoints;
    private int currentWaypoint = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool isPressed = false;
        bool isMoving = false;
        Vector2 movement = new Vector2(0, 0);

        Debug.LogError(isMoving);

        if (currentWaypoint < waypoints.Length)
        {
            Transform waypoint = waypoints[currentWaypoint];
                
            if (transform.position.x < waypoint.position.x)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    movement.x = 1;
                    isPressed = true;
                }
            }
            else if (transform.position.x > waypoint.position.x)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    movement.x = -1;
                    isPressed = true;
                }
            }
                
            if (transform.position.y < waypoint.position.y)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    movement.y = 1;
                    isPressed = true;
                }
            }
            else if (transform.position.y > waypoint.position.y)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    movement.y = -1;
                    isPressed = true;
                }
            }
                
            movement.Normalize();
            rb.velocity = movement * moveSpeed;

            if (Vector2.Distance(transform.position, waypoint.position) < 0.1f)
            {
                currentWaypoint++;
                
            }

            animator.SetBool("isPressed", isPressed);
        } 
    }
}