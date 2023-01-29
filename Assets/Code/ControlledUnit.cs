using UnityEngine;

public class ControlledUnit : Unit
{
    public override void Move(Vector3 target) => base.Move(target);

    public ControlledUnit(IMovable movableBehaviour)
    {
        this.movableBehaviour = movableBehaviour;
    }
    private void Update() => Move(target);
}