using UnityEngine;

public class Ore : MonoBehaviour, IRaycastClickable
{
    [SerializeField] protected int hp;

    public virtual void OnMouseClick(Player player) { }
}
