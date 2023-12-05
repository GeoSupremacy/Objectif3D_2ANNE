using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SpawnerToolComponent : MonoBehaviour
{
    [SerializeField] SpawnerModule[] modules = null;
    [SerializeField ] SpawnerItemBehaviour itemBehaviour = new SpawnerItemBehaviour();

    [SerializeField] MySpawnerDictionary<string, List<GameObject>> moduleHistoric = new();   
    public SpawnerItemBehaviour ItemBehaviour => itemBehaviour;
       
    public void InitModule()
    {
        modules = Resources.LoadAll<SpawnerModule>("ToolModules");
    }
    public void DisableModule()
    {
        for (int i = 0; i < modules.Length; i++)
            modules[i].ModuleEnable = false;
        
    }

    public void AddNewItems(string _id, List<GameObject> items)
    {
        if (moduleHistoric.ContainsKey(_id))
            moduleHistoric.Get(_id).AddRange(items);
        else
            moduleHistoric.Add(_id, items);
     
    }
    public void RemoveItems(string _id)
    {
        if (!moduleHistoric.ContainsKey(_id))
            return;
        for (int i = 0; i < moduleHistoric.Get(_id).Count; i++)
        {
            DestroyImmediate(moduleHistoric.Get(_id)[i]);
        }
        moduleHistoric.Get(_id).Clear();
    }
}//
