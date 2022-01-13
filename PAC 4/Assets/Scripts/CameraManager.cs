using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class CameraManager : MonoBehaviour
{
	public void Shake()
	{
		GetComponent<CinemachineImpulseSource>().GenerateImpulse();
	}
}
