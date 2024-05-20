using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcel : MonoBehaviour
{
    [SerializeField] GameObject deliveryAddress;

    public GameObject DeliveryAddress
    {
        get => deliveryAddress;
        set => deliveryAddress = value;
    }
}
