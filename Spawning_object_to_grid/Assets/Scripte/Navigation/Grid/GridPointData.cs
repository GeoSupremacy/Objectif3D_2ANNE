using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Grid Point")]
public class GridPointData : ScriptableObject
{
    [field: SerializeField] public List<Corr_Node> Nodes { get; private set; } = new();

    public void ResetCost()  { for (int i = 0; i < Nodes.Count; i++) Nodes[i].ResetNode(); }
           
        
       
    
}
