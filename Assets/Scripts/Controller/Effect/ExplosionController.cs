using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class ExplosionController : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void EndAnim()
    {
        PoolingObject.DestroyPooling<ExplosionController>(this);
    }
}
