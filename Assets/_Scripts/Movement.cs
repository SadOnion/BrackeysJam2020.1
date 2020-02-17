using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam.CharController.Movement
{
    public class Movement : MonoBehaviour
    {
        /// <summary>
        /// Velocity of the player.
        /// </summary>
        private protected float currentVelocity = 1f;

        /// <summary>
        /// Jump force of the player
        /// </summary>
        private protected float jumpForce = 1f;

        /// <summary>
        /// RidigBody of the player
        /// </summary>
        private protected Rigidbody2D ridBody;

        private void Start()
        {
            ridBody = gameObject.GetComponent<Rigidbody2D>();
        }

        private void LateUpdate()                   // TODO: INPUT HANDLER
        {
            if (Input.GetKey(KeyCode.D))
                MoveRight();
            else if (Input.GetKey(KeyCode.A))
                MoveLeft();
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }

        /// <summary>
        /// Moves the player to the right
        /// </summary>
        public void MoveRight()
        {
            ridBody.AddForce(Vector3.right * currentVelocity);
        }

        /// <summary>
        /// Moves the player to the left
        /// </summary>
        public void MoveLeft()
        {
            ridBody.AddForce(Vector3.left * currentVelocity);
        }

        /// <summary>
        /// Prompts the player to jump
        /// </summary>
        public void Jump()
        {
            ridBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
