using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class StateVO : BaseVO
{
    public StateVO()
    {
        LoadData("State");
        //Debug.Log("Run State");
    }
    public StateInfo LoadStateInfo(int currentState)
    {
        JSONArray array = data.AsArray;
        if (currentState >= array.Count)
        {
            return null;
        }
        Debug.Log(array[currentState].ToString());
        return JsonUtility.FromJson<StateInfo>(array[currentState].ToString());
    }
}
