public class Attack : PowerUp
{
    public override void Give(Player player)
    {
        player.Bluff(Bluff.ATTACK);
        Destroy(gameObject);
    }
}
