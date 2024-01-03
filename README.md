# CopyImage

- 一个复制图片文件内容（而不是文件本身）到剪贴板的工具。
- 方便 右键菜单/发送到菜单/打开方式 等方式一键复制。
- 免去打开图片查看软件再使用复制功能的麻烦。
- 支持的语言 Supported languages: `简体中文`, `繁體中文`, `English`, `日本語`

![icon](copy-image/ico/copy-image-1.ico)

## 系统要求

- 普通版本
  - 至少 Windows 10 版本 1607, x32/64 或 arm32/64
  - 至少 [.NET Framework 桌面运行时 8](https://dotnet.microsoft.com/zh-cn/download/dotnet/8.0)
- compatible 分支版本
  - 至少 Windows XP, x32/64
  - 至少 [.NET Framework 3.5](https://dotnet.microsoft.com/zh-cn/download/dotnet-framework/net35-sp1)

两个版本的功能相同。

## 使用

- 直接双击 `copy-image.exe` 运行，将会打开软件设置窗口。
- 将图片拖曳到 `copy-image.exe` 上面，或者用 `copy-image.exe` 打开图片，将会直接将该图片复制到剪贴板。
  - 右下角将会出现一个预览窗口，并显示图片加载到剪贴板的状态。
  - 在预览窗口的标题栏，可以看到图片的 实际尺寸 和 复制到剪贴板的尺寸（如果已开启尺寸限制功能）

### 命令行参数

- `copy-image.exe`: 打开软件设置窗口。
- `copy-image.exe <图片文件路径>`: 复制该图片到剪贴板。 

## 配置

在配置窗口中：

- 可以调整显示的语言，默认根据系统设置自动决定。
- 可以指定亮色外观和暗色外观，默认根据系统设置自动决定。
- 可以指定右下角预览窗口的操作完成后的停留时间。
  - 将滑块移动到最左侧，可以在后台进行操作（最小化预览窗口，复制完成后立即退出）。
  - 将滑块移动到最右侧，可以使预览窗口一直停留，直到手动关闭它。
- 对于复制特大尺寸图片，会使复制过程和其他软件中的粘贴过程变得缓慢。如果只是粘贴到非原图的场合（例如聊天软件非原图发送），可以指定「图片尺寸限制」。
  - 在启用该功能后，如果复制的图片大于指定的尺寸，则先自动将图片缩小到该尺寸，然后再复制到剪贴板。

## 安装

1. 解压到文件夹到本地硬盘。
2. 直接双击 `copy-image.exe` 运行，将会打开软件设置窗口，可以进行软件配置。
3. 创建快捷访问，以下有多种方法。

注：
- 一旦创建任何快捷访问，在删除这些快捷访问之前请不要移动这些文件的位置。
- 如果一种方式无效，可以尝试其他方式进行。
- 在 Windows 11 中：这些选项在文件右键菜单的「显示更多选项」中，也可以按住 `Shift` 键点右键。
- 在这些操作完成后，建议注销或重新启动电脑，以便重新加载 `explorer.exe` 。

### 为图片文件添加「文件资源管理器」右键菜单

在软件设置窗口中，按「添加右键菜单」按钮。

可以通过「查看右键菜单状态」按钮检查每种图片文件扩展名的菜单添加状态。

软件将添加注册表项: `计算机\HKEY_CURRENT_USER\Software\Classes\(文件扩展名)\shell\CopyImageToClipboard` ，以便在「文件资源管理器」的右键菜单中访问。

以 `.jpg` 扩展名为例，默认设置下添加的注册表结构示例如下：

```reg
Windows Registry Editor Version 5.00

[HKEY_CURRENT_USER\Software\Classes\.jpg\shell]

[HKEY_CURRENT_USER\Software\Classes\.jpg\shell\CopyImageToClipboard]
@="复制图片到剪贴板"
"Icon"="copy-image.exe"

[HKEY_CURRENT_USER\Software\Classes\.jpg\shell\CopyImageToClipboard\command]
@="copy-image.exe \"%1\""
```

### 添加到右键的「发送到」菜单

1. 打开「运行」对话框（快捷键是 `Windows+R` ）。
2. 输入 `shell:sendto` 并「确定」。
3. 将 `copy-image.exe` 创建快捷方式到打开的文件夹中。

### 添加到「打开方式」列表

在右键菜单选择「打开方式」→「选择其他应用」→最下面的「在电脑上选择应用」→选择 `copy-image.exe` →按「仅一次」按钮。

注：不要按「始终」按钮，否则双击打开会直接变成复制图片到剪贴板。

## 隐私

该程序不具备以下行为，如果在使用中出现以下任何行为之一，则意味着软件遭到篡改：

- 向局域网或互联网发送数据。
- 从局域网或互联网下载数据。
- 变更操作系统或其他程序的文件。
- 显示广告或自动安装其他软件。
- 要求付费解锁功能或开通付费订阅。

## LICENSE

Copyright (c) 2023 KagurazakaYashi CopyImage is licensed under Mulan PSL v2. You can use this software according to the terms and conditions of the Mulan PSL v2. You may obtain a copy of Mulan PSL v2 at: http://license.coscl.org.cn/MulanPSL2 THIS SOFTWARE IS PROVIDED ON AN “AS IS” BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE. See the Mulan PSL v2 for more details.
