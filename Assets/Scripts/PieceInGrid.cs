using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PieceInGrid 
{
    public static readonly PieceInGrid Box = new PieceInGrid(new int[,] { { 1, 1 }, { 1, 1 } }, Vector2.zero);

    int[,] _grid;
    Vector2 _pivotPoint;
    public int[,] Grid => _grid;
    public Vector2 PivotPoint => _pivotPoint;

    public PieceInGrid(int[,] pieceInGrid, Vector2 pivotPoint)
    {
        _grid = pieceInGrid;
        _pivotPoint = pivotPoint;
    }

}
