using UnityEngine;

public class Stone : Ore
{
    public override void OnMouseClick(Player player)
    {
        player.money.Up(1);
    }
}
