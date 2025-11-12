using Microsoft.VisualStudio.TestTools.UnitTesting;
using TowerOfHanoi;

namespace TowerOfHanoiTest;

[TestClass]
public class HanoiTest
{
    [TestMethod]
    public void ShouldInitializeTowerCorrectly()
    {
        HanoiTower tower = new HanoiTower(3);

        Assert.AreEqual(3, tower.DiscsCount);
        Assert.AreEqual(0, tower.MovesCount);
        Assert.AreEqual(3, tower.From.Count);
        Assert.AreEqual(0, tower.To.Count);
        Assert.AreEqual(0, tower.Auxillary.Count);
        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, tower.From.Reverse().ToArray());
    }

    [TestMethod]
    public void ShouldTransferDiscsCorrectly()
    {
        HanoiTower tower = new HanoiTower(3);

        tower.Start();

        Assert.AreEqual(0, tower.From.Count);
        Assert.AreEqual(3, tower.To.Count);
        Assert.AreEqual(0, tower.Auxillary.Count);
        Assert.AreEqual(7, tower.MovesCount); // 2
    }

    [TestMethod]
    public void PauseAndResumeShouldWorkCorrectly()
    {
        HanoiTower tower = new HanoiTower(2);

        tower.Pause();
        Assert.IsTrue(tower.IsPaused);

        tower.Resume();
        Assert.IsFalse(tower.IsPaused);
    }

    [TestMethod]
    public void SaveStateShouldSaveGame()
    {
        HanoiTower tower = new HanoiTower(3);
        tower.Start();

        var savedState = tower.SaveState();

        Assert.AreEqual(tower.DiscsCount, savedState.DiscsCount);
        Assert.AreEqual(tower.MovesCount, savedState.MovesCount);
        Assert.IsNotNull(savedState.From);
        Assert.IsNotNull(savedState.To);
        Assert.IsNotNull(savedState.Auxillary);
    }

    [TestMethod]
    public void LoadStateShouldLoadGame()
    {
        HanoiTower tower = new HanoiTower(3);
        tower.Start();
        var savedState = tower.SaveState();
        var newTower = new HanoiTower(1);

        newTower.LoadState(savedState);

        Assert.AreEqual(tower.DiscsCount, newTower.DiscsCount);
        Assert.AreEqual(tower.MovesCount, newTower.MovesCount);
        CollectionAssert.AreEqual(tower.From.ToArray(), newTower.From.ToArray());
    }
}
