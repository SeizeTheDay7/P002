using UnityEngine;

public class MouseClickHandler : MonoBehaviour
{
    [SerializeField] Player player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) RaycastCheck();
    }

    void RaycastCheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 50f))
        {
            hit.collider.GetComponent<IRaycastClickable>()?.OnMouseClick(player);
        }
    }
}
