using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverWorldNode : MonoBehaviour {

    public List<OverWorldNode> linkedNodes;
    OverWorldNode [] directions;
    public OverWorldNode UP;
    public OverWorldNode RIGHT;
    public OverWorldNode DOWN;
    public OverWorldNode LEFT;

    private void Awake() {
        directions = new OverWorldNode[4];
        directions[0] = UP;
        directions[1] = RIGHT;
        directions[2] = DOWN;
        directions[3] = LEFT;
    }

    public bool IsLinkedTo(OverWorldNode otherNode) {
        if (linkedNodes.Contains(otherNode)) {
            return true;
        }
        return false;
    }

    public bool CanMoveTo(Utils.Direction dir) {
        if (directions[(int)dir] != null) {
            return true;
        }
        
        return false;
    }


}
