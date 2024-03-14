using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkLogger : MonoBehaviour
{
    Vector2 scroll;
    static List<string> log = new();


    void ClearLog() => log.Clear();

    public static void Add(string _msg, Color _color)
    {
        log.Add($"<b><color=#{ColorUtility.ToHtmlStringRGB(_color)}>{_msg}</color></b>");
    }
    public static void Add(string _msg)
    {
        log.Add($"<b><color=#{ColorUtility.ToHtmlStringRGB(Color.green)}>{_msg}</color></b>");
    }
    public static void AddWarning(string _msg)
    {
        log.Add($"<b><color=#{ColorUtility.ToHtmlStringRGB(Color.yellow)}>{_msg}</color></b>");
    }
    public static void AddError(string _msg)
    {
        log.Add($"<b><color=#{ColorUtility.ToHtmlStringRGB(Color.red)}>{_msg}</color></b>");
    }
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width - 300, 0, 300, 300));
        scroll = GUILayout.BeginScrollView(scroll);
        for (int i = 0; i < log.Count; i++)
            GUILayout.Box(log[i]);


        if (GUILayout.Button("Clear"))
            ClearLog();

         
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }
}