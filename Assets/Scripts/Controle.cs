using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controle : MonoBehaviour {

	public static ArrayList birds;
	public int passaros = 10;
	public GameObject birdModel;


	private float forcaSeparacao = 3;

	private float forcaCoesao = 1;

	private float forcaAlinhar = 1;

	private float distanciaSeparacao = 2;

	private float distanciaCoesao = 5;

	private float distanciaAlinhar = 1;

	public   float ForcaSeparacao { get { return forcaSeparacao; } }
	 
	public   float ForcaCoesao { get { return forcaCoesao; } }

	public   float ForcaAlinhar { get { return forcaAlinhar; } }

	public   float DistanciaSeparacao { get { return distanciaSeparacao; } } 

	public   float DistanciaCoesao { get { return distanciaCoesao; } }

	public    float DistanciaAlinhar { get { return distanciaAlinhar; } }

	public Scrollbar ScrollForcaSeparacao  ;

	public Scrollbar ScrollForcaCoesao;

	public Scrollbar ScrollForcaAlinhar;

	public Scrollbar ScrollDistanciaSeparacao;

	public Scrollbar ScrollDistanciaCoesao;

	public Scrollbar ScrollDistanciaAlinhar;

	public Text TForcaSeparacao;
	public Text TForcaCoesao;
	public Text TForcaAlinhar;
	public Text TDistanciaSeparacao;
	public Text TDistanciaCoesao;
	public Text TDistanciaAlinhar;


	// Use this for initialization
	void Start () {
		birds = new ArrayList();
		
		for(int i = 0; i < passaros; i++)
		{

			float Y = Random.Range
				(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
			float X = Random.Range
				(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

			birds.Add(Instantiate(birdModel, new Vector3(X,Y,0), Quaternion.identity));



		}

		ScrollForcaSeparacao.onValueChanged.AddListener(delegate { MudarForcaSeparacao(); });
		ScrollForcaCoesao.onValueChanged.AddListener(delegate { MudarForcaCoesao(); });
		ScrollForcaAlinhar.onValueChanged.AddListener(delegate { MudarForcaAlinhar(); });
		ScrollDistanciaSeparacao.onValueChanged.AddListener(delegate { MudarDistanciaSeparacao(); });
		ScrollDistanciaCoesao.onValueChanged.AddListener(delegate { MudarDistanciaCoesao(); });
		ScrollDistanciaAlinhar.onValueChanged.AddListener(delegate { MudarDistanciaAlinhar(); });

		MudarForcaSeparacao();
		MudarForcaCoesao();
		MudarForcaAlinhar();
		MudarDistanciaSeparacao();
		MudarDistanciaCoesao();
		MudarDistanciaAlinhar();
	}

	// Update is called once per frame
	void Update () {


 


	}

	public void MudarForcaSeparacao()
	{
		forcaSeparacao = Mathf.Lerp(0, 20, ScrollForcaSeparacao.GetComponent<Scrollbar>().value);

		TForcaSeparacao.text = "Força Separação:" + forcaSeparacao;
	

	}
	public void MudarForcaCoesao()
	{
		forcaCoesao = Mathf.Lerp(0, 20, ScrollForcaCoesao.GetComponent<Scrollbar>().value);
		TForcaCoesao.text = "Força Coesão:" + forcaCoesao;

	}
	public void MudarForcaAlinhar()
	{
		forcaAlinhar = Mathf.Lerp(0, 20, ScrollForcaAlinhar.GetComponent<Scrollbar>().value);
		 TForcaAlinhar.text = "Força Alinhar:" + forcaAlinhar;
	

}
	public void MudarDistanciaSeparacao()
	{
		distanciaSeparacao = Mathf.Lerp(0, 0.5f, ScrollDistanciaSeparacao.GetComponent<Scrollbar>().value);
		TDistanciaSeparacao.text = "Distância Separação:" + distanciaSeparacao;


}
	public void MudarDistanciaCoesao()
	{
		distanciaCoesao = Mathf.Lerp(0, 5, ScrollDistanciaCoesao.GetComponent<Scrollbar>().value);
		TDistanciaCoesao.text = "Distância Coesão:" + distanciaCoesao;


 
	

}
	public void MudarDistanciaAlinhar()
	{
		distanciaAlinhar = Mathf.Lerp(0, 5, ScrollDistanciaAlinhar.GetComponent<Scrollbar>().value);
		 TDistanciaAlinhar.text = "Distância Alinhar:" + distanciaAlinhar;
	}

}
