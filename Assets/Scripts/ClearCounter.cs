using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{

    [SerializeField]
    private KitchenObjectSO kitchenObjectSO;

    [SerializeField]
    private Transform counterTop;

    private KitchenObject kitchenObject;

    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private void Update()
    {
        if(testing && Input.GetKeyDown(KeyCode.T))
        {
            if(kitchenObject != null)
            {
                kitchenObject.SetclearCounter(secondClearCounter);
            }
        }
    }
    public void Interact()
    {
        if (kitchenObject == null)
        {
            //Spawn Objects
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTop);
            kitchenObjectTransform.localPosition = Vector3.zero;
            kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            kitchenObject.SetclearCounter(this);
        }
        else
        {
            Debug.Log(kitchenObject.GetClearCounter());
        }

    }
    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTop;
    }

    public void SetKitchenObject (KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public bool ClearKitchenObject()
    {
        return kitchenObject != null;
    }
}
