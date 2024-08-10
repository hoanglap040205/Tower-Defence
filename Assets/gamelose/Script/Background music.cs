using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundmusic : MonoBehaviour
{
    private static Backgroundmusic backgroundmusic;
   void Awake()
    {
        if (backgroundmusic == null) 
        {
            backgroundmusic = this;
            DontDestroyOnLoad(backgroundmusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
