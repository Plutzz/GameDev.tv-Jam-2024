using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class Player : StateMachineCore, IDamageable
{
    [SerializeField] private Image healthBar;
    public static Player Instance { get; private set; }
    [field: SerializeField] public float maxHealth { get; set; } = 5;
    public float currentHealth { get; set; }
    [SerializeField] private float invincibleTime = 1.5f;

    #region Player Variables
    public InputManager inputManager;
    public PlayerAttacks playerAttacks;
    public SpriteRenderer graphics;
    public GameObject hitbox;
    [SerializeField] private float cameraShakeIntensity;
    [SerializeField] private float cameraShakeTime;
    [SerializeField] private Ease cameraShakeEase;

    [Header("Roll")]
    [SerializeField] private float rollCooldown = 1f;
    private float rollTimer;
    #endregion

    public bool invincible = false;
    private float invincibleTimer;
    [SerializeField] private int numBlinks;

    #region Unity Methods
    private void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;

        SetupInstances();
        stateMachine.Initialize(states["Idle"]);
    }

    private void Start()
    {
        transform.parent = Persistence.Instance?.transform;
        currentHealth = maxHealth;
        invincibleTimer = invincibleTime;
    }

    private void Update()
    {
        stateMachine.currentState.DoUpdateBranch();

        rollTimer -= Time.deltaTime;

        if(invincible == true)
        {
            invincibleTimer -= Time.deltaTime;
        }

        if(invincibleTimer <= 0f)
        {
            invincible = false;
            invincibleTimer = invincibleTime;
        }


        if (rollTimer < 0 && inputManager.RollPressedThisFrame)
        {
            stateMachine.ChangeState(states["Roll"]);
            rollTimer = rollCooldown;
        }
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.DoFixedUpdateBranch();
    }

    #endregion


    #region Player Take Damage Functions
    public void TakeDamage(int damage, float knockback, float xPos)
    {

        if (invincible)
        {
            if(currentHealth == 0)
            {
                PlayerDeath();
            }

            return;
        }



        currentHealth -= damage;
        healthBar.fillAmount = currentHealth/maxHealth;
        CinemachineShake.Instance?.ShakeCamera(cameraShakeIntensity, cameraShakeTime, cameraShakeEase);
        TimeFreezer.Instance?.StopTime();
        invincible = true;
        StartCoroutine(InvincibleBlink());
    }

    private IEnumerator InvincibleBlink()
    {
        while(invincible)
        {
            yield return new WaitForSeconds(invincibleTime / numBlinks / 2);
            graphics.enabled = false;
            yield return new WaitForSeconds(invincibleTime / numBlinks / 2);
            graphics.enabled = true;
        }
    }

    private void PlayerDeath()
    {
        currentHealth = maxHealth;
        SceneSwapManager.Instance.SwapSceneFromDoorUse(SceneSwapManager.Instance.meteorScene, DoorTriggerInteraction.DoorToSpawnAt.One);
    }
    #endregion
}
