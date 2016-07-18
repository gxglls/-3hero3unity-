using UnityEngine;
using System.Collections;

public class IndentAttribute : PropertyAttribute {
	public int indentLevel;

	public IndentAttribute(){
		indentLevel = 1;
	}

	public IndentAttribute(int indentLevel){
		this.indentLevel = indentLevel;
	}
}
