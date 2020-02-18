using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJam.CharController.Movement;

public class InputHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            var handlerRef = GameObject.Find("CharacterSwitchingHandler").GetComponent<CharacterSwitchHandler>();
            handlerRef.ChangeFocus();
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.D))
            CharacterSwitchHandler.newTarget.MoveRight();
        else if (Input.GetKey(KeyCode.A))
            CharacterSwitchHandler.newTarget.MoveLeft();
        if (Input.GetKeyDown(KeyCode.Space))
            if (CharacterSwitchHandler.newTarget.groundCheck.IsOnGround())
                CharacterSwitchHandler.newTarget.Jump();
    }
}
