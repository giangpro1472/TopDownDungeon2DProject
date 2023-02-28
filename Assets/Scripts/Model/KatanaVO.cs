using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class KatanaVO : BaseVO
{
    public KatanaVO()
    {
        LoadData("Katana");
    }
    //public KatanaInfo LoadSwordInfo(int level)
    //{
    //    JSONArray array = data.AsArray;
    //    if (level >= array.Count)
    //    {
    //        return null;
    //    }
    //    Debug.Log(array[level].ToString());
    //    return JsonUtility.FromJson<KatanaInfo>(array[level].ToString());
    //}
}
