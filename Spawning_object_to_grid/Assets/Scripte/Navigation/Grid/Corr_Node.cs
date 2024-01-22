using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Corr_Node
{
    [field: SerializeField] public GridPointData Grid { get; set; }
    [field: SerializeField] public Vector3 Position { get; set; }
    [field: SerializeField] public List<int> Successors { get; private set; } = new();
    [field: SerializeField] public bool IsSelected { get; set; } = false;
    public void AddSuccessor(int _successor) => Successors.Add(_successor);
    public void DrawGizmos(Color _nodeColor, Color _lineColor)
    {
        Gizmos.color = _nodeColor;
        Gizmos.DrawSphere(Position, .2f);
        //Gizmos.color = IsSelected ? Color.white :  _lineColor;
        for (int i = 0; IsSelected && i < Successors.Count; i++)
        {
            //GRID.GET(i) 
            Gizmos.DrawLine(Position, Grid.Nodes[Successors[i]].Position);
        }
    }
}
