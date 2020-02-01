namespace Roguelike {
  public class PlayerStatus
  {
    public int maxHp_ { private set; get; } = 0;
    public int Hp_ { private set; get; } = 0;
    public int power_ { private set; get; } = 0;
    public int tough_ { private set; get; } = 0;
    public PlayerStatus()
    {
      maxHp_ = Hp_ = 10;
      power_ = 1;
      tough_ = 0;
    }
  }
}
