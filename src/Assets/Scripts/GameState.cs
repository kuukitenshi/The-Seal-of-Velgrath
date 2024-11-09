public static class GameState
{
    public static bool KeyCrafted { get; set; } = false;

    public static int FragmentsCollected { get; set; } = 0;

    public static Quest CurrentQuest { get; set; } = null;

    public static string LastScene { get; set; } = string.Empty;

    public static bool DoorUnlocked { get; set; } = false;

    public static bool ApHouseUnlocked { get; set; } = false;

    public static void Reset()
    {
        KeyCrafted = false;
        FragmentsCollected = 0;
        CurrentQuest = null;
        LastScene = string.Empty;
        DoorUnlocked = false;
        ApHouseUnlocked = false;
        Pin.pinCounter = 0;
    }
}
