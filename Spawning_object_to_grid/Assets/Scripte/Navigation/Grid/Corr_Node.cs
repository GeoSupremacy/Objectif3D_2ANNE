using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;


[Serializable]
public class Corr_Node
{
    
    [field: SerializeField] public GridPointData Grid { get; set; }
    [field: SerializeField] public Vector3 Position { get; set; }
    [field: SerializeField] public List<int> Successors { get; private set; } = new();
    [field: SerializeField] public bool IsSelected { get; set; } = false;
    //Nav
    [field: SerializeField] public float G { get; set; } = float.MaxValue; //distance last from previous
    [field: SerializeField] public float H { get; set; } = float.MaxValue; //distance from final distance
    public float F =>G +H; //totalCost
    [field: SerializeField] public Corr_Node Parent { get; set; }
    //
    //Collision
   
    [field: SerializeField] public GameObject Target { get; set; }
    [field: SerializeField] public LayerMask mask { get; set; }
    public bool IsOpen { get;  set; } = true;



    public void AddSuccessor(int _successor) {  Successors.Add(_successor); }
    public void DrawGizmos(Color _nodeColor, Color _lineColor)
    {
        Gizmos.color = IsOpen ? _nodeColor: Color.clear;
        Gizmos.DrawSphere(Position, .2f);

        for (int i = 0; IsSelected && i < Successors.Count; i++)
          Gizmos.DrawLine(Position, Grid.Nodes[Successors[i]].Position);
        
    }
    public void CheckForObtacle()=> IsOpen=  Physics.OverlapSphere(Position, 1, mask).Length == 0;
    
    
    public void ResetNode()
    {
        H = float.MaxValue;
        G = float.MaxValue;
        Parent = null;
    }
}
