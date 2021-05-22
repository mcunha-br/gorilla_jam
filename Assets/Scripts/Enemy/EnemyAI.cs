using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public delegate IEnumerator UpdateHealth(float health);
    public static UpdateHealth OnUpdateHealth;

    [Header("Settings Enemy")]
    public float speed = 5f;
    public float strong = 10f;
    public float health = 100f;

    [Header("Settings Attack")]
    public float attackRange = 1f;
    public Vector3 attackOffset = new Vector2(1.5f, 0);
    public LayerMask attackMask;

    [Header("Settings SFX")]
    public AudioClip sfxPunch;
    public AudioClip sfxDeath;
    public AudioClip[] sfxHits;

    private Transform player;
    private bool death = false;
    private bool lookRight;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;


    private void Start() {
        player = GameObject.FindWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        LookAt();
        NormalizeSprite();
    }

    public void ApplyDamage(float damage) {
        health -= damage;
        if(health <= 0 && !death) {
            death = true;
            health = 0;
            Death();

        } else if(health > 0 && !death) {
            StartCoroutine("TakeDamage");
        }
    }

    public void Attack() {
        Vector3 posisiton = transform.position;
		posisiton += transform.right * attackOffset.x;
		posisiton += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(posisiton, attackRange, attackMask);
		if (colInfo != null) {
			colInfo.GetComponent<PlayerMotor>().ApplyDamage(strong);
		}
    }

    public void LookAt() {
        if(transform.position.x > player.position.x && !lookRight) {
            lookRight = true;
            transform.Rotate(0, 180, 0);

        } else if(transform.position.x < player.position.x && lookRight) {
            lookRight = false;
            transform.Rotate(0, 180, 0);
        }
    }

    private void NormalizeSprite() {
        spriteRenderer.sortingOrder = (player.position.y < transform.position.y) ? 1 : 2;        
    }

    private IEnumerator TakeDamage() {
        StartCoroutine(OnUpdateHealth(health));
        audioSource.PlayOneShot(sfxHits[Random.Range(0, sfxHits.Length)]);
        yield return null;
        //TODO: Feedback para o player
    }

    private void Death() {
        StartCoroutine(OnUpdateHealth(health));
        audioSource.PlayOneShot(sfxDeath);
        //TODO: Animação de morte
    }

    void OnDrawGizmosSelected() {
		Vector3 posisiton = transform.position;
		posisiton += transform.right * attackOffset.x;
		posisiton += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(posisiton, attackRange);
	}
}
