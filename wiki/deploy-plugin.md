# Развертывание плагина

## Куда и чего

Плагины Vault загружается из папки:

_c:\ProgramData\Autodesk\Vault \<version>\Extensions\<PluginName>_

Основная конфигурация для загрузчика плагина находится в файле: 

_\<PluginName>.vcet.config_

```xml
<configuration>
  <connectivity.ExtensionSettings3>
    <extension
      interface="Autodesk.Connectivity.Explorer.Extensibility.IExplorerExtension, Autodesk.Connectivity.Explorer.Extensibility, Version=[version].0.0.0, Culture=neutral, PublicKeyToken=aa20f34aedd220e1"
      type="VaultExtensions.Main, [PluginName]">
    </extension>
  </connectivity.ExtensionSettings3>
</configuration>
```