using System;
using System.Collections.Generic;
using System.Linq;

public class SmartHouseManager
{
    private List<Device> devices = new List<Device>();

    // Create a new device
    public void AddDevice(Device device)
    {
        // TODO: Add validation for duplicate IDs
        devices.Add(device);
        Console.WriteLine($"Device {device.Name} added.");
    }

    // Read all devices
    public List<Device> GetDevices()
    {
        return devices;
    }

    // TODO create a reset device function

    // Update a device by ID
    public void UpdateDevice(string id, Device updatedDevice)
    {
        var deviceIndex = devices.FindIndex(device => device.Id == id);
        if (deviceIndex == -1)
        {
            Console.WriteLine($"Device with ID {id} not found.");
            return;
        }
        
        // TODO: This should use proper object mapping instead of manual assignment
        var existingDevice = devices[deviceIndex];
        if (!string.IsNullOrEmpty(updatedDevice.Name)) existingDevice.Name = updatedDevice.Name;
        if (!string.IsNullOrEmpty(updatedDevice.Type)) existingDevice.Type = updatedDevice.Type;
        if (!string.IsNullOrEmpty(updatedDevice.Status)) existingDevice.Status = updatedDevice.Status;
        
        Console.WriteLine($"Device with ID {id} updated.");
    }

    // Delete a device by ID
    public void DeleteDevice(string id)
    {
        var deviceIndex = devices.FindIndex(device => device.Id == id);
        if (deviceIndex == -1)
        {
            Console.WriteLine($"Device with ID {id} not found.");
            return;
        }
        var removedDevice = devices[deviceIndex];
        devices.RemoveAt(deviceIndex);
        Console.WriteLine($"Device {removedDevice.Name} removed.");
    }
}

// TODO: This should be in a separate file and implement IDevice interface
public class Device
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Status { get; set; } // TODO: Make this an enum instead of string
}

// Example usage
public class LegacyCodeBaseExample
{
    public static void RunExample()
    {
        var manager = new SmartHouseManager();

        manager.AddDevice(new Device { Id = "1", Name = "Living Room Light", Type = "light", Status = "off" });
        manager.AddDevice(new Device { Id = "2", Name = "Thermostat", Type = "thermostat", Status = "on" });
        // TODO Add my fridge

        Console.WriteLine("All devices:");
        manager.GetDevices().ForEach(device => Console.WriteLine($"{device.Id}: {device.Name} ({device.Type}) - {device.Status}"));

        manager.UpdateDevice("1", new Device { Status = "on" });
        Console.WriteLine("After updating device 1:");
        manager.GetDevices().ForEach(device => Console.WriteLine($"{device.Id}: {device.Name} ({device.Type}) - {device.Status}"));

        manager.DeleteDevice("2");
        Console.WriteLine("After deleting device 2:");
        manager.GetDevices().ForEach(device => Console.WriteLine($"{device.Id}: {device.Name} ({device.Type}) - {device.Status}"));
    }
}
