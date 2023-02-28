using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSummonPottal : MonoBehaviour
{
    [SerializeField] GameObject demon;

    private void Start()
    {
        AudioController.instance.PlaySFX("PortalSummon");
    }

    public void Disapear()
    {
        Destroy(this.gameObject);
    }
    public void SummonDemon()
    {
        Instantiate(demon, this.transform.position, this.transform.rotation);
    }
}
