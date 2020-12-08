using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameActionAssetHandler : ScriptableObject
{
    public GameAction gameActionObj;
    public UnityEvent handlerEvent;

    private void OnEnable()
    {
        gameActionObj.action += ActionHandler;
    }

    private void ActionHandler()
    {
        handlerEvent.Invoke();
    }
}
