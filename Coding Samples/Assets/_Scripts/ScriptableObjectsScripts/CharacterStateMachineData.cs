using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class CharacterStateMachineData : ScriptableObject
{
    public enum characterStates
    {
        StandardWalk,
        WalkWithNoGravity,
        WallCrawl
    }
    
    public characterStates value;

    public void StandardWalk()
    {
        value = characterStates.StandardWalk;
    }

    public void WalkWithNoGravity()
    {
        value = characterStates.WalkWithNoGravity;
    }
    
    public void WallCrawl()
    {
        value = characterStates.WallCrawl;
    }
}
