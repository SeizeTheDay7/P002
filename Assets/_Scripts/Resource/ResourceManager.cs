using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] Transform plane;
    [SerializeField] GameObject test_ore;
    float plane_width;
    float plane_height;
    int attempts;
    int maxAttempts = 10;
    int resourceMask;

    void Start()
    {
        resourceMask = LayerMask.GetMask("Resource");

        Bounds plane_bound = plane.GetComponent<MeshCollider>().bounds;

        plane_width = (plane_bound.max.x - plane_bound.min.x) / 10;
        plane_height = (plane_bound.max.z - plane_bound.min.z) / 10;

        for (int i = 0; i < 10; i++)
        {
            Vector3 resource_pos = PlaneRandomPos();
            if (!Physics.CheckSphere(resource_pos, 0.5f, resourceMask))
            {
                GenNewResource(resource_pos);
            }
        }
    }

    private Vector3 PlaneRandomPos()
    {
        float randomX = Random.Range(-plane_width, plane_width);
        float randomZ = Random.Range(-plane_height, plane_height);

        Vector3 randomLocalPosition = new Vector3(randomX, 0f, randomZ);
        return plane.TransformPoint(randomLocalPosition);
    }

    public void GenNewResource(Vector3 resource_pos)
    {
        Bounds ore_bound = test_ore.GetComponent<Collider>().bounds;
        float ore_height = (ore_bound.max.y - ore_bound.min.y) / 2;
        resource_pos.y += ore_height;

        Instantiate(test_ore, resource_pos, Quaternion.identity);
    }
}