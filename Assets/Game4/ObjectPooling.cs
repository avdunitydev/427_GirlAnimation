using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    List<PoolObject> objects;
    Transform objectsParent;

    public void  Inizialize(int count, PoolObject sample, Transform objects_parent)
    {
        objects = new List<PoolObject>();
        objectsParent = objects_parent;
        for (int i = 0; i < count; i++)
        {
            AddObject(sample, objects_parent);
        }
    }

    void AddObject(PoolObject sample, Transform objects_parent)
    {
        GameObject temp = Instantiate(sample.gameObject);
        temp.name = sample.name;
        temp.transform.parent = objects_parent;
        objects.Add(temp.GetComponent<PoolObject>());
        temp.SetActive(false);
    }

    public PoolObject GetObject()
    {
        for (int i = 0; i < objects.Count; ++i)
        {
            if (!objects [i].gameObject.activeInHierarchy)
            {
                return objects [i];
            }
        }
        AddObject(objects [0], objectsParent);
        return objects [objects.Count - 1];
    }

}
