using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{

    [SerializeField]
    private Transform goal;
    private NavMeshAgent agent;

    [SerializeField]
    private int health;

    [SerializeField]
    private Image heartSprite;
    [SerializeField]
    private List<Image> lives;

    [SerializeField]
    private float speedBoostDuration = 3;
    [SerializeField]
    private ParticleSystem boostParticleSystem;
    [SerializeField]
    private float shieldDuration = 3f;
    [SerializeField]
    private GameObject shield;

    private GameObject gameOver;

    [SerializeField]
    private Text shieldValue;
    [SerializeField]
    private Text boostValue;

    private int shieldAmount;
    private int boostAmount;

    private float regularSpeed = 3.5f;
    private float boostedSpeed = 7.0f;
    private bool canBoost = true;
    private bool canShield = true;
    private bool hasShield = true;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(Random.Range(-13, 13), 0.5f, -1);
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.position);
        health = 5;
        shieldAmount = 3;
        boostAmount = 3;
        shieldValue.text = shieldAmount.ToString();
        boostValue.text = boostAmount.ToString();
        gameOver = GameObject.FindGameObjectWithTag("GameOver");
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (boostAmount > 0)
            {
                if (canBoost)
                {
                    StartCoroutine(Boost());
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (shieldAmount > 0)
            {
                if (canShield)
                {
                    StartCoroutine(Shield());
                }
            }
        }
    }

    private IEnumerator Shield()
    {
        canShield = false;
        shieldAmount--;
        shieldValue.text = shieldAmount.ToString();
        shield.SetActive(true);
        float shieldCounter = 0f;
        while (shieldCounter < shieldDuration)
        {
            shieldCounter += Time.deltaTime;
            yield return null;
        }
        canShield = true;
        shield.SetActive(false);
    }

    private IEnumerator Boost()
    {
        canBoost = false;
        boostAmount--;
        boostValue.text = boostAmount.ToString();
        agent.speed = boostedSpeed;
        boostParticleSystem.Play();
        float boostCounter = 0f;
        while (boostCounter < speedBoostDuration)
        {
            boostCounter += Time.deltaTime;
            yield return null;
        }
        canBoost = true;
        boostParticleSystem.Pause();
        agent.speed = regularSpeed;
    }

    public void Shooted()
    {
        if (shield.active == false)
        {
            health -= 1;
            var live = lives.Last();
            Destroy(live.gameObject);
            lives.Remove(live);
        }
    }
}
