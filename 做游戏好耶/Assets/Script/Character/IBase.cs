using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IBase : MonoBehaviour {
    public virtual void ChangeHealth (int dheal) { }
    public int MaxHealth;
    public int health { get { return m_health; } }
    protected int m_health;
    protected new Rigidbody2D rigidbody;
    public virtual void ChangeSprite (float direction) {
        if (direction != 0) {
            if (direction > 0) this.transform.localScale = new Vector3 (1, 1, 1);
            else this.transform.localScale = new Vector3 (-1, 1, 1);
        }
    }
}