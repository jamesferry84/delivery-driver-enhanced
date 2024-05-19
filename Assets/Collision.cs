using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float delayToDestroy = 0.5f;

    [SerializeField] List<GameObject> deliveryAddresses;
    [SerializeField] GameObject parcel;
    bool hasParcel = false;
    GameObject spawnNewParcelObject;

    SpriteRenderer spriteRenderer;

    [SerializeField] GameObject arrowTarget;
    RotateAround arrowTargetScript;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        foreach (GameObject address in deliveryAddresses)
        {
            address.SetActive(false);
        }
        spawnNewParcelObject = Instantiate(parcel);
        spawnNewParcelObject.SetActive(false);
        arrowTargetScript = arrowTarget.GetComponent<RotateAround>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Crash");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Parcel") && !hasParcel)
        {
            Debug.Log("Collected");
            hasParcel = true;
            spriteRenderer.color = other.GetComponent<SpriteRenderer>().color;
            GameObject addressToDeliver = deliveryAddresses.Last();
            addressToDeliver.SetActive(true);
            arrowTargetScript.SetTarget(addressToDeliver.transform);
            Destroy(other.gameObject, delayToDestroy);
        }

        if (other.tag.Equals("Customer") && hasParcel)
        {
            Debug.Log("Delivered");
            hasParcel = false;
            spriteRenderer.color = noPackageColor;
            GameObject newParcel = Instantiate(spawnNewParcelObject);
            arrowTargetScript.SetTarget(newParcel.transform);
            Destroy(other.gameObject, delayToDestroy);
            deliveryAddresses.RemoveAt(deliveryAddresses.Count - 1);

            newParcel.SetActive(true);
        }

    }
}
