using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class CreateController : MonoBehaviour
{
    public ExplosionController hitExplosion;

    public ExplosionController destroyExplosion;

    public NecromancerAttack necromancerAttack;

    public NecromancerSpecialAttack necromancerSpecialAttack;

    public DarkCytheProjectile darkScytheAttack;

    public BestsyWrathProjectile bestsyWrathProjectile;

    public WaterBoltProjectile waterBolt;

    public MeteorProjetile meteor;

    public SkeletonController skeleton;

    public IceZombieController iceZombie;

    public NecromancerController necromancer;

    public FireDemon fireDemon;

    public OrgeController orge;

    public MudSlime mudslime;

    public BossController boss;

    public void CreateHitExplosion(Vector3 pos)
    {
        ExplosionController currentExplosion = PoolingObject.createPooling<ExplosionController>(hitExplosion);
        if (currentExplosion != null)
        {
            currentExplosion.transform.position = pos;
            currentExplosion.transform.rotation = hitExplosion.transform.rotation;
            currentExplosion.gameObject.SetActive(true);
            return;
        }
        Instantiate(hitExplosion, pos, hitExplosion.transform.rotation);
    }

    public void CreateDestroyExplosion(Vector3 pos)
    {
        ExplosionController currentExplosion = PoolingObject.createPooling<ExplosionController>(destroyExplosion);
        if (currentExplosion != null)
        {
            currentExplosion.transform.position = pos;
            currentExplosion.transform.rotation = destroyExplosion.transform.rotation;
            currentExplosion.gameObject.SetActive(true);
            return;
        }
        Instantiate(destroyExplosion, pos, destroyExplosion.transform.rotation);
    }

    public NecromancerAttack CreateNecromancerAttack(Transform shootPos)
    {
        NecromancerAttack currentBullet = PoolingObject.createPooling<NecromancerAttack>(necromancerAttack);
        if (currentBullet != null)
        {
            currentBullet.transform.position = shootPos.position;
            currentBullet.transform.rotation = shootPos.rotation;
            currentBullet.destroy = currentBullet.destroyTime;
            currentBullet.gameObject.SetActive(true);
            return necromancerAttack;
        }

        return Instantiate(necromancerAttack, shootPos.position, shootPos.rotation);
    }

    public NecromancerSpecialAttack CreateNecromancerSpecialAttack(Transform shootPos)
    {
        NecromancerSpecialAttack currentBullet = PoolingObject.createPooling<NecromancerSpecialAttack>(necromancerSpecialAttack);
        if (currentBullet != null)
        {
            currentBullet.transform.position = shootPos.position;
            currentBullet.transform.rotation = shootPos.rotation;
            currentBullet.destroy = currentBullet.destroyTime;
            currentBullet.gameObject.SetActive(true);
            return necromancerSpecialAttack;
        }

        return Instantiate(necromancerSpecialAttack, shootPos.position, shootPos.rotation);
    }

    public DarkCytheProjectile CreateDarkScytheAttack(Transform shootPos)
    {
        DarkCytheProjectile currentBullet = PoolingObject.createPooling<DarkCytheProjectile>(darkScytheAttack);
        if (currentBullet != null)
        {
            currentBullet.transform.position = shootPos.position;
            currentBullet.transform.rotation = shootPos.rotation;
            currentBullet.destroy = currentBullet.destroyTime;
            currentBullet.gameObject.SetActive(true);
            return darkScytheAttack;
        }

        return Instantiate(darkScytheAttack, shootPos.position, shootPos.rotation);
    }

    public BestsyWrathProjectile CreateBestsyAttack(Transform shootPos)
    {
        BestsyWrathProjectile currentBullet = PoolingObject.createPooling<BestsyWrathProjectile>(bestsyWrathProjectile);
        if (currentBullet != null)
        {
            currentBullet.transform.position = shootPos.position;
            currentBullet.transform.rotation = shootPos.rotation;
            currentBullet.destroy = currentBullet.destroyTime;
            currentBullet.gameObject.SetActive(true);
            return bestsyWrathProjectile;
        }

        return Instantiate(bestsyWrathProjectile, shootPos.position, shootPos.rotation);
    }

    public MeteorProjetile CreateMeteorAttack(Transform shootPos)
    {
        MeteorProjetile currentBullet = PoolingObject.createPooling<MeteorProjetile>(meteor);
        if (currentBullet != null)
        {
            currentBullet.transform.position = shootPos.position;
            currentBullet.transform.rotation = shootPos.rotation;
            currentBullet.destroy = currentBullet.destroyTime;
            currentBullet.gameObject.SetActive(true);
            return meteor;
        }

        return Instantiate(meteor, shootPos.position, shootPos.rotation);
    }

    public WaterBoltProjectile CreateWalterBolt(Transform shootPos)
    {
        WaterBoltProjectile currentBullet = PoolingObject.createPooling<WaterBoltProjectile>(waterBolt);
        if (currentBullet != null)
        {
            currentBullet.transform.position = shootPos.position;
            currentBullet.transform.rotation = shootPos.rotation;
            currentBullet.destroy = currentBullet.destroyTime;
            currentBullet.gameObject.SetActive(true);
            return waterBolt;
        }

        return Instantiate(waterBolt, shootPos.position, shootPos.rotation);
    }

    public SkeletonController CreateSkeleton(Vector3 pos)
    {
        return Instantiate(skeleton, pos, transform.rotation);
    }

    public IceZombieController CreateIceZombie(Vector3 pos)
    {
        return Instantiate(iceZombie, pos, transform.rotation);
    }

    public FireDemon CreateFireDemon(Vector3 pos)
    {
        return Instantiate(fireDemon, pos, transform.rotation);
    }

    public NecromancerController CreateNecromancer(Vector3 pos)
    {
        return Instantiate(necromancer, pos, transform.rotation);
    }

    public MudSlime CreateMudSlime(Vector3 pos)
    {
        return Instantiate(mudslime, pos, transform.rotation);
    }

    public OrgeController CreateOrge(Vector3 pos)
    {
        return Instantiate(orge, pos, transform.rotation);
    }

    public BossController CreateBoss(Vector3 pos)
    {
        return Instantiate(boss, pos, transform.rotation);
    }


}

public class Create : SingletonMonoBehaviour<CreateController>
{

}
