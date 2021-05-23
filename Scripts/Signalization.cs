using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    private AudioSource _soundtrack;   
    private float _respond = 0.2f;

    void Start()
    {
        _soundtrack = GetComponent<AudioSource>();        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {           
            _soundtrack.Play();            
            StartCoroutine(ChangeVolume(true));
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
            StartCoroutine(ChangeVolume(false));
    }
    

    private IEnumerator ChangeVolume(bool alert) 
    {        
        if (alert)
        {
            while (_soundtrack.volume != 1)
            {
                _soundtrack.volume += Mathf.Lerp(0, 1, Time.deltaTime);
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
        else
        {
            while (_soundtrack.volume != 0)
            {
                _soundtrack.volume -= Mathf.Lerp(0, 1, Time.deltaTime);                
                yield return new WaitForSeconds(Time.deltaTime);
            }
            _soundtrack.Pause();
        }       
    }
}
