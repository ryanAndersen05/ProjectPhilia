using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoolGeneric<T> : MonoBehaviour where T : MonoBehaviour {
    [Tooltip("Will switch between using spawn pool functionality or using Unity's default functions Instantiate and Destroy for spawning and despawning objects")]
    public bool useSpawnPoolFunctionality = true;
    public int initialPoolSize = 10;
    public T[] prefabList = new T[1];

    /// <summary>
    /// Holds a reference to all currently available objects in the spawn pool
    /// </summary>
    private Dictionary<string, Queue<T>> spawnPoolDictionary = new Dictionary<string, Queue<T>>();
    /// <summary>
    /// Keeps a reference to every pooled object whether or not they are available or not
    /// </summary>
    private List<T> allPooledObjects = new List<T>();

    #region monobehaviour methods

    protected virtual void Start()
    {
        InitializeSpawnPoolList();
    }

    protected virtual void OnValidate()
    {
        if (this.initialPoolSize < 1)
        {
            this.initialPoolSize = 1;
        }
    }


    #endregion monobehaviour methods
    #region list management methods

    public virtual void InitializeSpawnPoolList()
    {

        foreach (T prefabToPool in prefabList)
        {
            if (!spawnPoolDictionary.ContainsKey(prefabToPool.name))
            {
                spawnPoolDictionary.Add(prefabToPool.name, new Queue<T>());
            }

            for (int i = 0; i < initialPoolSize; i++)
            {
                T objectToAddToPool = CreateNewPooledPrefab(prefabToPool);
                objectToAddToPool.gameObject.SetActive(false);
                spawnPoolDictionary[prefabToPool.name].Enqueue(objectToAddToPool);
            }
        }
    }

    public virtual void ClearAllPooledObjects()
    {
        
    }

    /// <summary>
    /// You will pass in the prefab of the object that is meant to be spawned here
    /// If this particular pool doesn't hold a reference to this prefab it will return
    /// a null object
    /// </summary>
    /// <param name="prefabObjectToSpawn"></param>
    /// <returns></returns>
    public virtual T Spawn(T prefabObjectToSpawn)
    {
        if (!spawnPoolDictionary.ContainsKey(prefabObjectToSpawn.name))
        {
            Debug.Log("There is no prefab with the name " + prefabObjectToSpawn.name + " found in this specific instance of Spawn Pool");
            return null;
        }
        if (!this.useSpawnPoolFunctionality)
        {
            return CreateNewPooledPrefab(prefabObjectToSpawn);
        }

        Queue<T> spawnQueue = spawnPoolDictionary[prefabObjectToSpawn.name];
        if (spawnQueue.Count > 0)
        {
            T objectToReturn = spawnQueue.Dequeue();
            objectToReturn.gameObject.SetActive(true);

            return objectToReturn;
        }
        return CreateNewPooledPrefab(prefabObjectToSpawn);
    }

    /// <summary>
    /// This method will set the gameobject to inactivate and will make it avaialble to be spawned
    /// Returns true if it was successfully despawned. False if was not a valid object to despawn
    /// </summary>
    /// <param name="objectToDespawn"></param>
    /// <returns></returns>
    public virtual bool Despawn(T objectToDespawn)
    {
        string clonedPrefabName = objectToDespawn.name;
        if (!spawnPoolDictionary.ContainsKey(clonedPrefabName))
        {
            Debug.Log("There is no prefab with the name " + clonedPrefabName + " in this specific instance of Spawn Pool");
            return false;
        }
        objectToDespawn.gameObject.SetActive(false);
        spawnPoolDictionary[clonedPrefabName].Enqueue(objectToDespawn);
        return true;

    }

    /// <summary>
    /// Instantiates a new object and adds it to the list of all allPooledObjects list. Returns the newly created
    /// Monobehaviour object
    /// </summary>
    /// <param name="prefabToCreate"></param>
    /// <returns></returns>
    public T CreateNewPooledPrefab(T prefabToCreate)
    {
        T newlyCreatedObject = Instantiate<T>(prefabToCreate);

        return newlyCreatedObject;
    }
    #endregion list management methods

    #region helper methods
    /// <summary>
    /// Removes the (Clone) phrase that is placed at the end of the cloned
    /// prefabs in order to check if it matches the name of the original prefab object
    /// </summary>
    /// <param name="cloneName"></param>
    /// <returns></returns>
    private string GetPrefabNameFromClone(string cloneName)
    {
        string cloneKeyWord = "(Clone)";
        if (cloneName.Contains(cloneKeyWord))
        {
            return cloneName.Substring(0, cloneKeyWord.Length);
        }
        return cloneName;
    }
    #endregion helper methods
}
