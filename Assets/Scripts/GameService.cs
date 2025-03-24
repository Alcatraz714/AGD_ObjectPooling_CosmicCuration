#region Namespaces
using UnityEngine;
using TMPro;
using CosmicCuration.Audio;
using CosmicCuration.Enemy;
using CosmicCuration.Bullets;
using CosmicCuration.VFX;
using CosmicCuration.Player;
using CosmicCuration.UI;
using CosmicCuration.Utilities;
using CosmicCuration.PowerUps; 
#endregion


public class GameService : GenericMonoSingleton<GameService>
{
    #region Dependencies

    private PlayerService playerService;
    private EnemyService enemyService;
    private PowerUpService powerUpService;
    private VFXService vfxService;
    private SoundService soundService;
    [SerializeField] private UIView uiService;

    #endregion

    #region Prefabs
    [SerializeField] private PlayerView playerPrefab;
    [SerializeField] private BulletView playerBulletPrefab;
    [SerializeField] private EnemyView enemyPrefab;
    [SerializeField] private VFXView vfxPrefab;
    #endregion

    #region Scriptable Objects
    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private BulletScriptableObject playerBulletScriptableObject;
    [SerializeField] private EnemyScriptableObject enemyScriptableObject;
    [SerializeField] private PowerUpScriptableObject powerUpScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    //[SerializeField] private VFXScriptableObject vfxScriptableObject;
    #endregion

    #region Scene References
    [SerializeField] private AudioSource audioEffectSource;
    [SerializeField] private AudioSource backgroundMusicSource;
    #endregion

    private void Start()
    {
        // Initialize all Services.
        soundService = new SoundService(soundScriptableObject, audioEffectSource, backgroundMusicSource);
        playerService = new PlayerService(playerPrefab, playerScriptableObject, playerBulletPrefab, playerBulletScriptableObject);
        powerUpService = new PowerUpService(powerUpScriptableObject);
        enemyService = new EnemyService(enemyPrefab, enemyScriptableObject);
        //vfxService = new VFXService(vfxScriptableObject);
        vfxService = new VFXService(vfxPrefab);
    }

    private void Update()
    {
        powerUpService?.Update();
        enemyService?.Update();
    }

    #region Getters
    public PlayerService GetPlayerService() => playerService;

    public EnemyService GetEnemyService() => enemyService;

    public PowerUpService GetPowerUpService() => powerUpService;

    public VFXService GetVFXService() => vfxService;

    public SoundService GetSoundService() => soundService;

    public UIView GetUIService() => uiService; 
    #endregion

}
