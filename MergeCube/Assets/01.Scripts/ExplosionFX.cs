using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFX : MonoBehaviour
{
    public static ExplosionFX Instance;

    [SerializeField] private ParticleSystem cubeExplosionFX;

    ParticleSystem.MainModule cubeExplosionFXmodule;
    private void Awake() {
        
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start() {
        
        cubeExplosionFXmodule = cubeExplosionFX.main;
    }

    public void PlayCubeExplosion(Vector3 pos, Color color){

        cubeExplosionFXmodule.startColor = new ParticleSystem.MinMaxGradient(color);
        cubeExplosionFX.transform.position = pos;
        cubeExplosionFX.Play();
    }

}
