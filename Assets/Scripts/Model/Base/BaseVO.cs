using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class BaseVO 
{
    protected JSONNode data;
    protected void LoadData(string pathData)
    {
        TextAsset text = Resources.Load<TextAsset>("Data/" + pathData);
        data = JSON.Parse(text.text)["data"];
        if (data == null)
        {
            Debug.Log("NULL");
        }
    }
}
