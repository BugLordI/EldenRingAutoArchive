namespace AutoArchivePlus.Model
{
    public class AppSetting
    {
        private bool autoCheckStartProgram;
        private bool alwaysAskWhenExits;

        public bool AutoCheckStartProgram { get => autoCheckStartProgram; set => autoCheckStartProgram = value; }
        public bool AlwaysAskWhenExits { get => alwaysAskWhenExits; set => alwaysAskWhenExits = value; }
    }
}
