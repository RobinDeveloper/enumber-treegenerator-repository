using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BambooTree : MonoBehaviour
{
    private GameObject m_LeafPrefab;
    private GameObject m_MoleculeNamePrefab;
    private GameObject m_Parent;
    private List<Molecule> m_Molecules = new List<Molecule>();

    public void SetupLeafes(List<Molecule> _molecules, GameObject _leafPrefab, GameObject _moleculeNamePrefab, GameObject _parent)
    {
        m_LeafPrefab = _leafPrefab;
        m_Molecules = _molecules;
        m_Parent = _parent;
        m_MoleculeNamePrefab = _moleculeNamePrefab;
        GenerateLeafs();
    }

    private void GenerateLeafs()
    {
        for (int i = 0; i < m_Molecules.Count; i++)
        {
            GameObject leaf = Instantiate(m_LeafPrefab, this.gameObject.transform, true) as GameObject;
            leaf.GetComponent<BambooLeaf>().SetupLeaf(m_Molecules[i], leaf, m_MoleculeNamePrefab);
            leaf.transform.localScale = Vector3.one * 0.5f;
            leaf.transform.localPosition = new Vector3(0.5f, Random.Range(0.5f, 2), 0.5f);
        }
    }
}
