using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] private Int32 m_Offset;

    [Header("Bamboo Leaf variables")] 
    [SerializeField] private GameObject m_BambooLeafPrefab;
    [SerializeField] private GameObject m_MoleculeNamePrefab;

    private List<List<Molecule>> m_Molecules;

    private List<GameObject> m_BambooTrees = new List<GameObject>();
    
    private void Start()
    {
        EnumberDataParser enumberDataParser = new EnumberDataParser();
        m_Molecules = enumberDataParser.GetMolecules();
        
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
        int iterationValue = m_Molecules.Count / 2;
        for (int x = 0; x < iterationValue; x++)
        {
            for (int z = 0; z < iterationValue; z++)
            {
                GameObject bambooTree = Instantiate(m_BambooStemPrefab) as GameObject;
                float thickness = Random.Range(m_Thickness.Minimum, m_Thickness.Maximum);
                bambooTree.transform.localScale =
                    new Vector3(thickness, Random.Range(m_Height.Minimum, m_Height.Maximum), thickness);
                bambooTree.transform.position = new Vector3((x * Random.Range(m_Offset - 0.2f, m_Offset + 0.2f)) + 10, 0, (z * Random.Range(m_Offset - 0.2f, m_Offset + 0.2f)) + 10);

                bambooTree.AddComponent<BambooTree>().SetupLeafes(m_Molecules[x+z], m_BambooLeafPrefab, m_MoleculeNamePrefab, bambooTree);
                
                m_BambooTrees.Add(bambooTree);
            }
        }
    }
}
