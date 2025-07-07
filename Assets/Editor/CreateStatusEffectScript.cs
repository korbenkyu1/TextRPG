using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateEnemySkillScript
{
    [MenuItem("Assets/Create/Status Effect Script", priority = 81)]    
    public static void CreateStatusEffectScriptFile()
    {
        string path = GetSelectedPathOrFallback();
        string scriptName = "NewStatusEffect";
        string fullPath = AssetDatabase.GenerateUniqueAssetPath(Path.Combine(path, scriptName + ".cs"));

        string scriptTemplate = @"using UnityEngine;

[CreateAssetMenu(menuName = ""Data/StatusEffects/{0}"")]
public class {0} : StatusEffectData
{{
    // Add your custom behavior here
}}";

        string className = Path.GetFileNameWithoutExtension(fullPath);
        string scriptContent = string.Format(scriptTemplate, className);

        File.WriteAllText(fullPath, scriptContent);
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = AssetDatabase.LoadAssetAtPath<MonoScript>(fullPath);
    }

    private static string GetSelectedPathOrFallback()
    {
        string path = "Assets";
        foreach (Object obj in Selection.GetFiltered(typeof(Object), SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                return path;
            else if (!string.IsNullOrEmpty(path))
                return Path.GetDirectoryName(path);
        }
        return path;
    }
}
