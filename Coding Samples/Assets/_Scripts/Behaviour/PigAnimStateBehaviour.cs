using UnityEngine;
using UnityEngine.Events;

public class PigAnimStateBehaviour : MonoBehaviour
{

    public UnityEvent forwardEvent, backwardEvent, idleEvent;

    private void Start()
    {
        idleEvent.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            forwardEvent.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            backwardEvent.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            idleEvent.Invoke();
        }
    }
}
