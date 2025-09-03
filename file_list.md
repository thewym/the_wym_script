The_wym_script/                  // 解决方案根目录
├─.gitignore                            // 版本控制忽略文件
├─ The_wym_script.sln            // 解决方案文件
├─ README.md                            // 项目说明文档
│
├─ The_wym_script/               // 主应用项目
│  ├─ The_wym_script.csproj      // 项目配置文件
│  ├─ App.xaml                          // 应用入口（全局资源、启动配置）
│  ├─ App.xaml.cs                       // 应用初始化逻辑
│  ├─ MainWindow.xaml                   // 主窗口（启动器主界面容器）
│  ├─ MainWindow.xaml.cs                // 主窗口生命周期管理
│  │
│  ├─ Assets/                           // 静态资源（对应HMCL的资源文件）
│  │  ├─ Images/                        // 图片资源
│  │  │  ├─ Logo/                       // 启动器图标
│  │  │  ├─ Backgrounds/                // 界面背景图
│  │  │  └─ Minecraft/                  // 游戏相关图片（如版本图标）
│  │  ├─ Styles/                        // 样式资源
│  │  │  ├─ Theme.xaml                  // 主题样式（亮色/暗色模式）
│  │  │  ├─ Controls.xaml               // 自定义控件样式（按钮、列表等）
│  │  │  └─ LauncherStyles.xaml         // 启动器专属样式
│  │  └─ Fonts/                         // 自定义字体
│  │
│  ├─ Core/                             // 核心框架（业务逻辑核心）
│  │  ├─ Models/                        // 数据模型
│  │  │  ├─ MinecraftVersion.cs         // 游戏版本信息模型
│  │  │  ├─ Account.cs                  // 账号信息模型
│  │  │  ├─ LaunchSettings.cs           // 启动参数模型
│  │  │  └─ GameResource.cs             // 游戏资源模型（资产、库文件等）
│  │  ├─ Services/                      // 服务层（核心功能实现）
│  │  │  ├─ VersionManager.cs           // 版本管理服务（下载、切换版本）
│  │  │  ├─ LauncherService.cs          // 启动器核心服务（游戏启动逻辑）
│  │  │  ├─ AccountService.cs           // 账号管理服务（登录、保存账号）
│  │  │  ├─ ResourceDownloader.cs       // 资源下载服务（资产、库文件下载）
│  │  │  └─ SettingsService.cs          // 设置服务（保存/读取配置）
│  │  ├─ Helpers/                       // 工具类
│  │  │  ├─ FileHelper.cs               // 文件操作工具（对应HMCL的文件管理）
│  │  │  ├─ HttpHelper.cs               // 网络请求工具（下载资源）
│  │  │  ├─ MinecraftHelper.cs          // 游戏相关工具（校验文件、解析版本）
│  │  │  └─ Logger.cs                   // 日志工具（记录启动器运行日志）
│  │  └─ Enums/                         // 枚举定义
│  │     ├─ VersionType.cs              // 版本类型（Release、Snapshot等）
│  │     └─ LaunchStatus.cs             // 启动状态（准备中、启动中、失败等）
│  │
│  ├─ UI/                               // 界面相关（按功能模块划分）
│  │  ├─ Views/                         // 视图（界面）
│  │  │  ├─ Dashboard/                  // 主面板视图
│  │  │  │  └─ DashboardView.xaml       // 显示版本列表、启动按钮等
│  │  │  ├─ VersionManager/             // 版本管理视图
│  │  │  │  └─ VersionManagerView.xaml  // 版本下载、删除界面
│  │  │  ├─ Settings/                   // 设置视图
│  │  │  │  └─ SettingsView.xaml        // 启动参数、路径设置等界面
│  │  │  └─ AccountManager/             // 账号管理视图
│  │  │     └─ AccountManagerView.xaml  // 账号添加、切换界面
│  │  ├─ ViewModels/                    // 视图模型（数据绑定+界面逻辑）
│  │  │  ├─ DashboardViewModel.cs       // 主面板视图模型
│  │  │  ├─ VersionManagerViewModel.cs  // 版本管理视图模型
│  │  │  ├─ SettingsViewModel.cs        // 设置视图模型
│  │  │  └─ AccountManagerViewModel.cs  // 账号管理视图模型
│  │  └─ Controls/                      // 自定义控件
│  │     ├─ VersionCard.xaml            // 版本卡片控件（显示版本信息）
│  │     ├─ DownloadProgress.xaml       // 下载进度控件
│  │     └─ LaunchButton.xaml           // 启动按钮控件
│  │
│  └─ Data/                             // 数据存储（对应HMCL的配置和缓存）
│     ├─ Configs/                       // 配置文件
│     │  ├─ accounts.json               // 账号配置
│     │  ├─ launchSettings.json         // 启动参数配置
│     │  └─ appSettings.json            // 应用设置
│     ├─ Cache/                         // 缓存文件
│     │  └─ version_manifest.json       // 版本清单缓存
│     └─ Logs/                          // 日志文件
│        └─ 2025-09-03_launcher.log     // 启动器运行日志
│
└─ The_wym_script.Tests/         // 单元测试项目
   ├─ Services/                         // 服务层测试
   │  └─ VersionManagerTests.cs
   └─ Helpers/                          // 工具类测试
      └─ FileHelperTests.cs
