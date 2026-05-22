namespace WitchSpringRTestPlugin
{
    public static class EventContext
    {
        public static string CurrentEventId = "";
        public static int CurrentMethodId = -1;
        public static string CurrentCommand = "";

        public static void Set(string eventId, int methodId, string command)
        {
            CurrentEventId = eventId;
            CurrentMethodId = methodId;
            CurrentCommand = command;
        }

        public static void Clear()
        {
            CurrentEventId = "";
            CurrentMethodId = -1;
            CurrentCommand = "";
        }
    }
}