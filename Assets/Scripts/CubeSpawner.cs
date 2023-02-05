using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CC.Managers
{
    public class CubeSpawner : SingletonMono<CubeSpawner>
    {
        [SerializeField] private int poolIndex = 0;
        [SerializeField] private float spawnInterval = 1f;
        [SerializeField] private float spawnRadius = 1f;
        [SerializeField] private int burstCount = 10;

        [SerializeField] private Texture2D image;
        private void Start()
        {
            //Invoke("SpawnObjectsBurstMode", 0.5f);
            //InvokeRepeating("SpawnObject", 5f, spawnInterval);
            
            //Invoke("SpawnAccordingImage", 0.5f);
        }

        private void SpawnObjectsBurstMode()
        {
            for (int i=0; i<burstCount; i++)
            {
                SpawnObject();
            }
        }
        private void SpawnObject()
        {
            GameObject obj = ObjectPooler.Instance.GetPooledObject(poolIndex);
            obj.transform.position = new Vector3(transform.position.x + Random.Range(-spawnRadius, spawnRadius), transform.position.y, transform.position.z + Random.Range(-spawnRadius, spawnRadius));
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);
        }
        private void SpawnAccordingImage()
        {
            Color[] pixels = image.GetPixels();
            int width = image.width;
            int height = image.height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = y * width + x;
                    Color pixelColor = pixels[index];

                    GameObject obj = ObjectPooler.Instance.GetPooledObject(poolIndex);
                    obj.GetComponent<Rigidbody>().isKinematic = true;
                    obj.transform.position = new Vector3(x, 0, y);
                    obj.transform.rotation = transform.rotation;
                    obj.SetActive(true);

                    //cube.GetComponent<Renderer>().material.color = pixelColor;
                }
            }
        }

        internal void DestroyObject(GameObject go)
        {
            ObjectPooler.Instance.AddObject(go, 1, true);
        }
    }
}

