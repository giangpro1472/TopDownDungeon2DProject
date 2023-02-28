using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

[System.Serializable]
public class PlayerInfo
{
    public float HP;
    public float speed;
    public float maxEXP;
    public float mana;
}
public abstract class PlayerController : GameCharacterController
{
    protected Animator anim;
    public EXPController expController;
    public ManaController manaController;

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
        expController.levelUp = LevelUp;
    }

    protected override void Update()
    {
        base.Update();
        OnRun();
    }

    protected void OnRun()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 playerMove = new Vector3(horizontal, vertical, 0).normalized;
        CharacterMove(playerMove);

        if (horizontal == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }

    void LevelUp(int level)
    {
        PlayerInfo playerInfo = GetPlayerInfoFromData(level);
        if (playerInfo == null)
        {

            Debug.Log("Cannot find player");
        }
        speed = playerInfo.speed;
        hpController.SetNewHP(playerInfo.HP);
        expController.SetMaxEXP(playerInfo.maxEXP);
        manaController.SetNewMana(playerInfo.mana);
    }

    private PlayerInfo GetPlayerInfoFromData(int level)
    {
        return DataController.Instance.playerVO.GetPlayerInfo(level);
    }
    public override void TakeDamage(float damage)
    {
        if (isInvincible)
        {
            return;
        }
        else
        {
            base.TakeDamage(damage);
            Debug.Log("Player take damage");
            AudioController.instance.PlaySFX("PlayerHurt");
        }

    }
}

public class Player : SingletonMonoBehaviour<PlayerController>
{

}
