using Godot;
using System;

public class Game : Node
{
    public Vector2 Player_pos = new Vector2();

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

    public override void _Process(float delta)
    {
        // Called every frame. Delta is time since last frame.
        // Update game logic here.
        //GD.Print("Player Posistion" + Player_pos);

    }
}
