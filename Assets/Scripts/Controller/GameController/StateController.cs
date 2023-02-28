using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

[System.Serializable]
public class StateInfo
{
    public WaveInfo[] waves;
}
public class StateController : MonoBehaviour
{
    [SerializeField]
    int currentState = 0;

    [SerializeField]
    DoorController door;

    private void Awake()
    {
        Observer.Instance.AddObserver(TOPICNAME.ENDWAVE, EndWave);
    }

    private void Start()
    {
        StartState();
    }

    void EndWave(object data)
    {
        currentState++;
        StartState();
    }

    private void OnDestroy()
    {
        Observer.Instance.RemoveObserver(TOPICNAME.ENDWAVE, EndWave);
    }

    void StartState()
    {
        StateInfo stateInfo = DataController.Instance.stateVO.LoadStateInfo(currentState);
        if (stateInfo == null)
        {
            Debug.Log("Victory");
            door.anim.SetBool("isClearState", true);
            return;
        }

        Wave.Instance.WaveInfos = stateInfo.waves;
        Wave.Instance.StartWave();
    }
}
