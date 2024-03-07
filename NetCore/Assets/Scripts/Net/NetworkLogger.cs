using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkLogger : MonoBehaviour
{
    Vector2 scroll;
    static List<string> log = new();


    void ClearLog()=>log.Clear();
    
    public static void Add(string _msg, Color _color)
    {
        log.Add($"<b><color=#{ColorUtility.ToHtmlStringRGB(_color)}>{_msg}</color></b>");
    }
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width - 300, 0, 300, 300));
        scroll = GUILayout.BeginScrollView(scroll);
        for (int i = 0; i < log.Count; i++)
        {
            GUILayout.Box(log[i]);
        }
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }
}
