using Model;
using NUnit.Framework;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

public class Test
{
    private GameModel _gameModel;

    [SetUp]
    public void Setup()
    {
        _gameModel = new GameModel();
    }
    [UnityTest]
    public void Balance_Updates_Correctly_After_Spin()
    {
        int initialBalance = _gameModel.PlayerBalance;
        int winnings = _gameModel.SegmentValues[0]; 
        _gameModel.AddBalance(100); 
        Assert.AreEqual(initialBalance + winnings, _gameModel.PlayerBalance);
    }
    
}