using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField]
    private KitchenObjectSO kitchenObjectSO;
    private ClearCounter clearCounter;
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetclearCounter(ClearCounter clearCounter)
    {
        this.clearCounter = clearCounter;
    }

    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}
