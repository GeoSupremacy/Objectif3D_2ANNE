using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Corr_Grid : MonoBehaviour
{
    [SerializeField, Range(2, 10)] int size = 4;
    [SerializeField, Range(1, 100)] int gap = 100;
    [SerializeField] Color gridNodeColor = Color.green, gridLinesColor = Color.red;
    [field: SerializeField] protected LayerMask layerMask;
    [field: SerializeField] public GridPointData Data { get; set; }
    public void Generate()
    {
        if (!Data)
            return;
        Data.Nodes.Clear();
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Vector3 _pos = new Vector3(x * gap, 0, y * gap) + transform.position;
                Corr_Node _ne= new()
                {
                    Grid = Data,
                    Position = _pos,
                    mask = layerMask
                } ;
                _ne.CheckForObtacle();
                Data.Nodes.Add(_ne) ;
            }
        }
        SetSuccessors();
    }
    void SetSuccessors()
    {
        for (int i = 0; i < size * size; i++)
        {
            bool _canRight = i % size != size - 1,
                 _canTop = i >= size,
                 _canDown = i < (size * size) - size,
                 _canLeft = i % size != 0;
            if (_canRight)
            
                    Data.Nodes[i].AddSuccessor(i + 1);
            if (_canLeft)
             
                    Data.Nodes[i].AddSuccessor(i - 1);
            if (_canTop)
            {
                
                    Data.Nodes[i].AddSuccessor(i - size);
                if (_canRight)
                
                        Data.Nodes[i].AddSuccessor((i + 1 - size));
                if (_canLeft)
                    
                        Data.Nodes[i].AddSuccessor((i - 1 - size));
            }
            if (_canDown)
            {
              
                    Data.Nodes[i].AddSuccessor(i + size);
                if (_canRight)
                 
                        Data.Nodes[i].AddSuccessor(i + 1 + size);
                if (_canLeft)
                   
                        Data.Nodes[i].AddSuccessor((i - 1 + size));
            }
        }
    }




    private void OnDrawGizmos()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Gizmos.DrawWireCube(new Vector3(x * gap, 0, y * gap) + transform.position, Vector3.one * .2f);
            }
        }
        for (int i = 0; i < Data?.Nodes.Count; i++)
        {
            Data.Nodes[i].DrawGizmos(gridNodeColor, gridLinesColor);
        }
    }

    private void OnDestroy()
    {
        Data.ResetCost();
    }
}
