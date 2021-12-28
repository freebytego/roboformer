using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackFinish : MonoBehaviour
{
    private GameObject parentToBind, player;
    private HackController parentHC;
    public int failDamage = 15;

    private void Start()
    {
        parentHC = transform.parent.gameObject.GetComponent<HackController>();
        if (parentHC.getHackedState()) Hack();
    }
    public void Hack()
    {
        if (!parentHC.getHackedState()) parentHC.setHackedState(true);
        parentToBind = transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        parentToBind.GetComponent<EnemyControl>().SwitchControl();
        player.GetComponent<PlayerStatistics>().isHacking = false;
        
        Destroy(gameObject);
    }
    public void Failed()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerStatistics>().isHacking = false;
        player.GetComponent<PlayerStatistics>().DealDamage(failDamage);
        player.GetComponent<Movement>().beingControled = true;
        Destroy(gameObject);
    }
}
