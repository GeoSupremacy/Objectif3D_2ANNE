using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AstarAlgo
{
    [field:SerializeField] public List<Corr_Node> correctPath { get; private set; } = new List<Corr_Node>();
    public void ComputePath(Corr_Node _start, Corr_Node _end )
    {
        _start.Grid.ResetCost();
        List<Corr_Node> _openList = new (), _closeList = new ();
        _start.G = 0;
        _end.H = 0;
        _openList.Add( _start );
        while (_openList.Count > 0 )
        {
            Corr_Node _current = _openList[0];
            _openList.Remove(_current);  
            _closeList.Add( _current );
            if(_current== _end)
            {
                correctPath = GetFinalPath(_start, _end);
                //TODO return final path
                return;
            }
            for (int i = 0; i < _current.Successors.Count; i++)
            {
                Corr_Node _next = _current.Grid.Nodes[_current.Successors[i]];
                if (_closeList.Contains(_next))
                    continue;
                float _hCost = Vector3.Distance(_current.Position, _end.Position);
                float _gCost = _current.G + _hCost;
                if(_gCost< _next.G)//!_openList.Contains(_next)
                {
                    _next.G = _gCost;
                    _next.H = _hCost;
                    _next.Parent = _current;
                    _openList.Add(_next);
                }
            }
        }
    }

    List< Corr_Node> GetFinalPath(Corr_Node _start, Corr_Node _end)
    {
        List<Corr_Node> _path = new();
        Corr_Node _current = _end;
        _path.Add(_end);
        while(_current != _start) 
        { 
            _path.Add(_current.Parent);
            _current= _current.Parent;
        }
        _path.Reverse();
        return _path; 
    }

    public void DrawPath()
    {
        Gizmos.color = Color.magenta;
        for (int i = 0; i < correctPath.Count-1; i++)
        {
         
            Gizmos.DrawLine(correctPath[i].Position+ Vector3.up, correctPath[i + 1].Position+ Vector3.up);
        }
        
    }
}
