using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterWithStatesBehaviour : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;
    private float gravity = -9.81f;

    public CharacterStateMachineData currentCharacterStates;
    public float speed = 3f;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var input = Input.GetAxis("Horizontal") * speed;
        
        switch (currentCharacterStates.value)
        {
            case CharacterStateMachineData.characterStates.StandardWalk:
                movement.Set(input, gravity, 0);
                break;
            case CharacterStateMachineData.characterStates.WallCrawl:
                movement.Set(0, input, 0);
                break;
            case CharacterStateMachineData.characterStates.WalkWithNoGravity:
                movement.Set(input, 0, 0);
                break;
            
        }

        var newMovement = movement * Time.deltaTime;
        controller.Move(newMovement);
    }
}
