using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReceiver : MonoBehaviour {
	public GameObject ObjectToSpawnOnDeath;
	public GameObject DestructionFX;
	public float SpawnDistance = 2;
	public float DeflectionAngle = 45;
    public int HP = 100;
	public float DestructionFXDuration = 0.5f;
	public uint ScoreOnDeath = 0;
	public bool DebugDraw = false;
	
	public void ReceiveHit(GameObject damageDealer)
	{
        if (damageDealer.tag == "Asteroid")
        {
            HP = HP - 10;
        }
        else { HP = 0; }
		if (ObjectToSpawnOnDeath != null)
		{
			Vector3 hitDirection = transform.position - damageDealer.transform.position;
			hitDirection.Normalize();
			if (DebugDraw) {
				Debug.DrawLine (damageDealer.transform.position, transform.position, Color.red, 2.0f);
			}
			SpawnDeathObject (hitDirection, -DeflectionAngle);
			SpawnDeathObject (hitDirection, DeflectionAngle);
		}
		if (DestructionFX != null) {
			GameObject spawnedFX = Instantiate (DestructionFX, transform.position, Random.rotation);
			Destroy (spawnedFX, DestructionFXDuration);
		}
		GameStateController.Instance.IncrementScore (ScoreOnDeath);
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
	}

	private void SpawnDeathObject(Vector3 hitDirection, float angle)
	{
		Vector3 spawnDirection = Quaternion.AngleAxis (angle, Vector3.up) * hitDirection;
		Vector3 spawnPosition = transform.position + spawnDirection * SpawnDistance;
		if (DebugDraw) {
			Debug.DrawLine (transform.position, spawnPosition, Color.green, 2.0f);
		}

		GameObject spawnedObject = Instantiate(ObjectToSpawnOnDeath, spawnPosition, Random.rotation);
		var asteroidMovementController = spawnedObject.GetComponent<AsteroidMovementController> ();
		if (asteroidMovementController) {
			asteroidMovementController.InitialDirection = spawnDirection;
		}
	}
}
