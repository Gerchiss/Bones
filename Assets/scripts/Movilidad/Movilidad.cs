using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movilidad : MonoBehaviour
{
    [HideInInspector]
    public Animaciones anim;
    [HideInInspector]
    public int velocidadH = 0;
    [HideInInspector]
    public int velocidadV = 0;
    [HideInInspector]
    public bool moverse;
    [HideInInspector]
    public string child;

    public virtual void Moverse(float horizontal, float vertical)
    {
        transform.Translate(horizontal * velocidadH * Time.deltaTime, vertical * velocidadV * Time.deltaTime, 0);
        moverse = true;
        anim.Moverse(horizontal, velocidadH, velocidadV);
    }

    void Awake()
    {
        anim = GetComponent<Animaciones>();
    }

    // Update is called once per frame
    void Update()
    {
        print(velocidadH);
    }
}
