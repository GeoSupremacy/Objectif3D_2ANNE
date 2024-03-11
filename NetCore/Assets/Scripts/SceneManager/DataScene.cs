using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public enum StateOwner
{
    IsServer,
    IsHost,
    IsCLient,
    IsDown,

}
public class DataScene
{
    public static StateOwner stateOwner = StateOwner.IsDown;
}
