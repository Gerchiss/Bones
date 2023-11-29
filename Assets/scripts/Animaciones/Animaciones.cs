using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaciones : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    public void Recibir()
    {
        anim.SetTrigger("Recibir");
    }

    public void Morir()
    {
        anim.SetTrigger("Morir");
    }

    public void Moverse(float horizontal, float velocidadH, float velocidadV)
    {
        print(horizontal);
        if (horizontal != 0)
        {
            anim.SetFloat("VelocidadH", velocidadH);
        }
        else
        {
            anim.SetFloat("VelocidadH", 0);
        }
        anim.SetFloat("VelocidadV", velocidadV);
    }

    public void Caminar(float horizontal)
    {
        if (horizontal != 0)
        {
            anim.SetFloat("Velocidad", 1);
        }
        else
        {
            anim.SetFloat("Velocidad", 0);
        }
    }
    public void Saltar()
    {
        anim.SetTrigger("Saltar");
    }

    public void Atacar()
    {
        anim.SetTrigger("Atacar");
    }

    public void Atacar2()
    {
        anim.SetTrigger("Atacar2");
    }
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
