using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPortalSummonController : MonoBehaviour
{
    private void Start()
    {
        AudioController.instance.PlaySFX("PortalSummon");
    }
    public void EndAnim()
    {
        Destroy(this.gameObject);
    }
}
