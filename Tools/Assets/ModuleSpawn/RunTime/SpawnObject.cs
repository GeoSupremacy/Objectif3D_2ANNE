using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EChoiceSpawn
{
    PrefabChoice,
    ListChoice,
}


public class SpawnObject : MonoBehaviour
{

    #region Property
    [SerializeField] int column;
    [SerializeField] int line;
    [SerializeField] float spaceColumn;
    [SerializeField] float spaceLine;
    [SerializeField] int scale;
    [SerializeField] EChoiceSpawn choice;
    [SerializeField] GameObject spawnObject;
    [SerializeField] List<GameObject> listGameObject;
    [SerializeField, HideInInspector] List<GameObject> deleteList;
    #endregion


    #region Acesseur
    public bool ISValid() => column > 0 && line >0;
    public int Column {get => column; set => column =value; }
    public int Line {get => line; set => line=value;}
    public float SpaceColumn { get => spaceColumn; set => spaceColumn=value;}
    public float SpaceLine { get => spaceLine; set => spaceLine=value;}
    public EChoiceSpawn EChoice { get => choice;set => choice=value;}
    public GameObject CurrentPrefab { get => spawnObject; set => spawnObject=value;}
    public List<GameObject> ListGameObject { get => listGameObject; set => listGameObject = value; }
    public List<GameObject> DeleteList { get => deleteList; }
    #endregion

    
    #region Method
    public void Spawn(bool _dispersion)
    {
      
       

        switch (choice)
        {
            case EChoiceSpawn.PrefabChoice:
                {
                    
                    SpawnPrefab( column,  line,  spaceColumn,  spaceLine, _dispersion);
                    break;
                }
               
            case EChoiceSpawn.ListChoice:
                {
                    
                    SpawnByList(column, line, spaceColumn, spaceLine, _dispersion);
                    break;
                }
                
            default:
                break;
        }


      

    }
    public void Delete()
    {
       

        for (int i = 0; i < deleteList.Count; i++)
            DestroyImmediate( deleteList[i]);
        
        deleteList.Clear();
        

    }

    private void SpawnPrefab(int _column, int _line, float _spaceColumn, float _spaceLine, bool _dispersion)
    {
        int _random;
        if (!spawnObject)
            throw new System.NullReferenceException("SpawnObject => not prefab");
        for (int i = 0; i < line; i++)
            for (int j = 0; j < column; j++)
            {
                _random = Random.Range(0, 10);
                spawnObject = Instantiate(spawnObject);
                if(_dispersion)
                {

                    _random = Random.Range(0, scale);
                    spawnObject.transform.localScale = new Vector3(_random, _random, _random);
                }
                spawnObject.transform.position = new Vector3(transform.position.x + j * spaceColumn, transform.position.y, transform.position.z + i * spaceLine);
                deleteList.Add(spawnObject);
            }
        
    }
    private void SpawnByList(int _column, int _line, float _spaceColumn, float _spaceLine, bool _dispersion)
    {
        int _random, _oky;
        for (int i = 0; i < line; i++)
            for (int j = 0; j < column; j++)
            {
                _random = Random.Range(0, listGameObject.Count);
                if (!listGameObject[_random])
                    throw new System.NullReferenceException("SpawnObject => one element is null");
                spawnObject = Instantiate(listGameObject[_random]);
                if (_dispersion)
                {
                    _oky = Random.Range(0, 100);
                    spawnObject.transform.localScale = new Vector3(_oky, _oky, _oky);
                }
                spawnObject.transform.position = new Vector3(transform.position.x + j * spaceColumn, transform.position.y, transform.position.z + i * spaceLine);
                deleteList.Add(spawnObject);
            }

    }
    #endregion
    private void OnDestroy()=> Delete();
    
}
