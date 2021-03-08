
using UnityEngine;
public class Tank : MonoBehaviour {

	// Référence vers le tank ennemi 
	public Transform enemy;
	// Référence vers le canon du tank
	public Transform cannon;
	// Distance maximale de tir du tank
	public float maxShootDistance = 20;

	void Update () 
	{
		// Calculer la distance entre les deux tanks
		float distance = Vector3.Distance(cannon.position, enemy.position);

		// Calculer le vecteur qui va de notre tank vers le tank ennemi
		Vector3 dirToEnemy = cannon.position - enemy.position;
		dirToEnemy.Normalize();
		


		// Utiliser Vector3.Dot() et dirToEnemy pour savoir si l'ennemi et devant ou derrière nous
		float dotProduct = Vector3.Dot(cannon.position, dirToEnemy);
		bool enemyIsInFront = dotProduct> 0.5f;
		


		// Calculer le vecteur qui va du tank ennemi vers notre tank
		Vector3 dirFromEnemy = enemy.position - cannon.position;
		dirFromEnemy.Normalize();
	
		
		// Utiliser Vector3.Dot() pour savoir si l'ennemi regarde dans notre direction
		float dotProduct2 = Vector3.Dot(cannon.position, dirToEnemy);
		bool enemyIsLookingToMe = dotProduct2> 0.5f;
		Debug.Log(enemyIsLookingToMe);
		
		// Calculer la position maximale du tir du tank
		// cette position sera située à maxDistance du canon, dans l'axe forward du canon
		Vector3 shootPosition =
		
	}
}


