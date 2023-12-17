using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ : MonoBehaviour
{
    [SerializeField]
    Dialog_Settings dialog_Settings;
    [SerializeField]
     string id = "id";
    public static Action<PNJ> dialogUI;
    public static Action leftDialogUI;
    bool inChat = false;
    public Dialog_Settings Dialog_Settings => dialog_Settings;
    public string ID { get { return id; } }
    private void Awake()
    {
        Player.onOpenDialog += OpenDialog;
        Player.onLeftDialog += CloseDialog;
    }
    void OpenDialog(string _id)
    {
        if (_id != id)
            return;
        inChat = true;
        dialogUI?.Invoke(this);

    }
    void CloseDialog()
    {
        if ((!inChat))
            return;
        inChat = false;
        dialogUI?.Invoke(this);
        
    }
    void Update()
    {
        
    }
}
