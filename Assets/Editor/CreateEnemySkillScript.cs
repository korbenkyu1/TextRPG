using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateStatusEffectScript
{
    [MenuItem("Assets/Create/Enemy Skill Script", priority = 83)]    
    public static void CreateEnemySkillScriptFile()
    {
        string path = GetSelectedPathOrFallback();
        string scriptName = "NewEnemySkill";
        string fullPath = AssetDatabase.GenerateUniqueAssetPath(Path.Combine(path, scriptName + ".cs"));

        string scriptTemplate = @"using UnityEngine;

[CreateAssetMenu(menuName = ""Data/EnemySkill/{0}"")]
public class {0} : EnemySkillData
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
