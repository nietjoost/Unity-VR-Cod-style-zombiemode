using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;
    [SerializeField] private TextMeshProUGUI ammoText;

    [Header("Settings")]
    [SerializeField] private ButtonHandler shootInput;
    [SerializeField] private float bulletRange;
    [SerializeField] private int gunDamage;
    [SerializeField] private int magazineAmount;
    int magazineAmountCurrent;
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Type 0 for full auto")] [SerializeField] private float triggerTimer;

    [Header("Sounds")]
    private AudioSource source;
    public AudioClip fire;

    private bool fullAuto = false;
    private float time;

    private bool inHand;

	private void OnEnable()
	{
        shootInput.OnButtonDown += Shoot;
    }

    private void OnDisable()
    {
        shootInput.OnButtonDown -= Shoot;
    }

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        //Get components
        source = GetComponent<AudioSource>();

        //Check if full auto gun
        if (triggerTimer == 0)
            fullAuto = true;

        //Set current bullets in gun
        magazineAmountCurrent = magazineAmount;
        ammoText.text = magazineAmountCurrent + " / " + magazineAmount;
    }

	private void FixedUpdate()
	{
        //Add time to the timer for shoot timer
        if (inHand)
            time += Time.fixedDeltaTime;
	}


    //This function creates the bullet behavior
    private void Shoot(XRController controller)
    {
        if (inHand)
        { 
            if (time > triggerTimer && magazineAmountCurrent > 0)
            {
                time = 0f;

                source.PlayOneShot(fire);

                if (muzzleFlashPrefab)
                {
                    //Create the muzzle flash
                    GameObject tempFlash;
                    tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

                    //Destroy the muzzle flash effect
                    Destroy(tempFlash, destroyTimer);
                }

                //RayCast gun
                RaycastHit hit;
                if (Physics.Raycast(barrelLocation.position, barrelLocation.forward, out hit, bulletRange))
                {
                    ZombieAI zom = hit.transform.GetComponent<ZombieAI>();
                    if (zom != null)
                    {
                        //true if zombie hit
                        zom.TakeDamage(gunDamage);

                        //Player stats
                        ZombieModeManager.main.playerManager.stats.AddMoney(10);
                    }
                }

                RemoveBulletFromMagazine();
                CasingRelease();
            }
        }
    }

    //Called by XR Interactor
    public void SetInHand()
	{
        inHand = true;
    }

    //Called by XR Interactor
    public void SetOutHand()
    {
        inHand = false;
    }

    //Set current amount of bullets in gun
    private void RemoveBulletFromMagazine()
	{
        magazineAmountCurrent--;
        ammoText.text = magazineAmountCurrent + " / " + magazineAmount;
	}

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(700f * 0.7f, 250f), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

}
