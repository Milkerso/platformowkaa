namespace SnakeClassic_Csharp_dev.pl
{
    public class MenuState
    {
        private static bool _IsShowMainMenuScene;
        private static bool _IsShowGameScene;
        private static bool _IsShowGameOverScene;

        public static bool IsShowMainMenuScene { get { return _IsShowMainMenuScene; } set { if (value == true) { _IsShowGameScene = false; _IsShowGameOverScene = false; } _IsShowMainMenuScene = value; } }
        public static bool IsShowGameScene { get { return _IsShowGameScene; } set { if (value == true) { _IsShowMainMenuScene = false; _IsShowGameOverScene = false; } _IsShowGameScene = value; } }
        public static bool IsShowGameOverScene { get { return _IsShowGameOverScene; } set { if (value == true) { _IsShowMainMenuScene = false; _IsShowGameScene = false; } _IsShowGameOverScene = value; } }
    }
}
