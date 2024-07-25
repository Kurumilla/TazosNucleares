using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tazos_Material : MonoBehaviour
{
    [Header("1=MegaMetal, 2=MegaPlastic, 3=Metal, 4=Plastic")]
    public int tipo;
    [Header("1 a 5. Se multiplica al tipo.")]
    public int id;

    private void Start()
    {
        Setup(id);
    }

    public void Setup(int _id)
    {
        string filename = "Tazo_" + (_id * tipo);
        //Debug.Log(filename);
        GetComponent<MeshRenderer>().material.mainTexture = Resources.Load<Texture>("Texturas/Tazos/" + filename);
    }
}
