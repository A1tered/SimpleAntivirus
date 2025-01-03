﻿
using System;
using System.Threading.Tasks;
namespace AlertHandler;
class Program
{
    public static async Task Main(string[] args)
    {
        AlertManager alertManager = new AlertManager();
        EventBus eventBus = new EventBus(alertManager);

        // Simulate receiving alerts from different system components (stubs)
        MaliciousCodeScannerStub maliciousCodeScanner = new MaliciousCodeScannerStub(eventBus);
        IntegrityCheckerStub integrityChecker = new IntegrityCheckerStub(eventBus);

        //IntegrityDatabaseIntermediary databaseIntermediary = new("IntegrityDatabase", false);
        //IntegrityManagement integrityModule = new IntegrityManagement(databaseIntermediary);

        // Trigger alerts from stubs
        await maliciousCodeScanner.ScanForMaliciousCodeAsync();
        await integrityChecker.CheckFileIntegrityAsync();

        // Retrieve and display all stored alerts
        var allAlerts = await alertManager.GetAllAlertsAsync();
        Console.WriteLine("\nAll Stored Alerts:");
        foreach (var alert in allAlerts)
        {
            alert.DisplayAlert();
        }
    }
}
