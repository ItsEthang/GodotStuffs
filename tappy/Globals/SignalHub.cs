using Godot;

public partial class SignalHub : Node
{
	public static SignalHub Instance { get; private set; }

	[Signal] public delegate void OnTappyDiedEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	public static void EmitOnTappyDied()
	{
		Instance.EmitSignal(SignalName.OnTappyDied);
	}
}
