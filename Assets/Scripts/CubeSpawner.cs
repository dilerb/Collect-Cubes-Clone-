using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CC.Managers.GameManager;

namespace CC.Managers
{
    public class CubeSpawner : SingletonMono<CubeSpawner>
    {
        [SerializeField] private int poolIndex = 0;
        [SerializeField] private float spawnInterval = 1f;
        [SerializeField] private float spawnRadius = 1f;
        [SerializeField] private int initialBurst = 100;
        [SerializeField] private int burstCount = 10;

        [SerializeField] private Texture2D image;

        private bool spawnerEnable = false;
        internal void StartSpawn(GameMode _mode)
        {
            spawnerEnable = true;

            if (_mode == GameMode.Classic)
            {
                //Invoke("SpawnAccordingImage", 0.5f);
            }
            else if (_mode == GameMode.TimeChallange)
            {
                StartCoroutine(SpawnObject(burstCount, 0));
                StartCoroutine(SpawnObject(burstCount, spawnInterval));
            }
            else if (_mode == GameMode.RivalAI)
            {
                Invoke("SpawnObjectsBurstMode", 0.5f);
                StartCoroutine(SpawnObject(burstCount, spawnInterval));
            }
        }

        IEnumerator SpawnObject(int burst, float interval)
        {
            while (spawnerEnable)
            {
                if (burst == 0)
                    burst = burstCount;

                for (int i = 0; i < burst; i++)
                {
                    GameObject obj = ObjectPooler.Instance.GetPooledObject(poolIndex);
                    obj.transform.position = new Vector3(transform.position.x + Random.Range(-spawnRadius, spawnRadius), transform.position.y, transform.position.z + Random.Range(-spawnRadius, spawnRadius));
                    obj.transform.rotation = transform.rotation;
                    obj.SetActive(true);
                }

                if (spawnInterval == 0)
                    break;
                else
                    yield return new WaitForSeconds(spawnInterval);
            }
        }
        internal void SpawnAccordingImage()
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

        internal void StopSpawn()
        {
            spawnerEnable = false;
        }

        internal void DestroyObject(GameObject go)
        {
            ObjectPooler.Instance.AddObject(go, 1, true);
        }
    }
}

