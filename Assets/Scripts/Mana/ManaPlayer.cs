using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class ManaPlayer : NetworkBehaviour
{
    public float MaxMana;

    [SyncVar]
    public float PlayerMana;
    private float time = 0f;

    private void Start()
    {
        PlayerMana = MaxMana;
    }
    void Update() 
    {
        if (PlayerMana < MaxMana)
        {
            RecoveryMana();
        }
    }
    [Command]
    public void DecrementMana()
    {
        PlayerMana -= 20f;
        ManaText.ChangeManaText(PlayerMana);
    } //вызов этой функции в месте где instantiate у фаербола
    [Command]
    public void RecoveryMana()
    {
        time += Time.deltaTime;
        if (time > 1) {
            PlayerMana += 1f;
            time = 0f;
            ManaText.ChangeManaText(PlayerMana);
        }
    }
}
