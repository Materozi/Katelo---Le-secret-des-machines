using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Emirzota.LeSecretDesMachines
{
    public class PlayerController : MonoBehaviour
    {
        CharacterController characterController;

        public float speed = 6.0f;
        public float jumpSpeed = 8.0f;
        public float gravity = 20.0f;
        public GameObject cameraPlayer;

        private Vector3 moveDirection = Vector3.zero;
        public float smoothRotation = 5.0f;
        void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        void Update()
        {

            if (characterController.isGrounded)
            {
                
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);

            Quaternion newRotation = Quaternion.Euler(transform.eulerAngles.x, cameraPlayer.transform.eulerAngles.y, transform.eulerAngles.z);
            Quaternion oldRotation = transform.localRotation;
            transform.localRotation = Quaternion.Lerp(oldRotation, newRotation, Time.deltaTime*smoothRotation);

        }
    }
}


