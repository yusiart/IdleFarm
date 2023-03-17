using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Plant : MonoBehaviour
{
    [SerializeField] private GameObject _cornBag;
    
    public event UnityAction<Plant> OnPlantDied;

    private List<GameObject> _parts;

    private void Start()
    {
        _parts = new List<GameObject>();
        FindAllChildrenObjects();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Mower mower))
        {
            TryDestroyPlant();
        }
    }
    
    private void TryDestroyPlant()
    {
        if (gameObject.GetComponent<PlantGrowth>().IsGrow)
        {
            OnPlantDied?.Invoke(this);
            ActivateParts();
            Vector3 cornBagPosition =
                new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            Instantiate(_cornBag, cornBagPosition, Quaternion.identity);
            Destroy(gameObject, 2f);
        }
    }

    private void FindAllChildrenObjects()
    {
        foreach (Transform ob in transform)
        {
            _parts.Add(ob.gameObject);
            ob.gameObject.SetActive(false);
        }
    }

    private void ActivateParts()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        
        foreach (GameObject ob in  _parts)
        {
            ob.SetActive(true);
        }
    }
}
