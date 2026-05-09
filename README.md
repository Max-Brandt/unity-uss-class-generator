# USS Class Generator

A Unity Editor tool that automatically generates C# constants from your USS class names whenever a `.uss` file is saved or imported. Instead of scattering magic strings throughout your code, you get type-safe constants with full IDE autocompletion — no manual steps required.

---

## Features

- C# constants are generated **automatically** whenever a `.uss` file is saved or reimported
- No manual trigger needed — works seamlessly in the background via Unity's asset import pipeline
- Full IDE autocompletion and refactoring support instead of magic strings
- Compatible with Unity UI Toolkit (UXML / USS / UI Builder)
- Includes a sample project to get started quickly

---

## Requirements

- Unity **6000.3.13f1** or newer
- UI Toolkit (built into Unity 6 by default)

---

## Installation via Package Manager

1. Open **Window → Package Manager** in Unity
2. Click the **`+`** button in the top-left corner
3. Select **"Add package from git URL..."**
4. Paste the following URL:

```
https://github.com/Max-Brandt/unity-uss-class-generator.git
```

5. Click **Add** — Unity will download and register the package automatically.

---

## Importing the Sample

The package includes a sample scene (`Uss Generator Scene`) that demonstrates the generator in action.

1. Open **Window → Package Manager**
2. Select **"In Project"** from the dropdown, or search for **"USS-Class Generator"**
3. Click on the package to expand it and navigate to the **"Samples"** tab
4. Click **"Import"** next to **"Uss Generator Scene"**

The sample files will be copied into `Assets/Samples/USS-Class Generator/` and are fully editable from there.

> **Note:** The `Samples~/` folder is intentionally excluded from your project by default. Always import samples through the Package Manager to get a proper, editable copy.

---

## How It Works

The generator hooks into Unity's asset import pipeline. Every time you **save or modify a `.uss` file**, it is automatically scanned for class selectors and a corresponding C# file is generated next to it.

Given a stylesheet like this:

```css
/* MyStyles.uss */
.button--primary {
    background-color: #4a90d9;
    color: white;
}

.panel--dark {
    background-color: #1e1e1e;
}
```

The tool automatically produces a C# file with constants matching your class names:

```csharp
// MyStyles.cs (auto-generated — do not edit manually)
public static class MyStylesUssClasses
{
    public const string ButtonPrimary = "button--primary";
    public const string PanelDark = "panel--dark";
}
```

---

## Usage in Code

Use the generated constants wherever you would normally pass a USS class name as a string:

```csharp
// Without USS Class Generator — error-prone magic strings:
element.AddToClassList("button--primary");

// With USS Class Generator — type-safe constants:
element.AddToClassList(MyStylesUssClasses.ButtonPrimary);
```

This eliminates typos, enables rename refactoring, and gives you autocomplete across the entire codebase.



## License

MIT License — see [LICENSE](./LICENSE)
