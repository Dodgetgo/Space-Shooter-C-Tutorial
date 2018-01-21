using Godot;
using System;

public class Gui : Control
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    public int SCORE = 0;


    public bool is_paused = false;
    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

    public override void _Process(float delta)
    {
        // Called every frame. Delta is time since last frame.
        // Update game logic here.

        var score_label = (Label)GetNode("Info/Score");
        score_label.SetText("SCORE: " + SCORE);

        if (Input.IsActionJustPressed("pause"))
        {
            is_paused = !is_paused;
            if (is_paused)
            {
                GD.Print("Paused");
            }
        }
        GetTree().SetPause(is_paused);
    }
    public void Score_Points(int Points)
    {
        SCORE += Points;
    }
}
