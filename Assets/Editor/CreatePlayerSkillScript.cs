using UnityEngine;
using UnityEditor;
using System.IO;

public class CreatePlayerSkillScript
{
    [MenuItem("Assets/Create/Player Skill Script", priority = 82)]    
    public static void CreatePlayerSkillScriptFile()
    {
        string path = GetSelectedPathOrFallback();
        string scriptName = "NewPlayerSkill";
        string fullPath = AssetDatabase.GenerateUniqueAssetPath(Path.Combine(path, scriptName + ".cs"));

        string scriptTemplate = @"using UnityEngine;

[CreateAssetMenu(menuName = ""Data/PlayerSkill/{0}"")]
public class {0} : PlayerSkillData
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
