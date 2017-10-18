using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour {

	private BoxCollider2D collider;
	public float hp;
	public GameObject healthBar;
	private float hpBarSizeConst;

	void Awake () {
		collider = GetComponent<BoxCollider2D> ();
		hp = 100;
		hpBarSizeConst = healthBar.transform.localScale.x;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "poisonHazard") {
			StartCoroutine (poisonDmg (10));
		}
	}
	
	IEnumerator poisonDmg (int duration) {
		double count = 0;
		while (count < duration) {
			hp-=0.1f;
			count+=0.1;
			healthBar.transform.localScale = new Vector3 (healthBar.transform.localScale.x - (hpBarSizeConst * 0.001f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
			//healthBar.transform.localScale.x = healthBar.transform.localScale.x - (healthBar.transform.localScale.x * 0.1f);
			Debug.Log(hp);
			yield return null;
		}
	}
}
