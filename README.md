# USS Class Generator

Ein Unity Editor-Tool, das automatisch C#-Konstanten aus USS-Klassen deines Unity UI Toolkit Stylesheets generiert. Statt USS-Klassennamen als magische Strings im Code zu schreiben, erhältst du typsichere Konstanten – keine Tippfehler, vollständige IDE-Autovervollständigung.

---

## Features

- Automatische Generierung von C#-Konstanten aus `.uss`-Dateien
- Nahtlose Integration in den Unity Editor
- Unterstützt Unity UI Toolkit (UI Builder / UXML / USS)
- Enthält ein Beispielprojekt (Sample) zum schnellen Einstieg

---

## Voraussetzungen

- Unity **6000.3.13f1** oder neuer
- UI Toolkit (in Unity 6 standardmäßig enthalten)

---

## Installation via Package Manager

Das Package lässt sich direkt über den Unity Package Manager per Git-URL einbinden.

1. Öffne in Unity: **Window → Package Manager**
2. Klicke oben links auf das **`+`**-Symbol
3. Wähle **„Add package from git URL..."**
4. Füge folgende URL ein:

```
https://github.com/Max-Brandt/unity-uss-class-generator.git
```

5. Klicke **Add** – Unity lädt das Package automatisch herunter und bindet es ein.

---

## Sample importieren

Das Package enthält ein Beispielprojekt (`Uss Generator Scene`), das zeigt, wie der Generator verwendet wird.

**So importierst du das Sample:**

1. Öffne den **Package Manager** (**Window → Package Manager**)
2. Wähle links in der Dropdown-Liste **„In Project"** oder suche nach **„USS-Class Generator"**
3. Klicke auf das Package, um es aufzuklappen
4. Navigiere zum Tab **„Samples"**
5. Klicke neben **„Uss Generator Scene"** auf **„Import"**

Die Sample-Dateien werden in deinen `Assets`-Ordner unter `Assets/Samples/USS-Class Generator/` kopiert und sind ab dann wie normale Assets bearbeitbar.

---

## Verwendung

### 1. USS-Datei vorbereiten

Stelle sicher, dass du eine `.uss`-Datei mit definierten Klassen hast, z. B.:

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

### 2. C#-Konstanten generieren

1. Rechtsklicke in Unity auf deine `.uss`-Datei im **Project-Fenster**
2. Wähle im Kontextmenü den Eintrag zum Generieren der Klasse *(Menüeintrag je nach Version, z. B. **„Generate USS Class"**)*
3. Unity erstellt eine C#-Datei mit Konstanten, die deinen USS-Klassennamen entsprechen.

### 3. Konstanten im Code verwenden

```csharp
// Statt magischer Strings:
element.AddToClassList("button--primary");

// Mit generierten Konstanten:
element.AddToClassList(MyStylesUssClasses.ButtonPrimary);
```

Dies vermeidet Tippfehler und macht Refactorings deutlich einfacher.

---

## Projektstruktur

```
unity-uss-class-generator/
├── Editor/                          # Editor-only Scripts (Generator-Logik)
├── Samples~/
│   └── Uss_Generator_Sample/        # Beispielszene und -assets
├── package.json                     # Unity Package Manifest
└── LICENSE
```

> Der `Samples~/`-Ordner wird von Unity nicht automatisch in dein Projekt kopiert. Verwende immer den **Package Manager → Samples → Import**, um die Beispieldateien korrekt einzubinden.

---

## Lizenz

MIT License – siehe [LICENSE](./LICENSE)# USS Class Generator

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
