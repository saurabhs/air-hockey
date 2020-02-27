using UnityEngine;

namespace AirHockey.Core
{
    public class Constants
    {
        public static Color GetColor(int index)
        {
            switch(index)
            {
            case 0:
                return Color.red;
            case 1:
                return Color.green;
            }

            return Color.yellow;
        }
    }
}