using UnityEngine;

namespace Model
{
    public class GameModel
    {
        public int PlayerBalance { get; set; }
        public int[] SegmentValues { get; private set; }
        public GameModel()
        {
            PlayerBalance = PlayerPrefs.GetInt("PlayerBalance", 0);
            GenerateSegmentValues();
        }

        public void AddBalance(int amount)
        {
            PlayerBalance += amount;
            PlayerPrefs.SetInt("PlayerBalance", PlayerBalance);
        }

        private void GenerateSegmentValues()
        {
            SegmentValues = new int[16];
            var rand = new System.Random();
            for (int i = 0; i < 16; i++)
            {
                int value;
                do
                {
                    value = rand.Next(10, 1001) * 100;
                } while (i > 0 && System.Array.Exists(SegmentValues, x => x == value));
                SegmentValues[i] = value;
            }
        }
        
    }
}

