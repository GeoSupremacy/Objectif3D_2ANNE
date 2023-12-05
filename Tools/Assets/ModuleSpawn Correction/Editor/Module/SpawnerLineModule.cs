using EditorUtils.Handles;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = " Spawner Line Module")]
public class SpawnerLineModule : SpawnerModule
{
    [SerializeField, Range(2, 50)] int numberItems = 10;
    [SerializeField, Range(.1f, 50)] float gap = 1;


    public override void DrawModule(SpawnerToolComponent _tool)
    {
        base.DrawModule(_tool);
        if (!moduleEnable) 
            return;

        numberItems = EditorGUILayout.IntSlider(new GUIContent("Grid size X: "), numberItems, 2, 100);
        gap = EditorGUILayout.Slider(new GUIContent("gap: "), gap, 2, 50);
    }
    public override void DrawSceneModule(Vector3 _origin)
    {
        base.DrawSceneModule(_origin);

        if (!moduleEnable)
            return;

       for(float i = 0; i < numberItems *gap; i+=gap)
        {
            Vector3 _point = _origin + new Vector3(i, 0, 0);
            Handles.DrawWireCube(_point, Vector3.one * 0.5f);
            HandlesUtils.DrawLine(_point, _origin, Color.red);
        }

    }
    public override List<GameObject> Spawn(SpawnerToolComponent _tool)
    {

        List<GameObject> list = new List<GameObject>();
        for (float i = 0; i < numberItems* gap; i+=gap)
            {
                Vector3 _point = _tool.transform.position + new Vector3(i , 0, 0);
                GameObject _item = Instantiate(_tool.ItemBehaviour.PickItem(), _tool.ItemBehaviour.GetItemPosition(_point), Quaternion.identity);
                _item.name += $" [SPAWNNED ->{moduleName}]";
                deleteList.Add(_item);
                list.Add(_item);
            }
        return list;
    }
    public override void Delete()
    {
        base.Delete();
    }
}
