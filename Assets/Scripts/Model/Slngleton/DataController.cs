using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class DataController : Singleton<DataController>
{
    public PlayerVO playerVO;

    public SkeletonVO skeletonVO;

    public StateVO stateVO;

    public SwordVO swordVO;

    public KatanaVO katanaVO;

    public void LoadDataLocal()
    {
        playerVO = new PlayerVO();

        skeletonVO = new SkeletonVO();

        stateVO = new StateVO();

        swordVO = new SwordVO();

        katanaVO = new KatanaVO();
    }
}
