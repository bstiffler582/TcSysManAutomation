### TcSysManAutomation

This repository illustrates the use of TwinCAT's "standalone system manager" assembly, which facilitates a subset of the [Automation Interface](https://infosys.beckhoff.com/english.php?content=../content/1033/tc3_automationinterface/242682763.html&id=5107059583047685772) functionality *without* a dependency on the VS/XAE DTE (development environment). In this demo:
- Variant selection
- I/O configuration (add, remove, disable)
- Linking
- runtime activation

Requirements:
- TwinCAT 4026 XAR
- TcSysManRMLib COM assembly
  - Currently Windows only :(
- TwinCAT project file (*.tsproj)
  - *Plus all referenced files (e.g. PLC TMC)
 
The TwinCAT project's I/O config also contains a third-party Baumuller EtherCAT drive. To run as-is, you will either need to load their [EtherCAT XML definitions](https://www.baumueller.com/en/download/b-maxx-6000-5000-3300-3200-2500-ethercat-xml-all), or just replace that drive with another Beckhoff drive and configure the variance appropriately.

For more information (examples, compatibility, etc.) check the included [pdf](/TwinCAT_Standalone_System_Manager_V2.pdf)
