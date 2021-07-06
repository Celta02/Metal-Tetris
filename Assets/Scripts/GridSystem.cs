using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] PieceSO _piece;
    SheetMetalGrid _grid;
    PlayerController _controller;

    private void OnEnable() => _controller.PlayerClicked += PlacePiece;
    private void OnDisable() => _controller.PlayerClicked -= PlacePiece;

    private void Awake() => _controller = GetComponent<PlayerController>();

    void Start()
    {
        _grid = new SheetMetalGrid(6, 10, 1);
    }

    private void PlacePiece(Vector3 mouseWorldPosition)
    {
        _grid.GetXY(mouseWorldPosition, out int x, out int y);
        Vector2Int mousePosition = new Vector2Int(x,y);

        if (!_grid.ValidPositionCheck(mousePosition,_piece)) return;

        _grid.OccupyCells(mousePosition, _piece);
        Instantiate(_piece.PrefabTransform,_grid.GetWorldPosition(x,y) , Quaternion.identity);
    }
}
