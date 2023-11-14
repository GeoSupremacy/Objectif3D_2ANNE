using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    #region event
    public static event Action OnLookPNJ = null;
    public static event Action OnLookPlayer = null;


    public static event Action OnQUitButton = null;
    public static event Action OnReturntButton = null;
    public static event Action OnDialogueButton = null;
    #endregion
    [SerializeField]
    private TMP_Text dialogue = null;

    [SerializeField]
    private Button quitButton = null;
    [SerializeField]
    private Button returnButton = null;
    [SerializeField]
    private Button dialogButton = null;
    [SerializeField]
    private GameObject Canvas = null;

    public bool IsValid => quitButton && returnButton && dialogButton && dialogue && Canvas;

    private void Awake()
    {

        OnQUitButton += QuitDialogue;
        OnReturntButton += ReturnUI;
        OnDialogueButton += Dialog;
    }


    void Start()
    {
        if (!IsValid)
            throw new System.NullReferenceException(" ManagerUI =>Start() line 40: Missing UIelement");

        quitButton.onClick.AddListener(() => OnQUitButton?.Invoke());
        returnButton.onClick.AddListener( () => OnReturntButton?.Invoke());
        dialogButton.onClick.AddListener(() => OnDialogueButton?.Invoke());

        dialogue.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
    }

   

    private void QuitDialogue()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
    private void ReturnUI()
    {
        quitButton.gameObject.SetActive(true);
        dialogButton.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(false);
        dialogue.gameObject.SetActive(false);
        OnLookPlayer?.Invoke();
    }
    private void Dialog()
    {
        quitButton.gameObject.SetActive(false);
        dialogButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(true);
        dialogue.gameObject.SetActive(true);
   
        //TODO event camera
        OnLookPNJ?.Invoke();
    }
    private void OnDestroy()
    {
        OnQUitButton = null;
        OnReturntButton = null;
        OnDialogueButton = null;
    }
}
