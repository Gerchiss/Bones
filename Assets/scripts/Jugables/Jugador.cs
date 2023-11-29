using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{

	int x = 0;
	float y = 39.5f;
	Vector2 posicionInicial;
	Vector2 posicion;
	Animaciones anim;
	Rigidbody2D rigid;
	Arma arma;
	Movilidad mov;

	bool mirandoDer = true;
	bool atacando = false;
	bool caminando = false;
	bool saltando = false;
	bool recibiendo = false;
	bool muriendo = false;
	int ataque = 5;
	int vida = 30;
	
		//	Vector2 plataformaActual = fondo.juego().at(x, 39.5);
	int enemigosMuertos = 0;
	float walk = 1;
	int nivel = 1;
	int exp = 0;
	int expProxNivel = 30;
	bool combo = false;
	bool nuevaArma = false;
	

	public Vector2 GetPosicion()
    {
		return posicion;
    }


	void BoostVida(int unaCantidad)
	{
		vida += unaCantidad;
	}
	void boostAtaque(int unaCantidad)
	{
		ataque += unaCantidad;
	}

	public int GetAtaque() { return ataque; }

	public int GetVida() { return vida; }

	public bool GetAtacando() { return atacando; }
	public void FinalizaAtaque()
    {
		atacando = false;
    }

	public void FinalizaSalto()
	{
		saltando = false;
	}


	void animRecibir()
	{

	}

	void voltear(float horizontal)
	{

		if (transform.localScale.x < 0)
			mirandoDer = false;
		else
			mirandoDer = true;

		if ((horizontal > 0 && !mirandoDer) || (horizontal < 0 && mirandoDer))
			{
				caminando = true;
				Vector3 scale = transform.localScale;
				scale.x *= -1;
				transform.localScale = scale;
			}
	}

	void caminar()
	{
		if (! atacando && ! recibiendo)
		{
			float horizontal = Input.GetAxis("Horizontal");
			//float vertical = Input.GetAxis("Vertical");
			mov.Moverse(horizontal, 0);
			voltear(horizontal);
			caminando = horizontal != 0;
		}

	}

	void saltar()
	{
		if (Input.GetButtonDown("saltar"))
		{
			if (!saltando)
			{
				saltando = true;
				anim.Saltar();
				rigid.AddForce(new Vector2(0, 200));
			}
		}
	}
				
	void descender()
		{
		//	posicion = posicion.down(2);
			if (mirandoDer)
			{
			//	posicion = posicion.right(1);
				//fondo.desplazarseIzq();
			}
			else
			{
				//posicion = posicion.left(1);
				//fondo.desplazarseDer();
			}
			//fondo.juego().onTick(62.5, "descender", ({
				//if (plataformaActual.y() < posicion.y())
				{
					//posicion = posicion.down(2);
					if (mirandoDer)
					{
						//posicion = posicion.right(1);
						//fondo.desplazarseIzq()
					}
					else
					{
					//	posicion = posicion.left(1);
						//fondo.desplazarseDer();
					}
				}
				//if (plataformaActual.y() == posicion.y())
				{
				//	fondo.juego().removeTickEvent("descender");
				}
		}

	void atacar()
	{
		if (Input.GetButtonDown("atacar"))
		{
			if (!atacando)
			{
				
				atacando = true;
				anim.Atacar();
			}
            else
            {
				anim.Atacar2();
			}
		}
	}


	void quitarVida(int unAtaque)
	{
		//var ataqueReal = vida.min(unAtaque) / 10
		//console.println(ataqueReal)
		//console.println(fondo.listaVidas().get(fondo.listaVidas().size()-1).posicion().x())
		//(1..ataqueReal).forEach{
		//	e =>
		//fondo.juego().removeVisual(fondo.listaVidas().get(fondo.listaVidas().size() - 1))
		//fondo.listaVidas().remove(fondo.listaVidas().get(fondo.listaVidas().size() - 1))

			//vida = 0.max(vida - unAtaque)
	if (vida <= 0)
		morir();
	else { }
		//fondo.juego().onTick(250, "recibiendoJugador", ({ self.animRecibir()}))
	}

	void morir()
	{
		muriendo = true;
		//cuadros.clear();
		//animMorir.cuadros().clear();
		//animMorir.cargaDeFrames(self);

		try
		{
		//	fondo.juego().removeTickEvent("readyJugador");
		}
		catch { }
		try
		{
		//	fondo.juego().removeTickEvent("recibiendoJugador");
		}
		catch { }
		try
		{
		//	fondo.juego().removeTickEvent("caminarJugador");
		}
		catch { }
		try
		{
			//fondo.juego().removeTickEvent("atacarJugador");
		}
		catch { }
		try
		{
		//	fondo.juego().removeTickEvent("animSalto");
		}
		catch { }
		//fondo.juego().onTick(125, "morirJugador",{ self.animMorir()});
	}

	void recibirGolpe()
	{
		animRecibir();
		recibiendo = true;
		atacando = false;
		if (vida > 0) { }
	//	quitarVida(demonio().ataque());
	}

	void detectarEnemigo()
	{
		//if ((posicion.x() - fondo.demonio().posicion().x()).abs() < 16 and fondo.demonio().atacando() and not recibiendo and not atacando)		
	recibirGolpe();
	}

	public int GetEnemigosMuertos()
	{
		return enemigosMuertos;
	}

	public void sumarMuertos(Enemigo enemigo, int valor)
	{
		enemigosMuertos += valor;
		exp += enemigo.exp;
		if (exp >= expProxNivel)
			subirNivel();
	}

	void subirNivel()
	{
		nivel++;
		//fondo.juego().say(cabeza, "Subi de nivel!!");
		if (nivel == 2)
		{
			expProxNivel = 50;
			//fondo.sumaVida();
			vida = 40;
			ataque = 10;
	}
		if (nivel == 3)
		{
			expProxNivel = 80;
			//fondo.sumaVida();
			vida = 50;
			ataque = 15;
		}
		if (nivel == 4)
		{
			expProxNivel = 100;
			//fondo.sumaVida();
			vida = 60;
			ataque = 20;
		}
	}

	void nuevoAtaque()
	{
		//cuadros.clear();
		//cuadros.addAll(animNuevoAtaqueDer.cuadros());
		//image = cuadros.get(indiceCuadro);
		//const slash = fondo.sonido("sounds/slash.mp3");
		//slash.play();
		//fondo.juego().onTick(150, "NuevoAtaque",{ self.animNuevoAtaque()});
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Suelo")
		{
			rigid.velocity = Vector2.zero;
			rigid.gravityScale = 0;
			if (saltando)
			{
				FinalizaSalto();
				anim.anim.SetTrigger("Ready");
			}
		}
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Suelo")
		{
			rigid.gravityScale = 1;
		}
	}


	void Start()
	{
		posicionInicial = posicion;
		anim = GetComponent<Animaciones>();
		rigid = GetComponent<Rigidbody2D>();
		arma = GetComponentInChildren<Arma>();
		mov = GetComponent<Movilidad>();
	}

	// Update is called once per frame
	void Update()
	{
		posicion = transform.position;
		float nuevaPosY = Mathf.Clamp(transform.position.y, -2.09f, 10);
		transform.position = new Vector3(transform.position.x, nuevaPosY, transform.position.z);
		caminar();
		atacar();
		saltar();

	}
}
