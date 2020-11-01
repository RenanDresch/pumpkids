using UnityEngine;

public class SetaDisparo : MonoBehaviour
{
    public DragShot dragShot;
    public SpriteRenderer sprite;

    private void Update()
    {
        if(dragShot.mirando)
        {
            sprite.size = new Vector2(dragShot.direcao.magnitude*0.01f, sprite.size.y);
            transform.rotation = Quaternion.LookRotation(Vector3.down, new Vector3(-dragShot.direcao.y, 0, dragShot.direcao.x));
        }
        else
        {
            sprite.size = new Vector2(0, sprite.size.y);
        }
    }
}
