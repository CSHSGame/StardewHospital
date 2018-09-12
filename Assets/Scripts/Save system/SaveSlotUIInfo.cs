using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotUIInfo : MonoBehaviour {

    public Text fileName;
    public Text date;
    public string filePath;
    public void deleteSelf()
    {

        SaveManager.DeleteSave(filePath);
        Destroy(this.gameObject);
    }
}
