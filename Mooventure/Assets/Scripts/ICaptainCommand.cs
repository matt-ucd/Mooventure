using UnityEngine;

namespace Captain.Command
{
    public interface ICaptainCommand
    {
        void Execute(GameObject gameObject);
        public void Change_speed(int spd);
    }
}
