using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;

    public Transform cameraHelperTransform;

    public float pushPower = 2.0f;

    private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if(cameraHelperTransform != null){
            move = cameraHelperTransform.rotation * move;
        }

        if (move != Vector3.zero)
        {
            animator.SetBool("isRunning", true);
            gameObject.transform.forward = move;
        } else {
            animator.SetBool("isRunning", false);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(((move * playerSpeed) + playerVelocity) * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(!hit.collider.CompareTag("Pushable")){
            return;
        }
        
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;

        Domino domino;
        if(hit.collider.TryGetComponent<Domino>(out domino)){
            domino.Fall();
        }
    }
}
