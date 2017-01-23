using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAudio : MonoBehaviour {

    AudioSource m_AudioSource;
    public AudioClip roarClip;
    public AudioClip screamClip;
    public Transform player;
    AlienAnimation alienAnim;

    // Use this for initialization
    void Start () {
        m_AudioSource = GetComponent<AudioSource>();
        alienAnim = GetComponent<AlienAnimation>();
        m_AudioSource.clip = roarClip;
        m_AudioSource.loop = true;
    }

    bool gameOver = false;
    void Update()
    {   
        if (Vector3.Distance(transform.position, player.position) < 3f && !gameOver)
        {
            m_AudioSource.clip = screamClip;
            m_AudioSource.loop = false;
            m_AudioSource.Stop();
            m_AudioSource.PlayOneShot(m_AudioSource.clip);
            gameOver = true;
        }
        if(!m_AudioSource.isPlaying && !gameOver)
            m_AudioSource.Play();

        if (Vector3.Distance(transform.position, player.position) < 1.5f)
        {
            Time.timeScale = 0f;
        }
    }
}
