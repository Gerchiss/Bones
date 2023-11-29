using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [HideInInspector]
    public int ataque;
    [HideInInspector]
    public int atMin;
    [HideInInspector]
    public int atMax;
    [HideInInspector]
    public Enemigo objetivo;
    public int GetAtaque()
    {
        return ataque;
    }

    public void SetAtaque(int valor)
    {
        ataque = valor;
    }
    public virtual void AjustarAtaque()
    {
        SetAtaque(Random.Range(atMin, atMax));
    }
    public virtual void Habilidad()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemigo")
        {
            if (objetivo == null)
                objetivo = collision.GetComponent<Enemigo>();
            AjustarAtaque();
            objetivo.recibir(ataque);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
