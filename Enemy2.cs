using Godot;
using System;

public class Enemy2 : KinematicBody2D
{
    private Vector2 Down = new Vector2(0,1);
    private float Speed = 1.5f;
    public int HP = 2;


    public override void _Ready()
    {


    }

    public override void _Process(float delta)
    {
        Vector2 Vel = new Vector2();
        var playerpos = (Vector2)GetNode("..").Get("Player_pos");
        //GD.Print("playerpos" + playerpos);
        Vel += Down;
        if(Position.y > 436)
        {
            QueueFree();
        }

        if(Position.x > playerpos.x)
        {
            Vel.x -= 0.5f;
        }
        if (Position.x < playerpos.x)
        {
            Vel.x += 0.5f;
        }
        var hit = MoveAndCollide(Vel * Speed);
        if (hit?.Collider != null)
        {
            hit.Collider.Call("HIT", 3);
            QueueFree();
        }
        if (HP == 0)
        {
            GetNode("../Gui").Call("Score_Points", 500);
            QueueFree();
        }
    }
    public void HIT()
    {
        HP -= 1;
    }

}
