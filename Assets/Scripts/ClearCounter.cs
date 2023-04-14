using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{

    [SerializeField]
    private KitchenObjectSO kitchenObjectSO;

    [SerializeField]
    private Transform counterTop;

    private KitchenObject kitchenObject;
    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            //Spawn Objects
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTop);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
            
        }
        else
        {
            //Give the object to the player
            kitchenObject.SetKitchenObjectParent(player);
            
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

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
