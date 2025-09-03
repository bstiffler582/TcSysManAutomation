using TcSysManRMLib;

var systemManagerRM = Activator.CreateInstance(Type.GetTypeFromProgID("TcSysManagerRM", throwOnError: true)!) as ITcSysManagerRM;
var stSysManager = systemManagerRM?.CreateSysManager15();

const string path = @"C:\temp\SysManAutomation\";

if (stSysManager != null)
{
    // open base project
    stSysManager.OpenConfiguration(path + "SysManAutomation.tsproj");

    // disable existing analog terminal / unlink from PLC
    stSysManager.UnlinkVariables("TIPC^PLC1^PLC1 Instance^PlcTask Inputs^MAIN.manualMap",
        "TIID^Device 1 (EtherCAT)^Term 1 (EK1100)^Term 5 (EL3001)^AI Standard^Value");
    ITcSmTreeItem disable = stSysManager.LookupTreeItem("TIID^Device 1 (EtherCAT)^Term 1 (EK1100)^Term 5 (EL3001)");
    disable.Disabled = DISABLED_STATE.SMDS_DISABLED;

    // create new analog terminal / link with PLC
    ITcSmTreeItem ecMaster = stSysManager.LookupTreeItem("TIID^Device 1 (EtherCAT)^Term 1 (EK1100)");
    ecMaster.CreateChild("Term 5 (EL3004)", 9099, "Term 4 (EK1110)", "EL3004");
    stSysManager.LinkVariables("TIPC^PLC1^PLC1 Instance^PlcTask Inputs^MAIN.manualMap",
        "TIID^Device 1 (EtherCAT)^Term 1 (EK1100)^Term 5 (EL3004)^AI Standard Channel 1^Value");

    Console.WriteLine("Select variant (1 or 2):");
    var key = Console.ReadKey();

    // variant selection
    if (key.Key == ConsoleKey.D1)
    {
        stSysManager.CurrentProjectVariant = "inputs";
    }
    else if (key.Key == ConsoleKey.D2)
    {
        stSysManager.CurrentProjectVariant = "outputs";
    }
    else
    {
        Console.WriteLine("Invlaid input!");
    }

    // save as, hook into new proj
    stSysManager.SaveConfiguration(path + "_modified.tsproj");
    stSysManager.OpenConfiguration(path + "_modified.tsproj");

    // activate / run
    stSysManager.ActivateConfiguration();
    //stSysManager.StartRestartTwinCAT();
}