using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    Cube cube;

    private void Awake() {
        
        cube = GetComponent<Cube>();
    }

    private void OnCollisionEnter(Collision other) {
        
        Cube otherCube = other.gameObject.GetComponent<Cube>();

        if(otherCube != null && cube.cubeId > otherCube.cubeId){

            if(cube.cubeNumber == otherCube.cubeNumber){

                Debug.Log("HIT");
                Vector3 contactPoint = other.contacts[0].point;

                if(otherCube.cubeNumber < CubeSpawner.Instance.maxCubeNumber){

                    Cube newCube = CubeSpawner.Instance.Spawn(cube.cubeNumber * 2, contactPoint + Vector3.up * 1.5f);
                    float pushForce = 2.5f;

                    newCube.cubeRigidbody.AddForce(new Vector3(0, 0.3f, 1f) * pushForce, ForceMode.Impulse);
                }

                Collider[] surroundCube = Physics.OverlapSphere(contactPoint, 2f);
                float explosionForce = 400f;
                float explosionRadius = 1.5f;

                foreach(Collider cubeCollider in surroundCube){

                    if(cubeCollider.attachedRigidbody != null){

                        cubeCollider.attachedRigidbody.AddExplosionForce(explosionForce, contactPoint, explosionRadius);
                    }
                }

                ExplosionFX.Instance.PlayCubeExplosion(contactPoint, cube.cubeColor);

                CubeSpawner.Instance.DestroyCube(cube);
                CubeSpawner.Instance.DestroyCube(otherCube);
            }
        }
    }
}
