using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using WS1RCLASS;

namespace WitchSpringRTestPlugin
{
    public class EventContextScanner
    {
        private string lastLogKey = "";

        public void Scan()
        {
            try
            {
                MonoBehaviour[] behaviours = UnityEngine.Resources.FindObjectsOfTypeAll<MonoBehaviour>();

                foreach (MonoBehaviour behaviour in behaviours)
                {
                    if (behaviour == null)
                        continue;

                    Type type = behaviour.GetType();
                    //if (type.Name.Contains("Event") || type.Name.Contains("Loader"))
                    //    {
                    //        Plugin.LogRef.LogWarning($"EVENT TYPE FOUND: {type.FullName}");
                    //    }

                    if (!type.Name.Contains("EventLoader"))
                        continue;

                    object eventInfo = ReadValue(behaviour, "info");
                    if (eventInfo == null)
                        eventInfo = ReadValue(behaviour, "eventInfo");
                    if (eventInfo == null)
                        eventInfo = ReadValue(behaviour, "nowEventInfo");
                    if (eventInfo == null)
                        eventInfo = ReadValue(behaviour, "event");
                    if (eventInfo == null)
                        eventInfo = ReadValue(behaviour, "ev");

                    

                    if (eventInfo == null)
                    {
                        Plugin.LogRef.LogWarning($"EVENTLOADER found but no info/eventInfo field readable: {type.FullName}");
                        continue;
                    }

                    string eventId = ReadString(eventInfo, "eventFileName");
                    object methodList = ReadValue(eventInfo, "mathodList");

                    if (string.IsNullOrEmpty(eventId))
                        continue;

                    EventContext.Set(eventId, -1, "");

                    string logKey = $"{eventId}|{methodList}";
                    if (logKey != lastLogKey)
                    {
                        lastLogKey = logKey;

                        //Plugin.LogRef.LogWarning(
                        //    $"EVENTINFO DEBUG: event={eventId} methodList={methodList}"
                        //);
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogError($"EventContextScanner error: {ex}");
            }
        }

        private static object ReadValue(object obj, string name)
        {
            if (obj == null)
                return null;

            Type type = obj.GetType();

            FieldInfo field = type.GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (field != null)
                return field.GetValue(obj);

            PropertyInfo prop = type.GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (prop != null)
                return prop.GetValue(obj);

            return null;
        }

        private static string ReadString(object obj, string name)
        {
            object value = ReadValue(obj, name);
            return value?.ToString() ?? "";
        }

        private static int ReadInt(object obj, string name, int fallback)
        {
            object value = ReadValue(obj, name);

            if (value == null)
                return fallback;

            if (int.TryParse(value.ToString(), out int result))
                return result;

            return fallback;
        }

        private static string ReadCurrentCommand(object methodList, int methodId)
        {
            if (methodList == null || methodId < 0)
                return "";

            if (methodList is IEnumerable enumerable)
            {
                int index = 0;

                foreach (object entry in enumerable)
                {
                    if (index == methodId)
                        return ReadCommandFromEntry(entry);

                    index++;
                }
            }

            return "";
        }

        private static string ReadCommandFromEntry(object entry)
        {
            if (entry == null)
                return "";

            object command = ReadValue(entry, "command");
            if (command != null)
                return command.ToString();

            object method = ReadValue(entry, "method");
            if (method != null)
                return method.ToString();

            MethodInfo getCommand = entry.GetType().GetMethod(
                "GetCommand",
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
            );

            if (getCommand != null)
            {
                object result = getCommand.Invoke(entry, null);
                return result?.ToString() ?? "";
            }

            return entry.ToString();
        }
    }
}