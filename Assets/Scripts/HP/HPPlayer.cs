using UnityEngine;
using Mirror;
public class HPPlayer : NetworkBehaviour
{
    [SyncVar]
    public float HpPlayer = 100f;

    public GameObject objectOfAttackPrefab;

    void OnTriggerEnter(Collider objectOfAttackInTriggerZone) {
        GameObject attack = Instantiate(objectOfAttackPrefab, objectOfAttackInTriggerZone.transform.position, objectOfAttackInTriggerZone.transform.rotation);
        Destroy(objectOfAttackInTriggerZone.gameObject);
        GetDamage();
        HPText.ChangeHealthText(HpPlayer);
    }
    [Command]
    private void GetDamage() {
        if (HpPlayer > 0) {
            HpPlayer -= 10;
        } else {
            print("You are not deathless, so game over");
            Destroy(gameObject);
        }
    }
}
