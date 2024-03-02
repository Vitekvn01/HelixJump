using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator animator;

    [Header("Fall")]
    [SerializeField] private float fallHeight;
    [SerializeField] private float fallSpeedDefault;
    [SerializeField] private float fallSpeedMax;
    [SerializeField] private float fallSpeedAxeleration;

    private float fallSpeed;
    private float floorY;

    private void Start()
    {
        enabled = false;
    }

    private void Update()
    {
        if (transform.position.y > floorY)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        
            if (fallSpeed < fallHeight)
            {
                fallSpeed += fallSpeedAxeleration * Time.deltaTime;
            }        
        }

        else
        {
            transform.position = new Vector3 (transform.position.x, floorY, transform.position.z);
            enabled = false;
        }
    }
    public void Jump()
    {
        animator.speed = 1;
        fallSpeed = fallSpeedDefault;
        Debug.Log("Jump");
    }
    public void Fall(float startFloorY)
    {
        animator.speed = 0;
        enabled = true;
        floorY = startFloorY - fallHeight;
        Debug.Log("fall");
    }
    public void Stop()
    {
        animator.speed = 0;
        Debug.Log("Stop");
    }
}
