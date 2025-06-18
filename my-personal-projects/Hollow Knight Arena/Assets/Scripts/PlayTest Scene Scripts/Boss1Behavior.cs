using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;


public class Boss1Behavior : MonoBehaviour
{

    //      OBJECTS:

    [SerializeField] private Transform boss1;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D player;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Transform bossDealingDamageHitbox;
    [SerializeField] private Boss1Health boss1Health;

    [SerializeField] private Transform boss1LastPhaseJumpLocation;

    [SerializeField] private Transform bouncyFireBall;

    [SerializeField] private Game game;
    [SerializeField] private PlayerNail playerNail;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Enemy enemy;
    [SerializeField] private AudioManager audioManager;

    [SerializeField] private Transform fireBallFromHeadFireBall;
    [SerializeField] private Transform fireBallFireTrail;
    [SerializeField] private Transform fireBallSpinFireBall;
    [SerializeField] private Transform throwFireBallBombFireBall;
    [SerializeField] private Transform throwFireBallBombFireBallPiece;
    [SerializeField] private Transform spinJumpFireBall;

    private GameObject fireBallBombInstance;


    //      GENERAL:


    private float maximumDistanceForBossBehavior = 5f;

    public enum BossPhase
    {
        Passive,
        Phase1,
        Phase2,
        Phase3,
        LastPhase
    }

    public BossPhase currentBossPhase = 0;

    public  float currentHeadFireHeight = 0f;
    private float phase2HeadFireHeight = 1f;
    private float phase3HeadFireHeight = 5f;

    public bool bossBehaviorEnabled = false;
    public bool isFacingRight;

    public  int currentBossStunDuration = 0;

    public static class Stagger
    {
        public static int currentCooldown = 0;
        public static int totalCooldown = 360;
        public static int currentRecentDamageTaken = 0;
        public static int totalRecentDamageTaken = 300;
        public static int totalDuration = 150;
        public static int startingFramesThatDontEndStaggerIfAttacked = 30;
        public static int recentDamageTakenDuration = 10;
        public static int gamePauseDurationInFrames = 20;
        public static int totalDamageTakenToTrigger = 600;
        public static int currentDamageTakenToTrigger = 0;
    }

    public List<Coroutine> staggerRecentDamageTakenTimerCoroutines = new List<Coroutine>();

    public string[] previousAttackActions = new string[4];


    private float commonObjectLifetimeProgressToStartColorTransition = 0.75f;
    private float commonColorTransitionProgressToDisableColliders = 0.75f;

    private float commonColorTransitionDuration = 0.6f;
    
    private float commonFireTrailDuration = 3f;



    [SerializeField] private Sprite[] fireDashSpriteSlices;
    public List<GameObject> fireDashSliceGameObjects = new List<GameObject>();
    private int nextFireDashGameObjectToFadeAway = 0;


    [SerializeField] private Sprite[] jumpDiveFireTrailSpriteSlices;
    public List<GameObject> jumpDiveFireTrailSliceGameObjects = new List<GameObject>();
    private int nextJumpDiveFireTrailGameObjectToFadeAway = 0;



    private float normalBossGravity = 2.25f;


    //      STATUSES:


    public static class AttackStatus
    {
        public static bool isPerformingThrowFireballFromHead = false;
        public static bool isPerformingFireBallSpin = false;
        public static bool isPerformingThrowFireBallBomb = false;
        public static bool isPerformingSpinJump = false;
        public static bool isPerformingJumpDive = false;
        public static bool currentlyThrowingFireBall = false;
        public static bool summoningBouncyFireBalls = false;
        public static bool isPerformingAParryableAttack = false;
    }

    public static class MovementStatus
    {
        public static bool isPerformingSmallBackwardsJump = false;
        public static bool isPerformingShortRunBackwards = false;
        public static bool isPerformingRunTowardsPlayer = false;
        public static bool isPerformingDash = false;
        public static bool isPerformingLastPhaseJump = false;
        
    }

    public bool isStaggered = false;

    //      HELPER VARIABLES:


    Vector2 dashFireSpriteTemporaryPosition;

    Vector2 jumpDiveFireTrailSpriteTemporaryPosition;

    public int currentActionCounter = 0;

    private bool playedDashSound = false;

    public bool readyForLastPhaseRun = false;
    public bool isPreparingForLastPhaseJump = false;
    public bool flippedForLastPhaseRun = false;
    public bool stoppedBeforeLastPhaseRun = false;
    public bool readyForLastPhaseBouncyFireBallsAttack = false;

    public bool flippedBackwardsForPerformingShortRunBackwards = false;
    public bool jumpedForPerformingSmallJumpBackwards = false;

    private bool jumpDiveReadyToStartAscend = false;
    private bool jumpDiveCancelled = false;

    public bool spinJumpJumpFinished = false;
    public  int howManyFireBallsLeftToThrow = 0;


    //      MOVEMENT NUMBERS:

    public static class Movement
    {
        public static class Run
        {
            public static int primer = 6;
        }

        public static class Dash
        {
            public static int primer = 6;
        }

        public static class SmallBackwardsJump
        {
            public static int primer = 6;
        }

        public static class ShortRunBackwards
        {
            public static int primer = 6;
        }

        public static class LastPhaseJump
        {
            public static int primer = 6;
        }
    }

    public enum BossAction
    {
        None = 0,
        ThrowingFireballFromHead,
        FireBallSpinning,
        ThrowingFireBallBomb,
        SpinJumping,
        JumpDiving,
        ThrowingFireBall,
        SummoningBouncyFireBalls,
        PerformingAParryableAttack,
        SmallBackwardsJumping,
        ShortRunningBackwards,
        RunningTowardsPlayer,
        Dashing,
        LastPhaseJumping,
    }

    public BossAction currentBossAction = 0;


    public  float dashSpeed = 14.5f;

    private float maximumHorizontalPlayerDistanceToDash = 4f; 
    private float maximumVerticalPlayerDistanceToDash = 6f;
    private float maximumWallDistanceForDash = 8f;

    private float fireDashLingerDurationPerPhase = 0.66f;
    private float currentDashLingerDuration = 0f;

    private float fireDashHorizontalHitbox = 1f;
    private float fireDashVerticalHitbox = 0.5f;

    private float fireDashDelayBeforeColorTransition = 0.5f;

    private float fireDashSpritesHorizontalPositionChangePerFrame = 0;



    public  float runTowardsPlayerSpeed = 4.5f;

    private float minimumHorizontalPlayerDistanceToRun = 3.75f;



    private float shortRunBackwardsSpeed = 6f;

    private float maximumWallDistanceForShortRunBackwards = 5f;
    private float maximumHorizontalPlayerDistanceForShortRunBackwards = 4f;



    private float smallBackwardsJumpSpeed = 3.5f;
    private float smallBackwardsJumpJumpingHeight = 9f;

    private float maximumHorizontalPlayerDistanceForSmallBackwardsJump = 4f;
    private float maximumWallDistanceForSmallBackwardsJump = 4f;

    public  float lastPhaseJumpJumpingHeight = 26f;

    

    public static class Cooldowns
    {
        public static int cooldowniiii = 26;
        public static List<Action> a1 = new List<Action>();
    }


    //      ATTACKS NUMBERS:


    private   int fireBallMaximumSpeed = 6;

    private   int fireBallDurationFromStationaryToMaxSpeedInFrames = 60;
    private float fireBallFromHeadFireTrailDuration = 3f;
    private float fireBallFromHeadFireBallSearchAreaForGround;

    private   int fireBallFromHeadThrow1FireBallChance = 25;
    private   int fireBallFromHeadThrow2FireBallsChance = 50;
    private   int fireBallFromHeadThrow3FireBallsChance = 15;
    private   int fireBallFromHeadThrow4FireBallsChance = 10;

    private float fireBallMaxAngleChangePerFrame = 1.5f;
    private float fireBallDurationUntilItMoves = 0.25f;
    private float fireBallMaxAngleMultiplayerPerPhase = 1f;

    private float fireBallPositionVerticalOffset = 0.92f;
    private   int fireBallDurationInFrames = 240;



    private float fireBallSpinBossSpeed = 3f;
    private float fireBallSpinFireBallSpeed = 7f;

    private float maximumWallDistanceForFireBallSpin = 10f;
    private   int fireBallSpinNotFirstPhaseAngleIncrement = 30;
    private   int fireBallSpinFirstPhaseAngleIncrement = 45;
    private   int fireBallSpinFireBallThrowIntervalInFrames = 45;
    private float fireBallSpinFireBallSearchAreaForGround;



    private float throwFireBallBombHorizontalThrowSpeed = 4.5f;
    private float throwFireBallBombVerticalThrowSpeed = 8.5f;

    private float fireBallBombPieceBaseSpeed = 2f;
    private float fireBallBombPieceSpeedMultiplierPerPhase = 1.25f;

    private   int throwFireBallBombThrowHorizontalAngleWidth = 90;
    private float fireBallBombPieceSpeedMultiplierToCoverTheEntireGround = 5f;
    private float throwFireBallBombSearchAreaForGround;
    private float throwFireBallBombFireBallPieceSearchAreaForGround;



    private float spinJumpSpinBaseFireBallSpeed = 2.5f;
    private float spinJumpSpinFireBallSpeedMultiplierPerPhase = 1.5f;

    private float spinJumpJumpVerticalSpeed = 10f;

    private float maximumWallDistanceForSpinJump = 2f;
    private   int spinJumpSpinSummonFireBallsEveryThisManyFrames = 2;
    private float spinJumpFireBallFireTrailDuration = 1.25f;
    private float spinJumpFireBallSearchAreaForGround;
    private float spinJumpSummonFireBallRotationIncrement;



    private float jumpDiveJumpHorizontalSpeed = 10f;
    private float jumpDiveJumpVerticalSpeed = 13f;
    private float jumpDiveMinimumVerticalGroundDistanceToDive = 3f;

    private float jumpDiveDiveAscendVerticalSpeed = 1.5f;
    private float jumpDiveDiveDescendVerticalSpeed = -18f;

    private float maximumWallDistanceForJumpDive = 13f;

    private float jumpDivefireTrailVerticalOffset = -0.5f;

    private int   jumpDiveSummonFireTrailDurationInFrames = 60;

    private float jumpDiveFireTrailAdditionalVerticalOffsetPerSliceMultiplicator = 0.6f;

    private int   jumpDiveFirstFireTrailSpritesToSkip = 15;
    private int   jumpDiveLastFireTrailSpritesToSkip = 13;

    private float jumpDiveFireTrailHorizontalHitbox = 3f;
    private float jumpDiveFireTrailVerticalHitbox = 1.5f;

    private float jumpDiveFireTrailSpritesHorizontalPositionChangePerFrame = 0;

    private float jumpDiveFireTrailDelayBeforeColorTransition = 1f;


    //      MOVEMENT TIMERS:


    public  int currentRunningTowardsPlayerAnimationFrame = 0;
    private int totalRunningTowardsPlayerAnimationFrames = 30;



    public  int currentShortRunBackwardsInFrames = 0;
    private int totalShortRunBackwardsInFrames = 42;

    public  int currentShortRunBackwardsAnimationFrame = 0;
    private int totalShortRunBackwardsAnimationFrames = 20;

    public  int currentShortRunBackwardsCooldown = 0;
    private int totalShortRunBackwardsCooldown = 100;



    public  int currentSmallBackwardsJumpCooldown = 0;
    private int totalSmallBackwardsJumpCooldown = 100;

    public  int currentSmallBackwardsJumpAnimationFrame = 0;
    private int totalSmallBackwardsJumpAnimationFrames = 32;

    public  int currentSmallBackwardsJumpFrame = 0;

    public  int currentDashCooldown = 0;
    private int totalDashCooldown = 210;

    public  int currentDashingFrame = 0;
    private int totalDashingFrames = 28;  // needs to be the same as "numberOfFireDashSprites", because 1 frame spawns 1 sprite

    public  int currentDashingAnimationFrame = 0;
    private int totalDashingAnimationFrames = 40;


    //      ATTACK TIMERS:


    public  int currentThrowFireballFromHeadCooldown = 0;
    private int totalThrowFireballFromHeadCooldown = 500;

    public  int currentThrowFireBallFromHeadFrame = 0;

    public  int currentThrowing1FireBallAnimationFrame = 0;
    private int totalThrowing1FireballAnimationFrames = 40;

    public  int currentThrowFireBallFromHeadEndAnimationFrame = 0;
    private int totalThrowFireBallFromHeadEndAnimationFrames = 50;



    public  int currentFireBallSpinCooldown = 0;
    private int totalFireBallSpinCooldown = 300;

    public  int currentFireBallSpinAnimationFrame = 0;
    private int totalFireBallSpinAnimationFrames = 45;

    public  int currentFireBallSpinFrame = 0;
    private int totalFireBallSpinFrames = 200;



    public  int currentThrowFireBallBombCooldown = 0;
    private int totalThrowFireBallBombCooldown = 200;

    public  int currentThrowFireBallBombAnimationFrame = 0;
    private int totalThrowFireBallBombAnimationFrames = 75;

    public  int currentThrowFireBallBombFrame = 0;
    private int totalThrowFireBallBombFrames = 200;



    public  int currentSpinJumpCooldown = 0;
    private int totalSpinJumpCooldown = 200;

    public  int currentSpinJumpJumpAnimationFrame = 0;
    private int totalSpinJumpJumpAnimationFrames = 25;

    public  int currentSpinJumpSpinAnimationFrame = 0;
    private int totalSpinJumpSpinAnimationFrames = 80;

    public  int currentSpinJumpSpinFrame = 0;
    private int totalSpinJumpSpinframes = 80;

    private int currentSpinJumpEndAnimationFrame = 0;
    private int totalSpinJumpEndAnimationFrames = 50;



    public  int currentJumpDiveCooldown = 0;
    private int totalJumpDiveCooldown = 200;

    public  int currentJumpDiveAnimationFrame = 0;
    private int totalJumpDiveAnimationFrames = 45;

    public  int currentJumpDiveEndAnimationFrame = 0;
    private int totalJumpDiveEndAnimationFrames = 45;

    public  int currentJumpDiveAscendFrame = 0;
    private int totalJumpDiveAscendFrames = 75;



    public  int currentBouncyFireBallSpawnTimer = 0;
    private int totalBouncyFireBallSpawnTimer = 60;


    //      OTHER:


    private Vector2 bossParryableAttackHitboxSize;

    private int totalParryableAttackTimer = 150;
    private int currentParryableAttackTimer = 0;


    //      SETUP:


    private void Start()
    {
        BoxCollider2D hitboxCollider = bossDealingDamageHitbox.GetComponent<BoxCollider2D>();  // will use a different hitbox for actual parrying
        bossParryableAttackHitboxSize = 5.5f * hitboxCollider.size;

        spinJumpSummonFireBallRotationIncrement = 360f / totalSpinJumpSpinframes;

        Game.CalculateHorizontalSpritePositionChangePerFrame(fireDashSpriteSlices, ref fireDashSpritesHorizontalPositionChangePerFrame, true);
        Game.CalculateHorizontalSpritePositionChangePerFrame(jumpDiveFireTrailSpriteSlices, ref jumpDiveFireTrailSpritesHorizontalPositionChangePerFrame, true);

        SetUpHitboxVariablesForAttacks();
    }

    private void SetUpHitboxVariablesForAttacks()
    {
        fireBallSpinFireBallSearchAreaForGround = fireBallSpinFireBall.GetComponent<BoxCollider2D>().SearchDistance();
        fireBallFromHeadFireBallSearchAreaForGround = fireBallFromHeadFireBall.GetComponent<BoxCollider2D>().SearchDistance();
        throwFireBallBombSearchAreaForGround = throwFireBallBombFireBall.GetComponent<BoxCollider2D>().SearchDistance();
        throwFireBallBombFireBallPieceSearchAreaForGround = throwFireBallBombFireBallPiece.GetComponent<BoxCollider2D>().SearchDistance();
        spinJumpFireBallSearchAreaForGround = spinJumpFireBall.GetComponent<BoxCollider2D>().SearchDistance();
    }


    //      CODE:


    void Update()
    {
        BossBehaviorEnabledCheck();

        if (Game.Paused() || !bossBehaviorEnabled)
            return;

        if (currentBossStunDuration > 0)
        {
            rb.Stun();
            currentBossStunDuration--;
            return;
        }

        BossIsStaggeredCheck();

        CooldownCheck();

        ChangeBossPhaseCheck();

        BossPerformActionCheck();

        BossSoundCheck();
    }

    private void SetCurrentPerformingActionToTheChosenAction()  // HARDCODED
    {
        if (MovementStatus.isPerformingDash)
            SetNextActionToThisAction(ref MovementStatus.isPerformingDash, ref currentDashCooldown, totalDashCooldown);
        if (MovementStatus.isPerformingRunTowardsPlayer)
            SetNextActionToThisAction(ref MovementStatus.isPerformingRunTowardsPlayer);
        if (MovementStatus.isPerformingShortRunBackwards)
            SetNextActionToThisAction(ref MovementStatus.isPerformingShortRunBackwards, ref currentShortRunBackwardsCooldown, totalShortRunBackwardsCooldown);
        if (MovementStatus.isPerformingSmallBackwardsJump)
            SetNextActionToThisAction(ref MovementStatus.isPerformingSmallBackwardsJump, ref currentSmallBackwardsJumpCooldown, totalSmallBackwardsJumpCooldown);

        if (AttackStatus.isPerformingFireBallSpin)
            SetNextActionToThisAction(ref AttackStatus.isPerformingFireBallSpin, ref currentFireBallSpinCooldown, totalFireBallSpinCooldown, "FireBallSpin");
        if (AttackStatus.isPerformingThrowFireballFromHead)
            SetNextActionToThisAction(ref AttackStatus.isPerformingThrowFireballFromHead, ref currentThrowFireballFromHeadCooldown, totalThrowFireballFromHeadCooldown, "ThrowFireBallFromHead");
        if (AttackStatus.isPerformingThrowFireBallBomb)
            SetNextActionToThisAction(ref AttackStatus.isPerformingThrowFireBallBomb, ref currentThrowFireBallBombCooldown, totalThrowFireBallBombCooldown, "ThrowFireBallBomb");
        if (AttackStatus.isPerformingSpinJump)
            SetNextActionToThisAction(ref AttackStatus.isPerformingSpinJump, ref currentSpinJumpCooldown, totalSpinJumpCooldown, "SpinJump");
        if (AttackStatus.isPerformingJumpDive)
            SetNextActionToThisAction(ref AttackStatus.isPerformingJumpDive, ref currentJumpDiveCooldown, totalJumpDiveCooldown, "JumpDive");
    }

    private void DisableAllActions()  // HARDCODED
    {
        MovementStatus.isPerformingDash = MovementStatus.isPerformingRunTowardsPlayer = MovementStatus.isPerformingShortRunBackwards = MovementStatus.isPerformingSmallBackwardsJump = false;

        AttackStatus.isPerformingThrowFireballFromHead = AttackStatus.isPerformingFireBallSpin = AttackStatus.isPerformingThrowFireBallBomb = AttackStatus.isPerformingSpinJump = AttackStatus.isPerformingJumpDive = false;
    }

    private void BossPerformActionCheck()
    {
        if (!MovementStatus.isPerformingSmallBackwardsJump)
            FlipCheck();

        if (!IsBusyPerformingAnAction())
        {
            if (currentActionCounter % 2 == 0)
            {
                if (currentBossPhase == BossPhase.LastPhase)
                {
                    //LastPhaseMovementCheck();
                    return;
                }

                SetViableMovementActionsToTrue();
            } 
            else
            {
                SetViableAttackActionsToTrue();

                /*if (currentBossPhase == totalBossPhases)
                {
                    //LastPhaseAttacksCheck();
                    return;
                }

                HeadFireCheck();

                currentParryableAttackTimer++;

                if (currentParryableAttackTimer == totalParryableAttackTimer)  // ovaj deo ce se kasnije svejedno obrisati
                {
                    currentParryableAttackTimer = 0;
                    isPerformingAParryableAttack = !isPerformingAParryableAttack;
                }

                enemy.ParryBossCheck(ref currentBossStunDuration, isPerformingAParryableAttack, bossDealingDamageHitbox, bossParryableAttackHitboxSize);
                enemy.KnockBackPlayerForBlockingAttackCheck(bossDealingDamageHitbox, bossParryableAttackHitboxSize, isPerformingAParryableAttack);*/
            }

            SetPerformActionToTrueOnlyToTheChosenAction();
        }

        PerformChosenAction();
    }

    private void FlipCheck()
    {
        if (rb.velocity.x > 0 && !isFacingRight || rb.velocity.x < 0 && isFacingRight)
            rb.transform.Flip(ref isFacingRight);
    }

    private void FaceThePlayer()
    {
        if (isFacingRight && player.position.x <= rb.position.x || !isFacingRight && player.position.x > rb.position.x)
            rb.transform.Flip(ref isFacingRight);
    }

    private void BossBehaviorEnabledCheck()
    {
        if (!bossBehaviorEnabled && Vector2.Distance(rb.position, player.position) < maximumDistanceForBossBehavior)
            bossBehaviorEnabled = true;
    }

    private void Run(bool runForwards, float runSpeed) => rb.velocity = new Vector2((runForwards == isFacingRight ? 1 : -1) * runSpeed, rb.velocity.y);
         
    private void ChangeBossPhaseCheck()
    {
        float healthPercentage = (float)boss1Health.currentBoss1Health / boss1Health.totalBoss1Health;

        currentBossPhase = healthPercentage switch
        {
            <= 0f => BossPhase.LastPhase,
            <= 0.33f => BossPhase.Phase3,
            <= 0.66f => BossPhase.Phase2,
            _ => BossPhase.Phase1
        };
    }
    
    private void HeadFireCheck() =>
        currentHeadFireHeight = (int)currentBossPhase switch
        {
            1 => 0,
            2 => phase2HeadFireHeight,
            _ => phase3HeadFireHeight
        };
    
    private void SetPerformActionToTrueOnlyToTheChosenAction()  // HARDCODED
    {
        bool[] boolArray = { MovementStatus.isPerformingDash, MovementStatus.isPerformingRunTowardsPlayer, MovementStatus.isPerformingShortRunBackwards, MovementStatus.isPerformingSmallBackwardsJump,
                             AttackStatus.isPerformingThrowFireballFromHead, AttackStatus.isPerformingFireBallSpin, AttackStatus.isPerformingThrowFireBallBomb, AttackStatus.isPerformingSpinJump, AttackStatus.isPerformingJumpDive };

        ChooseRandomActionToPerformOutOfViableActions(boolArray);

        int i = 0;

        MovementStatus.isPerformingDash = boolArray[i++];  // HARDCODED
        MovementStatus.isPerformingRunTowardsPlayer = boolArray[i++];
        MovementStatus.isPerformingShortRunBackwards = boolArray[i++];
        MovementStatus.isPerformingSmallBackwardsJump = boolArray[i++];
        AttackStatus.isPerformingThrowFireballFromHead = boolArray[i++];
        AttackStatus.isPerformingFireBallSpin = boolArray[i++];
        AttackStatus.isPerformingThrowFireBallBomb = boolArray[i++];
        AttackStatus.isPerformingSpinJump = boolArray[i++];
        AttackStatus.isPerformingJumpDive = boolArray[i++];

        SetCurrentPerformingActionToTheChosenAction();
    }

    private void PerformChosenAction()  // HARDCODED
    {
        if (MovementStatus.isPerformingRunTowardsPlayer)
            RunTowardsPlayer();
        if (MovementStatus.isPerformingSmallBackwardsJump)
            ShortBackwardsJump();
        if (MovementStatus.isPerformingShortRunBackwards)
            ShortRunBackwards();
        if (MovementStatus.isPerformingDash)
            Dash();

        if (AttackStatus.isPerformingThrowFireballFromHead)
            ThrowFireBallFromHead();
        if (AttackStatus.isPerformingFireBallSpin)
            FireBallSpin();
        if (AttackStatus.isPerformingThrowFireBallBomb)
            ThrowFireBallBomb();
        if (AttackStatus.isPerformingSpinJump)
            SpinJump();
        if (AttackStatus.isPerformingJumpDive)
            JumpDive();
    }

    private void RunTowardsPlayer()
    {
        FaceThePlayer();

        currentRunningTowardsPlayerAnimationFrame++;

        if (rb.StopEntityIfTimerDidntPass(currentRunningTowardsPlayerAnimationFrame, totalRunningTowardsPlayerAnimationFrames))
            return;

        Run(true, runTowardsPlayerSpeed);

        if (rb.transform.HorizontalDistance(player.transform) < minimumHorizontalPlayerDistanceToRun)
        {
            StopPerformingMovementAction(ref MovementStatus.isPerformingRunTowardsPlayer, ref currentRunningTowardsPlayerAnimationFrame);
            currentRunningTowardsPlayerAnimationFrame = 0;
        }
    }

    private void Dash()
    {
        if (currentDashingAnimationFrame == 0)
        {
            currentDashLingerDuration = fireDashLingerDurationPerPhase * (int)currentBossPhase;
            FaceThePlayer();
        }
            
        if (currentDashingAnimationFrame < totalDashingAnimationFrames)
        {
            currentDashingAnimationFrame++;
            return;
        }

        if (!playedDashSound)
        {
            audioManager.PlayAudioClip(audioManager.boss1Movement, "Boss1Dash");
            StartCoroutine(DashFireTrail());
            playedDashSound = true;
        }   

        Run(true, dashSpeed);

        currentDashingFrame++;

        if (currentDashingFrame == totalDashingFrames)
        {
            StopPerformingMovementAction(ref MovementStatus.isPerformingDash, ref currentDashingAnimationFrame);
            currentDashingFrame = 0;
            playedDashSound = false;
        }
    }

    private IEnumerator DashFireTrail()
    {
        int timer = 0;
        int nextFireDashSprite = 0;

        while (timer < totalDashingFrames)
        {
            GameObject newFireDashSlice = new GameObject("FireDashSliceObject" + nextFireDashSprite);

            SpriteRenderer newFireDashSliceSpriteRenderer = newFireDashSlice.AddComponent<SpriteRenderer>();

            if (nextFireDashSprite == 0)
                dashFireSpriteTemporaryPosition = rb.position;

            if (isFacingRight)
                newFireDashSliceSpriteRenderer.sprite = fireDashSpriteSlices[nextFireDashSprite];
            else
                newFireDashSliceSpriteRenderer.sprite = fireDashSpriteSlices[fireDashSpriteSlices.Length - nextFireDashSprite - 1];

            newFireDashSliceSpriteRenderer.enabled = true;

            if (isFacingRight)
                newFireDashSlice.transform.position =
                new Vector2(dashFireSpriteTemporaryPosition.x + nextFireDashSprite * fireDashSpritesHorizontalPositionChangePerFrame, dashFireSpriteTemporaryPosition.y);
            else
                newFireDashSlice.transform.position =
                new Vector2(dashFireSpriteTemporaryPosition.x - nextFireDashSprite * fireDashSpritesHorizontalPositionChangePerFrame, dashFireSpriteTemporaryPosition.y);

            BoxCollider2D newFireDashSliceBoxCollider = newFireDashSlice.AddComponent<BoxCollider2D>();

            newFireDashSliceBoxCollider.enabled = true;

            newFireDashSliceBoxCollider.size = new Vector2(fireDashHorizontalHitbox / fireDashSpriteSlices.Length, fireDashVerticalHitbox);

            newFireDashSliceBoxCollider.isTrigger = true;

            newFireDashSlice.layer = LayerMask.NameToLayer("EnemyDealingDamage");

            fireDashSliceGameObjects.Add(newFireDashSlice);

            Destroy(newFireDashSlice, currentDashLingerDuration);

            nextFireDashSprite++;

            if (nextFireDashSprite >= fireDashSpriteSlices.Length - 1)
                nextFireDashSprite = 0;

            timer++;

            Invoke("StartDashFadeOverTimeCoroutineWrapper", currentDashLingerDuration * fireDashDelayBeforeColorTransition);

            yield return null;
        }
    }

    private void StartDashFadeOverTimeCoroutineWrapper() 
    {
        game.StartFadeOverTimeCoroutine(fireDashSliceGameObjects, ref nextFireDashGameObjectToFadeAway,
        currentDashLingerDuration - currentDashLingerDuration * fireDashDelayBeforeColorTransition, commonColorTransitionProgressToDisableColliders);
    }

    private void ShortRunBackwards()
    {
        currentShortRunBackwardsAnimationFrame++;

        if (rb.StopEntityIfTimerDidntPass(currentShortRunBackwardsAnimationFrame, totalShortRunBackwardsAnimationFrames))
            return;

        if (!flippedBackwardsForPerformingShortRunBackwards)
        {
            FaceThePlayer();
            rb.transform.Flip(ref isFacingRight);
            flippedBackwardsForPerformingShortRunBackwards = true;
        }

        Run(true, shortRunBackwardsSpeed);

        currentShortRunBackwardsInFrames++;

        if (currentShortRunBackwardsInFrames == totalShortRunBackwardsInFrames)
        {
            StopPerformingMovementAction(ref MovementStatus.isPerformingShortRunBackwards, ref currentShortRunBackwardsAnimationFrame);
            currentShortRunBackwardsInFrames = 0;
            flippedBackwardsForPerformingShortRunBackwards = false;
            FaceThePlayer();
        }
    }

    private void ShortBackwardsJump()
    {
        currentSmallBackwardsJumpAnimationFrame++;

        if (rb.StopEntityIfTimerDidntPass(currentSmallBackwardsJumpAnimationFrame, totalSmallBackwardsJumpAnimationFrames))
            return;

        if (!jumpedForPerformingSmallJumpBackwards)
        {
            FaceThePlayer();
            rb.Jump(smallBackwardsJumpJumpingHeight);
            audioManager.PlayAudioClip(audioManager.boss1Movement, "Boss1Jump");
            jumpedForPerformingSmallJumpBackwards = true;
        }

        Run(false, smallBackwardsJumpSpeed);

        currentSmallBackwardsJumpFrame++;

        if (groundCheck.IsGrounded(groundLayer, 0.01f) && MovementStatus.isPerformingSmallBackwardsJump && currentSmallBackwardsJumpFrame > 15)
        {
            StopPerformingMovementAction(ref MovementStatus.isPerformingSmallBackwardsJump, ref currentSmallBackwardsJumpAnimationFrame);
            currentSmallBackwardsJumpFrame = 0;
            jumpedForPerformingSmallJumpBackwards = false;
        }
    }

    private void StopPerformingMovementAction(ref bool isPerformingMovementAction, ref int currentMovementAnimationFrame)
    {
        isPerformingMovementAction = false;
        currentMovementAnimationFrame = 0;
        rb.velocity = new Vector2(0f, rb.velocity.y);
    }

    private void LastPhaseMovementCheck()
    {
        LastPhaseFlipBeforeRunCheck();

        LastPhaseStopBeforeRunCheck();

        Invoke("ReadyForLastPhaseRun", 1f);

        RunToLastPhaseJumpLocationCheck();

        StopAfterPerformingLastPhaseJumpCheck();
    }

    private void LastPhaseAttacksCheck() => SummonBouncyFireBallsCheck();
    
    private bool CanPerformSmallBackwardsJumpCheck() => groundCheck.IsGrounded(groundLayer, 0.01f) && CanPerformActionWallDistanceCheck(maximumWallDistanceForSmallBackwardsJump, true)
        && currentSmallBackwardsJumpCooldown == 0
        && rb.transform.HorizontalDistance(player.transform) < maximumHorizontalPlayerDistanceForSmallBackwardsJump;
    
    private bool CanPerformShortRunBackwardsCheck() => groundCheck.IsGrounded(groundLayer, 0.01f) && currentShortRunBackwardsCooldown == 0
        && CanPerformActionWallDistanceCheck(maximumWallDistanceForShortRunBackwards, true) 
        && rb.transform.HorizontalDistance(player.transform) < maximumHorizontalPlayerDistanceForShortRunBackwards;

    private bool CanPerformRunTowardsPlayerCheck() => groundCheck.IsGrounded(groundLayer, 0.01f) &&
        rb.transform.HorizontalDistance(player.transform) > minimumHorizontalPlayerDistanceToRun;
    
    private bool CanPerformDashCheck() => groundCheck.IsGrounded(groundLayer, 0.01f) && currentDashCooldown == 0 && CanPerformActionWallDistanceCheck(maximumWallDistanceForDash, false)
        && rb.transform.HorizontalDistance(player.transform) < maximumHorizontalPlayerDistanceToDash
        && rb.transform.VerticalDistance(player.transform) < maximumVerticalPlayerDistanceToDash;
    
    private bool IsBusyMoving() =>  //HARDCODED
        MovementStatus.isPerformingSmallBackwardsJump || MovementStatus.isPerformingShortRunBackwards || MovementStatus.isPerformingRunTowardsPlayer || MovementStatus.isPerformingDash;
    
    private bool IsBusyAttacking() =>  //HARDCODED
        AttackStatus.isPerformingThrowFireballFromHead || AttackStatus.isPerformingFireBallSpin || AttackStatus.isPerformingThrowFireBallBomb || AttackStatus.isPerformingSpinJump || AttackStatus.isPerformingJumpDive;
    
    private bool IsBusyPerformingAnAction() => IsBusyMoving() || IsBusyAttacking();
    
    private void SetViableMovementActionsToTrue()  // HARDCODED
    {
        MovementStatus.isPerformingRunTowardsPlayer = CanPerformRunTowardsPlayerCheck();
        MovementStatus.isPerformingDash = CanPerformDashCheck();
        MovementStatus.isPerformingShortRunBackwards = CanPerformShortRunBackwardsCheck();
        MovementStatus.isPerformingSmallBackwardsJump = CanPerformSmallBackwardsJumpCheck();
    }

    private void ChooseRandomActionToPerformOutOfViableActions(bool[] numbers)
    {
        int randomNumber;
        int possibleActionsToPerform = numbers.Count(b => b);

        if (possibleActionsToPerform == 0)
        {
            Debug.Log("no possible actions");
            return;
        }
    
        while (true)
        {
            for (int i = 0; i < numbers.Count(); i++)
            {
                if (numbers[i] == true)
                {
                    randomNumber = UnityEngine.Random.Range(0, numbers.Count());

                    if (randomNumber == 0)
                    {
                        for (int j = 0; j < numbers.Length; j++)
                            numbers[i] = false;

                        numbers[i] = true;

                        return;
                    }  
                }
            }
        }
    }

    private void PerformThisActionsAndDisableAllOtherActions(ref bool actionToPerform)
    {
        DisableAllActions();

        actionToPerform = true;
        
        currentActionCounter++;
    }

    private void SetViableAttackActionsToTrue()  // HARDCODED - disable them here when testing 1 attack
    {
        AttackStatus.isPerformingThrowFireballFromHead = CanPerformThrowFireBallFromHeadCheck();
        AttackStatus.isPerformingFireBallSpin = CanPerformFireBallSpinCheck();
        AttackStatus.isPerformingThrowFireBallBomb = CanPerformThrowFireBallBombCheck();
        AttackStatus.isPerformingSpinJump = CanPerformSpinJumpCheck();
        AttackStatus.isPerformingJumpDive = CanPerformJumpDiveCheck();
    }

    private bool CanPerformThrowFireBallFromHeadCheck() => currentThrowFireballFromHeadCooldown == 0 && !previousAttackActions.Contains("ThrowFireBallFromHead");
    
    private bool CanPerformFireBallSpinCheck() => CanPerformActionWallDistanceCheck(maximumWallDistanceForFireBallSpin, false) &&
               currentFireBallSpinCooldown == 0 && !previousAttackActions.Contains("FireBallSpin");
    
    private bool CanPerformThrowFireBallBombCheck() => currentThrowFireBallBombCooldown == 0 && !previousAttackActions.Contains("ThrowFireBallBomb");
    
    private bool CanPerformSpinJumpCheck() => currentSpinJumpCooldown == 0 && groundCheck.IsGrounded(groundLayer, 0.01f) &&
               CanPerformActionWallDistanceCheck(maximumWallDistanceForSpinJump, false) && !previousAttackActions.Contains("SpinJump");
    
    private bool CanPerformJumpDiveCheck() => currentJumpDiveCooldown == 0 && CanPerformActionWallDistanceCheck(maximumWallDistanceForJumpDive, false) &&
               !previousAttackActions.Contains("JumpDive");
    
    private void ChooseHowManyFireBallsToThrow()
    {
        int[] fireBallChances = { fireBallFromHeadThrow1FireBallChance, fireBallFromHeadThrow2FireBallsChance, 
                                  fireBallFromHeadThrow3FireBallsChance, fireBallFromHeadThrow4FireBallsChance };

        int[] fireBallThresholds = new int[fireBallChances.Length];

        int randomNumber = UnityEngine.Random.Range(0, 100);
        int percentageSum = 0;

        for (int i = 0; i < fireBallThresholds.Length; i++)
        {
            percentageSum += fireBallChances[i];
            fireBallThresholds[i] = percentageSum;

            if (i > 0 && fireBallThresholds[i - 1] < randomNumber && fireBallThresholds[i] > randomNumber)
            {
                howManyFireBallsLeftToThrow = i + 1;
                return;
            }
        }
        howManyFireBallsLeftToThrow = 1;
    }

    private void ThrowFireBallFromHead()
    {
        if (currentThrowFireBallFromHeadFrame == 0)
            ChooseHowManyFireBallsToThrow();

        if (howManyFireBallsLeftToThrow == 0)
        {
            if (currentThrowFireBallFromHeadEndAnimationFrame < totalThrowFireBallFromHeadEndAnimationFrames)
            {
                currentThrowFireBallFromHeadEndAnimationFrame++;
                return;
            }
            
            currentThrowFireBallFromHeadEndAnimationFrame = 0;
            StopPerformingMovementAction(ref AttackStatus.isPerformingThrowFireballFromHead, ref currentThrowFireBallFromHeadFrame);
            return;
        }

        currentThrowFireBallFromHeadFrame++;

        if (currentThrowFireBallFromHeadFrame % 40 == 0)
        {
            if (!AttackStatus.currentlyThrowingFireBall)
                AttackStatus.currentlyThrowingFireBall = true;
        }

        if (AttackStatus.currentlyThrowingFireBall)
            Throw1FireBallCheck();
    }

    private void Throw1FireBallCheck()
    {
        FaceThePlayer();

        currentThrowing1FireBallAnimationFrame++;

        if (currentThrowing1FireBallAnimationFrame == totalThrowing1FireballAnimationFrames)
        {
            Throw1FireBall();
            howManyFireBallsLeftToThrow--;
            AttackStatus.currentlyThrowingFireBall = false;
            currentThrowing1FireBallAnimationFrame = 0;
        }
        else
            rb.velocity = new Vector2(0f, rb.velocity.y);
    }

    private void Throw1FireBall()
    {
        GameObject fireball = Instantiate(fireBallFromHeadFireBall,
                                          new Vector2(rb.position.x, rb.position.y + fireBallPositionVerticalOffset), Quaternion.identity).gameObject;

        fireball.GetComponent<SpriteRenderer>().enabled = true;

        audioManager.PlayAudioClip(audioManager.boss1Attacks, "Boss1ThrowFireBallFireBall");

        StartCoroutine(ThrowFireBallFromHeadFireBallBehavior(fireball, fireBallDurationInFrames));
    }

    IEnumerator ThrowFireBallFromHeadFireBallBehavior(GameObject fireBall, int timerDuration)
    {
        yield return new WaitForSeconds(fireBallDurationUntilItMoves);

        int currentTimer = 0;

        while (currentTimer < timerDuration)
        {
            currentTimer++;

            if (fireBall == null)
                yield break;

            if (fireBall.transform.IsGrounded(groundLayer, fireBallFromHeadFireBallSearchAreaForGround))
                SummonFireTrailWhereFireballHitGround(fireBall.transform, fireBallFromHeadFireBallSearchAreaForGround, fireBallFromHeadFireTrailDuration);

            Vector2 directionToPlayer = new Vector2(player.position.x - fireBall.transform.position.x, player.position.y - fireBall.transform.position.y).normalized;

            Vector2 currentDirection = fireBall.transform.up;

            float angle = Vector2.SignedAngle(currentDirection, directionToPlayer);

            float maxAngleChangePerFrame = fireBallMaxAngleChangePerFrame + (int)currentBossPhase * fireBallMaxAngleMultiplayerPerPhase;

            float maxRotation = maxAngleChangePerFrame * Time.fixedDeltaTime;

            float rotationAngle = Mathf.LerpAngle(0, angle, maxRotation);

            fireBall.transform.Rotate(Vector3.forward, rotationAngle);

            if (currentTimer >= 0 && currentTimer < fireBallDurationFromStationaryToMaxSpeedInFrames)
            {
                fireBall.GetComponent<Rigidbody2D>().velocity = fireBall.transform.up * fireBallMaximumSpeed *
                ((float)currentTimer / fireBallDurationFromStationaryToMaxSpeedInFrames);
                yield return new WaitForFixedUpdate();
                continue;
            }

            fireBall.GetComponent<Rigidbody2D>().velocity = fireBall.transform.up * fireBallMaximumSpeed;

            yield return new WaitForFixedUpdate();
        }

        Destroy(fireBall);
    }

    private void SummonFireTrailWhereFireballHitGround(Transform fireBall, float fireBallSearchArea, float fireTrailDuration)
    {
        if (Vector2.Distance(player.transform.position, fireBall.transform.position) < 8)
            audioManager.PlayAudioClip(audioManager.boss1Attacks, "Boss1FireBallHitGround");

        Vector2 groundHitDirection = fireBall.transform.ClosestDirectionToGround(groundLayer, fireBallSearchArea + 0.1f);

        GameObject fireBallFireTrail = Instantiate(this.fireBallFireTrail, fireBall.position, Quaternion.identity).gameObject;

        Destroy(fireBall.gameObject);

        fireBallFireTrail.GetComponent<SpriteRenderer>().enabled = true;

        if (groundHitDirection == Vector2.down)
            fireBallFireTrail.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else if (groundHitDirection == Vector2.right)
            fireBallFireTrail.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        else if (groundHitDirection == Vector2.up)
            fireBallFireTrail.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        if (groundHitDirection == Vector2.left)
            fireBallFireTrail.transform.rotation = Quaternion.Euler(0f, 0f, 270f);

        if (Vector2.Distance(player.transform.position, fireBall.transform.position) < 8)
        {
            Audio fireBallFireTrailBurningAudio = audioManager.PlayAudioClip(audioManager.boss1Attacks, "Boss1GroundFireBurning");
            StartCoroutine(StopFireBallFireTrailBurningAudio(fireBallFireTrail, fireTrailDuration, fireBallFireTrailBurningAudio));
        }

        StartCoroutine(FireBallFireTrailFadeOverTimeWrapper(fireTrailDuration * commonObjectLifetimeProgressToStartColorTransition,
        fireBallFireTrail, fireTrailDuration * (1 - commonObjectLifetimeProgressToStartColorTransition), commonColorTransitionProgressToDisableColliders));

        StartCoroutine(DestroyFireTrail(fireBallFireTrail, fireTrailDuration));
    }

    private IEnumerator FireBallFireTrailFadeOverTimeWrapper(float delay, GameObject fireBallFireTrailGameObject,
                                                             float colorTransitionDuration, float colorTransitionProgressToDisableColliders)
    {
        yield return new WaitForSeconds(delay);

        StartCoroutine(Game.AttackFadeOverTime(fireBallFireTrailGameObject, colorTransitionDuration, colorTransitionProgressToDisableColliders));
    }

    private IEnumerator StopFireBallFireTrailBurningAudio(GameObject fireBallFireTrail, float fireTrailDuration, Audio fireTrailBurningAudio)
    {
        float currentTimer = 0;

        while (currentTimer < fireTrailDuration)
        {
            currentTimer += Time.deltaTime;

            if (fireBallFireTrail == null || Vector2.Distance(player.transform.position, fireBallFireTrail.transform.position) > 11)
            {
                fireTrailBurningAudio.audioSource.Stop();
                yield break;
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private IEnumerator DestroyFireTrail(GameObject fireBallFireTrail, float fireTrailDuration)
    {
        yield return new WaitForSeconds(fireTrailDuration);
        
        if (Vector2.Distance(player.transform.position, fireBallFireTrail.transform.position) < 8)
            audioManager.PlayAudioClip(audioManager.boss1Attacks, "Boss1GroundFireEqtinguished");

        Destroy(fireBallFireTrail);
    }

    private void FireBallSpin()
    {
        if (currentFireBallSpinAnimationFrame == 0)
            FaceThePlayer();

        if (currentFireBallSpinAnimationFrame < totalFireBallSpinAnimationFrames)
        {
            currentFireBallSpinAnimationFrame++;
            rb.velocity = new Vector2(0f, rb.velocity.y);
            return;
        }
        else
            rb.velocity = new Vector2((isFacingRight ? 1 : -1) * fireBallSpinBossSpeed, rb.velocity.y);
            
        if (currentFireBallSpinFrame == totalFireBallSpinFrames)
        {
            currentFireBallSpinAnimationFrame = 0;
            rb.velocity = new Vector2(0f, rb.velocity.y);
            StopPerformingMovementAction(ref AttackStatus.isPerformingFireBallSpin, ref currentFireBallSpinFrame);
            return;
        }

        currentFireBallSpinFrame++;

        if (currentFireBallSpinFrame % fireBallSpinFireBallThrowIntervalInFrames == 0)
            SummonFireBallSpinFireBalls();
    }

    IEnumerator SummonFireTrailFromFireBallCheck(GameObject fireBall, int fireBallDuration, float hitboxSize, bool summonFireTrail, float fireTrailDuration)
    {
        int currentTimer = 0;

        while (currentTimer < fireBallDuration)
        {
            currentTimer++;

            if (fireBall.transform.IsGrounded(groundLayer, fireBallSpinFireBallSearchAreaForGround))
            {
                if (summonFireTrail)
                    SummonFireTrailWhereFireballHitGround(fireBall.transform, hitboxSize, fireTrailDuration);
                else
                    Destroy(fireBall);

                yield break;
            } 

            yield return new WaitForFixedUpdate();
        }

        Destroy(fireBall);
    }

    private void SummonFireBallSpinFireBalls()
    {
        audioManager.PlayAudioClip(audioManager.boss1Attacks, "Boss1SpinFireBalls2");

        int angleIncrement;

        if ((int)currentBossPhase == 1)
            angleIncrement = fireBallSpinFirstPhaseAngleIncrement;
        else
            angleIncrement = fireBallSpinNotFirstPhaseAngleIncrement;

        for (int i = 0; i < 360; i += angleIncrement) 
        {
            // this means - skip the angles between 90 and 270 - angles start from UP clockwise, so this means to skip the lower half of the circle
            if (i > 0 + 90 && i < 360 - 90)
                continue;

            Quaternion rotation = Quaternion.Euler(0, 0, i);

            GameObject fireBall = Instantiate(fireBallFromHeadFireBall, rb.position, rotation).gameObject;

            // "Vector2.up" - this means that the fireballs start spawning from UP
            fireBall.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.up * fireBallSpinFireBallSpeed;
            fireBall.GetComponent<SpriteRenderer>().enabled = true;

            StartCoroutine(SummonFireTrailFromFireBallCheck(fireBall, fireBallDurationInFrames, fireBallSpinFireBallSearchAreaForGround,
                                                            true,  commonFireTrailDuration));
        }
    }

    private void ThrowFireBallBomb()
    {
        if (currentThrowFireBallBombAnimationFrame < totalThrowFireBallBombAnimationFrames)
        {
            currentThrowFireBallBombAnimationFrame++;
            FaceThePlayer();
            rb.velocity = new Vector2(0f, rb.velocity.y);
            return;
        }

        if (currentThrowFireBallBombFrame == 0)
            ThrowFireBallBombSummonBomb();

        currentThrowFireBallBombFrame++;

        if (currentThrowFireBallBombFrame == totalThrowFireBallBombFrames)
        {
            currentThrowFireBallBombAnimationFrame = 0;
            rb.velocity = new Vector2(0f, rb.velocity.y);
            StopPerformingMovementAction(ref AttackStatus.isPerformingThrowFireBallBomb, ref currentThrowFireBallBombFrame);
        }
    }

    private void ThrowFireBallBombSummonBomb()
    {
        audioManager.PlayAudioClip(audioManager.boss1Attacks, "Boss1BombThrow");

        fireBallBombInstance = Instantiate(throwFireBallBombFireBall, rb.position, Quaternion.identity).gameObject;

        Rigidbody2D bombRb = fireBallBombInstance.GetComponent<Rigidbody2D>();
        
        bombRb.velocity = new Vector2((isFacingRight ? 1 : -1) * throwFireBallBombHorizontalThrowSpeed, bombRb.velocity.y);

        fireBallBombInstance.GetComponent<SpriteRenderer>().enabled = true;

        bombRb.Jump(throwFireBallBombVerticalThrowSpeed);

        StartCoroutine(ThrowFireBallBombSummonBombPiecesCoroutine());
    }

    private IEnumerator ThrowFireBallBombSummonBombPiecesCoroutine()
    {
        int timer = 0;
        int maxTimer = 500;

        while (!(fireBallBombInstance != null && fireBallBombInstance.transform.IsGrounded(groundLayer, throwFireBallBombSearchAreaForGround + 0.2f)))
        {
            timer++;

            if (timer > maxTimer)
                yield break;

            yield return null;
        }

        ThrowFireBallBombSummonBombPieces();
        Destroy(fireBallBombInstance);
    }

    private void ThrowFireBallBombSummonBombPieces()
    {
        audioManager.PlayAudioClip(audioManager.boss1Attacks, "Boss1BombHitGround");

        float fireBallBombPieceSpeed = fireBallBombPieceBaseSpeed + (int)currentBossPhase * fireBallBombPieceSpeedMultiplierPerPhase;

        int angleIncrement = (int)(throwFireBallBombThrowHorizontalAngleWidth / (fireBallBombPieceSpeedMultiplierToCoverTheEntireGround * fireBallBombPieceSpeed));

        for (int i = 0; i < 360; i += angleIncrement)
        {
            if (i > (0.5f * throwFireBallBombThrowHorizontalAngleWidth) && i < 360 - (0.5f * throwFireBallBombThrowHorizontalAngleWidth))
                continue;

            Quaternion rotation = Quaternion.Euler(0, 0, i);

            GameObject fireBallPiece = Instantiate(throwFireBallBombFireBallPiece, fireBallBombInstance.transform.position, rotation).gameObject;

            fireBallPiece.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.up * fireBallBombPieceSpeed;
            fireBallPiece.GetComponent<SpriteRenderer>().enabled = true;

            StartCoroutine(SummonFireTrailFromFireBallCheck(fireBallPiece, fireBallDurationInFrames, throwFireBallBombFireBallPieceSearchAreaForGround,
                                                            true, commonFireTrailDuration));
        }
    }

    private void SpinJump()
    {
        if (currentSpinJumpJumpAnimationFrame < totalSpinJumpJumpAnimationFrames)
        {
            rb.velocity = new Vector2(0f, 0f);
            currentSpinJumpJumpAnimationFrame++;
            return;
        }

        if (currentSpinJumpSpinAnimationFrame == 0)
        {
            currentSpinJumpSpinAnimationFrame++;
            FaceThePlayer();
            rb.Jump(spinJumpJumpVerticalSpeed);
            audioManager.PlayAudioClip(audioManager.boss1Movement, "Boss1Jump");
        }
            
        if (rb.velocity.y < 0f && !spinJumpJumpFinished)
        {
            spinJumpJumpFinished = true;
            rb.velocity = new Vector2(0f, 0f);
            rb.gravityScale = 0;
        }

        if (!spinJumpJumpFinished)
            return;

        if (currentSpinJumpSpinAnimationFrame < totalSpinJumpSpinAnimationFrames)
        {
            currentSpinJumpSpinAnimationFrame++;
            return;
        }

        if (currentSpinJumpSpinFrame == 0)
            audioManager.PlayAudioClip(audioManager.boss1Attacks, "Boss1SpinJumpFireballs");

        if (currentSpinJumpSpinFrame < totalSpinJumpSpinframes)
        {
            boss1.rotation = Quaternion.Euler( 0, 0, boss1.rotation.z + (isFacingRight ? -1 : 1) * currentSpinJumpSpinFrame * spinJumpSummonFireBallRotationIncrement);

            if (currentSpinJumpSpinFrame % spinJumpSpinSummonFireBallsEveryThisManyFrames == 0)
                SummonSpinJumpFireBall();

            currentSpinJumpSpinFrame++;
        }

        if (currentSpinJumpEndAnimationFrame < totalSpinJumpEndAnimationFrames)
        {
            currentSpinJumpEndAnimationFrame++;
            return;
        }

        if (currentSpinJumpSpinFrame == totalSpinJumpSpinframes)
        {
            boss1.rotation = Quaternion.Euler(0, 0, 0);
            currentSpinJumpSpinAnimationFrame = 0;
            currentSpinJumpJumpAnimationFrame = 0;
            currentSpinJumpEndAnimationFrame = 0;
            rb.velocity = new Vector2(0f, rb.velocity.y);
            StopPerformingMovementAction(ref AttackStatus.isPerformingSpinJump, ref currentSpinJumpSpinFrame);
            rb.gravityScale = normalBossGravity;
            spinJumpJumpFinished = false;
        }
    }

    private void SummonSpinJumpFireBall()
    {
        GameObject fireBall = Instantiate(spinJumpFireBall, rb.position, boss1.transform.rotation).gameObject;

        fireBall.transform.rotation = boss1.transform.rotation;

        fireBall.GetComponent<SpriteRenderer>().enabled = true;

        float fireBallSpeed = spinJumpSpinBaseFireBallSpeed + (int)currentBossPhase * spinJumpSpinFireBallSpeedMultiplierPerPhase;

        fireBall.GetComponent<Rigidbody2D>().velocity = boss1.transform.rotation * Vector2.up * fireBallSpeed;
        
        StartCoroutine(SummonFireTrailFromFireBallCheck(fireBall, fireBallDurationInFrames, spinJumpFireBallSearchAreaForGround,
                                                        true, spinJumpFireBallFireTrailDuration));
    }

    private void JumpDive()
    {
        if (currentJumpDiveAnimationFrame < totalJumpDiveAnimationFrames)
        {
            currentJumpDiveAnimationFrame++;
            FaceThePlayer();
            rb.velocity = new Vector2(0f, rb.velocity.y);
            
            if (currentJumpDiveAnimationFrame == totalJumpDiveAnimationFrames)
            {
                rb.velocity = new Vector2((isFacingRight ? 1 : -1) * jumpDiveJumpHorizontalSpeed, jumpDiveJumpVerticalSpeed);

                audioManager.PlayAudioClip(audioManager.boss1Movement, "Boss1Jump");
            }
            return;
        }
        
        if (rb.transform.CloseHorizontally(player.transform, 0.2f) && !jumpDiveReadyToStartAscend)
            jumpDiveReadyToStartAscend = true;

        if (rb.velocity.y < 0f && rb.transform.GroundIsNearBelow(groundLayer, 1.2f) && !jumpDiveReadyToStartAscend)
            jumpDiveCancelled = true;
        
        if (currentJumpDiveAscendFrame < totalJumpDiveAscendFrames && jumpDiveReadyToStartAscend &&
            !rb.transform.GroundIsNearBelow(groundLayer, jumpDiveMinimumVerticalGroundDistanceToDive))
        {
            currentJumpDiveAscendFrame++;
            rb.velocity = new Vector2(0f, jumpDiveDiveAscendVerticalSpeed);

            if (rb.transform.CloseHorizontally(player.transform, 0.3f) && (int)currentBossPhase > 1)
                rb.transform.position = new Vector2(player.transform.position.x, rb.transform.position.y);

            return;
        }

        if (currentJumpDiveAscendFrame == totalJumpDiveAscendFrames)
        {
            rb.velocity = new Vector2(0f, jumpDiveDiveDescendVerticalSpeed);

            if (groundCheck.IsGrounded(groundLayer, 0.01f))
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
                StartCoroutine(SummonJumpDiveFireTrail());
                currentJumpDiveAscendFrame++;
            }
        }

        if (rb.velocity.y == jumpDiveDiveDescendVerticalSpeed && rb.transform.GroundIsNearBelow(groundLayer, jumpDiveMinimumVerticalGroundDistanceToDive))
            audioManager.PlayAudioClipIfItsNotPlaying(audioManager.boss1Movement, "Boss1HardFall", true);

        if (currentJumpDiveEndAnimationFrame < totalJumpDiveEndAnimationFrames && groundCheck.IsGrounded(groundLayer, 0.01f) &&
           (jumpDiveReadyToStartAscend || jumpDiveCancelled))
        {
            currentJumpDiveEndAnimationFrame++;
            
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        
        if (currentJumpDiveEndAnimationFrame == totalJumpDiveEndAnimationFrames)
        {
            jumpDiveCancelled = false;
            jumpDiveReadyToStartAscend = false;
            currentJumpDiveEndAnimationFrame = 0;
            currentJumpDiveAscendFrame = 0;
            StopPerformingMovementAction(ref AttackStatus.isPerformingJumpDive, ref currentJumpDiveAnimationFrame);
        }
    }

    private IEnumerator SummonJumpDiveFireTrail()
    {
        int timer = 0;
        int currentSlice = 0;
        int JumpDiveFireTrailSlicesSummonedPerFrame = 1 + (int)currentBossPhase;

        int nextJumpDiveFireTrailSprite = jumpDiveFirstFireTrailSpritesToSkip;
        float currentVerticalOffset = jumpDivefireTrailVerticalOffset;

        float additionalVerticalOffsetPerSlice = -1f /
             (jumpDiveSummonFireTrailDurationInFrames * JumpDiveFireTrailSlicesSummonedPerFrame) * jumpDiveFireTrailAdditionalVerticalOffsetPerSliceMultiplicator;

        while (timer < jumpDiveSummonFireTrailDurationInFrames)
        {
            for (int i = 0; i < JumpDiveFireTrailSlicesSummonedPerFrame; i++)
            {
                SummonJumpDiveFireTrailSlice("FireTrailSliceObject", currentSlice, nextJumpDiveFireTrailSprite, currentVerticalOffset, true);
                SummonJumpDiveFireTrailSlice("FireTrailSliceObject", currentSlice, nextJumpDiveFireTrailSprite, currentVerticalOffset, false);

                currentVerticalOffset += additionalVerticalOffsetPerSlice;

                currentSlice++;
                nextJumpDiveFireTrailSprite++;
            }

            timer++;

            if (nextJumpDiveFireTrailSprite >= jumpDiveFireTrailSpriteSlices.Length - jumpDiveLastFireTrailSpritesToSkip)
                nextJumpDiveFireTrailSprite = jumpDiveFirstFireTrailSpritesToSkip;

            yield return new WaitForFixedUpdate();
        } 
    }

    private void SummonJumpDiveFireTrailSlice(string newGameObjectName, int currentSlice, int nextSprite,
                                              float currentSliceVerticalOffset, bool summonWithRightOffset)
    {
        GameObject newGameObjectSlice = new GameObject(newGameObjectName + currentSlice);

        SpriteRenderer newGameObjectSliceSpriteRenderer = newGameObjectSlice.AddComponent<SpriteRenderer>();

        if (currentSlice == 0)
            jumpDiveFireTrailSpriteTemporaryPosition = rb.position;

        if (isFacingRight)
            newGameObjectSliceSpriteRenderer.sprite = jumpDiveFireTrailSpriteSlices[nextSprite];
        else
            newGameObjectSliceSpriteRenderer.sprite = jumpDiveFireTrailSpriteSlices[jumpDiveFireTrailSpriteSlices.Length - nextSprite - 1];

        newGameObjectSliceSpriteRenderer.enabled = true;

        int offsetMultiplier = currentSlice;

        if (summonWithRightOffset)
            offsetMultiplier *= -1;

        newGameObjectSlice.transform.position =
        new Vector2(jumpDiveFireTrailSpriteTemporaryPosition.x + offsetMultiplier * jumpDiveFireTrailSpritesHorizontalPositionChangePerFrame,
                    jumpDiveFireTrailSpriteTemporaryPosition.y + currentSliceVerticalOffset);

        BoxCollider2D newGameObjectSliceBoxCollider = newGameObjectSlice.AddComponent<BoxCollider2D>();

        newGameObjectSliceBoxCollider.enabled = true;

        newGameObjectSliceBoxCollider.size = new Vector2(jumpDiveFireTrailHorizontalHitbox / jumpDiveFireTrailSpriteSlices.Length, jumpDiveFireTrailVerticalHitbox);

        newGameObjectSliceBoxCollider.isTrigger = true;

        newGameObjectSlice.layer = LayerMask.NameToLayer("EnemyDealingDamage");

        jumpDiveFireTrailSliceGameObjects.Add(newGameObjectSlice);

        Destroy(newGameObjectSlice, jumpDiveFireTrailDelayBeforeColorTransition + commonColorTransitionDuration);
           
        Invoke("StartJumpDiveFadeOverTimeCoroutineWrapper", jumpDiveFireTrailDelayBeforeColorTransition);
    }

    private void StartJumpDiveFadeOverTimeCoroutineWrapper() =>
        game.StartFadeOverTimeCoroutine(jumpDiveFireTrailSliceGameObjects, ref nextJumpDiveFireTrailGameObjectToFadeAway,
                                        commonColorTransitionDuration, commonColorTransitionProgressToDisableColliders);

    public void BossIsStaggeredCheck()
    {
        if (isStaggered && currentBossStunDuration == 0)
            isStaggered = false;
    }
    
    public void StaggerBossCheck()
    {
        if (Stagger.currentCooldown == 0 && groundCheck.IsGrounded(groundLayer, 0.01f) &&
            (Stagger.currentRecentDamageTaken >= Stagger.totalRecentDamageTaken || Stagger.currentDamageTakenToTrigger >= Stagger.totalDamageTakenToTrigger))
        {
            if (staggerRecentDamageTakenTimerCoroutines.Count > 0)
            {
                foreach (Coroutine coroutine in staggerRecentDamageTakenTimerCoroutines)
                {
                    if (coroutine != null)
                        StopCoroutine(coroutine);
                }
            }

            DisableAllActions();

            staggerRecentDamageTakenTimerCoroutines.Clear();

            audioManager.StopAllArraySounds(audioManager.boss1Attacks);
            audioManager.StopAllArraySounds(audioManager.boss1Movement);

            audioManager.PlayAudioClip(audioManager.enemyGeneral, "EnemyStagger");

            Stagger.currentRecentDamageTaken = 0;
            Stagger.currentDamageTakenToTrigger = 0;
            currentBossStunDuration = Stagger.totalDuration;
            Stagger.currentCooldown = Stagger.totalCooldown;
            isStaggered = true;

            Game.PauseTheGameTemporarily(Stagger.gamePauseDurationInFrames);
        }
    }

    public IEnumerator StaggerRecentDamageTakenTimer(int damageTaken)
    {
        // this means that the boss cannot be staggered while they are in the air
        if (!groundCheck.IsGrounded(groundLayer, 0.01f) && Stagger.currentRecentDamageTaken + damageTaken >= Stagger.totalRecentDamageTaken)
            yield break;

        Stagger.currentRecentDamageTaken += damageTaken;
        Stagger.currentDamageTakenToTrigger += damageTaken;

        yield return new WaitForSeconds(Stagger.recentDamageTakenDuration);

        Stagger.currentRecentDamageTaken -= damageTaken;

        staggerRecentDamageTakenTimerCoroutines.RemoveAt(0);
    }

    private void SetNextActionToThisAction(ref bool isPerformingThisAction, ref int currentActionCooldown, int? totalActionCooldown = null,
                                           string actionNameInPreviousAttackActionsArray = null)
    { 
        PerformThisActionsAndDisableAllOtherActions(ref isPerformingThisAction);

        currentActionCooldown = totalActionCooldown ?? currentActionCooldown;

        if (actionNameInPreviousAttackActionsArray != null)
            previousAttackActions.UpdateArrayQueue(actionNameInPreviousAttackActionsArray);
    }

    private void SetNextActionToThisAction(ref bool isPerformingThisAction) => PerformThisActionsAndDisableAllOtherActions(ref isPerformingThisAction);
    
    private bool CanPerformActionWallDistanceCheck(float maximumWallDistance, bool reverseWallSideChecking)
    {
        bool bossFacingBeforeActionCheck = isFacingRight;

        FaceThePlayer();

        bool wallCheckOnRight = reverseWallSideChecking ? !isFacingRight : isFacingRight;

        bool canPerformAction = wallCheckOnRight ? !rb.transform.WallIsNearOnTheRightSide(groundLayer, maximumWallDistance)
                                                 : !rb.transform.WallIsNearOnTheLeftSide(groundLayer, maximumWallDistance);

        if (bossFacingBeforeActionCheck != isFacingRight)
            rb.transform.Flip(ref isFacingRight);

        return canPerformAction;
    }

    public static void ReduceCooldownsIfOnCooldownCheck(Action[] cooldownActions) => Array.ForEach(cooldownActions, action => action());

    private void CooldownCheck()  // HARDCODED
    {
        Game.ReduceCooldownIfOnCooldownCheck(ref Stagger.currentCooldown);

        Game.ReduceCooldownIfOnCooldownCheck(ref currentDashCooldown);
        Game.ReduceCooldownIfOnCooldownCheck(ref currentShortRunBackwardsCooldown);
        Game.ReduceCooldownIfOnCooldownCheck(ref currentSmallBackwardsJumpCooldown);

        Game.ReduceCooldownIfOnCooldownCheck(ref currentThrowFireballFromHeadCooldown);
        Game.ReduceCooldownIfOnCooldownCheck(ref currentFireBallSpinCooldown);
        Game.ReduceCooldownIfOnCooldownCheck(ref currentThrowFireBallBombCooldown);
        Game.ReduceCooldownIfOnCooldownCheck(ref currentSpinJumpCooldown);
        Game.ReduceCooldownIfOnCooldownCheck(ref currentJumpDiveCooldown);
    }

    private void BossSoundCheck()
    {
        if (boss1Health.currentBoss1Health <= 0)
            return;

        audioManager.PlayAudioClipIfItsNotPlaying(audioManager.boss1Movement, "Boss1Running", 
                                                  rb.velocity.x != 0 && (MovementStatus.isPerformingRunTowardsPlayer || MovementStatus.isPerformingShortRunBackwards));
        audioManager.PlayAudioClipIfItsNotPlaying(audioManager.boss1Attacks, "Boss1FireBallThrowCharging", AttackStatus.isPerformingThrowFireballFromHead);
        audioManager.PlayAudioClipIfItsNotPlaying(audioManager.boss1Attacks, "Boss1Spinning", AttackStatus.isPerformingFireBallSpin && rb.velocity.x != 0);
        audioManager.PlayAudioClipIfItsNotPlaying(audioManager.boss1Attacks, "Boss1SpinCharge",
                                                  AttackStatus.isPerformingFireBallSpin && currentFireBallSpinAnimationFrame < totalFireBallSpinAnimationFrames);
        audioManager.PlayAudioClipIfItsNotPlaying(audioManager.boss1Attacks, "Boss1JumpSpinCharge",
                                                  AttackStatus.isPerformingSpinJump && currentSpinJumpSpinAnimationFrame < totalSpinJumpSpinAnimationFrames && spinJumpJumpFinished);
        audioManager.PlayAudioClipIfItsNotPlaying(audioManager.boss1Attacks, "Boss1DiveAscend",
                                                  AttackStatus.isPerformingJumpDive && rb.velocity.y == jumpDiveDiveAscendVerticalSpeed);
    }

    private void LastPhaseFlipBeforeRunCheck()
    {
        if (flippedForLastPhaseRun)
            return;

        isFacingRight = boss1LastPhaseJumpLocation.position.x > rb.position.x;

        FlipCheck();

        flippedForLastPhaseRun = true;
    }

    private void LastPhaseStopBeforeRunCheck()
    {
        if (stoppedBeforeLastPhaseRun)
            return;

        rb.velocity = new Vector2(0f, rb.velocity.y);
        stoppedBeforeLastPhaseRun = true;
    }

    private void ReadyForLastPhaseRun() => readyForLastPhaseRun = true;
    
    private void RunToLastPhaseJumpLocationCheck()
    {
        if (isPreparingForLastPhaseJump || !readyForLastPhaseRun)
            return;

        if (boss1LastPhaseJumpLocation.position.x - 0.15f > rb.position.x)
            rb.velocity = new Vector2(10f, rb.velocity.y);
        else if (boss1LastPhaseJumpLocation.position.x + 0.15f < rb.position.x)
            rb.velocity = new Vector2(-10f, rb.velocity.y);
        else
        {
            isPreparingForLastPhaseJump = true;
            isFacingRight = true;
            rb.transform.Flip(ref isFacingRight);
            rb.velocity = new Vector2(0f, rb.velocity.y);
            Invoke("PerformLastPhaseJump", 0.5f);
            return;
        }
    }

    private void PerformLastPhaseJump()
    {
        Invoke("IsPerformingLastPhaseJump", 0.2f);
        rb.velocity = new Vector2(20f, rb.velocity.y);
        rb.Jump(lastPhaseJumpJumpingHeight);
    }

    private void IsPerformingLastPhaseJump() => MovementStatus.isPerformingLastPhaseJump = true;
    
    private void StopAfterPerformingLastPhaseJumpCheck()
    {
        if (!MovementStatus.isPerformingLastPhaseJump)
            return;

        if (groundCheck.IsGrounded(groundLayer, 0.01f))
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            rb.transform.Flip(ref isFacingRight);
            MovementStatus.isPerformingLastPhaseJump = false;
            readyForLastPhaseBouncyFireBallsAttack = true;
        }   
    }

    private void SummonBouncyFireBallsCheck()
    {
        if (readyForLastPhaseBouncyFireBallsAttack)
            SummonBouncyFireBalls();
    }
    private void SummonBouncyFireBalls()
    {
        AttackStatus.summoningBouncyFireBalls = true;

        currentBouncyFireBallSpawnTimer++;

        if (currentBouncyFireBallSpawnTimer == totalBouncyFireBallSpawnTimer)
        {
            Vector2 bouncyFireBallPosition = new Vector2(rb.position.x - 2f, rb.position.y);

            bouncyFireBall = Instantiate(bouncyFireBall, bouncyFireBallPosition, Quaternion.identity);

            bouncyFireBall.GetComponent<SpriteRenderer>().enabled = true;
            bouncyFireBall.GetComponent<BoxCollider2D>().enabled = true;

            currentBouncyFireBallSpawnTimer = 0;
        }
    }
}
