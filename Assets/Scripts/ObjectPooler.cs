using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CC.Managers
{
	public class ObjectPooler : SingletonMono<ObjectPooler>
    {
		[SerializeField] private GameObject poolPrefab;
		[SerializeField] private GameObject poolObjects;
		[SerializeField] private GameObject createdObjects;

		private Queue<GameObject> pooledObjects;
		internal void Init()
		{
			pooledObjects = new Queue<GameObject>();
		}
		internal GameObject InstantiateFromPool(Vector3 pos)
        {
			if (pooledObjects.Count == 0)
            {
				return Instantiate(poolPrefab, pos, Quaternion.identity, createdObjects.transform);
            }
            else
            {
				GameObject returnObj = pooledObjects.Dequeue();
				returnObj.GetComponentInChildren<MeshCollider>().gameObject.layer = 0; //Default Collision layer
				returnObj.SetActive(true);
				returnObj.transform.SetParent(createdObjects.transform);
				returnObj.transform.position = pos;
				returnObj.transform.localScale = Vector3.one;
				returnObj.GetComponent<Rigidbody>().isKinematic = false;

				return returnObj;
            }
        }
		internal void DestroyIntoPool(GameObject go)
		{
			go.GetComponent<Rigidbody>().isKinematic = true;
			go.SetActive(false);
			go.transform.SetParent(poolObjects.transform);
			pooledObjects.Enqueue(go);
        }

		internal GameObject GetCreateObjectParent()
        {
			return createdObjects;

		}
    }


	/*
	[System.Serializable]
	public class ObjectPoolItem
	{

		public GameObject objectToPool;
		public int amountToPool;
		public bool shouldExpand = true;

		public ObjectPoolItem(GameObject obj, int amt, bool exp = true)
		{
			objectToPool = obj;
			amountToPool = Mathf.Max(amt, 1);
			shouldExpand = exp;
		}
	}

	public class ObjectPooler : SingletonMono<ObjectPooler>
	{
		public List<ObjectPoolItem> itemsToPool;

		public List<List<GameObject>> pooledObjectsList;
		public List<GameObject> pooledObjects;
		private List<int> positions;

		internal void Init()
		{
			pooledObjectsList = new List<List<GameObject>>();
			pooledObjects = new List<GameObject>();
			positions = new List<int>();


			//for (int i = 0; i < itemsToPool.Count; i++)
			//{
			//	ObjectPoolItemToPooledObject(i);
			//}
		}


		public GameObject GetPooledObject(int index)
		{
			int curSize = pooledObjectsList[index].Count;

			for (int i = positions[index] + 1; i < positions[index] + pooledObjectsList[index].Count; i++)
			{

				if (!pooledObjectsList[index][i % curSize].activeInHierarchy)
				{
					positions[index] = i % curSize;
					return pooledObjectsList[index][i % curSize];
				}
			}

			if (itemsToPool[index].shouldExpand)
			{

				GameObject obj = (GameObject)Instantiate(itemsToPool[index].objectToPool);
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledObjectsList[index].Add(obj);
				return obj;

			}

			return null;
		}

		public List<GameObject> GetAllPooledObjects(int index)
		{
			return pooledObjectsList[index];
		}

		public int AddObject(GameObject GO, int amt = 3, bool exp = true)
		{
			ObjectPoolItem item = new ObjectPoolItem(GO, amt, exp);
			int currLen = itemsToPool.Count;
			itemsToPool.Add(item);
			ObjectPoolItemToPooledObject(currLen);
			return currLen;
		}

		public void ObjectPoolItemToPooledObject(int index) //Create object into the pool
		{
			ObjectPoolItem item = itemsToPool[index];

			pooledObjects = new List<GameObject>();
			for (int i = 0; i < item.amountToPool; i++)
			{
				GameObject obj = (GameObject)Instantiate(item.objectToPool);
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledObjects.Add(obj);
			}
			pooledObjectsList.Add(pooledObjects);
			positions.Add(0);

		}
	}*/
}