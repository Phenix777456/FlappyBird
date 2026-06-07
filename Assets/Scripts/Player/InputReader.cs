using System;
using UnityEngine;
using UnityEngine.UI;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpButton = KeyCode.Space;
    [SerializeField] private KeyCode _shotButton = KeyCode.Mouse1;

    public event Action JumpButtonPresed;
    public event Action ShotButtonIsPressed;

    public void Update()
    {
        if (Input.GetKeyDown(_jumpButton))
            JumpButtonPresed?.Invoke();

        if (Input.GetKeyUp(_shotButton))
            ShotButtonIsPressed?.Invoke();
    }
}
