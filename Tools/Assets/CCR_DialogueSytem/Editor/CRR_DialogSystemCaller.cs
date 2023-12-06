using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CRR_DialogSystemCaller : MonoBehaviour
{
    [MenuItem("CRR_DS/Open")]
    public static void CallDialogSystem()
    {
       
        EditorWindow.GetWindow<CRR_DialogSystemWindow>("DialogueSystem");
    }
}//
