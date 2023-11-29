using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio : Enemigo
{

	public override void moverse()
    {
		if (Mathf.Abs(jugador.GetPosicion().x - posicion.x) < 4)
		{
			mov.enabled = mov.child == "correr";
			mov = GetComponent<Correr>();
		}
		else
		{
			mov.enabled = mov.child == "caminar";
			mov = GetComponent<Caminar>();
		}
		mov.Moverse(-transform.localScale.x, mov.velocidadV);
	}

	void detectarJugador()
	{
		if ((jugador.GetPosicion().x > posicion.x && !mirandoDer) || (jugador.GetPosicion().x < posicion.x && mirandoDer))
			voltear();

		if ((Mathf.Abs(jugador.GetPosicion().x - posicion.x) < 0.5f && jugador.GetVida() > 0) && !atacando)
		{
			atacar();
		}
		else if (!atacando)
			moverse();
	}

	public void SetVida(int nuevaVida)
    {
		vida = nuevaVida;
    }

	public override void recibir(int ataque)
	{
		if (jugador.GetAtacando() && !recibiendo)
		{
			recibiendo = true;
			SetVida(vida - ataque);
			print(ataque);
			print (vida);
			if (vida <= 0)
			{
				morir();
			}
			else
			{
				//const grito1 = fondo.sonido("sounds/demonioGolpe.wav")
				//grito1.play()
				anim.Recibir();
			}
		}
	}


	void reiniciar()
	{
		x = Random.Range(0.0f, 2.0f);
		y = 39.5f;
		posicion = new Vector2(x,y);

		//atacando = false;

		caminando = false;

		corriendo = false;

		recibiendo = false;

		muriendo = false;

		muerto = false;
			vida = 20;
	}

	void salioDelMapa()
	{
		if (posicion.x <= -2)
			destruir();
	}

	void Awake()
	{
		x = Random.Range(0.0f, 2.0f);
		anim = gameObject.GetComponent<Animaciones>();
		rigid = gameObject.GetComponent<Rigidbody2D>();
		collider = gameObject.GetComponent<BoxCollider2D>();
		mov = GetComponent<Movilidad>();
		velocidad = 1;
		vida = 20;
	}
    private void Start()
    {
		jugador = GameController.GC.GetJugador();
	}

    void Update()
    {
		base.Update();
		detectarJugador();

	}
}
