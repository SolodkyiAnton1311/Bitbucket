using Model;
using UnityEngine;

namespace ViewModel
{ public class GameViewModel : MonoBehaviour
    {
        public GameModel Model { get; private set; }
        public string FormattedBalance => FormatBalance(Model.PlayerBalance);
        public void Initialize()
        {
            Model = new GameModel();
        }
        public void SpinWheel(int winningSegment)
        {
            int winnings = Model.SegmentValues[winningSegment];
            Model.AddBalance(winnings);
        }
        private string FormatBalance(int balance)
        {
            if (balance >= 1000000)
                return (balance / 1000000f).ToString("F1") + "m";
            if (balance >= 1000)
                return (balance / 1000f).ToString("F1") + "k";
            return balance.ToString();
        }
    }
}
