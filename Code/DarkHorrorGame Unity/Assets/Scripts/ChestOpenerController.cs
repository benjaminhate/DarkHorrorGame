using UnityEngine;

[RequireComponent(typeof(Animation))]
public class ChestOpenerController : PlayerTriggerController
{
    private Animation _animation;

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && trigger)
        {
            Open();
        }
    }

    private void Open()
    {
        _animation.Play();
    }
}