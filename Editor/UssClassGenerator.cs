using UnityEditor;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class UssAutoGenerator : AssetPostprocessor
{
    private const string OutputFolder = "Assets/UI Toolkit/USS/";
    private const string SelectorPattern = @"^\s*([^{\r\n]+)\s*\{";
    private const string ClassPattern = @"\.([a-zA-Z_][a-zA-Z0-9_-]*)";

    static void OnPostprocessAllAssets(
        string[] importedAssets,
        string[] deletedAssets,
        string[] movedAssets,
        string[] movedFromAssetPaths)
    {
        foreach (string assetPath in importedAssets)
        {
            if (IsUssFile(assetPath))
            {
                GenerateFromUss(assetPath);
            }
        }
    }

    private static bool IsUssFile(string assetPath)
    {
        return assetPath.EndsWith(".uss");
    }

    private static void GenerateFromUss(string ussAssetPath)
    {
        string ussText = File.ReadAllText(ussAssetPath);
        HashSet<string> classNames = ExtractClassNames(ussText);

        if (classNames.Count == 0)
        {
            return;
        }

        EnsureOutputFolderExists();

        string className = BuildClassName(ussAssetPath);
        string outputPath = BuildOutputPath(className);
        string content = BuildClassContent(ussAssetPath, className, classNames);

        File.WriteAllText(outputPath, content);
        AssetDatabase.Refresh();
    }

    private static HashSet<string> ExtractClassNames(string ussText)
    {
        HashSet<string> classNames = new();

        MatchCollection selectorMatches = Regex.Matches(
            ussText,
            SelectorPattern,
            RegexOptions.Multiline);

        foreach (Match selectorMatch in selectorMatches)
        {
            AddClassesFromSelector(selectorMatch.Groups[1].Value, classNames);
        }

        return classNames;
    }

    private static void AddClassesFromSelector(string selectorText, HashSet<string> classNames)
    {
        MatchCollection classMatches = Regex.Matches(selectorText, ClassPattern);

        foreach (Match classMatch in classMatches)
        {
            classNames.Add(classMatch.Groups[1].Value);
        }
    }

    private static void EnsureOutputFolderExists()
    {
        if (!Directory.Exists(OutputFolder))
        {
            Directory.CreateDirectory(OutputFolder);
        }
    }

    private static string BuildClassName(string ussAssetPath)
    {
        string fileName = Path.GetFileNameWithoutExtension(ussAssetPath);
        return SanitizeIdentifier(fileName);
    }

    private static string BuildOutputPath(string className)
    {
        return Path.Combine(OutputFolder, className + ".cs");
    }

    private static string BuildClassContent(
        string ussAssetPath,
        string className,
        IEnumerable<string> classNames)
    {
        StringBuilder builder = new();

        builder.AppendLine("// Auto-generated from: " + ussAssetPath);
        builder.AppendLine("public static class " + className);
        builder.AppendLine("{");

        foreach (string styleClass in classNames)
        {
            string fieldName = SanitizeIdentifier(styleClass);
            builder.AppendLine($"    public const string {fieldName} = \"{styleClass}\";");
        }

        builder.AppendLine("}");

        return builder.ToString();
    }

    private static string SanitizeIdentifier(string input)
    {
        string result = input.Replace("-", "_");

        if (char.IsDigit(result[0]))
        {
            result = "_" + result;
        }

        return result;
    }
}