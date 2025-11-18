using System.Windows.Forms;

namespace TowerOfHanoi.GUI;

public partial class MainForm : Form
{
    private HanoiTower game; // Game logic
    private List<DiscVisual> discs = new List<DiscVisual>(); // Discs to draw
    private System.Windows.Forms.Timer gameTimer;

    public MainForm()
    {
        InitializeComponent();
        SetupGame();
        SetupTimer();
    }

    private void SetupGame()
    {
        int discCount = 5;
        game = new HanoiTower(discCount);

        CreateDiscs();

    }

    private void CreateDiscs()
    {
        throw new NotImplementedException();
    }

    private void SetupTimer()
    {
        gameTimer = new System.Windows.Forms.Timer();
        gameTimer.Interval = 1000;
        gameTimer.Tick += GameTimer_Tick;
    }

    private void GameTimer_Tick(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}
