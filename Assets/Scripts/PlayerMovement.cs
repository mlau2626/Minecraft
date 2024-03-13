using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Vector3 playerVelocity;
    bool groundedPlayer;
    [SerializeField] float playerSpeed = 2.0f;
    [SerializeField] float rotateSpeed = 50.0f;
    [SerializeField] float jumpHeight = 1.0f;
    float gravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        Vector3 rotate = new Vector3(0, Input.GetAxis("Horizontal"), 0);
        //controller.transform.Rotate(rotate * rotateSpeed * Time.deltaTime);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Change height position of player
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
