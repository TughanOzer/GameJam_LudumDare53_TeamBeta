using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    //public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public GameObject Dialogfield;


    private Queue<string> sentences;

    private void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog) {

        Dialogfield.SetActive(true);

        //nameText.text = dialog.name;

        sentences.Clear();

        foreach (string sentence in dialog.sentences) { 
        sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence() {
        if(sentences.Count == 0) {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }


    void EndDialog() {
        Dialogfield.SetActive(false);
    }
}
