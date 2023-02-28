using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class CharacterVO : BaseVO
{
    public PlayerInfo GetPlayerInfo(int level)
    {
        JSONArray array = data.AsArray;
        if (level >= array.Count)
        {
            level = array.Count;
        }
        //Debug.Log(array[level - 1].ToString());
        return JsonUtility.FromJson<PlayerInfo>(array[level - 1].ToString());
    }

    //public SkeletonInfo GetSkeletonInfo(int level)
    //{
    //    JSONArray array = data.AsArray;
    //    if (level >= array.Count)
    //    {
    //        level = array.Count;
    //    }
    //    return JsonUtility.FromJson<SkeletonInfo>(array[level - 1].ToString());
    //}

}
