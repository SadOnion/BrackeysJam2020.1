using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam.CharController.Movement
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]private protected float currentVelocity = 1.5f;

        [SerializeField]private protected float jumpForce = 2f;

        private protected Rigidbody2D ridBody;

        public GroundCheck groundCheck;

        private void Start()
        {
            ridBody = gameObject.GetComponent<Rigidbody2D>();
            groundCheck = new GroundCheck(GetComponent<BoxCollider2D>());
        }

        /// <summary>
        /// Moves the player to the right
        /// </summary>
        public void MoveRight()
        {
            ridBody.AddForce(Vector3.right * currentVelocity * Time.deltaTime);
        }

        /// <summary>
        /// Moves the player to the left
        /// </summary>
        public void MoveLeft()
        {
            ridBody.AddForce(Vector3.left * currentVelocity*Time.deltaTime);
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
