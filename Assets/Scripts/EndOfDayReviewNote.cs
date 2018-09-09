using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EndOfDayReviewNote : ScriptableObject {
    public enum OperationType {AND,OR}
    public string[] VariablesToEvaluate;

    public OperationType Operation = OperationType.AND;
    [TextArea]
    public string VariableTrue;
    [TextArea]
    public string VariableFalse;

   

}
