using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpAndDown : MonoBehaviour
{
    [SerializeField] float maxScaleSize = 1f;

    [SerializeField] float minScaleSize = .5f;
    [SerializeField] private float scaleFactor = .3f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > maxScaleSize || transform.localScale.x < minScaleSize)
        {
            scaleFactor *= -1;
        }
        transform.localScale += new Vector3(scaleFactor, scaleFactor, 0f) * Time.deltaTime;
    }
}