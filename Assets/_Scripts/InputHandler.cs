using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJam.CharController.Movement;

public class InputHandler : MonoBehaviour
{
    CharacterSwitchHandler switchHandler;
    MouseSkill mouseSkill;
    private void Start()
    {
        mouseSkill = GameObject.FindObjectOfType<MouseSkill>();
         switchHandler = GameObject.Find("CharacterSwitchingHandler").GetComponent<CharacterSwitchHandler>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
           switchHandler.ChangeFocus();
            mouseSkill.ChangeSkill();
        }
        if (Input.GetMouseButtonDown(0) && PauseMenu.paused==false)
        {
            if(MouseSkill.canUseSkill&& Vector2.Distance(CharacterSwitchHandler.newTarget.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) < mouseSkill.skillRange)
            {
                mouseSkill.skill();
            }
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
