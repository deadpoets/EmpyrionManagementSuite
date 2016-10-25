namespace EmpyrionManagementSuite.Themes
{
    public enum ThemeType
    {
        MORPHEUS_DARK = 0,
        MORPHEUS_LIGHT = 1
    }

    public static class THEME
    {
        private static string MorpheusDark = "/Themes/MorpheusDark.xaml";
        private static string MorpheusLight = "/Themes/MorpheusLight.xaml";

        public static string GetThemePath(ThemeType TYPE)
        {
            string themePath = null;

            switch (TYPE)
            {
                case ThemeType.MORPHEUS_DARK:
                    themePath = MorpheusDark;
                    break;

                case ThemeType.MORPHEUS_LIGHT:
                    themePath = MorpheusLight;
                    break;

                default:
                    themePath = MorpheusDark;
                    break;
            }

            return themePath;
        }
    }
}