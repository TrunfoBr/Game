using UnityEngine;

public static class Logger {

    public static void Log(string msg) {
        Debug.Log(msg);
    }

    public static void Log(Object obj, string msg) {
        Log("[" + obj + "]" + msg);
    }

    public static void Log(Object obj, string method_name, string msg) {
        Log("[" + obj + "]" + method_name + ": " + msg);
    }

    public static void LogWarning(string msg) {
        Debug.LogWarning(msg);
    }

    public static void LogWarning(Object obj, string msg) {
        LogWarning("[" + obj + "]" + msg);
    }

    public static void LogWarning(Object obj, string method_name, string msg) {
        LogWarning("[" + obj + "]" + method_name + ": " + msg);
    }

    public static void LogError(string msg) {
        Debug.LogError(msg);
    }

    public static void LogError(Object obj, string msg) {
        LogError("[" + obj + "]" + msg);
    }

    public static void LogError(Object obj, string method_name, string msg) {
        LogError("[" + obj + "]" + method_name + ": " + msg);
    }
}
