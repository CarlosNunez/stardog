using UnityEngine;

public class Shield : PowerUp
{
    public override void Give(Player player)
    {
        player.Bluff(Bluff.SHIELD);
        Destroy(gameObject);
    }
}
