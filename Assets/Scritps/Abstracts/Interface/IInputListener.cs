using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Abstracts.Inputs
{
    public interface IInputListener
    {
        float Horizontal { get; }
        bool IsJump { get; }
    }
}