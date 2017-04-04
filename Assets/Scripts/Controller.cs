using Characters;
using UnityEngine;
using System.Collections.Generic;

public class Controller: MonoBehaviour
{
    [SerializeField]
    private Character character;

	private int actionPoints = 10;
	private bool isExecuting;
	private Queue<Command> actions;
	public int CurrentActionPoints {
		get;
		private set;
	}

	private void Awake ()
	{
		actions = new Queue<Command> ();
		character = GetComponent<Character> ();
	}

	private void Start ()
	{
		Reset ();
	}

	public void ExecuteActions()
	{
		isExecuting = true;
		ExecuteNextAction ();
	
	}

	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.A)) {
			TryAddAction (new Attack ());
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			TryAddAction (new SuperAttack ());
		}

		if (Input.GetKeyDown (KeyCode.M)) {
			TryAddAction (new Move (5,4));
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			ExecuteActions ();
		}

	}

	public bool TryAddAction (Command action)
	{

		if (!isExecuting && CurrentActionPoints >= action.Cost) {
			actions.Enqueue (action);
			CurrentActionPoints -= action.Cost;
			return true;
		} else
			return false;

	}

	private void ExecuteNextAction ()
	{
		if (actions.Count == 0) {
			Reset ();
			return;
		}
		Command next = actions.Dequeue ();
		next.OnCompleted += ExecuteNextAction;
		next.Execute (character);
	}

	private void Reset ()
	{
		isExecuting = false;
		CurrentActionPoints = actionPoints;
	}
   
}