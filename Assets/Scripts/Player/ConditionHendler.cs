using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(PlayerMover))]
public class ConditionHendler : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private PlayerGunPool _gunPool;

    private InputReader _inputReader;
    private PlayerMover _mover;
    
    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<PlayerMover>();
        
    }

    private void OnEnable()
    {
        _inputReader.JumpButtonPresed += OnJumpButtonPresed;
        _inputReader.ShotButtonIsPressed += OnShotButtonIsPressed;
    }

    private void OnJumpButtonPresed()
    {
        _mover.Move(_jumpForce);
    }

    private void OnShotButtonIsPressed()
    {
        _gunPool.Spawn();
    }

    private void OnDisable()
    {
        _inputReader.JumpButtonPresed -= OnJumpButtonPresed;
        _inputReader.ShotButtonIsPressed -= OnShotButtonIsPressed;
    }
}
