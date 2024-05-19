using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] Transform pivotPoint;
    [SerializeField] public Transform target;
    [SerializeField] float rotationSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null) {
            Vector3 Look = transform.InverseTransformPoint(target.transform.position);
            float angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;
            transform.Rotate(0,0, angle);
        }
    }

    public void SetTarget(Transform newTarget) {
        this.target = newTarget;
    }
}
