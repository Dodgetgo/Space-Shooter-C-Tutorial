using Godot;

public class Player : KinematicBody2D
{
    private float Speed = 1.5f;
    static PackedScene bullet = (PackedScene)ResourceLoader.Load("res://Bullet.tscn");
    int HP = 10;
    public override void _Ready()
    {
         
    }

    public override void _Process(float delta)
    {
        GetNode("..").Set("Player_pos", Position);
        Vector2 vel = new Vector2(0, 0);
        GetNode("../Gui").Set("HP_player", HP);
        GD.Print(HP);
        var hp_bar = (TextureProgress)GetNode("../Gui/Info/Hp");
        hp_bar.SetValue(HP);
        if (Input.IsActionPressed("ui_left"))
        {
            vel.x -= Speed;
        }
        if (Input.IsActionPressed("ui_right"))
        {
            vel.x += Speed;
        }
        if (Input.IsActionPressed("ui_up"))
        {
            vel.y -= Speed;
        }
        if (Input.IsActionPressed("ui_down"))
        {
            vel.y += Speed;
        }
        if (Input.IsActionJustPressed("fire"))
        {
            _Fire();
        }
        if(HP <= 0)
        {
            GetTree().ReloadCurrentScene();
        }
        MoveAndCollide(vel);
    }

    public void _Fire()
    {
        Node p = (Node)GetNode("..");
        KinematicBody2D b = (KinematicBody2D)bullet.Instance();

        if (b != null)
        {
            b.Position = Position;
            p.AddChild(b);
        }

    }
    
    public void HIT(int amount)
    {

        HP -= amount;

    }
}