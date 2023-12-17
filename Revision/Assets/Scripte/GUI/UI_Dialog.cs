using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class UI_Dialog : MonoBehaviour
{

       List<TMP_Text> texts;
    [SerializeField]
        TMP_Text textAnswer;
    [SerializeField]
        TMP_Text textQuote;
    [SerializeField]
        GameObject panel; 
    public static Action displayUI;
    public static Action closeUI;
    private void Awake()
    {
        PNJ.dialogUI += OpenDialog;
        PNJ.leftDialogUI += CloseDialog;
    }
    void Start()
    {
        ActiveUI(false);
    }

  
    void Update()
    {
        
    }
  public  void ActiveUI(bool _active)
    {
        panel.SetActive(_active);
        textAnswer.enabled = _active;
        textQuote.enabled = _active;
    }
    void OpenDialog(PNJ pNJ)
    {
        ActiveUI(true);

        textQuote.text = pNJ.Dialog_Settings.Dialogues[0].Quote;
        for (int i = 0; i <= pNJ.Dialog_Settings.Dialogues[0].CountAnswers; i++)
        {
            TMP_Text _text = Instantiate(textAnswer);
            _text.text = pNJ.Dialog_Settings.Dialogues[0].Answer(i);
            texts.Add(_text);
        }


        displayUI?.Invoke();
    }
    void CloseDialog()
    {
        ActiveUI(false);
        closeUI?.Invoke();
    }

    
}
