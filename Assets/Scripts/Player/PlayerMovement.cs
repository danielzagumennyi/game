using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float playerSpeed = 2.0f;
    public Animator animator;
    private CharacterController _controller;

    private void Start()
    {
        _controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {


        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        _controller.Move(move * (Time.deltaTime * playerSpeed));
        animator.SetFloat("isWalk", Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")));

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
