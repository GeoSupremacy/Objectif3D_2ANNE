using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
        UI_Dialog dialog;

    private void Awake()
    {
        UI_Dialog.displayUI += DisplayDialog;
        UI_Dialog.closeUI += CloseDialog;
    }
    void Start()
    {
        dialog.ActiveUI(false);
    }

    void DisplayDialog()
    {
        dialog.ActiveUI(true);
    }
    void CloseDialog()
    {
        dialog.ActiveUI(false);
    }
}
