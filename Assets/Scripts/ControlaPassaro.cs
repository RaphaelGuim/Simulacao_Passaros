using UnityEngine;

public class ControlaPassaro : MonoBehaviour {

	private Rigidbody rb;
	public float maxSpeed;
	private Controle controle;
	private float AnguloVisao = 60;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3(Random.value, Random.value, Random.value);
		controle = FindObjectOfType<Controle>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		 

		Vector3 separacao = Separar();
		Vector3 alinhar = Alinhar();
		Vector3 coesao = Coesao();

		separacao =  controle.ForcaSeparacao * separacao.normalized ;
		alinhar =  controle.ForcaAlinhar * alinhar.normalized;
		coesao = controle.ForcaCoesao * coesao.normalized;

		rb.AddForce(alinhar);
		rb.AddForce(separacao);
		rb.AddForce(coesao);

		rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

		Rotate(rb.velocity);
		Borders();
	}

	Vector3 Coesao()
	{
		Vector3 soma = Vector3.zero;
		int vizinhos = 0;
		for (int i = 0; i < Controle.birds.Count; i++)
		{
			GameObject vizinho = Controle.birds[i] as GameObject;

			Vector3 direcao =  vizinho.transform.position - transform.position;
			if (direcao.magnitude < controle.DistanciaCoesao && direcao.magnitude > 0)
			{

				float angulo = Vector3.Angle(rb.velocity, direcao);
				
				if (angulo < AnguloVisao)
				{
					 				 
					soma += vizinho.transform.position;
					vizinhos++;

				}
			}
			 

		}

		if (vizinhos > 0)
		{
			soma = soma / vizinhos;
			 
			 
			return Perseguir(soma);
		}
		else
		{
			return Vector3.zero;
		}

	}
	Vector3 Alinhar()
	{
		Vector3 soma = Vector3.zero;
		int vizinhos = 0;
		for (int i = 0; i < Controle.birds.Count; i++)
		{
			GameObject vizinho = Controle.birds[i] as GameObject;

			Vector3 direcao = vizinho.transform.position - transform.position ;
			
				
			if (direcao.magnitude < controle.DistanciaAlinhar && direcao.magnitude > 0)
			{
				float angulo = Vector3.Angle(rb.velocity, direcao);

				if (angulo < AnguloVisao) {
					 
					soma += vizinho.GetComponent<Rigidbody>().velocity;
						vizinhos++;

				}

			}

			
		}

		if(vizinhos > 0)
		{
			soma = soma / vizinhos;
			soma = soma.normalized* maxSpeed;
			Vector3 perseguir = soma - rb.velocity;
			Vector3.ClampMagnitude(perseguir, maxSpeed);		
			return Perseguir(perseguir);
		}
		else
		{
			return Vector3.zero;
		}



	}

	void Borders()
	{
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
	 
		 

		if (screenPosition.y > Screen.height)
		{
			transform.position = new Vector3(transform.position.x, -transform.position.y);
		}

		if (screenPosition.y < 0)
		{
			transform.position = new Vector3(transform.position.x, -transform.position.y);
		}

		if (screenPosition.x > Screen.width)
		{
			transform.position = new Vector3(-transform.position.x, transform.position.y);
		}

		if (screenPosition.x < 0)
		{
			transform.position = new Vector3(-transform.position.x, transform.position.y);
		}
	}

	Vector3 Separar()
	{
		Vector3 force = Vector3.zero;
		for(int i = 0; i < Controle.birds.Count; i++)
		{
			GameObject vizinho = Controle.birds[i] as GameObject;

			 
				Vector3 direcao = transform.position - vizinho.transform.position;
				if (direcao.magnitude < controle.DistanciaSeparacao && direcao.magnitude > 0)
				{

					force += direcao;
				}
			 
			
		}

		return force;
	}

	Vector3 Perseguir(Vector3 target)
	{

		if(target.magnitude <= 0)
		{
			return Vector3.zero;
		}
		Vector3 disired = target - transform.position;		 
		 
		disired = disired.normalized * maxSpeed;
		Vector3 steer = disired - rb.velocity;
		return steer;
		 
		 
			
		
	}

	void Rotate(Vector3 direcao)
	{

		//var dir = direcao - transform.position;
		var dir = direcao ;
		var angle = 180 + Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward),0.2f)	;

	}

	 
}
