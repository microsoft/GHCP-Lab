class SmartHouseManager {
	// TODO Create an interface for the device (DRY-principal)
	private devices: { id: string; name: string; type: string; status: 'on' | 'off'; }[] = [];

	// Create a new device
	addDevice(device: { id: string; name: string; type: string; status: 'on' | 'off'; }): void {
		this.devices.push(device);
		console.log(`Device ${device.name} added.`);
	}

	// Read all devices
	getDevices(): { id: string; name: string; type: string; status: 'on' | 'off'; }[] {
		return this.devices;
	}

	// TODO create a reset device function

	// Update a device by ID
	updateDevice(id: string, updatedDevice: Partial<{ id: string; name: string; type: string; status: 'on' | 'off'; }>): void {
		const deviceIndex = this.devices.findIndex((device) => device.id === id);
		if (deviceIndex === -1) {
			console.log(`Device with ID ${id} not found.`);
			return;
		}
		this.devices[deviceIndex] = { ...this.devices[deviceIndex], ...updatedDevice };
		console.log(`Device with ID ${id} updated.`);
	}

	// Delete a device by ID
	deleteDevice(id: string): void {
		const deviceIndex = this.devices.findIndex((device) => device.id === id);
		if (deviceIndex === -1) {
			console.log(`Device with ID ${id} not found.`);
			return;
		}
		const removedDevice = this.devices.splice(deviceIndex, 1);
		console.log(`Device ${removedDevice[0].name} removed.`);
	}
}

// Example usage
const manager = new SmartHouseManager();

manager.addDevice({ id: '1', name: 'Living Room Light', type: 'light', status: 'off' });
manager.addDevice({ id: '2', name: 'Thermostat', type: 'thermostat', status: 'on' });
// TODO Add my fridge

console.log(manager.getDevices());

manager.updateDevice('1', { status: 'on' });
console.log(manager.getDevices());

manager.deleteDevice('2');
console.log(manager.getDevices());