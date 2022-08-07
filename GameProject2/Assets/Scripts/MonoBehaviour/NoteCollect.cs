using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NoteCollect : MonoBehaviour
{
    private PlayerControls playerControls;

    public SphereCast sphereCast;
    private GameObject currentHit;
    [SerializeField] private GameObject researchNote;
    [SerializeField] private GameObject researchNote2;
    [SerializeField] private GameObject researchNote3;
    [SerializeField] private GameObject researchNote4;

    private AudioSource collectSource;
    public AudioClip collectSound;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        collectSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHit = sphereCast.currentHitObj;
        if (currentHit == null) return;

        if(sphereCast.currentHitObj.tag == "ResearchNote")
        {
            if (playerControls.Game.Interact.ReadValue<float>() > 0)
            {
                if(researchNote)
                {
                    collectSource.PlayOneShot(collectSound);
                    Destroy(sphereCast.currentHitObj.gameObject);
                    researchNote.SetActive(true);
                }
            }
        }
        if (sphereCast.currentHitObj.tag == "ResearchNote2")
        {
            if (playerControls.Game.Interact.ReadValue<float>() > 0)
            {
                collectSource.PlayOneShot(collectSound);
                Destroy(sphereCast.currentHitObj.gameObject);
                researchNote2.SetActive(true);
            }
        }
        if (sphereCast.currentHitObj.tag == "ResearchNote3")
        {
            if (playerControls.Game.Interact.ReadValue<float>() > 0)
            {
                collectSource.PlayOneShot(collectSound);
                Destroy(sphereCast.currentHitObj.gameObject);
                researchNote3.SetActive(true);
            }
        }
        if (sphereCast.currentHitObj.tag == "ResearchNote4")
        {
            if (playerControls.Game.Interact.ReadValue<float>() > 0)
            {
                collectSource.PlayOneShot(collectSound);
                Destroy(sphereCast.currentHitObj.gameObject);
                researchNote4.SetActive(true);
            }
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        collectSource.clip = collectSound;
        collectSource.PlayOneShot(collectSound);
        NoteSystem.notes += 1;
        Destroy(gameObject);
    }*/
}
