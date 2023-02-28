using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class SwordVO : BaseVO
{
    public SwordVO()
    {
        LoadData("Sword");
    }
    //public SwordInfo LoadSwordInfo(int level)
    //{
    //    JSONArray array = data.AsArray;
    //    if (level >= array.Count)
    //    {
    //        return null;
    //    }
    //    Debug.Log(array[level].ToString());
    //    return JsonUtility.FromJson<SwordInfo>(array[level].ToString());
    //}
}
