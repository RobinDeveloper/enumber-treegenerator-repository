using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class BambooLeaf : MonoBehaviour
{
    private Molecule m_Molecule;
    private GameObject m_Parent;
    private GameObject m_MoleculeNamePrefab;

    public void SetupLeaf(Molecule _molecule, GameObject _parent, GameObject _moleculeNamePrefab)
    {
        m_Molecule = _molecule;
        m_Parent = _parent;
        m_MoleculeNamePrefab = _moleculeNamePrefab;
        GenerateEnumbers();
    }

    private void GenerateEnumbers()
    {
        GameObject eNumber = Instantiate(m_MoleculeNamePrefab, m_Parent.transform, true) as GameObject;
        eNumber.GetComponent<TMP_Text>().text = m_Molecule.ENumber.ToString();
        Quaternion rotate = eNumber.transform.rotation;
        eNumber.transform.Rotate(new Vector3(rotate.x, Random.Range(0, 180), rotate.z), Space.Self);
        eNumber.transform.position = m_Parent.transform.position;
    }
}
