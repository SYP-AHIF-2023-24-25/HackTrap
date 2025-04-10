using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Team { Green, Blue }

    public Team team;
    private bool isOnCorrectField = false;

    public bool IsOnCorrectField()
    {
        return isOnCorrectField;
    }

    public void SetOnCorrectField(bool onCorrectField)
    {
        isOnCorrectField = onCorrectField;
    }
}
