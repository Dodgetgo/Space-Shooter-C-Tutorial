using System;
using Godot;

public class Bullet : KinematicBody2D
{
    private float Speed = 2.5f;
    public VisibilityNotifier2D vis;
    Vector2 UP = new Vector2(0, -1);


    public override void _Ready()
    {
        vis = (VisibilityNotifier2D)GetNode("VisibilityNotifier2D");
    }

    public override void _Process(float delta)
    {

        if (!vis.IsOnScreen())
        {
            _remove();
        }
        
        var hit = MoveAndCollide(UP*Speed);
        
        if (hit?.Collider != null)
        {
            hit.Collider.Call("HIT");
            GD.Print("HIT");
            _remove();

        }
        
    }

    public void _remove()
    {
        QueueFree();
    }
}
