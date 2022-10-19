
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Stat : MonoBehaviour
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public float Value { get; private set; }
        public Stat(string name, float value,int id)
        {
            Name = name;
            Value = value;
            Id = id;
        }
    }
}
