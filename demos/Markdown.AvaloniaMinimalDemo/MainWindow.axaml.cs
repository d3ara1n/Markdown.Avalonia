using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Markdown.Avalonia;

namespace Markdown.AvaloniaMinimalDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var viewer = this.FindControl<MarkdownScrollViewer>("MarkdownViewer");
            
            // Sample Markdown text for testing
            string markdown = @"# Welcome to Markdown.Avalonia

This is a minimal demo showing the basic rendering capabilities.

## Features

- **Bold** and *Italic* text
- [Links](https://github.com/whistyun/Markdown.Avalonia)
- Code blocks with syntax highlighting

```csharp
public class HelloWorld
{
    public static void Main()
    {
        Console.WriteLine(""Hello, World!"");
    }
}
```

## Lists

1. First item
2. Second item
3. Third item

- Unordered item
- Another item

## Blockquote

> This is a blockquote.
> It can span multiple lines.

---

Thank you for using Markdown.Avalonia!
";

            viewer.Markdown = markdown;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}