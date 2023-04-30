using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableReader : MonoBehaviour
{
    [SerializeField] TextAsset textAssetData;
    [SerializeField] int colCount;

    [System.Serializable]
    public class List {
        public string dialogText;
        public string itemText;
    }

    [System.Serializable]
    public class DialogList {
        public List[] list;
    }
    public DialogList dialogList = new DialogList();





    void ReadCSV() {
        string[] data = textAssetData.text.Split(new string[] { ";", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / colCount - 1; // 2 = number of Collums
        dialogList.list = new List[tableSize];

        for (int i = 0; i < tableSize; i++) {
            dialogList.list[i] = new List();
            dialogList.list[i].dialogText = data[2 * (i+1)];
            dialogList.list[i].itemText = data[i+1];
        }
    }


    private void Start() {
        ReadCSV();
    }
}
