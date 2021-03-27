using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect {
    //Effect的变量可以再加，目前想到的无法做到的事情：萨尔大招的劈砍
    void Effect (IBase activeTarget, IBase passiveTarget);
}