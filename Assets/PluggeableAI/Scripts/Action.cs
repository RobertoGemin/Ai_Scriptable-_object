using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Complete;

public abstract class Action : ScriptableObject {
    public abstract void Act(StateController Controller);
	
}
