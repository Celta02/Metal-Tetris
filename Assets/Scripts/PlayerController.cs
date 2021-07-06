using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Controller _controller;
    Camera _mainCamera;
    Vector2 _mouseWorldPosition;
    public Action<Vector3> PlayerClicked;

    private void OnEnable() => _controller.Enable();
    private void OnDisable() => _controller.Disable();

    private void Awake()
    {
        _controller = new Controller();
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        _controller.Player.MousePosition.performed += t => MousePostion(t.ReadValue<Vector2>());
        _controller.Player.PlacePiece.performed += t => PlacePiece();  
    }

    private void MousePostion(Vector2 cursorInput) => _mouseWorldPosition = _mainCamera.ScreenToWorldPoint(cursorInput);
    private void PlacePiece() => PlayerClicked(_mouseWorldPosition);
}
