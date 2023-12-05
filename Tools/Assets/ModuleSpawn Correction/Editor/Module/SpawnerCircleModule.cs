using EditorUtils.Handles;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GridBrushBase;


[CreateAssetMenu(fileName = " Spawner Circle Module")]
public class SpawnerCircleModule : SpawnerModule
{
    [SerializeField, Range(2, 50)] int numberItems = 10;
    [SerializeField, Range(.1f, 50)] float radius = 1;
   

    public override void DrawModule(SpawnerToolComponent _tool)
    {
        base.DrawModule(_tool);
        if (!moduleEnable)
            return;

        numberItems = EditorGUILayout.IntSlider(new GUIContent("Number Items: "), numberItems, 2, 100);
        radius = EditorGUILayout.Slider(new GUIContent("Radius: "), radius, 2, 50);
    }
    public override void DrawSceneModule(Vector3 _origin)
    {
        base.DrawSceneModule(_origin);

        if (!moduleEnable)
            return;
        Handles.DrawWireDisc(_origin, Vector3.up, radius);

        for (int i = 0; i < numberItems; i++)
        {
            float _a = ((float)i / numberItems) * 360f;
            Vector3 _point  =_origin + GetPositionOnCircle(_a);
            Handles.DrawWireDisc(_point, Vector3.up, .3f);
        }
      
    }
    public override List<GameObject> Spawn(SpawnerToolComponent _tool)
    {

        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < numberItems; i++)
        {
            float _a = ((float)i / numberItems) * 360f;
            Vector3 _point = _tool.transform.position + GetPositionOnCircle(_a);
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

    private Vector3 GetPositionOnCircle(float _angle)
    {

        float _y = Mathf.Sin(_angle * Mathf.Deg2Rad) * radius;
            
        float _x = Mathf.Cos(_angle * Mathf.Deg2Rad) * radius;
        return new Vector3(_x, 0, _y);
    }
}
