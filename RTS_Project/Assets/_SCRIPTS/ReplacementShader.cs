using UnityEngine;
using System.Collections;

public class ReplacementShader : MonoBehaviour {

    public Shader myReplacementShader;

    void OnEnable()
    {
        if (myReplacementShader != null)
            GetComponent<Camera>().SetReplacementShader(myReplacementShader, "");
    }

    void OnDisable()
    {
        GetComponent<Camera>().ResetReplacementShader();
    }

}
