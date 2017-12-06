using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBehaviour : MonoBehaviour {
	private Rigidbody r = null;
	private float _localTimeScale = 1.0f;
	public float localTimeScale
	{
		get
		{
			return _localTimeScale;
		}
		set
		{
			if (r == null) r = GetComponent<Rigidbody>();
			if (r != null)
			{
				float multiplier = value / _localTimeScale;
				r.angularDrag *= multiplier;
				r.drag *= multiplier;
				r.mass /= multiplier;
				r.velocity *= multiplier;
				r.angularVelocity *= multiplier;
			}

			_localTimeScale = value;
		}
	}
	public float localDeltaTime
	{
		get
		{
			return Time.deltaTime * Time.timeScale * _localTimeScale;
		}
	}

	void FixedUpdate()
	{
		// Counter gravity
		if (r == null) r = GetComponent<Rigidbody>();
		if (r != null)
		{
			r.AddForce(-Physics.gravity + (Physics.gravity * (_localTimeScale * _localTimeScale)), ForceMode.Acceleration);
		}
	}
}
