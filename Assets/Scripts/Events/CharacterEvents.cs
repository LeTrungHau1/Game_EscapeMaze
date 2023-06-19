using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class CharacterEvents
{
    //character damaged and damage value
    public static UnityAction<GameObject, float> characterDamaged;
    public static UnityAction<GameObject, float> PlayerDamaged;

    //character health and anmount healed
    public static UnityAction<GameObject, float> characterHealthed;


}
