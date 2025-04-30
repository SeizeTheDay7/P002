using UnityEngine;

public class Stone : Ore
{
    public override void OnMouseClick(Player player)
    {
        player.money.Up(1);
        hp -= 1;
        if (hp <= 0)
        {
            ResourceManager.Instance.GenNewResource();
            Destroy(gameObject);
        }
    }
}
