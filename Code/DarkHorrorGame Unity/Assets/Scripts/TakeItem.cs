using UnityEngine;
using UnityEngine.Events;

public class TakeItem : PlayerTriggerController
{
    public UnityEvent takeEvent;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && trigger)
        {
            Take();
        }
    }

    private void Take()
    {
        Destroy(gameObject);
        takeEvent.Invoke();
    }
}
