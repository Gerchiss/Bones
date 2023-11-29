using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    [HideInInspector]
    public int velocidad;
    [HideInInspector]
    public Vector2 posicion;
    [HideInInspector]
    public float x;
    [HideInInspector]
    public float y = 39.5f;
    [HideInInspector]
    public bool atacando = false;
    [HideInInspector]
    public bool caminando = false;
    [HideInInspector]
    public bool corriendo = false;
    [HideInInspector]
    public bool recibiendo = false;
    [HideInInspector]
    public bool muriendo = false;
    [HideInInspector]
    public bool muerto = false;
    [HideInInspector]
    public int vida;
    [HideInInspector]
    public int ataque;
    [HideInInspector]
    public bool mirandoDer = false;
    [HideInInspector]
    public int exp;
    [HideInInspector]
    public BoxCollider2D collider;
    [HideInInspector]
    public Rigidbody2D rigid;
    [HideInInspector]
    public Jugador jugador;
    [HideInInspector]
    public Animaciones anim;
    [HideInInspector]
    public Movilidad mov;


    public void FinalizaAtaque()
    {
        atacando = false;
    }
    public virtual void detectarJugador() { }
    public void Recuperarse()
    {
        recibiendo = false;
        detectarJugador();
    }

    public virtual void atacar()
    {
        if (!atacando)
        {
            corriendo = false;
            atacando = true;
            anim.Atacar();
        }
    }

    public virtual void moverse() { }
    public void voltear()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        mirandoDer = !mirandoDer;
    }


    public virtual void recibir(int ataque)
    {

    }

    public void morir()
    {
        muriendo = true;
        //	atacando = false;
        anim.Morir();
        jugador.sumarMuertos(this, 1);
    }

    public void destruir()
    {
        muerto = true;
      //  reiniciar();
        GameController.GC.SpawnEnemigo();
    }
    void Start()
    {
        

    }

    // Update is called once per frame
    public void Update()
    {
        posicion = gameObject.transform.position;
    }
}
