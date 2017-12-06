using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //Make sure that we can see class in Inspector
    [System.Serializable]
    public class PlayerStats
    {
        public float Health = 100f;

    }
    private Rigidbody2D rb2D;
    private bool eLadoDireito;

    [SerializeField]
    private float velocidade = 0;
    private Animator animator;
    float horizontal;
    private bool acao;
	public float jumpImpulse = 10;
	private int jumpLimit = 1;

    PlayerStats playerStats = new PlayerStats();
    public float fallBoundary = -15;
    [SerializeField]
    private GameObject posicaoProjetil;
    [SerializeField]
    private GameObject projetil;
    void Start(){
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        eLadoDireito = transform.localScale.x>0;
    }
    
    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        if(playerStats.Health <= 0)
        {
            Debug.Log("Kill Player");
            GameManager.KillPlayer(this);
        }
    }

    void Update()
    {
        if (transform.position.y <= fallBoundary)
        {
            DamagePlayer(int.MaxValue);
        } 
        Resetar();
    }
    void FixedUpdate(){
        horizontal = Input.GetAxis("Horizontal");
        Movimentar(horizontal);
        MudarDirecao(horizontal);
        ControlarEntradas();
        Acao();
    }
    private void Movimentar(float h){
        if(!animator.GetCurrentAnimatorStateInfo(0).IsTag("Atirar")){
            rb2D.velocity = new Vector2(h*velocidade, rb2D.velocity.y);
        }
        animator.SetFloat("velocidade", Mathf.Abs(h));
    }
    private void MudarDirecao(float horizontal){
        if(horizontal>0 && !eLadoDireito || horizontal<0 && eLadoDireito){
            eLadoDireito = !eLadoDireito;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        } 
    }
    private void ControlarEntradas(){
        if(Input.GetKeyDown(KeyCode.X)){
            acao = true;
        }
        if (Input.GetKeyDown ("up") && jumpLimit >= 0) {
			rb2D.AddForce (new Vector2 (0, jumpImpulse), ForceMode2D.Impulse);
			jumpLimit--;
		}
    }
    void Resetar(){
        acao = false;
    }
    void Acao(){
        if(acao && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Atirar")){
            animator.SetTrigger("atirar");
            AcaoAtirar();
        }
    }
    private void AcaoAtirar(){
        GameObject tmpProjetil = (GameObject) (Instantiate(projetil, posicaoProjetil.transform.position, Quaternion.identity));
        if(eLadoDireito){
            tmpProjetil.GetComponent<Bala>().Inicializar(Vector2.right);
        }
        else{
            tmpProjetil.GetComponent<Bala>().Inicializar(Vector2.left);
        }
    }

    void OnCollisionEnter2D (Collision2D collision) {
		jumpLimit = 1;
	}

	void OnCollisionExit2D (Collision2D collision) {
		jumpLimit = 0;
	}
}
