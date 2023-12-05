using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EditorUtils.Button;
using EditorUtils.Handles;
using UnityEditor;

[CreateAssetMenu(fileName = " Spawner Grid Module")]

public class SpawnerGridModule : SpawnerModule
{
    [SerializeField, Range(2, 50)] int sizeX = 2, sizeY = 2;
    [SerializeField, Range(.1f, 50)] float gap = 1;
    public int Total => sizeX * sizeY;

    public override void DrawModule(SpawnerToolComponent _tool)
    {
        base.DrawModule(_tool);
        if (!moduleEnable) return;
        sizeX = EditorGUILayout.IntSlider(new GUIContent("Grid size X: "), sizeX, 2, 50);
        sizeY = EditorGUILayout.IntSlider(new GUIContent("Grid size Y: "), sizeY, 2, 50);
        gap = EditorGUILayout.Slider(new GUIContent("gap: "), gap, 2, 50);
    }
    public override void DrawSceneModule(Vector3 _origin)
    {
        base.DrawSceneModule(_origin);

       if(!moduleEnable) 
            return;

       for (int i = 0; i< sizeX; i++)
        for (int j = 0; j < sizeY; j++)
            {
                Vector3 _point = _origin +new Vector3(i +(gap *i),0,j + (gap * j));
                HandlesUtils.SolidDisc(_point, 0.3f, Color.white);
            }
        

    }
    public override List<GameObject> Spawn(SpawnerToolComponent _tool)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < sizeX; i++)
            for (int j = 0; j < sizeY; j++)
            {
                Vector3 _point = _tool.transform.position + new Vector3(i + (gap * i), 0, j + (gap * j));
                GameObject _item = Instantiate(_tool.ItemBehaviour.PickItem(), _point, Quaternion.identity);
                _item.name += $" [SPAWNNED ->{moduleName}]";
                deleteList.Add(_item);
                list.Add(_item);
            }
        return list;
    }
    public override void Delete( ) 
    {
        base.Delete( );
    }
}

