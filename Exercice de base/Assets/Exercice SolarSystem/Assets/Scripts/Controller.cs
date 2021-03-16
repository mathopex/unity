using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour 
{
	// Références vers les composants Transform de la terre, de la lune et du soleil
	public Transform sun;
	public Transform earth;
	public Transform moon;

	// Distance terre - lune
	public float moonDistance = 5f;

	// Axe de rotation de la terre autour du soleil
	public Vector3 sunRotationAxis = new Vector3(0.2f, 1f, 0.2f);

	// Angle de rotation de la terre autour du soleil
	private float sunCumulatedAngle = 0;
	
	// Valeur ajoutée à l'angle de rotation de la terre autour du soleil
	public float sunAngleIncrement = 0.02f;

	
	void FixedUpdate ()
	{
		// Faire tourner la terre autour du soleil 
		earth.RotateAround(sun.position, sunRotationAxis, sunAngleIncrement);

		// Faire tourner la terre sur elle même, 365 fois en un tour de soleil

		earth.transform.rotation = Quaternion.Euler(new Vector3(0, sunCumulatedAngle * 365, 0));
		// Faire tourner la lune autour de la terre
		// La lune doit tourner 27 fois autour de la terre, lorsque celle-ci fait un tour du soleil
		Quaternion moonRotation = Quaternion.Euler(0, sunCumulatedAngle * 27, 0);
		moon.position = earth.position + moonRotation * new Vector3(0, 0, moonDistance);
		// La lune doit toujours regarder la terre avec la même face
		moon.transform.LookAt(earth.position);
		
		// On incrémente l'angle de la terre autour du soleil
		sunCumulatedAngle += sunAngleIncrement;
	}
}
