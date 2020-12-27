using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;
/*
namespace RootMotion.Demos {

	/// <summary>
	/// Resets an interaction object to it's initial position and rotation after "resetDelay" from interaction trigger.
	/// </summary>
	public class ResetInteractionObject : MonoBehaviour {

		public float resetDelay = 1f; // Time since interaction trigger to reset this Transform

		private Vector3 defaultPosition;
		private Quaternion defaultRotation;
		private Transform defaultParent;
		private Rigidbody r;

		void Start() {
			// Store the defaults
			defaultPosition = transform.position;
			defaultRotation = transform.rotation;
			defaultParent = transform.parent;

			r = GetComponent<Rigidbody>();
		}

		// Called by the Interaction Object
		void OnPickUp(Transform t) {
			StopAllCoroutines();
			StartCoroutine(ResetObject(Time.time + resetDelay));
		}

		// Reset after a certain delay
		private IEnumerator ResetObject(float resetTime)
		{
			while (Time.time < resetTime) yield return null;

		}
            /*
				var poser = transform.parent.GetComponent<Poser>();
				if (poser != null) {
					poser.poseRoot = null;
					poser.weight = 0f;
				}
				
				transform.parent = null;
				//transform.position = defaultPosition;
				//transform.rotation = defaultRotation;
				
				if (r != null) r.isKinematic = false;
           // }

		}
		private IEnumerator Drop()
        {
			GetComponent<Rigidbody>().isKinematic = false;
			transform.parent = null;
			yield return null;
        }
	}
}
*/

namespace Droping
{
	public class ResetInteractionObject : MonoBehaviour
    {
		public float resetDelay = 1f;
		[SerializeField]
		private GameObject obj;
		Vector3 velocity = new Vector3( 0.0f, -20.0f, 0.0f );
		void OnPickUp(Transform t)
		{
			StopAllCoroutines();

		}
		private void Update()
        {
			if (Input.GetKeyDown(KeyCode.Q))
				StartCoroutine(Drop(obj, Time.time + resetDelay));
        }

		public IEnumerator Drop(GameObject obj, float resetTime)
        {
			obj.transform.parent = null;

			if(obj.GetComponent<Rigidbody>() != null)
            {
				
				Rigidbody rb = obj.GetComponent<Rigidbody>();
				rb.isKinematic = false;
				rb.velocity = velocity * 10 * Time.deltaTime;
			}
			else if(obj.GetComponentInChildren<Rigidbody>() != null)
            {
				Rigidbody rb = obj.GetComponentInChildren<Rigidbody>();
				rb.isKinematic = false;
				rb.velocity= velocity*10*Time.deltaTime;
			}
			yield return null;
        }
    }
}