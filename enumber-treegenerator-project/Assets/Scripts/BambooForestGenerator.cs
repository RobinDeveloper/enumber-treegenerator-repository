using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public struct MinMax
{
    public float Minimum;
    public float Maximum;
}

public class BambooForestGenerator : MonoBehaviour
{
    [Header("BambooStem variables")]
    [SerializeField] private GameObject m_BambooStemPrefab;
    [SerializeField] private MinMax m_Height;
    [SerializeField] private MinMax m_Thickness;

    [Header("Temp variables")]
    [SerializeField] private Int32 m_BambooCount;

    private List<GameObject> m_BambooTrees = new List<GameObject>();
    
    private void Start()
    {
        GenerateForest();
    }

    private void Update()
    {
        RegenerateBambooForest();
    }

    private void RegenerateBambooForest()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            for (int i = 0; i < m_BambooTrees.Count; i++)
            {
                Destroy(m_BambooTrees[i]);
            }
            
            GenerateForest();
        }
    }
    
    private void GenerateForest()
    {
        int iterationValue = m_BambooCount / 2;
        int offset = 10;
        for (int x = 0; x < iterationValue; x++)
        {
            for (int z = 0; z < iterationValue; z++)
            {
                GameObject bambooTree = Instantiate(m_BambooStemPrefab) as GameObject;
                float thickness = Random.Range(m_Thickness.Minimum, m_Thickness.Maximum);
                bambooTree.transform.localScale =
                    new Vector3(thickness, Random.Range(m_Height.Minimum, m_Height.Maximum), thickness);
                bambooTree.transform.position = new Vector3((x * 1.1f) + offset, 0, (z * 1.1f) + offset);

                bambooTree.AddComponent<BambooTree>().SetupLeafes();
                
                m_BambooTrees.Add(bambooTree);
            }
        }
    }
}
