using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Padding2D
{
    public int Top { get; set; }
    public int Left { get; set; }
  public Padding2D(int top, int left)
    {
        Top = top;
        Left = left;
    }
}
