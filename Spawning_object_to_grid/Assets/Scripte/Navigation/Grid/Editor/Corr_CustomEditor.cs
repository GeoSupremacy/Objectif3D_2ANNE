
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Corr_Grid))]
public class Corr_CustomEditor : Editor
{
    SerializedProperty size, gap, nodeColor, lineColor;
    Corr_Grid grid = null;
    Rect UIPosition;
    private void OnEnable()
    {
        grid = (Corr_Grid)target;
        size = serializedObject.FindProperty("size");
        gap = serializedObject.FindProperty("gap");
        nodeColor = serializedObject.FindProperty("gridNodeColor");
        lineColor = serializedObject.FindProperty("gridLinesColor");
        UIPosition = new Rect(0, 0, 200, 100);
        EditorUtility.SetDirty(grid);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawGridUI();
    }
    private void OnSceneGUI()
    {
        Handles.BeginGUI();
        UIPosition = GUILayout.Window(0, UIPosition, DrawGridSceneWindow, "Grid manager");
        Handles.EndGUI();
        DrawNodesScene();
        serializedObject.ApplyModifiedProperties();
        //
    }
    void DrawGridSceneWindow(int _id)
    {
        size.intValue = EditorGUILayout.IntSlider(size.intValue, 2, 10);
        gap.intValue = EditorGUILayout.IntSlider(gap.intValue, 1, 100);
        nodeColor.colorValue = EditorGUILayout.ColorField(nodeColor.colorValue);
        lineColor.colorValue = EditorGUILayout.ColorField(lineColor.colorValue);
        EditorGUILayout.HelpBox($"Total points count = {grid.Data?.Nodes.Count}", MessageType.Info);
        DrawGridUI();
        GUI.DragWindow();
    }
    void DrawNodesScene()
    {
        for (int i = 0; i < grid.Data?.Nodes.Count; i++)
            if (grid.Data.Nodes[i].IsOpen)
            {
                bool _click = Handles.Button(grid.Data.Nodes[i].Position, Quaternion.identity, .2f, .1f, Handles.CubeHandleCap);
                Handles.Label(grid.Data.Nodes[i].Position, grid.Data.Nodes[i].F.ToString());
                if (_click)
                    grid.Data.Nodes[i].IsSelected = !grid.Data.Nodes[i].IsSelected;
            }
        
    }
    void DrawGridUI()
    {
        if (GUILayout.Button("Generate"))
        {
            grid.Generate();
            SceneView.RepaintAll();
        }
    }
}
