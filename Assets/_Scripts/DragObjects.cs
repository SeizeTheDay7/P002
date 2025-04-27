using UnityEngine;

public class DragObjects : MonoBehaviour
{
    private Transform holdingObjTransform;
    private float holdingObjYPos;
    private int groundMask;

    void Start()
    {
        groundMask = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        HandleMouseInput();

        if (holdingObjTransform != null) FollowMouse();
    }

    private void HandleMouseInput()
    {
        // 마우스를 클릭하면 게임 오브젝트 드래그 시작
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 50f))
            {
                if (hit.collider.GetComponent<IRaycastClickable>() != null)
                {
                    holdingObjTransform = hit.collider.gameObject.transform;
                    holdingObjYPos = holdingObjTransform.position.y;
                }
            }
        }
        // 마우스를 떼면 드래그 종료
        else if (Input.GetMouseButtonUp(0))
        {
            holdingObjTransform = null;
        }
    }

    private void FollowMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 50f, groundMask))
        {
            holdingObjTransform.position = new Vector3(hit.point.x, hit.point.y + holdingObjYPos, hit.point.z);
        }
    }
}
