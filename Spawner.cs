using Godot;
using System;

public class Spawner : Node2D
{
    [Export]
    public Vector2 zone_start = new Vector2(0,0);
    [Export]
    public Vector2 zone_end = new Vector2(0,0);
    float timer = 3.0f;

    static PackedScene enemy = (PackedScene)ResourceLoader.Load("res://Enemy.tscn");
    static PackedScene enemy2 = (PackedScene)ResourceLoader.Load("res://Enemy2.tscn");

    public override void _Ready()
    {

    }

    public override void _Process(float delta)
    {
        timer -= delta;
        if(timer < 0)
        {
            __spawn_enemy((Vector2)_PointSelect(zone_start, zone_end));
            timer = 0.8f;
        }
        
        
    }
    public void __spawn_enemy(Vector2 pos)
    {
        Node p = (Node)GetNode("..");
        KinematicBody2D b;
        Random rnd = new Random();
        int sel = 0;
        sel = rnd.Next(0, 10);

        if (sel < 7)
        {
            b = (KinematicBody2D)enemy.Instance();
        }
        else
        {
            b = (KinematicBody2D)enemy2.Instance();
        }

        if (b != null)
        {
            b.Position = pos;
            p.AddChild(b);
        }

    }

    public object _PointSelect(Vector2 Start, Vector2 End)
    {
        Vector2 Rand_Vec2 = new Vector2();
        Random rnd = new Random();
        Rand_Vec2.x = rnd.Next((int)Start.x, (int)End.x);
        Rand_Vec2.y = rnd.Next((int)Start.y, (int)End.y);
        return Rand_Vec2;
    }
}

