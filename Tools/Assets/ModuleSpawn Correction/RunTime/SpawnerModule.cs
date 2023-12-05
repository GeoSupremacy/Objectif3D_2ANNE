using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
//using EditorUtils.Button;
//using EditorUtils.Handles;
using UnityEditor;
#endif
using UnityEngine;


public abstract class SpawnerModule : ScriptableObject
{
    [SerializeField] protected string moduleName = "";
    [SerializeField] protected bool moduleEnable = false;
    //
    [SerializeField, HideInInspector] protected List<GameObject> deleteList = new();
    public string ModuleName => moduleName;
    public bool ModuleEnable { get =>  moduleEnable; set => moduleEnable = value;}
    public virtual List<GameObject> Spawn(SpawnerToolComponent _tool) { return new List<GameObject>() ; }
    public virtual void Delete() {
        for (int i = 0; i < deleteList.Count; i++)
            DestroyImmediate(deleteList[i]);

        deleteList.Clear();
    }

#if UNITY_EDITOR
    public virtual void DrawModule(SpawnerToolComponent _tool) 
    {
        
        if (GUILayout.Button("Disable"))
        {
            _tool.DisableModule();
           
        }
     
    }
    public virtual void DrawSceneModule(Vector3 _origin)
    {
        
    }
#endif
}//
