# Markdown.Avalonia Minimal (.NET 10 + Avalonia 12)

这是 Markdown.Avalonia 项目的精简版本，只包含核心的 Markdown 渲染功能，升级到 .NET 10 和 Avalonia 12。

## 项目结构

```
Markdown.Avalonia.Minimal.sln
├── ColorTextBlock.Avalonia/       # 富文本块渲染
├── ColorDocument.Avalonia/        # Markdown 文档元素处理
├── Markdown.Avalonia.Tight/        # Markdown 解析和渲染引擎
└── demos/
    └── Markdown.AvaloniaMinimalDemo/  # 最小演示项目
```

## 核心功能

### ColorTextBlock.Avalonia
- 提供富文本块渲染
- 支持粗体、斜体、下划线、删除线等文本样式
- 支持超链接、图片、行内代码等内联元素
- 支持自动换行和文本对齐

### ColorDocument.Avalonia
- 处理 Markdown 文档元素
- 支持标题、段落、列表、引用块等块级元素
- 支持表格、代码块、分隔线
- 支持文本标记样式（圆点、数字、字母等）

### Markdown.Avalonia.Tight
- Markdown 解析和渲染引擎
- 将 Markdown 文本转换为 Avalonia 控件
- 提供多种内置样式（Standard、SimpleTheme、FluentTheme 等）
- 支持插件系统（可扩展）

## 构建状态

✅ **所有项目已在 .NET 10 和 Avalonia 12 上成功构建**

### 构建命令

```bash
# 构建所有项目
dotnet build Markdown.Avalonia.Minimal.sln -f net10.0

# 构建特定项目
dotnet build ColorTextBlock.Avalonia/ColorTextBlock.Avalonia.csproj -f net10.0
dotnet build ColorDocument.Avalonia/ColorDocument.Avalonia.csproj -f net10.0
dotnet build Markdown.Avalonia.Tight/Markdown.Avalonia.Tight.csproj -f net10.0
```

## 运行演示

```bash
cd demos/Markdown.AvaloniaMinimalDemo
dotnet run -f net10.0
```

## 功能支持

| 功能 | 状态 |
|------|------|
| 标题 (H1-H6) | ✅ |
| 段落 | ✅ |
| 列表 (有序/无序) | ✅ |
| 代码块 | ✅ (无语法高亮) |
| 行内代码 | ✅ |
| 粗体/斜体 | ✅ |
| 链接 | ✅ |
| 图片 (PNG/JPG) | ✅ |
| 引用块 | ✅ |
| 分隔线 | ✅ |
| 表格 | ✅ |
| HTML 标签 | ❌ |
| 代码语法高亮 | ❌ |
| 图片 (SVG) | ❌ |

## 依赖

### 核心依赖

- **Avalonia** 12.0.0-rc1
- **.NET** 10.0

### 外部依赖（可选）

如果需要以下功能，可以添加相应的 NuGet 包：

- **代码语法高亮**: AvaloniaEdit 12.0.0-rc1
- **SVG 图像**: Avalonia.Svg 11.0.10 (注意：当前版本不支持 Avalonia 12)
- **HTML 标签**: 需要自定义实现

## 使用示例

### XAML 中使用

```xml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:md="https://github.com/whistyun/Markdown.Avalonia.Tight">
    <md:MarkdownScrollViewer x:Name="Viewer" />
</Window>
```

### 代码中设置 Markdown

```csharp
var viewer = this.FindControl<MarkdownScrollViewer>("Viewer");
viewer.Markdown = "# Hello World\n\nThis is **bold** text.";
```

### 选择样式

```csharp
// 使用内置样式
viewer.MarkdownStyleName = "SimpleTheme";
viewer.MarkdownStyleName = "FluentTheme";
viewer.MarkdownStyleName = "Standard";
```

## 与完整版本的区别

### 已移除的项目

- **Markdown.Avalonia.Svg** - SVG 图像支持
- **Markdown.Avalonia.SyntaxHigh** - 代码语法高亮
- **Markdown.Avalonia.Html** - HTML 标签支持
- **Markdown.Avalonia** - 旧版本库
- **demos/Markdown.AvaloniaDemo** - 完整演示
- **demos/Markdown.AvaloniaFluentDemo** - Fluent 主题演示
- **demos/Markdown.AvaloniaFluentAvaloniaDemo** - FluentAvalonia 演示
- **benchmark/** - 基准测试项目
- **tests/** - 单元测试项目
- **example/** - 示例项目
- **docs/** - 文档
- **plans/** - 升级计划

### 保留的项目

- **ColorTextBlock.Avalonia** - 核心文本渲染
- **ColorDocument.Avalonia** - 核心文档处理
- **Markdown.Avalonia.Tight** - 核心 Markdown 引擎
- **demos/Markdown.AvaloniaMinimalDemo** - 最小演示
- **.github/** - GitHub Actions 配置

## 注意事项

1. **Avalonia 12 是 RC 版本**: 当前使用的是 12.0.0-rc1，可能会有一些不稳定
2. **无语法高亮**: 代码块将以纯文本形式显示，没有颜色高亮
3. **无 SVG 支持**: 无法渲染 SVG 图像
4. **无 HTML 支持**: 无法解析 HTML 标签

## 许可证

MIT License - 与原始项目相同

## 原始项目

原始项目地址: https://github.com/whistyun/Markdown.Avalonia

## 升级说明

此版本已从 Avalonia 11 升级到 Avalonia 12，主要变更包括：

- 目标框架更新为 .NET 10
- Avalonia 版本更新为 12.0.0-rc1
- 适配 Avalonia 12 API 变更（IBinding → BindingBase 等）
- 修复 MathUtilities.AreClose 移除问题
- 更新剪贴板 API 调用

详细升级信息请参考原始升级计划文档。
