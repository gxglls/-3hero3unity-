using UnityEngine;
using System.Collections;

namespace ICode{
	public class UnityEventHandler : MonoBehaviour {
		public delegate void Trigger(GameObject other);
		public event Trigger onTrigger;
		public EventType type;

		private void OnTriggerEnter (Collider other) {
			if (onTrigger != null && type== EventType.OnTriggerEnter) {
				onTrigger (other.gameObject);
			}
		}
		
		private void OnTriggerExit(Collider other) {
			if (onTrigger != null && type== EventType.OnTriggerExit) {
				onTrigger (other.gameObject);
			}
		}
		
		private void OnTriggerStay(Collider other) {
			if (onTrigger != null && type== EventType.OnTriggerStay) {
				onTrigger (other.gameObject);
			}
		}
		
		private void OnCollisionEnter(Collision collision) {
			if (onTrigger != null && type== EventType.OnCollisionEnter) {
				onTrigger (collision.gameObject);
			}
		}
		
		private void OnCollisionExit(Collision collision) {
			if (onTrigger != null && type== EventType.OnCollisionExit) {
				onTrigger (collision.gameObject);
			}
		}
		
		private void OnCollisionStay(Collision collision) {
			if (onTrigger != null && type== EventType.OnCollisionStay) {
				onTrigger (collision.gameObject);
			}
		}
		
		private void OnTriggerEnter2D (Collider2D other) {
			if (onTrigger != null && type== EventType.OnTriggerEnter2D) {
				onTrigger (other.gameObject);
			}
		}
		
		private void OnTriggerExit2D (Collider2D other) {
			if (onTrigger != null && type== EventType.OnTriggerExit2D) {
				onTrigger (other.gameObject);
			}
		}
		
		private void OnTriggerStay2D (Collider2D other) {
			if (onTrigger != null && type== EventType.OnTriggerStay2D) {
				onTrigger (other.gameObject);
			}
		}

		private void OnCollisionEnter2D (Collision2D collision) {
			if (onTrigger != null && type== EventType.OnCollisionEnter2D) {
				onTrigger (collision.gameObject);
			}
		}

		private void OnCollisionExit2D (Collision2D collision) {
			if (onTrigger != null && type== EventType.OnCollisionExit2D) {
				onTrigger (collision.gameObject);
			}
		}

		private void OnCollisionStay2D (Collision2D collision) {
			if (onTrigger != null && type== EventType.OnCollisionStay2D) {
				onTrigger (collision.gameObject);
			}
		}

		private void OnMouseDown(){
			if (onTrigger != null && type== EventType.OnMouseDown) {
				onTrigger (gameObject);
			}
		}

		private void OnMouseUp(){
			if (onTrigger != null && type== EventType.OnMouseUp) {
				onTrigger (gameObject);
			}
		}

		private void OnMouseDrag(){
			if (onTrigger != null && type== EventType.OnMouseDrag) {
				onTrigger (gameObject);
			}
		}

		private void OnMouseEnter(){
			if (onTrigger != null && type== EventType.OnMouseEnter) {
				onTrigger (gameObject);
			}
		}

		private void OnMouseOver(){
			if (onTrigger != null && type== EventType.OnMouseOver) {
				onTrigger (gameObject);
			}
		}

		private void OnMouseExit(){
			if (onTrigger != null && type== EventType.OnMouseExit) {
				onTrigger (gameObject);
			}
		}

		public enum EventType{
			OnTriggerEnter,
			OnTriggerExit,
			OnTriggerStay,
			OnCollisionEnter,
			OnCollisionExit,
			OnCollisionStay,
			OnTriggerEnter2D,
			OnTriggerExit2D,
			OnTriggerStay2D,
			OnCollisionEnter2D,
			OnCollisionExit2D,
			OnCollisionStay2D,
			OnMouseDown,
			OnMouseUp,
			OnMouseDrag,
			OnMouseEnter,
			OnMouseExit,
			OnMouseOver,
		}
	}
}
